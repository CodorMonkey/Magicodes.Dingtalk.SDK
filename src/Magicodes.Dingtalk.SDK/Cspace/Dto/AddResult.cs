using Newtonsoft.Json;

namespace Magicodes.Dingtalk.SDK.Cspace.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class AddResult : ApiResultBase
    {
        /// <summary>
        /// 文件的详细信息
        /// </summary>
        [JsonProperty("dentry")]
        public string Dentry { get; set; }
    }
}