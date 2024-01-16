using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Джоан", "Роулинг" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Анджей", "Сапковский" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, "Стивен", "Кинг" },
                    { 4, "Маргарет", "Митчелл" },
                    { 5, "Дэн", "Браун" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Borrowed", "Description", "DueDate", "GenreId", "Isbn", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "Третья книга из серии о приключениях юного волшебника Гарри Поттера, который узнает что их тюрьмы сбежал опасный преступник Сириус Блэк, якобы замышляющий убить Гарри", null, 1, "978-5-389-17021-6", "Гарри Поттер и узник Азкабана" },
                    { 2, 2, null, "Первая книга из цикла «Ведьмак» о приключениях профессионального охотника за чудовищами Геральта из Ривии, который путешествует по миру, полному магии и опасностей, и выполняет различные заказы", null, 1, "978-5-17-120969-2", "Последнее желание" }
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Фэнтези — это фантастический жанр, который использует мифологические и фольклорные, а также сказочные мотивы в повествовании. В фэнтези часто создаются вымышленные миры, населенные необычными существами и героями, обладающими магическими способностями. Фэнтези может быть основано на разных мифологиях и культурах, а также иметь разные поджанры, такие как эпическое фэнтези, героическое фэнтези, городское фэнтези и т.д.", "Фэнтези" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Детектив — это жанр литературы, в котором главным элементом является расследование преступления, загадки или тайны. В детективе обычно присутствуют следующие персонажи: детектив, который пытается разгадать преступление, подозреваемый, который может быть виновным или невиновным, жертва, которая пострадала от преступления, и свидетели, которые могут дать полезную информацию. Детектив может иметь разные поджанры, такие как классический детектив, иронический детектив, полицейский детектив и т.д.", "Детектив" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Исторический роман — это жанр литературы, в котором действие происходит в определенный исторический период или эпоху. В историческом романе автор стремится воссоздать атмосферу и детали того времени, а также показать взаимодействие вымышленных и реальных исторических персонажей. Исторический роман может быть основан на реальных событиях или выдуманных, а также иметь разные поджанры, такие как приключенческий исторический роман, военный исторический роман, романтический исторический роман и т.д.", "Исторический роман" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Borrowed", "Description", "DueDate", "GenreId", "Isbn", "Title" },
                values: new object[,]
                {
                    { 3, 3, null, "Роман, действие которого происходит в тюремном блоке смертников, где надзиратель Пол Эджкомб сталкивается с необычным заключенным Джоном Коффи, обладающим сверхъестественными способностями", null, 2, "978-5-17-085348-9", "Зеленая миля" },
                    { 4, 4, null, "Эпическая история любви и ненависти, страсти и гордости, жизни и смерти на фоне Гражданской войны в США, в центре которой находится красавица и своенравная Скарлетт О’Хара и ее отношения с харизматичным Реттом Батлером", null, 3, "978-5-389-17583-9", "Унесенные ветром" },
                    { 5, 5, null, "Знаменитый роман о тайне, которая скрывается в произведениях Леонардо да Винчи, и о загадочном ордене, который охраняет ее. Главные герои - профессор символогии Роберт Лэнгдон и криптограф Софи Невё - пытаются разгадать код, который может изменить мировую историю", null, 2, "978-5-17-121367-5", "Код да Винчи" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Isbn",
                table: "Books",
                column: "Isbn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Isbn",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "FirstName1", "LastName1" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "FirstName2", "LastName2" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description 1", "Genre1" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description 2", "Genre2" });
        }
    }
}
