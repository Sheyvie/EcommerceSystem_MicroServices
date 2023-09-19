using AutoMapper;
using TheJitu_Commerce_Orders.Models;
using TheJitu_Commerce_Orders.Models.Dtos;

namespace TheJitu_Commerce_Orders.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<CartHeaderDto ,OrderHeaderDto>()
                .ForMember(dest => dest.OrderTotal, scr => scr.MapFrom (x=>x.CartTotal)).ReverseMap();

            CreateMap<CartDetailsDto ,OrderDetailsDto>()
                .ForMember(dest =>dest.ProductName , scr => scr.MapFrom(x=>x.Product.Name))
            .ForMember(dest => dest.Price, scr => scr.MapFrom(x => x.Product.Price));

            CreateMap<OrderDetailsDto , CartDetailsDto>();
            CreateMap<OrderHeader, OrderHeaderDto>();
            CreateMap<OrderDetails, OrderDetailsDto>();

        }
    }
}
