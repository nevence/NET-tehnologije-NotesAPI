using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Dto.CommentDto
{
    public record CommentForManipulationDto
    {
        [Required]
        public string CommentBody { get; set; }
    }
}
