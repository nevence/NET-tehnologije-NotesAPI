using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.Dto.CommentDto;
using NotesAPI.Entities;
using System.Security.Claims;

namespace NotesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> AddComment(int id, [FromBody] CommentForCreationDto comment)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                
                var note = await _context.Notes.Where(n=> n.Id == id && n.UserId == userId).FirstOrDefaultAsync();

                if(note == null)
                {
                    return NotFound();
                }

                if(!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                   .Select(e => e.ErrorMessage)
                                                   .ToList();
                    return BadRequest(new { Errors = errors });
                }

                var commentToCreate = new Comment
                {
                    NoteId = note.Id,
                    CommentBody = comment.CommentBody
                };

                await _context.Comments.AddAsync(commentToCreate);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var comment = await _context.Comments.Where(c => c.Note.UserId == userId && c.NoteId == id).FirstOrDefaultAsync();

            if(comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
    }
}
