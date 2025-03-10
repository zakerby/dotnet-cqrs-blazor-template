using System.Threading.Tasks;

namespace Core.Backend.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<Domain.Models.Project> GetProjectById(int id);

        Task<bool> CreateProject(string projectName);
    }
}