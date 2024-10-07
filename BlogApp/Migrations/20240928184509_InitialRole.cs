using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS(Select Id from AspNetRoles where Id = '89eead86-8314-48ce-908b-742d68e27356')
BEGIN
	INSERT AspNetRoles (Id, [Name], [NormalizedName])
	VALUES ('89eead86-8314-48ce-908b-742d68e27356', 'admin', 'ADMIN')
END

");
            migrationBuilder.Sql(@"
IF NOT EXISTS(Select Id from AspNetRoles where Id = 'de12248b-e406-483c-97d1-ab45f7739dbd')
BEGIN
	INSERT AspNetRoles (Id, [Name], [NormalizedName])
	VALUES ('de12248b-e406-483c-97d1-ab45f7739dbd', 'user', 'USER')
END

");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = '89eead86-8314-48ce-908b-742d68e27356'");
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = 'de12248b-e406-483c-97d1-ab45f7739dbd'");

        }
    }
}
