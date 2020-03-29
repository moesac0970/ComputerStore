using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerStore.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "BearerHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    BearerToken = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BearerHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BearerHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PlatformUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_PlatformUserId",
                        column: x => x.PlatformUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PcParts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Ean = table.Column<string>(nullable: true),
                    MakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PcParts_Makers_MakerId",
                        column: x => x.MakerId,
                        principalTable: "Makers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cpus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PcPartId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CoreCount = table.Column<int>(nullable: false),
                    Frequency = table.Column<double>(nullable: false),
                    TurboFrequency = table.Column<double>(nullable: false),
                    Cache = table.Column<double>(nullable: false),
                    ThreadCount = table.Column<int>(nullable: false),
                    MicroArchitecture = table.Column<string>(nullable: true),
                    Channels = table.Column<int>(nullable: false),
                    TDP = table.Column<double>(nullable: false),
                    Voltage = table.Column<double>(nullable: false),
                    MemoryType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cpus_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PcPartId = table.Column<int>(nullable: false),
                    PowerUsage = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Memory = table.Column<double>(nullable: false),
                    Frequency = table.Column<double>(nullable: false),
                    BoostFrequency = table.Column<double>(nullable: false),
                    MemoryType = table.Column<int>(nullable: false),
                    Ports = table.Column<string>(nullable: true),
                    Os = table.Column<string>(nullable: true),
                    Connection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gpus_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PcPartId = table.Column<int>(nullable: false),
                    Parttype = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    WeightMb = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PcPartId = table.Column<int>(nullable: false),
                    Capacity = table.Column<double>(nullable: false),
                    Cache = table.Column<double>(nullable: false),
                    Speed = table.Column<double>(nullable: false),
                    PowerUsage = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Interface = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memory_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PcPartId = table.Column<int>(nullable: false),
                    Chipset = table.Column<string>(nullable: true),
                    Inputs = table.Column<string>(nullable: true),
                    Usage = table.Column<string>(nullable: true),
                    MaxMemory = table.Column<double>(nullable: false),
                    SupportedMemoryType = table.Column<int>(nullable: false),
                    MemorySlotCount = table.Column<int>(nullable: false),
                    BiosType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherBoards_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    IsDelivered = table.Column<bool>(nullable: true),
                    PcPartsId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_PcParts_PcPartsId",
                        column: x => x.PcPartsId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PcCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PcPartId = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Materials = table.Column<string>(nullable: true),
                    InternalDimentions = table.Column<string>(nullable: true),
                    Dimentions = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PcCases_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Makers",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 29, 20, 24, 27, 207, DateTimeKind.Local).AddTicks(7399), "Nvidia" },
                    { 15, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8951), "Cougar" },
                    { 14, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8948), "Asus" },
                    { 13, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8945), "Sandisk" },
                    { 12, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8942), "Corsair" },
                    { 11, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8939), "WD" },
                    { 10, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8936), "ThermalTake" },
                    { 16, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(9024), "Ldlc" },
                    { 9, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8933), "Msi" },
                    { 7, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8927), "GigaByte" },
                    { 6, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8924), "Razer" },
                    { 5, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8920), "Logitech" },
                    { 4, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8917), "Radeon" },
                    { 3, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8913), "AMD" },
                    { 2, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8896), "Intel" },
                    { 8, new DateTime(2020, 3, 29, 20, 24, 27, 209, DateTimeKind.Local).AddTicks(8930), "Segate" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreationDate", "PlatformUserId" },
                values: new object[] { 1, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(2465), null });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreationDate", "IsDelivered", "OrderId", "PcPartsId", "Quantity" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(2073), false, 1, null, 4 },
                    { 1, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(868), false, 1, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "PcParts",
                columns: new[] { "Id", "CreationDate", "Ean", "MakerId", "Name", "Price", "ReleaseDate", "Type" },
                values: new object[,]
                {
                    { 9, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4912), "321365646561231", 14, "asus rog strix helios", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4915), 4 },
                    { 8, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4907), "321365646561231", 14, "asus rog strix", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4909), 3 },
                    { 7, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4901), "321365646561231", 14, "asus gaming", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4904), 3 },
                    { 20, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4976), "321365646561231", 13, "sandisk sdcard 1tb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4979), 2 },
                    { 28, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5021), "321365646561231", 12, "corsair carbide spec omega", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5023), 4 },
                    { 10, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4918), "321365646561231", 12, "Cougar conquer atx gaming", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4920), 4 },
                    { 21, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4981), "321365646561231", 8, "seagate barracuda 5tb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4984), 2 },
                    { 26, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5009), "321365646561231", 11, "wd blue 1tb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5012), 2 },
                    { 2, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4853), "321365646561231", 11, "wd blue sn500gb nvme ssd", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4862), 2 },
                    { 25, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5004), "321365646561231", 10, "thermaltake core3 g3 ", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5006), 4 },
                    { 19, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4970), "321365646561231", 9, "msi b450 gaming", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4973), 3 },
                    { 24, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4998), "321365646561231", 8, "seagate nightghawk 8tb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5001), 2 },
                    { 23, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4993), "321365646561231", 8, "seagate barracuda ssd 510gb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4995), 2 },
                    { 22, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4987), "321365646561231", 8, "seagate barracuda 8tb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4990), 2 },
                    { 18, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4965), "321365646561231", 15, "Ldlc ssd pcie nvme", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4967), 2 },
                    { 27, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5015), "321365646561231", 11, "wd red nas hdd 2tb", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5018), 2 },
                    { 3, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4877), "232235846323225", 8, "Segate SSD500GB", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4880), 2 },
                    { 11, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4924), "321365646561231", 7, "gigabyte md80", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4926), 3 },
                    { 30, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5032), "321365646561231", 1, "geforce gtx 1070", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5034), 1 },
                    { 31, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5037), "321365646561231", 1, "geforce rtx 2080ti ", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5040), 1 },
                    { 13, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4935), "321365646561231", 2, "intel core pentium", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4938), 0 },
                    { 14, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4941), "321365646561231", 2, "intel i5", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4943), 0 },
                    { 15, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4947), "321365646561231", 2, "intel i7", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4950), 0 },
                    { 16, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4953), "321365646561231", 2, "intel i9", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4956), 0 },
                    { 12, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4929), "321365646561231", 7, "gigabyte x570", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4932), 3 },
                    { 17, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4959), "321365646561231", 2, "intel server motherbaord", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4962), 3 },
                    { 5, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4888), "321365646561231", 3, "amd ryzen 7", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4892), 0 },
                    { 6, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4895), "321365646561231", 3, "amd ryzen 9", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4898), 0 },
                    { 29, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5026), "321365646561231", 3, "gtx 1050ti", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5029), 1 },
                    { 32, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5044), "321365646561231", 3, "amd vega 11", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5046), 1 },
                    { 33, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5050), "321365646561231", 3, "amd radeon rx5700", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5052), 1 },
                    { 34, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5055), "321365646561231", 3, "radeon rx 5600xt", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5058), 1 },
                    { 4, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4883), "321365646561231", 3, "amd ryzen 5", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(4885), 0 },
                    { 1, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(3596), "131653135165133", 1, "GeForce GTX 1660 Ti", 100.0, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(3606), 1 }
                });

            migrationBuilder.InsertData(
                table: "Cpus",
                columns: new[] { "Id", "Cache", "Channels", "CoreCount", "CreationDate", "Description", "Frequency", "MemoryType", "MicroArchitecture", "PcPartId", "TDP", "ThreadCount", "TurboFrequency", "Voltage" },
                values: new object[,]
                {
                    { 3, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(1137), null, 2.7999999999999998, 3, "Kaby lake", 6, 70.0, 8, 3.6000000000000001, 100.0 },
                    { 2, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(1116), null, 2.7999999999999998, 3, "Kaby lake", 5, 70.0, 8, 3.6000000000000001, 100.0 },
                    { 1, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9691), null, 2.7999999999999998, 3, "Kaby lake", 4, 70.0, 8, 3.6000000000000001, 100.0 },
                    { 7, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(1150), null, 2.7999999999999998, 3, "Kaby lake", 16, 70.0, 8, 3.6000000000000001, 100.0 },
                    { 4, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(1141), null, 2.7999999999999998, 3, "Kaby lake", 13, 70.0, 8, 3.6000000000000001, 100.0 },
                    { 6, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(1147), null, 2.7999999999999998, 3, "Kaby lake", 15, 70.0, 8, 3.6000000000000001, 100.0 },
                    { 5, 8.0, 6, 4, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(1144), null, 2.7999999999999998, 3, "Kaby lake", 14, 70.0, 8, 3.6000000000000001, 100.0 }
                });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "BoostFrequency", "Connection", "CreationDate", "Description", "Frequency", "Memory", "MemoryType", "Os", "PcPartId", "Ports", "PowerUsage" },
                values: new object[,]
                {
                    { 4, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9376), "amd vega 11, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 32, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 },
                    { 5, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9386), "amd radeon tx 5600xt, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 33, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 },
                    { 7, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9404), "gtx 1050ti, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 29, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 },
                    { 6, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9395), "radeon rx 5600xt, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 34, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 },
                    { 1, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7695), "nvdia GeForce GTX 1660 Ti, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 1, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 },
                    { 3, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9366), "nvdia GeForce rtx 2080ti, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 31, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 },
                    { 2, 1770.0, "PCIe x16 Versie 3.0", new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(9327), "nvdia GeForce GTX 1070 founders edition, good for gaming and video editing up to 4K", 1500.0, 8.0, 2, "linux, windows10, windows7, windows8", 30, "1x HDMI Versie 2.0b, 3x DisplayPort Versie 1.4", 105.59999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreationDate", "FileName", "Parttype", "PcPartId", "Type", "WeightMb" },
                values: new object[,]
                {
                    { 17, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7199), "Msi_b450_gaming.jpg", 2, 19, "image/jpeg", 1.3 },
                    { 36, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7392), "gigabyte_x570.jpg", 0, 12, "image/jpeg", 1.3 },
                    { 16, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7196), "ldlc_ssd_pcienvme_240.jpg", 2, 18, "image/jpeg", 1.3 },
                    { 35, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7252), "Seagate_BarraCuda_SSD__500_GB.jpg", 0, 3, "image/jpeg", 1.3 },
                    { 34, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7249), "wd_blue_nvme_ssd_500.jpg", 0, 2, "image/jpeg", 1.3 },
                    { 4, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7166), "asus_gaming.jpg", 2, 7, "image/jpeg", 1.3 },
                    { 19, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7204), "seagate_barracuda_5tb.jpg", 2, 21, "image/jpeg", 1.3 },
                    { 25, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7223), "wd_red_nas_hdd_2tb.jpg", 2, 27, "image/jpeg", 1.3 },
                    { 20, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7207), "Seagate_barracuda_8tb.jpg", 2, 22, "image/jpeg", 1.3 },
                    { 18, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7202), "sandisk_sdcard_1tb.jpg", 2, 20, "image/jpeg", 1.3 },
                    { 21, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7210), "seagate_barracuda_ssd_510.jpg", 2, 23, "image/jpeg", 1.3 },
                    { 5, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7169), "asus_rog_strix.jpg", 2, 8, "image/jpeg", 1.3 },
                    { 23, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7217), "thermaltake_core3_g3.jpg", 2, 25, "image/jpeg", 1.3 },
                    { 22, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7215), "seagate_nighthawk_8tb.jpg", 2, 24, "image/jpeg", 1.3 },
                    { 8, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7178), "Cougar_conquer_atx_gaming.jpg", 2, 10, "image/jpeg", 1.3 },
                    { 7, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7175), "Corsair_carbide_spec_omega.jpg", 2, 28, "image/jpeg", 1.3 },
                    { 30, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7238), "gtx_1660ti.jpg", 1, 1, "image/jpeg", 1.3 },
                    { 32, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7244), "radeon-rx-5600xt.jpg", 1, 34, "image/jpeg", 1.3 },
                    { 28, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7232), "geforce_gtx_1070_founder.jpg", 1, 30, "image/jpeg", 1.3 },
                    { 29, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7235), "geforce_rtx_2080ti_11gb.jpg", 1, 31, "image/jpeg", 1.3 },
                    { 33, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7246), "intel_core_pentium.jpg", 0, 13, "image/jpeg", 1.3 },
                    { 12, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7184), "intel_i5.jpg", 2, 14, "image/jpeg", 1.3 },
                    { 13, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7187), "intel_i7.jpg", 2, 15, "image/jpeg", 1.3 },
                    { 14, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7190), "intel_i9.jpg", 2, 16, "image/jpeg", 1.3 },
                    { 15, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7193), "intel_server_motherboard.jpg", 2, 17, "image/jpeg", 1.3 },
                    { 9, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7181), "gigabyte_MD80.jpg", 2, 11, "image/jpeg", 1.3 },
                    { 6, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7172), "ASUS_ROG_Strix_Helios.jpg", 2, 9, "image/jpeg", 1.3 },
                    { 2, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7140), "amd_ryzen_7.jpg", 2, 5, "image/jpeg", 1.3 },
                    { 3, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7160), "AMD-Ryzen-9-3950X.jpg", 2, 6, "image/jpeg", 1.3 },
                    { 31, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7241), "Gtx-1050Ti.jpg", 1, 29, "image/jpeg", 1.3 },
                    { 26, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7226), "amd_vega_11.jpg", 1, 32, "image/jpeg", 1.3 },
                    { 27, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7229), "amd-radeon-rx-5700.jpg", 1, 33, "image/jpeg", 1.3 },
                    { 1, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(5345), "amd_ryzen_5.jpg", 2, 4, "image/jpeg", 1.3 },
                    { 24, new DateTime(2020, 3, 29, 20, 24, 27, 210, DateTimeKind.Local).AddTicks(7220), "wd_blue_1tb.jpg", 2, 26, "image/jpeg", 1.3 }
                });

            migrationBuilder.InsertData(
                table: "Memory",
                columns: new[] { "Id", "Cache", "Capacity", "CreationDate", "Description", "Interface", "PcPartId", "PowerUsage", "Speed", "Weight" },
                values: new object[,]
                {
                    { 4, 8.0, 1000.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5370), null, null, 20, 50.0, 200.01300000000001, 100.0 },
                    { 10, 8.0, 2000.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5391), null, null, 27, 50.0, 200.0, 100.0 },
                    { 9, 8.0, 1000.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5388), null, null, 26, 50.0, 200.011, 100.0 },
                    { 3, 8.0, 500.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5366), null, null, 18, 50.0, 200.0, 100.0 },
                    { 8, 8.0, 8000.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5384), null, null, 24, 50.0, 200.08000000000001, 100.0 },
                    { 7, 8.0, 500.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5381), null, null, 23, 50.0, 200.0, 100.0 },
                    { 6, 8.0, 8000.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5377), null, null, 22, 50.0, 200.08000000000001, 100.0 },
                    { 5, 8.0, 5000.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5374), null, null, 21, 50.0, 200.08000000000001, 100.0 },
                    { 2, 8.0, 500.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(5346), null, null, 3, 50.0, 200.0, 100.0 },
                    { 1, 8.0, 500.0, new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(3631), null, null, 2, 50.0, 200.0, 100.0 }
                });

            migrationBuilder.InsertData(
                table: "MotherBoards",
                columns: new[] { "Id", "BiosType", "Chipset", "CreationDate", "Description", "Inputs", "MaxMemory", "MemorySlotCount", "PcPartId", "SupportedMemoryType", "Usage" },
                values: new object[,]
                {
                    { 6, "Uefi", "something", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(9594), null, "pcie", 128.5, 6, 19, 3, "pc" },
                    { 1, "Uefi", "something", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(6987), null, "pcie", 128.5, 6, 7, 3, "pc" },
                    { 3, "Uefi", "something", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(9582), null, "pcie", 128.5, 6, 11, 3, "pc" },
                    { 2, "Uefi", "something", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(9554), null, "pcie", 128.5, 6, 8, 3, "pc" },
                    { 5, "Uefi", "something", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(9590), null, "pcie", 128.5, 6, 17, 3, "pc" },
                    { 4, "Uefi", "something", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(9587), null, "pcie", 128.5, 6, 12, 3, "pc" }
                });

            migrationBuilder.InsertData(
                table: "PcCases",
                columns: new[] { "Id", "Color", "CreationDate", "Description", "Dimentions", "InternalDimentions", "Materials", "PcPartId" },
                values: new object[,]
                {
                    { 2, "black", new DateTime(2020, 3, 29, 20, 24, 27, 212, DateTimeKind.Local).AddTicks(1197), "newest case from thermaltake ", "100,30,30", "100,30,30", "aluminium", 25 },
                    { 3, "black", new DateTime(2020, 3, 29, 20, 24, 27, 212, DateTimeKind.Local).AddTicks(1218), "newest case from cougar", "100,30,30", "100,30,30", "aluminium", 10 },
                    { 4, "black", new DateTime(2020, 3, 29, 20, 24, 27, 212, DateTimeKind.Local).AddTicks(1221), "newest case from corsair", "100,30,30", "100,30,30", "aluminium", 28 },
                    { 1, "black", new DateTime(2020, 3, 29, 20, 24, 27, 211, DateTimeKind.Local).AddTicks(9923), "newest case from asus ", "100,30,30", "100,30,30", "aluminium", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BearerHistories_UserId",
                table: "BearerHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpus_PcPartId",
                table: "Cpus",
                column: "PcPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_PcPartId",
                table: "Gpus",
                column: "PcPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PcPartId",
                table: "Images",
                column: "PcPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Memory_PcPartId",
                table: "Memory",
                column: "PcPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoards_PcPartId",
                table: "MotherBoards",
                column: "PcPartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PcPartsId",
                table: "OrderItems",
                column: "PcPartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlatformUserId",
                table: "Orders",
                column: "PlatformUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PcCases_PcPartId",
                table: "PcCases",
                column: "PcPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PcParts_MakerId",
                table: "PcParts",
                column: "MakerId");
        }

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
                name: "BearerHistories");

            migrationBuilder.DropTable(
                name: "Cpus");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MotherBoards");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PcCases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PcParts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Makers");
        }
    }
}
