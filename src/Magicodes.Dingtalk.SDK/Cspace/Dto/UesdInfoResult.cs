﻿using Newtonsoft.Json;

namespace Magicodes.Dingtalk.SDK.Cspace.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class UesdInfoResult : ApiResultBase
    {
        /// <summary>
        /// 对应空间已使用大小，单位为Bytes
        /// </summary>
        [JsonProperty("used_size")]
        public byte UsedSize { get; set; }
    }
}