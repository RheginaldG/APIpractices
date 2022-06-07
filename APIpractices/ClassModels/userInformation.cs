using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Practice.ClassModels
{
 
    public class userInformation
    {
        [JsonProperty("User Name")]
        public string user_name { get; set; }   
        public string job { get; set; }
        public string id { get; set; }
        public string createdAt { get; set; }
    }


}
