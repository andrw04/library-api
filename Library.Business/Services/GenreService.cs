using AutoMapper;
using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Models.Genre;
using Library.DataAccess.Abstractions;

namespace Library.Business.Services;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RequestGenreDto> _validator;
    public GenreService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<RequestGenreDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public Task CreateGenre(RequestGenreDto genre)
    {
        throw new NotImplementedException();
    }

    public Task DeleteGenre(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ResponseGenreDto>> GetAllGenres()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseGenreDto> GetGenreById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateGenre(int id, RequestGenreDto genre)
    {
        throw new NotImplementedException();
    }
    /*public async Task<ResponseData<ResponseGenreDto?>> CreateGenre(RequestGenreDto genre)
{
   try
   {
       _validator.ValidateAndThrow(genre);

       await _unitOfWork.GenreRepository.AddAsync(_mapper.Map<Genre>(genre));

       await _unitOfWork.SaveAllAsync();

       return new ResponseData<ResponseGenreDto?>();
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseGenreDto?>
       {
           IsSuccess = false,
           Data = null,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<ResponseGenreDto?>> DeleteGenre(int id)
{
   try
   {
       var existsGenre = await _unitOfWork.GenreRepository.GetByIdAsync(id);

       if (existsGenre == null)
       {
           throw new InvalidOperationException();
       }

       await _unitOfWork.GenreRepository.DeleteAsync(existsGenre);

       return new ResponseData<ResponseGenreDto?>();
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseGenreDto?>
       {
           IsSuccess = false,
           Data = null,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<IEnumerable<ResponseGenreDto>>> GetAllGenres()
{
   try
   {
       var genres = await _unitOfWork.GenreRepository.GetAsync();

       return new ResponseData<IEnumerable<ResponseGenreDto>>
       {
           Data = genres.Select(g => _mapper.Map<ResponseGenreDto>(g))
       };
   }
   catch (Exception ex)
   {
       return new ResponseData<IEnumerable<ResponseGenreDto>>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<ResponseGenreDto?>> GetGenreById(int id)
{
   try
   {
       var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id);

       return new ResponseData<ResponseGenreDto?>
       {
           Data = _mapper.Map<ResponseGenreDto>(genre)
       };
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseGenreDto?>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<ResponseGenreDto?>> UpdateGenre(int id, RequestGenreDto genre)
{
   try
   {
       _validator.ValidateAndThrow(genre);

       var existsGenre = await _unitOfWork.GenreRepository.GetByIdAsync(id);

       if (existsGenre == null)
       {
           throw new InvalidOperationException();
       }

       _mapper.Map(genre, existsGenre);

       await _unitOfWork.GenreRepository.UpdateAsync(existsGenre!);

       return new ResponseData<ResponseGenreDto?>();
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseGenreDto?>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}*/
}
