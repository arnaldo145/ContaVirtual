using ContaVirtual_AM.Application.v1.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Controllers.v1.Transactions
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("debit")]
        public async Task<IActionResult> DebitAsync([FromBody] AccountDebit.Command accountDebitCommand)
        {
            var response = await _mediator.Send(accountDebitCommand);
            return Ok(response);
        }

        [HttpPost]
        [Route("credit")]
        public async Task<IActionResult> CreditAsync([FromBody] AccountCredit.Command accountDebitCommand)
        {
            var response = await _mediator.Send(accountDebitCommand);
            return Ok(response);
        }

        [HttpGet]       
        [Route("{cpf}")]
        public async Task<IActionResult> GetAsync([FromRoute] string cpf)
        {
            var query = new TransactionCollection.Query(cpf);
            var response = await _mediator.Send(query);

            

            return Ok(response);
        }
    }
}
