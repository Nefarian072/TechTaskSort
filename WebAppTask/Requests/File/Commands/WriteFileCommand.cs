using MediatR;
using WebAppTask.Server.Responses.File.Commands;
namespace WebAppTask.Server.Requests.File.Commands;

public class WriteFileCommand: IRequest<WriteFileCommandResult>
{
    public List<string> Items { get; set; } = new List<string>();
}
