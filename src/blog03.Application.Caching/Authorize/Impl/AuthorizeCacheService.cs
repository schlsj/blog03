using blog03.ToolKits.Base;
using blog03.ToolKits.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03.Application.Caching.Authorize.Impl
{
    public class AuthorizeCacheService : CachingServiceBase, IAuthorizeCacheService
    {
        private const string KEY_GetLoginAddress = "Authorize:GetLoginAddress";
        private const string KEY_GetAccessToken = "Authorize:GetAccessToken-{0}";
        private const string KEY_GenerateToken = "Authorize:GenerateToken-{0}";

        public async Task<ServiceResult<string>> GenerateTokenAsync(string access_token, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GenerateToken.FormatWith(access_token), factory, CacheStrategy.ONE_HOURS);
        }

        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetAccessToken.FormatWith(code), factory, CacheStrategy.FIVE_MINUTES);
        }

        public async Task<ServiceResult<string>> GetLoginAddressAsync(Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetLoginAddress, factory, CacheStrategy.NEVER);
        }
    }
}
