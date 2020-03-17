using System.Threading.Tasks;

namespace MyProject.Core.IRepository
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();

        void SaveChange();
    }
}