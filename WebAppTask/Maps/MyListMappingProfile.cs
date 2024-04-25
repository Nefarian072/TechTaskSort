using AutoMapper;
using WebAppTask.Server.Models;
using WebAppTask.Server.Requests.File.Commands;
using WebAppTask.Server.Responses.File.Commands;
using WebAppTask.Server.Requests.MyList;
using WebAppTask.Server.Responses.MyList;
namespace WebAppTask.Server.Maps;

public class MyListMappingProfile:Profile
{
    public MyListMappingProfile()
    {
        CreateMap<MyList, SortMyListCommand>();
        CreateMap<SortMyListCommandResult, MyList>();
        CreateMap<ReadFileCommand, ReadFileCommandResult>();
        CreateMap<ReadFileCommandResult, MyList>();
    }
}
