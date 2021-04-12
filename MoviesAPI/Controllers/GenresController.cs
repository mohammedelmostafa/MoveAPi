using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesAPI.Entites;
using MoviesAPI.Filters;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // api/Genres
        [HttpGet("list")] //api/Genres/list
        [HttpGet("/allgenres")] // allgenres
        [ResponseCache(Duration =60)]
        [ServiceFilter(typeof(MyactionFilter))]
        
        public async Task< ActionResult<List<Genre>>> Get()
        {
            var genres = await repository.GetAllGenres();
            return genres;
        }

        
        [HttpGet("{id:int}")] //api/Genres/id
        public ActionResult<Genre> Get(int id,[FromServices] string param)
        {
           
            var genre= repository.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]

        public ActionResult Post( [FromBody] Genre genre)
        {
            repository.addGenre(genre);

            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            return NoContent();
        }

        [HttpDelete]

        public ActionResult Delete()
        {
            return NoContent();
        }
        
    }
}
