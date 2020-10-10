using Newtonsoft.Json;

namespace Magicodes.Dingtalk.SDK.Role.Dto
{
    /// <summary>
    /// 创建角色组返回结果
    /// </summary>
    public class CreateRoleGroupResult : ApiResultBase
    {
        /// <summary>
        /// 角色组id
        /// </summary>
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
    }
}