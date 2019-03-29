using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GU.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tree_Type",
                columns: table => new
                {
                    Tree_Type_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tree_LV1_IMG = table.Column<string>(nullable: true),
                    Tree_LV2_IMG = table.Column<string>(nullable: true),
                    Tree_LV3_IMG = table.Column<string>(nullable: true),
                    Tree_Type_Name = table.Column<string>(nullable: true),
                    Tree_Type_Description = table.Column<string>(nullable: true),
                    Tree_LV1_DIE = table.Column<string>(nullable: true),
                    Tree_LV2_DIE = table.Column<string>(nullable: true),
                    Tree_LV3_DIE = table.Column<string>(nullable: true),
                    Tree_LV4_DIE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree_Type", x => x.Tree_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role_ID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Wrong_Password_Count = table.Column<int>(nullable: false),
                    Last_Login = table.Column<string>(nullable: true),
                    Last_Update = table.Column<string>(nullable: true),
                    User_Status = table.Column<string>(nullable: true),
                    User_isLock = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "ToDo_Task",
                columns: table => new
                {
                    Task_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Task_Parent_ID = table.Column<int>(nullable: false),
                    User_ID = table.Column<int>(nullable: false),
                    Task_Name = table.Column<string>(nullable: true),
                    Task_Due_Date = table.Column<string>(nullable: true),
                    Task_Due_Time = table.Column<string>(nullable: true),
                    Task_Description = table.Column<string>(nullable: true),
                    Task_isFocus = table.Column<int>(nullable: false),
                    Task_Create_Date = table.Column<string>(nullable: true),
                    Task_Update_Date = table.Column<string>(nullable: true),
                    Task_Status = table.Column<string>(nullable: true),
                    Task_isComplete = table.Column<string>(nullable: true),
                    Task_isFail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo_Task", x => x.Task_ID);
                    table.ForeignKey(
                        name: "FK_ToDo_Task_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Tree_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(nullable: false),
                    Tree_Type_ID = table.Column<int>(nullable: false),
                    Tree_Name = table.Column<string>(nullable: true),
                    Tree_HP = table.Column<int>(nullable: false),
                    Tree_EXP = table.Column<double>(nullable: false),
                    Tree_Level = table.Column<int>(nullable: false),
                    Plant_Date = table.Column<string>(nullable: true),
                    Tree_Description = table.Column<string>(nullable: true),
                    Tree_Status = table.Column<string>(nullable: true),
                    Create_Date = table.Column<string>(nullable: true),
                    Update_Date = table.Column<string>(nullable: true),
                    Tree_isDead = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Tree_ID);
                    table.ForeignKey(
                        name: "FK_Trees_Tree_Type_Tree_Type_ID",
                        column: x => x.Tree_Type_ID,
                        principalTable: "Tree_Type",
                        principalColumn: "Tree_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trees_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_Task_User_ID",
                table: "ToDo_Task",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_Tree_Type_ID",
                table: "Trees",
                column: "Tree_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_User_ID",
                table: "Trees",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo_Task");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Tree_Type");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
