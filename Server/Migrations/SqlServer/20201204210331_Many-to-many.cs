﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Tess.Server.Migrations.SqlServer
{
    public partial class Manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionLinks");

            migrationBuilder.CreateTable(
                name: "DeviceGroupTessUser",
                columns: table => new
                {
                    DeviceGroupsID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroupTessUser", x => new { x.DeviceGroupsID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DeviceGroupTessUser_DeviceGroups_DeviceGroupsID",
                        column: x => x.DeviceGroupsID,
                        principalTable: "DeviceGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceGroupTessUser_TessUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "TessUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceGroupTessUser_UsersId",
                table: "DeviceGroupTessUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceGroupTessUser");

            migrationBuilder.CreateTable(
                name: "PermissionLinks",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceGroupID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionLinks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionLinks_DeviceGroups_DeviceGroupID",
                        column: x => x.DeviceGroupID,
                        principalTable: "DeviceGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionLinks_TessUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "TessUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionLinks_DeviceGroupID",
                table: "PermissionLinks",
                column: "DeviceGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionLinks_UserID",
                table: "PermissionLinks",
                column: "UserID");
        }
    }
}
