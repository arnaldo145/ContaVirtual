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

        /// <summary>
        /// Realiza operação de débito na conta virtual
        /// </summary>
        /// <returns>Informa se conseguiu realizar a operação de débito na conta virtual</returns>
        [HttpPost]
        [Route("debit")]
        public async Task<IActionResult> DebitAsync([FromBody] AccountDebit.Command accountDebitCommand)
        {
            var response = await _mediator.Send(accountDebitCommand);
            return Ok(response);
        }

        /// <summary>
        /// Realiza operação de crédito na conta virtual
        /// </summary>
        /// <returns>Informa se conseguiu realizar a operação de crédito na conta virtual</returns>
        [HttpPost]
        [Route("credit")]
        public async Task<IActionResult> CreditAsync([FromBody] AccountCredit.Command accountCreditCommand)
        {
            var response = await _mediator.Send(accountCreditCommand);
            return Ok(response);
        }


        /// <summary>
        /// Obtem o extrato da conta virtual
        /// </summary>
        /// <param name="cpf">CPF do cliente que possui conta virtual</param>
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
