using NotesAPI.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            var comment1 = new Comment
            {
                Id = 1,
                CommentBody = "This is a comment on Admin's first note",
                NoteId = 1
            };

            var comment2 = new Comment
            {
                Id = 2,
                CommentBody = "This is another comment on Admin's first note",
                NoteId = 1
            };

            builder.HasData(comment1, comment2);
        }
    }
}
