using System.Linq;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WatchStoreDataContext _db;

        public UserRepository(WatchStoreDataContext db)
        {
            _db = db;
        }

        public User GetUserByName(string name)
        {
            var users = _db.Users.Where(u => u.UserName == name).ToList();
            return users.SingleOrDefault(e => e.UserName == name); // case-sensitive
        }

        public User GetById(int id)
        {
            return _db.Users.Single(u => u.Id == id);
        }
    }
}
