using WebAppTask.Server.Enums;

namespace WebAppTask.Server.Responses.MyList;

public class SortMyListCommandResult
{
    public List<string> Items { get; set; } = new List<string>();
}
