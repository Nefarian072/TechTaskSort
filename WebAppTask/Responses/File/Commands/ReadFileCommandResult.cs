namespace WebAppTask.Server.Responses.File.Commands;

public class ReadFileCommandResult
{
    public List<string> Items { get; set; } = new List<string>();
    public string? ErrorMessage { get; set; }
}
