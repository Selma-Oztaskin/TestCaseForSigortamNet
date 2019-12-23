using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceOffer.Test.Case.DataLayer.Migrations
{
    public partial class CustomerInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TCKN = table.Column<string>(nullable: true),
                    Plaka = table.Column<string>(nullable: true),
                    RuhsatSeriKodu = table.Column<string>(nullable: true),
                    RuhsatSeriNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInsuranceOffers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirmaAdi = table.Column<string>(nullable: true),
                    FirmaLogosu = table.Column<string>(nullable: true),
                    TeklifAciklamasi = table.Column<string>(nullable: true),
                    TeklifTutari = table.Column<string>(nullable: true),
                    Plaka = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInsuranceOffers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropTable(
                name: "CustomerInsuranceOffers");
        }
    }
}
