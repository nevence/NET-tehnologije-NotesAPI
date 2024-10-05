using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Dto.UserDto
{
    public record UserDto
    {
        public int Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }
    }
}
