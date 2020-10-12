// ======================================================================
//   
//           Copyright (C) 2019-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : TokenManager.cs
//           description :
//   
//           created by 雪雁 at  2019-03-13 10:03
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NeoSmart.AsyncLock;

namespace Magicodes.Dingtalk.SDK.Token
{
    public class TokenManager
    {
        private const    string                Key = "DingtalkAccessToken";
        private readonly IDistributedCache     _cache;
        private readonly ILogger<TokenManager> _logger;
        private readonly TokenApi              _tokenApi;
        private static   AsyncLock _lock = new AsyncLock();

        public TokenManager(
            IDistributedCache     cache, TokenApi tokenApi,
            ILogger<TokenManager> logger) {
            _cache    = cache;
            _tokenApi = tokenApi;
            _logger   = logger;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetToken() {
            using (await _lock.LockAsync()) {
                var value = await _cache.GetStringAsync(Key);
                if (!string.IsNullOrEmpty(value)) return value;
                var result = await _tokenApi.GetToken();
                value = result.AccessToken;
                _logger.LogDebug("Token获取成功...");
                var distributedCacheEntryOptions =
                    new DistributedCacheEntryOptions().SetSlidingExpiration(
                        TimeSpan.FromSeconds(7000));
                await _cache.SetStringAsync(Key, value, distributedCacheEntryOptions);
                _logger.LogDebug("Token已写入缓存...");
                return value;
            }
        }
    }
}