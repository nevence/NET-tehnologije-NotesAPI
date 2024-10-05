using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.Dto.CommentDto;
using NotesAPI.Dto.NoteDto;
using NotesAPI.Entities;
using System.Security.Claims;

namespace NotesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var notes = await _context.Notes
                .Where(n => n.UserId == userId)
                .Select(n => new NoteDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description
                }).ToListAsync();

            return Ok(notes);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var note = await _context.Notes
                .Where(n => n.UserId == userId && n.Id == id)
                .Select(n => new NoteDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description
                })
                .SingleOrDefaultAsync();

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetComments(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var note = await _context.Notes
                .Where(n => n.UserId == userId && n.Id == id)
                .Include(n => n.Comments) 
                .FirstOrDefaultAsync();

            if (note == null)
            {
                return NotFound();
            }

            var commentsDto = note.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                CommentBody = c.CommentBody
            }).ToList();

            return Ok(commentsDto);
        }


        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] NoteForCreationDto note)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                   .Select(e => e.ErrorMessage)
                                                   .ToList();
                    return BadRequest(new { Errors = errors });
                }

                var noteToCreate = new Note
                {
                    Title = note.Title,
                    Description = note.Description,
                    UserId = userId,
                };

                await _context.Notes.AddAsync(noteToCreate);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] NoteForUpdateDto note)
        {
            var noteToUpdate = await _context.Notes.FindAsync(id);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();
                return BadRequest(new { Errors = errors });
            }

            noteToUpdate.Title = note.Title;
            noteToUpdate.Description = note.Description;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
