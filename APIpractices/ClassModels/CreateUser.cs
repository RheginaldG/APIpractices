using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Practice.ClassModels
{
    public partial class CreateUser
    {
        [JsonProperty("User Name")]
        public string name { get; set; }
        [JsonProperty("Job")]
        public string job { get; set; }
    }
}
