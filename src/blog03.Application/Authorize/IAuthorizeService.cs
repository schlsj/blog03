using blog03.ToolKits.Base;
using System.Threading.Tasks;

namespace blog03.Authorize
{
    public interface IAuthorizeService
    {
        Task<ServiceResult<string>> GetLoginAddressAsync();
        Task<ServiceResult<string>> GetAccessTokenAsync(string code);
        Task<ServiceResult<string>> GenerateTokenAsync(string access_token);
    }
}
