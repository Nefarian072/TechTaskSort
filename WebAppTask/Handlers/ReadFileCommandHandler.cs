using MediatR;
using WebAppTask.Server.Requests.File.Commands;
using WebAppTask.Server.Responses.File.Commands;

namespace WebAppTask.Server.Handlers;

public class ReadFileCommandHandler : IRequestHandler<ReadFileCommand, ReadFileCommandResult>
{
    public async Task<ReadFileCommandResult> Handle(ReadFileCommand request, CancellationToken cancellationToken)
    {
        var items = new List<string>();
        try
        {
            using var reader = new StreamReader(request.File.OpenReadStream());
            while (!reader.EndOfStream)
            {
                string? line = await reader.ReadLineAsync();
                if (line != null)
                {
                    items.AddRange(line.Split(","));
                }
            }
        }
        catch (Exception ex)
        {
            return new ReadFileCommandResult
            {
                ErrorMessage = ex.Message
            };
        }
        return new ReadFileCommandResult
        {
            Items = items
        };
    }
}
