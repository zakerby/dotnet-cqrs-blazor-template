namespace Core.Backend.Infrastructure.Postgres.Sql
{
    public class UpdateExampleNameById
    {
        public const string Value = @"UPDATE Example SET Name = @Name WHERE Id = @Id; SELECT @@ROWCOUNT;";
    }
}