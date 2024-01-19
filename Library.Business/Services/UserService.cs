using Library.Business.Abstractions;
using Library.Business.Models.User;
using Library.DataAccess.Abstractions;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using FluentValidation;
using Library.DataAccess.Models;
using Library.Business.Exceptions;

namespace Library.Business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly IValidator<RequestUserDto> _regValidator;
    private readonly IValidator<LoginUserDto> _logValidator;
    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IConfiguration config,
        IValidator<RequestUserDto> regValidator,
        IValidator<LoginUserDto> logValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _config = config;
        _regValidator = regValidator;
        _logValidator = logValidator;
    }

    public string CreateToken(ResponseUserDto user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _config.GetSection("Jwt:Secret").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, user.Username),
        };
        var token = new JwtSecurityToken(
        claims: claims,
            issuer: _config.GetSection("Jwt:Issuer").Value!,
            audience: _config.GetSection("Jwt:Audience").Value!,
            expires: DateTime.UtcNow.AddMinutes(
                int.Parse(_config.GetSection("Jwt:Expires").Value!)),
            signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public async Task RegisterAsync(RequestUserDto user, CancellationToken cancellationToken = default)
    {
        _regValidator.ValidateAndThrow(user);

        var users = await _unitOfWork.UserRepository.GetAsync(cancellationToken, u => u.Email.Equals(user.Email));
        var existsUser = users.FirstOrDefault();

        if (existsUser != null)
            throw new AlreadyExistsException(nameof(User));

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        var newUser = _mapper.Map<User>(user);

        await _unitOfWork.UserRepository.AddAsync(newUser, cancellationToken);
        await _unitOfWork.SaveAllAsync(cancellationToken);
    }

    public async Task<ResponseUserDto> LoginAsync(LoginUserDto user, CancellationToken cancellationToken = default)
    {
        _logValidator.ValidateAndThrow(user);

        var users = await _unitOfWork.UserRepository.GetAsync(cancellationToken, u => u.Email.Equals(user.Email));
        var existsUser = users.FirstOrDefault();

        bool verified = existsUser != null && BCrypt.Net.BCrypt.Verify(user.Password, existsUser.Password);

        if (!verified)
            throw new LoginException();

        return _mapper.Map<ResponseUserDto>(existsUser);
    }
}
