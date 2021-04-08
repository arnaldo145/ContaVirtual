using ContaVirtual_AM.Application.v1.Transactions;
using ContaVirtual_AM.Domain.v1.Accounts;
using ContaVirtual_AM.Domain.v1.Transactions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContaVirtualTests.Application.Transactions
{
    [TestFixture]
    public class AccountCreditTests
    {
        private Mock<IAccountRepository> _accountRepositoryFake;
        private Mock<IAccountTransactionRepository> _accountTransactionRepositoryFake;

        private AccountCredit.Handler _handler;

        [SetUp]
        public void Setup()
        {
            _accountRepositoryFake = new Mock<IAccountRepository>();
            _accountTransactionRepositoryFake = new Mock<IAccountTransactionRepository>();

            _handler = new AccountCredit.Handler(_accountRepositoryFake.Object, _accountTransactionRepositoryFake.Object);
        }

        [Test]
        public async Task RealizarCreditoNaConta_Deve_ObterSucesso()
        {
            // Arrange
            var expectedValue = 1750;

            var account = new Account()
            {
                CPF = "00100100199",
                Balance = 1500
            };

            var command = new AccountCredit.Command()
            {
                CPF = "00100100199",
                Description = "Pix",
                Value = 250
            };

            _accountRepositoryFake.Setup(x => x.GetByCPF(It.IsAny<string>()))
                .ReturnsAsync(account);
            _accountTransactionRepositoryFake.Setup(x => x.Add(It.IsAny<AccountTransaction>()))
                .ReturnsAsync(Guid.NewGuid());
            _accountRepositoryFake.Setup(x => x.Update(It.IsAny<Account>()));

            // Act
            var response = await _handler.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            Assert.IsTrue(response);
            Assert.AreEqual(expectedValue, account.Balance);
        }

        [Test]
        public async Task RealizarCreditoNaConta_Com_SaldoNegativo_NaoDeve_EfetuarOperacao()
        {
            // Arrange
            var account = new Account()
            {
                CPF = "00100100199",
                Balance = 1500
            };

            var command = new AccountCredit.Command()
            {
                CPF = "00100100199",
                Description = "Pix",
                Value = -50
            };

            _accountRepositoryFake.Setup(x => x.GetByCPF(It.IsAny<string>()))
                .ReturnsAsync(account);
            
            // Act
            var response = await _handler.Handle(command, It.IsAny<CancellationToken>());

            // Assert
            Assert.IsFalse(response);
        }

    }
}
