using AutoMapper;
using TheJitu_Commerce_Cart.Models.Dtos;
using TheJitu_Commerce_Cart.Models;

namespace TheJitu_Commerce_Cart.Profiles
{
    public class CartProfiles: Profile
    {

        public CartProfiles() 
        { 
             CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
        }
    }
}
 