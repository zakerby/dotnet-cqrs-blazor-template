namespace Core.Backend.Infrastructure.Postgres.Sql.Project
{
    public class CreateProject
    {
        public const string Value = @"INSERT INTO projects (name) VALUES (@Name);";
    }
}