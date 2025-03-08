using Core.Backend.Domain.Models;
using System.Threading.Tasks;

namespace Core.Backend.Application.Interfaces
{
    public interface IExampleServiceClient
    {
        Task<Example> GetExampleById(int id);
    }
}