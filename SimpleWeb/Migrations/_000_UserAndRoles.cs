
using FluentMigrator;

namespace SimpleWeb.Migrations
{
    [Migration(1)]
    public class _000_UserAndRoles : Migration
    {
        public override void Down()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsString(256)
                .WithColumn("password_hash").AsString(128);
        }

        public override void Up()
        {
            Delete.Table("users");
        }
    }
}