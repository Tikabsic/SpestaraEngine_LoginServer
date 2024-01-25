using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseIntegration.Migrations
{
    /// <inheritdoc />
    public partial class Changes_v001v : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCharacters_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterTransforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionX = table.Column<float>(type: "real", nullable: false),
                    PositionY = table.Column<float>(type: "real", nullable: false),
                    PositionZ = table.Column<float>(type: "real", nullable: false),
                    RotationX = table.Column<float>(type: "real", nullable: false),
                    RotationY = table.Column<float>(type: "real", nullable: false),
                    RotationZ = table.Column<float>(type: "real", nullable: false),
                    RotationW = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterTransforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCharacterTransforms_GameCharacters_GameCharacterId",
                        column: x => x.GameCharacterId,
                        principalTable: "GameCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObtainableItems",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    ItemIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObtainableItems", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_ObtainableItems_GameCharacters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "GameCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersSkills",
                columns: table => new
                {
                    GameCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersSkills", x => x.GameCharacterId);
                    table.ForeignKey(
                        name: "FK_PlayersSkills_GameCharacters_GameCharacterId",
                        column: x => x.GameCharacterId,
                        principalTable: "GameCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersStats",
                columns: table => new
                {
                    GameCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxHp = table.Column<int>(type: "int", nullable: false),
                    CurrentHp = table.Column<int>(type: "int", nullable: false),
                    MaxMana = table.Column<int>(type: "int", nullable: false),
                    CurrentMana = table.Column<int>(type: "int", nullable: false),
                    MaxStamina = table.Column<int>(type: "int", nullable: false),
                    CurrentStamina = table.Column<int>(type: "int", nullable: false),
                    CharacterLevelExperiencePoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStats", x => x.GameCharacterId);
                    table.ForeignKey(
                        name: "FK_PlayersStats_GameCharacters_GameCharacterId",
                        column: x => x.GameCharacterId,
                        principalTable: "GameCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id",
                table: "Accounts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_AccountId",
                table: "GameCharacters",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_Id",
                table: "GameCharacters",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacters_Nickname",
                table: "GameCharacters",
                column: "Nickname",
                unique: true,
                filter: "[Nickname] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GameCharacterTransforms_GameCharacterId",
                table: "GameCharacterTransforms",
                column: "GameCharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObtainableItems_ItemId",
                table: "ObtainableItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersSkills_GameCharacterId",
                table: "PlayersSkills",
                column: "GameCharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStats_GameCharacterId",
                table: "PlayersStats",
                column: "GameCharacterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCharacterTransforms");

            migrationBuilder.DropTable(
                name: "ObtainableItems");

            migrationBuilder.DropTable(
                name: "PlayersSkills");

            migrationBuilder.DropTable(
                name: "PlayersStats");

            migrationBuilder.DropTable(
                name: "GameCharacters");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
