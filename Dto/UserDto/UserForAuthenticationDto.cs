using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.UserDto
{
    public record UserForAuthenticationDto(
     [Required]
    string Username,

     [Required]
    string Password
 );
}
