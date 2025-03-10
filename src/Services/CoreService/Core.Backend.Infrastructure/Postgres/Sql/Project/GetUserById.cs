namespace Core.Backend.Infrastructure.Postgres.Sql.Project
{
    public class GetProjectById
    {
        public const string Value = @"SELECT * FROM projects WHERE Id = @Id;";
    }
}