using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Model
{
    public class UserInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id
        {
            get; set;
        }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName
        {
            get; set;
        }

        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get; set;
        }

        [JsonProperty(PropertyName = "gender")]
        public string Gender
        {
            get; set;
        }

        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress
        {
            get; set;
        }
    }

    public class UserInfoList
    {
        public List<UserInfo> records { get; set; }
    }
}
