using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : Controller
{
    protected readonly IMediator Mediator;
    
    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}