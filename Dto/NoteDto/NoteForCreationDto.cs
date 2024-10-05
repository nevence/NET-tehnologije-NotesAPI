using Microsoft.EntityFrameworkCore;
using NotesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.NoteDto
{
    public record NoteForCreationDto : NoteForManipulationDto
    {

    }
}