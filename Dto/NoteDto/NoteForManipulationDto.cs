﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.NoteDto
{
    public record NoteForManipulationDto
    {
        public string Title { get; init; }
        public string Description { get; init; }    
    }
}
