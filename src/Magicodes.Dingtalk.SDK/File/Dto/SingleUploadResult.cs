using Newtonsoft.Json;

namespace Magicodes.Dingtalk.SDK.File.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SingleUploadResult : ApiResultBase
    {
        /// <summary>
        /// 文件存储id
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}