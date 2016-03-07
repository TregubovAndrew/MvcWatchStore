using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        User GetCurrentUser();
    }
}
