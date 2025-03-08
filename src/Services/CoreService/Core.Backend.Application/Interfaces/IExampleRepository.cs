using System.Threading.Tasks;

namespace Core.Backend.Application.Interfaces
{
    public interface IExampleRepository
    {
        Task<int> UpdateExampleNameById(int id, string name);
    }
}