using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedById = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DistrictName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedById = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Districts_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GovernorateName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedById = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Governorate_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Governorate_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    GovernorateId = table.Column<int>(type: "INTEGER", nullable: false),
                    DistrictId = table.Column<int>(type: "INTEGER", nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedById = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedById", "CreatedDate", "LastModifiedById", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, "6 October", null, null, null, null },
                    { 2, "Masr El Gadida", null, null, null, null },
                    { 3, "New Cairo", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DistrictName", "LastModifiedById", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, null, null, "Sheikh Zayed", null, null },
                    { 2, null, null, "El Mohandeseen", null, null },
                    { 3, null, null, "Maadi", null, null }
                });

            migrationBuilder.InsertData(
                table: "Governorate",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "GovernorateName", "LastModifiedById", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, null, null, "Giza", null, null },
                    { 2, null, null, "Cairo", null, null },
                    { 3, null, null, "Cairo", null, null }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedDate", "DistrictId", "GovernorateId", "LastModifiedById", "LastModifiedDate", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2628), 1, 1, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2640), "01222868979", "UnHandled" },
                    { 2, 2, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2643), 2, 2, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2644), "01062065789", "UnHandled" },
                    { 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2647), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2648), "01124464869", "UnHandled" },
                    { 4, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2650), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2652), "01124464869", "UnHandled" },
                    { 6, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2654), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2655), "01124464869", "UnHandled" },
                    { 7, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2658), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2659), "01124464869", "UnHandled" },
                    { 8, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2673), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2674), "01124464869", "UnHandled" },
                    { 9, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2677), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2678), "01124464869", "UnHandled" },
                    { 10, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2681), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2682), "01124464869", "UnHandled" },
                    { 11, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2684), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2685), "01124464869", "UnHandled" },
                    { 12, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2688), 3, 3, null, new DateTime(2023, 10, 29, 3, 0, 22, 856, DateTimeKind.Local).AddTicks(2689), "01124464869", "UnHandled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedById",
                table: "Cities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LastModifiedById",
                table: "Cities",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CreatedById",
                table: "Districts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_LastModifiedById",
                table: "Districts",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Governorate_CreatedById",
                table: "Governorate",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Governorate_LastModifiedById",
                table: "Governorate",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CityId",
                table: "Ticket",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CreatedById",
                table: "Ticket",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DistrictId",
                table: "Ticket",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_GovernorateId",
                table: "Ticket",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_LastModifiedById",
                table: "Ticket",
                column: "LastModifiedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
