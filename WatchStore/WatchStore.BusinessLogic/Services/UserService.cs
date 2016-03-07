using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Services
{
    public class UserService :IUserService
    {
        private readonly IRequestContext _requestContext;

        public UserService(IRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public User GetCurrentUser()
        {
            return _requestContext.User;
        }
    }
}
