namespace NotesAPI.Dto.CommentDto
{
    public record CommentDto
    {
        public int Id { get; init; }
        public string CommentBody { get; init; }
    }
}
