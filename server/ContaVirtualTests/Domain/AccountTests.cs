using ContaVirtual_AM.Domain.v1.Accounts;
using NUnit.Framework;

namespace ContaVirtualTests.Domain
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void RealizarDebito_Deve_ObterSucesso()
        {
            // Arrange
            var account = new Account() {
                Balance = 1400
            };

            // Act
            var result = account.Debit(200);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RealizarDebito_Com_ValorMaiorDoQueSaldo_NaoDeve_RealizarDebito()
        {
            // Arrange
            var account = new Account()
            {
                Balance = 1400
            };

            // Act
            var result = account.Debit(1500);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void RealizarDebito_Com_ValorNegativo_NaoDeve_RealizarDebito()
        {
            // Arrange
            var account = new Account()
            {
                Balance = 1400
            };

            // Act
            var result = account.Debit(-50);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void RealizarCredito_Deve_ObterSucesso()
        {
            // Arrange
            var account = new Account()
            {
                Balance = 0
            };

            // Act
            var result = account.Credit(2000);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RealizarCredito_Com_ValorNegativo_NaoDeve_RealizarCredito()
        {
            // Arrange
            var account = new Account()
            {
                Balance = 0
            };

            // Act
            var result = account.Credit(-45);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
