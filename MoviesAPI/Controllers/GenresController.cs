using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entites;
using MoviesAPI.Filters;
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
        //private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger,
            ApplicationDbContext context,IMapper mapper)
        {
            //this.repository = repository;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/Genres
        //[HttpGet("list")] //api/Genres/list
        //[HttpGet("/allgenres")] // allgenres
        //[ResponseCache(Duration =60)]
        //[ServiceFilter(typeof(MyactionFilter))]
        
        public async Task< ActionResult<List<GenreDTO>>> Get()
        {
            logger.LogInformation("Get all genres...");


            //Using DTO
            var genres= await context.Genres.OrderBy(x=>x.Name).ToListAsync();

            return mapper.Map<List<GenreDTO>>(genres);

            //var genres = await repository.GetAllGenres();
            //return new List<Genre>() { new Genre() { Id = 1, Name = "Comedy" } };
           // return genres;
        }

        
        [HttpGet("{id:int}",Name ="getGenre")] //api/Genres/id
        //[ServiceFilter(typeof(MyactionFilter))]
        public async Task<ActionResult<GenreDTO>> Get(int id)
        {
            var genre = context.Genres.FirstOrDefaultAsync(x => x.Id==id);
            
            if (genre == null)
            {
                return NotFound();
            }

            return mapper.Map<GenreDTO>(genre);
        }

        [HttpPost]

        public async Task<ActionResult> Post( [FromBody] GenreCreationDTO genreCreationDTO)
        {
            //Using DTO
            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genre);
            await context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var genre = context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
             context.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
