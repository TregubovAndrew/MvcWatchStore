using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic
{
    public interface IRequestContext
    {
        User User { get; }

        string IPAddress { get; }

        string Session { get; }


    }

    public class RequestContext : IRequestContext
    {
        public User User { get; set; }

        public string IPAddress { get; set; }

        public string Session { get; set; }

    }
}
