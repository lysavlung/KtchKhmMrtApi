using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KtchKhmMrtApi.Entities
{
    public class ProductDisplay
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        private string ProductConfigValue { get; set; }
        public List<Dictionary<string, string>> ProductConfigValues {
            get {
                return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(ProductConfigValue);
            }
        }
    }
}
