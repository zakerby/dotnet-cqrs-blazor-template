using AutoMapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Npgsql;
using Dapper;


using Core.Backend.Application.Interfaces;
using Core.Backend.Application.Models;



namespace Core.Backend.Infrastructure.Postgres
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IOptions<EnvironmentConfiguration> _configuration;
        private readonly IMapper _mapper;

        public ProjectRepository(IMapper mapper, IOptions<EnvironmentConfiguration> configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Domain.Models.Project> GetProjectById(int id)
        {
            var query = Sql.Project.GetProjectById.Value;

            using (var conn = new NpgsqlConnection(this._configuration.Value.POSTGRES_CONNECTION_STRING))
            {
                conn.Open();

                var project = await conn.QueryFirstAsync<Domain.Models.Project>(query, new { Id = id });

                return project;
            }
        }
    }
}