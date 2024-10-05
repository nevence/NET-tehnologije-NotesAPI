using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Entities
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
