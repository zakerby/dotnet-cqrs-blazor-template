namespace Core.Backend.Infrastructure.Postgres.Sql
{
    public class GetUserById
    {
        public const string Value = @"SELECT * FROM Users WHERE Id = @Id;";
    }
}