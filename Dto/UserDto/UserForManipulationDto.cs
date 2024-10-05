using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.UserDto
{
    public record UserForManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; init; }

    }
}
