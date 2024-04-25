using WebAppTask.Server.Enums;

namespace WebAppTask.Server.Models;

public class MyList
{
    public List<string> Items { get; set; } = new List<string>();
    public int SortType { get; set; } = 0;
}