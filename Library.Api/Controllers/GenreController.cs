using Library.Business.Models.Genre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult> GetGenres()
        {
            throw new NotImplementedException();
        }

        [HttpGet("id:int")]
        public Task<ActionResult> GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult> CreateGenre([FromBody] RequestGenreDto genre)
        {
            throw new NotImplementedException();
        }

        [HttpPut("id:int")]
        public Task<ActionResult> UpdateGenre(int id, [FromBody] RequestGenreDto genre)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("id:int")]
        public Task<ActionResult> DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }
    }
}
