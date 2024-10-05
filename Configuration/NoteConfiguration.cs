using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAPI.Entities;

namespace NotesAPI.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            var note1 = new Note
            {
                Id = 1,
                Title = "Admin Note 1",
                Description = "This is the first note for Admin",
                UserId = 1
            };

            var note2 = new Note
            {
                Id = 2,
                Title = "Admin Note 2",
                Description = "This is the second note for Admin",
                UserId = 1
            };

            var note3 = new Note
            {
                Id = 3,
                Title = "User Note 1",
                Description = "This is the first note for User",
                UserId = 2
            };

            var note4 = new Note
            {
                Id = 4,
                Title = "User Note 2",
                Description = "This is the second note for User",
                UserId = 2
            };

            builder.HasData(note1, note2, note3, note4);
        }
    }
}
