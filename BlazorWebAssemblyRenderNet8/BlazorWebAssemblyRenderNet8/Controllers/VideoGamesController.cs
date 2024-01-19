using BlazorWebAssemblyRenderNet8.Data;
using BlazorWebAssemblyRenderNet8.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyRenderNet8.Controllers
{
    [Route("api/videogames")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly DataContext _context;

        public VideoGamesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAll()
        {
            return await _context.VideoGames.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameByIdAsync(int id)
        {
            var resul = await _context.VideoGames.FindAsync(id);
            if(resul == null)
            {
                return NotFound("Game not found");
            }
            return Ok(resul);
        }

        [HttpPost]
        public async Task<ActionResult> AddGameAsync(VideoGame videoGame)
        {
            _context.Add(videoGame);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VideoGame>> UpdateGameAsync(VideoGame videoGame, int id)
        {
            var dbgame = await _context.VideoGames.FindAsync(id);
            if (dbgame == null)
            {
                return NotFound("Game not found");
            }
            dbgame.Title = videoGame.Title;
            dbgame.Publisher = videoGame.Publisher;
            dbgame.ReleaseYear = videoGame.ReleaseYear;
            _context.Update(dbgame);
            await _context.SaveChangesAsync();

            return Ok(dbgame);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAsync(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
            {
                return NotFound("Game not Found");
            }

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return Ok(game);
        }


    }
}
