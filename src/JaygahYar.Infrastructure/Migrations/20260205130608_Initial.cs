using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaygahYar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
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
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OilToolInstallationForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    FormCompletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BuyerName = table.Column<string>(type: "text", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationAddress = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    DeviceInstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FloatQuantity = table.Column<int>(type: "integer", nullable: true),
                    StationType = table.Column<int>(type: "integer", nullable: true),
                    ShutOffValveInstalledCorrectly = table.Column<bool>(type: "boolean", nullable: false),
                    CheckValveInstalledForMotorized = table.Column<bool>(type: "boolean", nullable: false),
                    SuitableGlandsForInputCables = table.Column<bool>(type: "boolean", nullable: false),
                    InstallerName = table.Column<string>(type: "text", nullable: true),
                    InstallerSignature = table.Column<string>(type: "text", nullable: true),
                    RepresentativeStamp = table.Column<string>(type: "text", nullable: true),
                    RepresentativeSignature = table.Column<string>(type: "text", nullable: true),
                    StationOwnerStamp = table.Column<string>(type: "text", nullable: true),
                    StationOwnerSignature = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilToolInstallationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilToolInstallationForms_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stage2DeliveryForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    FormDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revision = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    StationOwnerName = table.Column<string>(type: "text", nullable: true),
                    CompanyBrand = table.Column<string>(type: "text", nullable: true),
                    SendDate = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    HasReceivedItems = table.Column<bool>(type: "boolean", nullable: false),
                    VacuumPumpCount = table.Column<int>(type: "integer", nullable: true),
                    MotorThreePhase = table.Column<bool>(type: "boolean", nullable: true),
                    SinglePhaseMotorCount = table.Column<int>(type: "integer", nullable: true),
                    DualWallHoseCount = table.Column<int>(type: "integer", nullable: true),
                    SeparatorCount = table.Column<int>(type: "integer", nullable: true),
                    CutoffCount = table.Column<int>(type: "integer", nullable: true),
                    NozzleCount = table.Column<int>(type: "integer", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "text", nullable: true),
                    DispenserModel = table.Column<string>(type: "text", nullable: true),
                    DispenserManufacturer = table.Column<string>(type: "text", nullable: true),
                    SingleNozzleDispenserCount = table.Column<int>(type: "integer", nullable: true),
                    TwoNozzleDispenserCount = table.Column<int>(type: "integer", nullable: true),
                    FourNozzleDispenserCount = table.Column<int>(type: "integer", nullable: true),
                    EquipmentInstalled = table.Column<bool>(type: "boolean", nullable: false),
                    Stage2PipingInsideDispensers = table.Column<bool>(type: "boolean", nullable: false),
                    Stage2TestApproved = table.Column<bool>(type: "boolean", nullable: false),
                    PipeSlopeTowardTank = table.Column<bool>(type: "boolean", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Trainee1Name = table.Column<string>(type: "text", nullable: true),
                    Trainee1NationalId = table.Column<string>(type: "text", nullable: true),
                    Trainee2Name = table.Column<string>(type: "text", nullable: true),
                    Trainee2NationalId = table.Column<string>(type: "text", nullable: true),
                    Trainee3Name = table.Column<string>(type: "text", nullable: true),
                    Trainee3NationalId = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    RepresentativeSignature = table.Column<string>(type: "text", nullable: true),
                    BrandCompanyStamp = table.Column<string>(type: "text", nullable: true),
                    StationStamp = table.Column<string>(type: "text", nullable: true),
                    StationManagerSignature = table.Column<string>(type: "text", nullable: true),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage2DeliveryForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage2DeliveryForms_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stage3DeliveryForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    FormDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Revision = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    StationOwnerName = table.Column<string>(type: "text", nullable: true),
                    CompanyBrand = table.Column<string>(type: "text", nullable: true),
                    SendDate = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DeliveryCommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDelivery = table.Column<bool>(type: "boolean", nullable: false),
                    IsCommissioning = table.Column<bool>(type: "boolean", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Trainee1Name = table.Column<string>(type: "text", nullable: true),
                    Trainee1NationalId = table.Column<string>(type: "text", nullable: true),
                    Trainee2Name = table.Column<string>(type: "text", nullable: true),
                    Trainee2NationalId = table.Column<string>(type: "text", nullable: true),
                    Trainee3Name = table.Column<string>(type: "text", nullable: true),
                    Trainee3NationalId = table.Column<string>(type: "text", nullable: true),
                    HasStage2Commissioning = table.Column<bool>(type: "boolean", nullable: false),
                    HPGaugePressureBeforeStart = table.Column<decimal>(type: "numeric", nullable: true),
                    LPGaugePressureBeforeStart = table.Column<decimal>(type: "numeric", nullable: true),
                    HPGaugePressureAfterStart = table.Column<decimal>(type: "numeric", nullable: true),
                    LPGaugePressureAfterStart = table.Column<decimal>(type: "numeric", nullable: true),
                    InitialTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    SecondaryTemperatureMin = table.Column<decimal>(type: "numeric", nullable: true),
                    CompressorMaxCurrentAmpere = table.Column<decimal>(type: "numeric", nullable: true),
                    ThermometerOffTempC = table.Column<decimal>(type: "numeric", nullable: true),
                    ThermometerOnTempC = table.Column<decimal>(type: "numeric", nullable: true),
                    CompressorHasOil = table.Column<bool>(type: "boolean", nullable: false),
                    TimeToSecondaryTempMinutes = table.Column<int>(type: "integer", nullable: true),
                    VaporInletOutletValvesChecked = table.Column<bool>(type: "boolean", nullable: false),
                    DipHatchGasTightChecked = table.Column<bool>(type: "boolean", nullable: false),
                    DrainHoseCapGasTightChecked = table.Column<bool>(type: "boolean", nullable: false),
                    PVValvesOperationChecked = table.Column<bool>(type: "boolean", nullable: false),
                    StationGroundToDeviceChecked = table.Column<bool>(type: "boolean", nullable: false),
                    FlameArresterInstalled = table.Column<bool>(type: "boolean", nullable: false),
                    ManualTakeoffBlockerInstalled = table.Column<bool>(type: "boolean", nullable: false),
                    PVCalibrationCertificateOnCollector = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceModel = table.Column<string>(type: "text", nullable: true),
                    DeviceSerialNumber = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    RepresentativeSignature = table.Column<string>(type: "text", nullable: true),
                    BrandCompanyStamp = table.Column<string>(type: "text", nullable: true),
                    StationStamp = table.Column<string>(type: "text", nullable: true),
                    StationManagerSignature = table.Column<string>(type: "text", nullable: true),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage3DeliveryForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage3DeliveryForms_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TankMonitoringInstallationForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    FormDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BuyerFullName = table.Column<string>(type: "text", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationAddress = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    GasolineTankCount = table.Column<int>(type: "integer", nullable: false),
                    DieselTankCount = table.Column<int>(type: "integer", nullable: false),
                    DeviceInstallationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeviceCommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    DisplaySerialNumber = table.Column<string>(type: "text", nullable: true),
                    PowerSerialNumber = table.Column<string>(type: "text", nullable: true),
                    DisplayPowerInstalledCorrectly = table.Column<bool>(type: "boolean", nullable: false),
                    SuitableCableUsed = table.Column<bool>(type: "boolean", nullable: false),
                    ProbesInstalledCorrectly = table.Column<bool>(type: "boolean", nullable: false),
                    JunctionBoxInstalledCorrectly = table.Column<bool>(type: "boolean", nullable: false),
                    CableEntryGasTight = table.Column<bool>(type: "boolean", nullable: false),
                    FloatsInstalledCorrectly = table.Column<bool>(type: "boolean", nullable: false),
                    ConsoleGroundAndProtectionUsed = table.Column<bool>(type: "boolean", nullable: false),
                    SoftwarePurchased = table.Column<bool>(type: "boolean", nullable: false),
                    SoftwareSetupPerformed = table.Column<bool>(type: "boolean", nullable: false),
                    TankInfoMatchesDipstick = table.Column<bool>(type: "boolean", nullable: false),
                    TrainingProvided = table.Column<bool>(type: "boolean", nullable: false),
                    StationManagerName = table.Column<string>(type: "text", nullable: true),
                    StationManagerSignature = table.Column<string>(type: "text", nullable: true),
                    AuthorizedRepresentativeName = table.Column<string>(type: "text", nullable: true),
                    AuthorizedRepresentativeSignature = table.Column<string>(type: "text", nullable: true),
                    JaygahYarManagementName = table.Column<string>(type: "text", nullable: true),
                    JaygahYarManagementSignature = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankMonitoringInstallationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TankMonitoringInstallationForms_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReportItems",
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
                        principalTable: "AfterSalesServiceReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DispenserInstallationItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OilToolInstallationFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowNumber = table.Column<int>(type: "integer", nullable: false),
                    DispenserType = table.Column<string>(type: "text", nullable: false),
                    NozzleCount = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    FuelTypeA = table.Column<string>(type: "text", nullable: true),
                    FuelTypeB = table.Column<string>(type: "text", nullable: true),
                    CurrentPerformanceC = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrentPerformanceD = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispenserInstallationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispenserInstallationItems_OilToolInstallationForms_OilTool~",
                        column: x => x.OilToolInstallationFormId,
                        principalTable: "OilToolInstallationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProbeItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TankMonitoringInstallationFormId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowNumber = table.Column<int>(type: "integer", nullable: false),
                    ProbeType = table.Column<string>(type: "text", nullable: false),
                    ProbeSerialNumber = table.Column<string>(type: "text", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    TankNumber = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProbeItems_TankMonitoringInstallationForms_TankMonitoringIn~",
                        column: x => x.TankMonitoringInstallationFormId,
                        principalTable: "TankMonitoringInstallationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfterSalesServiceReports_StationId",
                table: "AfterSalesServiceReports",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenserInstallationItems_OilToolInstallationFormId",
                table: "DispenserInstallationItems",
                column: "OilToolInstallationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_OilToolInstallationForms_StationId",
                table: "OilToolInstallationForms",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProbeItems_TankMonitoringInstallationFormId",
                table: "ProbeItems",
                column: "TankMonitoringInstallationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportItems_AfterSalesServiceReportId",
                table: "ServiceReportItems",
                column: "AfterSalesServiceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage2DeliveryForms_StationId",
                table: "Stage2DeliveryForms",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage3DeliveryForms_StationId",
                table: "Stage3DeliveryForms",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TankMonitoringInstallationForms_StationId",
                table: "TankMonitoringInstallationForms",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispenserInstallationItems");

            migrationBuilder.DropTable(
                name: "ProbeItems");

            migrationBuilder.DropTable(
                name: "ServiceReportItems");

            migrationBuilder.DropTable(
                name: "Stage2DeliveryForms");

            migrationBuilder.DropTable(
                name: "Stage3DeliveryForms");

            migrationBuilder.DropTable(
                name: "OilToolInstallationForms");

            migrationBuilder.DropTable(
                name: "TankMonitoringInstallationForms");

            migrationBuilder.DropTable(
                name: "AfterSalesServiceReports");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
