using TheJitu_CommerceFE.Models;
using JituCommerceFE.Models.Authorization;
using JituCommerceFE.Models;

namespace JituCommerceFE.Services.Authorization
{
    public interface IAuthInterface
    {
        Task<ResponseDto> Register(RegisterRequestDto registerRequestDto);
        Task<LoginResponseDto>Login(LoginRequestDto loginRequestDto);
    }
}
