using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string CommentBody { get; set; }

        [Required]
        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }

        [Required]
        public Note Note { get; set; }
    }
}
