using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaygahYar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFormsToUploadBased : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "JaygahYar");

            migrationBuilder.CreateTable(
                name: "Stations",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    GasolineTankCount = table.Column<int>(type: "integer", nullable: false),
                    DieselTankCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AfterSalesServiceReports",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PersonnelDispatch = table.Column<string>(type: "text", nullable: true),
                    WarehouseReceipt = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    LandlineAndMobile = table.Column<string>(type: "text", nullable: true),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceCommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DefectsReportedByCustomer = table.Column<string>(type: "text", nullable: true),
                    ContactDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ContactTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    ElectronicSystemType = table.Column<string>(type: "text", nullable: true),
                    PerformanceSideA = table.Column<decimal>(type: "numeric", nullable: true),
                    PerformanceSideB = table.Column<decimal>(type: "numeric", nullable: true),
                    PerformanceSideC = table.Column<decimal>(type: "numeric", nullable: true),
                    PerformanceSideD = table.Column<decimal>(type: "numeric", nullable: true),
                    ExpertOpinion = table.Column<string>(type: "text", nullable: true),
                    BarrierPlaced = table.Column<bool>(type: "boolean", nullable: false),
                    FireExtinguisherNearby = table.Column<bool>(type: "boolean", nullable: false),
                    DevicePowerCutOff = table.Column<bool>(type: "boolean", nullable: false),
                    ShutOffValveClosed = table.Column<bool>(type: "boolean", nullable: false),
                    LeakCheckAfterService = table.Column<bool>(type: "boolean", nullable: false),
                    IsWarranty = table.Column<bool>(type: "boolean", nullable: false),
                    DefectResolutionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DefectResolutionTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    TravelCost = table.Column<decimal>(type: "numeric", nullable: true),
                    DistanceKm = table.Column<decimal>(type: "numeric", nullable: true),
                    Downtime = table.Column<string>(type: "text", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    GrandTotalInWords = table.Column<string>(type: "text", nullable: true),
                    StationManagerName = table.Column<string>(type: "text", nullable: true),
                    StationManagerSignature = table.Column<string>(type: "text", nullable: true),
                    OilCompanyApprovalRequired = table.Column<bool>(type: "boolean", nullable: false),
                    RepairTechnicianName = table.Column<string>(type: "text", nullable: true),
                    RepairTechnicianSignature = table.Column<string>(type: "text", nullable: true),
                    ProvincialRepresentativeName = table.Column<string>(type: "text", nullable: true),
                    ProvincialRepresentativeSignature = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSalesServiceReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AfterSalesServiceReports_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "JaygahYar",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OilToolInstallationForms",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    BuyerFullName = table.Column<string>(type: "text", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationAddress = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    DeviceInstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InstallationFormFilePath = table.Column<string>(type: "text", nullable: false),
                    PeymanegarTestFormFilePath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilToolInstallationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilToolInstallationForms_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "JaygahYar",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stage2DeliveryForms",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    BuyerFullName = table.Column<string>(type: "text", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationAddress = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    DeviceInstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeviceCommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DispenserManufacturer = table.Column<string>(type: "text", nullable: false),
                    UploadedFormFilePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage2DeliveryForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage2DeliveryForms_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "JaygahYar",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stage3DeliveryForms",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    BuyerFullName = table.Column<string>(type: "text", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationAddress = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    DeviceInstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeviceCommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeviceModel = table.Column<string>(type: "text", nullable: false),
                    DeviceSerialNumber = table.Column<string>(type: "text", nullable: false),
                    UploadedFormFilePath = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage3DeliveryForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage3DeliveryForms_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "JaygahYar",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TankMonitoringInstallationForms",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    BuyerFullName = table.Column<string>(type: "text", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationAddress = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    TankCount = table.Column<int>(type: "integer", nullable: false),
                    DeviceModel = table.Column<string>(type: "text", nullable: false),
                    DisplaySerialNumber = table.Column<string>(type: "text", nullable: false),
                    DeviceInstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeviceCommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UploadedFormFilePath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankMonitoringInstallationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TankMonitoringInstallationForms_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "JaygahYar",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReportItems",
                schema: "JaygahYar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AfterSalesServiceReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DefectivePartSerialNumber = table.Column<string>(type: "text", nullable: true),
                    NewPartSerialNumber = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReportItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReportItems_AfterSalesServiceReports_AfterSalesServi~",
                        column: x => x.AfterSalesServiceReportId,
                        principalSchema: "JaygahYar",
                        principalTable: "AfterSalesServiceReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfterSalesServiceReports_StationId",
                schema: "JaygahYar",
                table: "AfterSalesServiceReports",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_OilToolInstallationForms_StationId",
                schema: "JaygahYar",
                table: "OilToolInstallationForms",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportItems_AfterSalesServiceReportId",
                schema: "JaygahYar",
                table: "ServiceReportItems",
                column: "AfterSalesServiceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage2DeliveryForms_StationId",
                schema: "JaygahYar",
                table: "Stage2DeliveryForms",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage3DeliveryForms_StationId",
                schema: "JaygahYar",
                table: "Stage3DeliveryForms",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TankMonitoringInstallationForms_StationId",
                schema: "JaygahYar",
                table: "TankMonitoringInstallationForms",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OilToolInstallationForms",
                schema: "JaygahYar");

            migrationBuilder.DropTable(
                name: "ServiceReportItems",
                schema: "JaygahYar");

            migrationBuilder.DropTable(
                name: "Stage2DeliveryForms",
                schema: "JaygahYar");

            migrationBuilder.DropTable(
                name: "Stage3DeliveryForms",
                schema: "JaygahYar");

            migrationBuilder.DropTable(
                name: "TankMonitoringInstallationForms",
                schema: "JaygahYar");

            migrationBuilder.DropTable(
                name: "AfterSalesServiceReports",
                schema: "JaygahYar");

            migrationBuilder.DropTable(
                name: "Stations",
                schema: "JaygahYar");
        }
    }
}
