using Microsoft.EntityFrameworkCore.Migrations;

namespace ContaVirtual_AM.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Accounts (Id, Customer, CPF, OpeningDate, Balance) 
                                   VALUES ('87b69247-dd1e-485c-b4bb-32e5863cf9cb','Arnaldo Madeira', 
                                           '37325220910', GETDATE(), 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Accounts WHERE Id = '87b69247-dd1e-485c-b4bb-32e5863cf9cb'");
        }
    }
}
