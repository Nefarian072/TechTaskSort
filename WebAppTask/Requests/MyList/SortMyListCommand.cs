using MediatR;
using WebAppTask.Server.Enums;
using WebAppTask.Server.Responses.MyList;

namespace WebAppTask.Server.Requests.MyList;

public class SortMyListCommand: IRequest<SortMyListCommandResult>
{
    public List<string> Items { get; set; } = new List<string>();
    public int SortType { get; set; } = 0;
}