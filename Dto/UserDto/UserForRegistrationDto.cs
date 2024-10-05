using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.UserDto
{
    public record UserForRegistrationDto : UserForManipulationDto
    {
        [Required]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
        [Required]
        public string Role { get; init; }
    }
}
