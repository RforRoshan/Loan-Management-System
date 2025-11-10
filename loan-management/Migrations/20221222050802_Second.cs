using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminsTable",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminsTable", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "PassedLoansInfoTable",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanAmount = table.Column<float>(type: "real", nullable: true),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    InterestAmount = table.Column<float>(type: "real", nullable: false),
                    ProcessingFee = table.Column<float>(type: "real", nullable: false),
                    LoanDurationInMonths = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanPayDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanAmountLeft = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedLoansInfoTable", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsDetailsTable",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayedAmount = table.Column<float>(type: "real", nullable: false),
                    AmountLeft = table.Column<float>(type: "real", nullable: false),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsDetailsTable", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PendingLoansInfoTable",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanAmount = table.Column<float>(type: "real", nullable: true),
                    LoanDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanDurationInMonths = table.Column<int>(type: "int", nullable: true),
                    LoanNotPass = table.Column<bool>(type: "bit", nullable: false),
                    LoanNotPassReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingLoansInfoTable", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Aadhaar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankIFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminsTable");

            migrationBuilder.DropTable(
                name: "PassedLoansInfoTable");

            migrationBuilder.DropTable(
                name: "PaymentsDetailsTable");

            migrationBuilder.DropTable(
                name: "PendingLoansInfoTable");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersDetails");
        }
    }
}
