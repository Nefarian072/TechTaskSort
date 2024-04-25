using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppTask.Server.Models;
using WebAppTask.Server.Requests.File.Commands;
using WebAppTask.Server.Requests.MyList;
using WebAppTask.Server.Responses.File.Commands;
using WebAppTask.Server.Responses.MyList;

namespace WebAppTask.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MyListController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MyListController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost("read-file")]
    public async Task<IActionResult> ReadFile(IFormFile? file)
    {
        try
        {
            ReadFileCommand command = new ReadFileCommand
            {
                File = file
            };
            var result = await _mediator.Send(command);
            return Ok(_mapper.Map<ReadFileCommandResult>(result));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }


    [HttpPost("sort")]
    public async Task<IActionResult> Sort([FromBody]MyList myList)
    {
        try
        {
            Console.WriteLine(myList.SortType);
            var command = _mapper.Map<SortMyListCommand>(myList);
            var result = await _mediator.Send(command);
            return Ok(_mapper.Map<SortMyListCommandResult>(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
