using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auto_Repair_Managment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mechanic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    qualification = table.Column<int>(type: "integer", nullable: false),
                    specialization = table.Column<int>(type: "integer", nullable: false),
                    experience_years = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mechanic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spare_part",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    article = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric(19,2)", nullable: false),
                    in_stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spare_part", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "work_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    norm_hours = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    price = table.Column<decimal>(type: "numeric(19,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.id);
                    table.ForeignKey(
                        name: "FK_car_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    mechanic_id = table.Column<int>(type: "integer", nullable: false),
                    car_id = table.Column<int>(type: "integer", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_car_car_id",
                        column: x => x.car_id,
                        principalTable: "car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointment_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointment_mechanic_mechanic_id",
                        column: x => x.mechanic_id,
                        principalTable: "mechanic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "repair_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointment_id = table.Column<int>(type: "integer", nullable: false),
                    work_type_id = table.Column<int>(type: "integer", nullable: false),
                    completed_at = table.Column<DateTime>(type: "date", nullable: false),
                    total_cost = table.Column<decimal>(type: "numeric(19,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_repair_order_appointment_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_repair_order_work_type_work_type_id",
                        column: x => x.work_type_id,
                        principalTable: "work_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "spare_part_usage",
                columns: table => new
                {
                    repair_order_id = table.Column<int>(type: "integer", nullable: false),
                    spare_part_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spare_part_usage", x => new { x.repair_order_id, x.spare_part_id });
                    table.ForeignKey(
                        name: "FK_spare_part_usage_repair_order_repair_order_id",
                        column: x => x.repair_order_id,
                        principalTable: "repair_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spare_part_usage_spare_part_spare_part_id",
                        column: x => x.spare_part_id,
                        principalTable: "spare_part",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "client",
                columns: new[] { "id", "full_name", "phone_number" },
                values: new object[,]
                {
                    { 1, "Иванов Иван Петрович", "+7 900 111-22-33" },
                    { 2, "Петрова Анна Сергеевна", "+7 900 222-33-44" },
                    { 3, "Сидоров Алексей Николаевич", "+7 900 333-44-55" }
                });

            migrationBuilder.InsertData(
                table: "car",
                columns: new[] { "id", "brand", "client_id", "model" },
                values: new object[,]
                {
                    { 1, "Toyota", 1, "Camry" },
                    { 2, "Kia", 1, "Rio" },
                    { 3, "Lada", 2, "Vesta" },
                    { 4, "Volkswagen", 3, "Polo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_car_id",
                table: "appointment",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_client_id",
                table: "appointment",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_mechanic_id",
                table: "appointment",
                column: "mechanic_id");

            migrationBuilder.CreateIndex(
                name: "IX_car_client_id",
                table: "car",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_repair_order_appointment_id",
                table: "repair_order",
                column: "appointment_id");

            migrationBuilder.CreateIndex(
                name: "IX_repair_order_work_type_id",
                table: "repair_order",
                column: "work_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_spare_part_usage_spare_part_id",
                table: "spare_part_usage",
                column: "spare_part_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spare_part_usage");

            migrationBuilder.DropTable(
                name: "repair_order");

            migrationBuilder.DropTable(
                name: "spare_part");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "work_type");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "mechanic");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
