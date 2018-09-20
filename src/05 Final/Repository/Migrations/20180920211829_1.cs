using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    StreetName = table.Column<string>(maxLength: 100, nullable: true),
                    LiberatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommercialContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Path = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: true),
                    PercentualDiscount = table.Column<decimal>(nullable: true),
                    ValueDiscount = table.Column<decimal>(nullable: true),
                    ExtraValue = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TAB_EXAMPLE_PERSON",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PER_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    PER_CPF = table.Column<string>(maxLength: 11, nullable: true),
                    PER_BIRTHDATE = table.Column<DateTime>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engageds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    MakingOfId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engageds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engageds_Addresses_MakingOfId",
                        column: x => x.MakingOfId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    PaidValue = table.Column<decimal>(nullable: true),
                    PaymentPlan_Id = table.Column<int>(nullable: false),
                    PaymentPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentPlans_PaymentPlanId",
                        column: x => x.PaymentPlanId,
                        principalTable: "PaymentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Couples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Engaged1Id = table.Column<int>(nullable: true),
                    Engaged2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couples_Engageds_Engaged1Id",
                        column: x => x.Engaged1Id,
                        principalTable: "Engageds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Couples_Engageds_Engaged2Id",
                        column: x => x.Engaged2Id,
                        principalTable: "Engageds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoupleId = table.Column<int>(nullable: true),
                    CerimonyId = table.Column<int>(nullable: true),
                    PartyId = table.Column<int>(nullable: true),
                    SamePlace = table.Column<bool>(nullable: false),
                    PaymentPlanId = table.Column<int>(nullable: true),
                    DeliveryBoxId = table.Column<int>(nullable: true),
                    WeddingTime = table.Column<DateTime>(nullable: false),
                    PackageId = table.Column<int>(nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    ExtraInformation = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weddings_Addresses_CerimonyId",
                        column: x => x.CerimonyId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_CommercialContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "CommercialContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_Couples_CoupleId",
                        column: x => x.CoupleId,
                        principalTable: "Couples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_DeliveryBoxes_DeliveryBoxId",
                        column: x => x.DeliveryBoxId,
                        principalTable: "DeliveryBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_Addresses_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_PaymentPlans_PaymentPlanId",
                        column: x => x.PaymentPlanId,
                        principalTable: "PaymentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Couples_Engaged1Id",
                table: "Couples",
                column: "Engaged1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Couples_Engaged2Id",
                table: "Couples",
                column: "Engaged2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Engageds_MakingOfId",
                table: "Engageds",
                column: "MakingOfId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentPlanId",
                table: "Payments",
                column: "PaymentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CerimonyId",
                table: "Weddings",
                column: "CerimonyId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_ContractId",
                table: "Weddings",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CoupleId",
                table: "Weddings",
                column: "CoupleId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_DeliveryBoxId",
                table: "Weddings",
                column: "DeliveryBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_PackageId",
                table: "Weddings",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_PartyId",
                table: "Weddings",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_PaymentPlanId",
                table: "Weddings",
                column: "PaymentPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TAB_EXAMPLE_PERSON");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "CommercialContracts");

            migrationBuilder.DropTable(
                name: "Couples");

            migrationBuilder.DropTable(
                name: "DeliveryBoxes");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "PaymentPlans");

            migrationBuilder.DropTable(
                name: "Engageds");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
