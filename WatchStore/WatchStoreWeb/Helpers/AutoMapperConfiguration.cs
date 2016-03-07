using AutoMapper;
using WatchStore.DataAccess.Entities;
using WatchStoreWeb.Models;

namespace WatchStoreWeb.Helpers
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<WatchModel, Watch>();
            //});
            
            Mapper.CreateMap<Watch, WatchModel>();
            Mapper.CreateMap<WatchModel, Watch>();

            Mapper.CreateMap<Order, OrderModel>();
            Mapper.CreateMap<OrderModel, Order>();

            Mapper.CreateMap<RegisterModel, Customer>();


        }
    }
}