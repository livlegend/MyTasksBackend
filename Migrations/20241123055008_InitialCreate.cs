using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyTasksBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_CategoryItems_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItems_UserItems_UserId",
                        column: x => x.UserId,
                        principalTable: "UserItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryItems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Travail" },
                    { 2, "Personnel" },
                    { 3, "Etudes" }
                });

            migrationBuilder.InsertData(
                table: "UserItems",
                columns: new[] { "Id", "Email", "Name", "Password", "Role", "Status" },
                values: new object[] { 1, "test@example.com", "HYAME Lorry", "RqN9ZaTJ6yIJuvPpGthQ/URXwL2AQSoLUPYF/dOmqmFMTAB5gc2lsDWfv/sSxnvL", "Administrator", "Active" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CategoryId", "DateLimit", "Description", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 23, 0, 50, 8, 179, DateTimeKind.Local).AddTicks(9320), "Ma desc1", 0, "Ma tâche 1", 1 },
                    { 2, 2, new DateTime(2024, 11, 23, 0, 50, 8, 179, DateTimeKind.Local).AddTicks(9369), "Ma desc2", 0, "Ma tâche 2", 1 },
                    { 3, 3, new DateTime(2024, 11, 23, 0, 50, 8, 179, DateTimeKind.Local).AddTicks(9371), "Ma desc2", 0, "Ma tâche 2", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CategoryId",
                table: "TaskItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "UserItems");
        }
    }
}
