using MediatR;
using WebAppTask.Server.Responses.File.Commands;
namespace WebAppTask.Server.Requests.File.Commands;

public class ReadFileCommand:IRequest<ReadFileCommandResult>
{
    public IFormFile? File { get; set; }
}
