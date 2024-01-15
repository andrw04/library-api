using AutoMapper;
using Library.Business.Abstractions;
using Library.Business.Models.Author;
using Library.Business.Models.Utility;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Models;

namespace Library.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseData<ResponseAuthorDto?>> CreateAuthor(RequestAuthorDto author)
        {
            try
            {
                await _unitOfWork.AuthorRepository.AddAsync(_mapper.Map<Author>(author));

                await _unitOfWork.SaveAllAsync();

                return new ResponseData<ResponseAuthorDto?>();
            }
            catch (Exception ex)
            {
                return new ResponseData<ResponseAuthorDto?>
                {
                    IsSuccess = false,
                    Data = null,
                    ExceptionData = ex
                };
            }
        }

        public async Task<ResponseData<ResponseAuthorDto?>> DeleteAuthor(int id)
        {
            try
            {
                var existsAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

                if (existsAuthor == null)
                {
                    throw new InvalidOperationException();
                }

                await _unitOfWork.AuthorRepository.DeleteAsync(existsAuthor);

                return new ResponseData<ResponseAuthorDto?>();
            }
            catch (Exception ex)
            {
                return new ResponseData<ResponseAuthorDto?>
                {
                    IsSuccess = false,
                    Data = null,
                    ExceptionData = ex
                };
            }
        }

        public async Task<ResponseData<IEnumerable<ResponseAuthorDto>>> GetAllAuthors()
        {
            try
            {
                var authors = await _unitOfWork.AuthorRepository.GetAsync();

                return new ResponseData<IEnumerable<ResponseAuthorDto>>
                {
                    Data = authors.Select(g => _mapper.Map<ResponseAuthorDto>(g))
                };
            }
            catch (Exception ex)
            {
                return new ResponseData<IEnumerable<ResponseAuthorDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    ExceptionData = ex
                };
            }
        }

        public async Task<ResponseData<ResponseAuthorDto?>> GetAuthorById(int id)
        {
            try
            {
                var author = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

                return new ResponseData<ResponseAuthorDto?>
                {
                    Data = _mapper.Map<ResponseAuthorDto>(author)
                };
            }
            catch (Exception ex)
            {
                return new ResponseData<ResponseAuthorDto?>
                {
                    Data = null,
                    IsSuccess = false,
                    ExceptionData = ex
                };
            }
        }

        public async Task<ResponseData<ResponseAuthorDto?>> UpdateAuthor(int id, RequestAuthorDto author)
        {
            try
            {
                var existsAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

                if (existsAuthor == null)
                {
                    throw new InvalidOperationException();
                }

                _mapper.Map(author, existsAuthor);

                await _unitOfWork.AuthorRepository.UpdateAsync(existsAuthor!);

                return new ResponseData<ResponseAuthorDto?>();
            }
            catch (Exception ex)
            {
                return new ResponseData<ResponseAuthorDto?>
                {
                    Data = null,
                    IsSuccess = false,
                    ExceptionData = ex
                };
            }
        }
    }
}
