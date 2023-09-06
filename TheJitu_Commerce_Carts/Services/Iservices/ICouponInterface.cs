using TheJitu_Commerce_Cart.Models.Dtos;

namespace TheJitu_Commerce_Cart.Services.Iservices
{
    public interface ICouponInterface
    {
        Task<CouponDto> GetCouponData(string CouponCode);

    }
}
