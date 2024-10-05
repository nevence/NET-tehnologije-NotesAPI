using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.NoteDto
{
    public record NoteDto
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }
    }
}
