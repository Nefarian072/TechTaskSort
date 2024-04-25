using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using WebAppTask.Server.Enums;
using WebAppTask.Server.Helper;
using WebAppTask.Server.Requests.MyList;
using WebAppTask.Server.Responses.MyList;

namespace WebAppTask.Server.Handlers;

public class SortMyListCommandHandler : IRequestHandler<SortMyListCommand, SortMyListCommandResult>
{
    private readonly SortHelper _sortHelper;
    public SortMyListCommandHandler(SortHelper sortHelper)
    {
        _sortHelper = sortHelper;
    }
    public async Task<SortMyListCommandResult> Handle(SortMyListCommand request, CancellationToken cancellationToken)
    {
        var listResult = await _sortHelper.Sort(request.Items, (SortType)request.SortType);
        return new SortMyListCommandResult
        {
            Items = listResult
        };
    }
}
