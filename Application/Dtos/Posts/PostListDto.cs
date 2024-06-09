namespace Application.Dtos.Posts;

public class PostListDto
{
    public long Id { get; set; }

    public string Header { get; set; }

    public string Content { get; set; }

    public string Date { get; set; }
    
    public string Time { get; set; }

    public IEnumerable<string> Photos { get; set; }
}