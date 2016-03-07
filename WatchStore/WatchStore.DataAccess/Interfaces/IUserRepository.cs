using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByName(string name);

        User GetById(int id);
    }
}
