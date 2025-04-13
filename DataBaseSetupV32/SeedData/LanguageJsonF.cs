using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSetupV3
{
    public class LanguageJsonF
    {
        [JsonProperty("KeyName")]
        public string KeyName { get; set; }

        [JsonProperty("KeyType")]
        public string KeyType { get; set; }

        [JsonProperty("zh_CN")]
        public string ZhCn { get; set; }

        [JsonProperty("zh_HK")]
        public string ZhHk { get; set; }

        [JsonProperty("en_US")]
        public string EnUs { get; set; }

        [JsonProperty("IndustryIdArr")]
        public string IndustryIdArr { get; set; }

        [JsonProperty("MainComIdArr")]
        public string MainComIdArr { get; set; }

        [JsonProperty("Remark")]
        public string Remark { get; set; }
    }
}
