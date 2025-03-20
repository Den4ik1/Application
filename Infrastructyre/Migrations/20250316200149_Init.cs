using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructyre.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JornalExeption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JornalExeption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeName = table.Column<string>(type: "text", nullable: false),
                    NodeName = table.Column<string>(type: "text", nullable: false),
                    ParentNodeId = table.Column<int>(type: "integer", nullable: true),
                    TreeId = table.Column<int>(type: "integer", nullable: false),
                    TreeNodeDataModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeNode_TreeNode_TreeNodeDataModelId",
                        column: x => x.TreeNodeDataModelId,
                        principalTable: "TreeNode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreeNode_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeNode_TreeId",
                table: "TreeNode",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeNode_TreeNodeDataModelId",
                table: "TreeNode",
                column: "TreeNodeDataModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JornalExeption");

            migrationBuilder.DropTable(
                name: "TreeNode");

            migrationBuilder.DropTable(
                name: "Tree");
        }
    }
}
