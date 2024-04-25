using MediatR;
using WebAppTask.Server.Requests.File.Commands;
using WebAppTask.Server.Responses.File.Commands;
using System.IO;
namespace WebAppTask.Server.Handlers;


public class WriteFileCommandHandler : IRequestHandler<WriteFileCommand, WriteFileCommandResult>
{
    public async Task<WriteFileCommandResult> Handle(WriteFileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using (var writer = new StreamWriter("output.txt"))
            {
                foreach (var item in request.Items)
                {
                    await writer.WriteLineAsync(item);
                }
            }
            return new WriteFileCommandResult { Message = "Файл записан" };
        }
        catch (Exception ex)
        {
            return new WriteFileCommandResult { Message = ex.ToString() };
        }
    }
}
