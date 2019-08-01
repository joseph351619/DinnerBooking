using Microsoft.EntityFrameworkCore.Migrations;

namespace DinnerBooking.Core.Data.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "是日精選" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "廚師推介" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "特價推廣" });

            migrationBuilder.InsertData(
                table: "Cuisine",
                columns: new[] { "Id", "CategoryId", "Count", "Detail", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 5, "巴西豬扒配泰式香料。", "泰式豬扒煲", 43 },
                    { 2, 1, 6, "肉質鮮嫩，入口即溶。", "一口和牛", 35 },
                    { 3, 1, 7, "咬落爽脆，充滿蛋香。", "惹味煎蛋餅", 28 },
                    { 4, 1, 7, "和式風味，簡單精緻。", "日式便當", 33 },
                    { 5, 2, 8, "素食人士必選。", "純素沙律", 45 },
                    { 6, 2, 9, "邊辣邊爽。", "辣炒翠肉瓜", 38 },
                    { 7, 3, 10, "每日限量。", "出爐麵包", 50 },
                    { 8, 3, 20, "別有一番風味。", "米紙壽司卷", 48 },
                    { 9, 3, 30, "茶記味道，不輸老麥。", "港式漢堡包", 52 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cuisine",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
