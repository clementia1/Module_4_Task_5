using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module_4_Task_5.Migrations
{
    public partial class AddAndPopulateClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql("INSERT INTO Client(Name, Address, Email, CreatedDate) VALUES('SoftServe', 'м.Львів, вул. Садова, 2д', 'hr@softserveinc.com', '2015-09-28')");
            migrationBuilder.Sql("INSERT INTO Client(Name, Address, Email, CreatedDate) VALUES('EPAM', 'Київ, вул. Кудряшова, 14Б', 'ua_career@epam.com', '2016-09-28')");
            migrationBuilder.Sql("INSERT INTO Client(Name, Address, Email, CreatedDate) VALUES('GlobalLogic', 'Харків, вул. Новгородська, 3Б', 'join.kharkiv@globallogic.com', '2016-10-28')");
            migrationBuilder.Sql("INSERT INTO Client(Name, Address, Email, CreatedDate) VALUES('Ciklum', 'Kharkiv, BC Dvizhenie, 2-3 floors, 18-D, Otakara Yarosha St.', 'ciklum@ciklum.com', '2017-09-28')");
            migrationBuilder.Sql("INSERT INTO Client(Name, Address, Email, CreatedDate) VALUES('Luxoft', 'Kyiv, 10/14 Radishcheva Str., Business Center IRVA B', 'kiev@luxoft.com', '2018-10-28')");

            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('SomeProject1', '200000', GETDATE(), 5)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('SomeProject2', '220000', GETDATE(), 3)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('SomeProject3', '240000', GETDATE(), 3)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('SomeProject4', '260000', GETDATE(), 2)");
            migrationBuilder.Sql("INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('SomeProject5', '280000', GETDATE(), 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);
        }
    }
}
