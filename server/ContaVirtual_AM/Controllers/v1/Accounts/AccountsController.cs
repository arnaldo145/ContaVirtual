using ContaVirtual_AM.Application.v1.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Controllers.v1.Accounts
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria uma conta virtual
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AccountCreate.Command accountCreateCommand)
        {
            var response = await _mediator.Send(accountCreateCommand);
            return Ok(response);
        }
    }
}
