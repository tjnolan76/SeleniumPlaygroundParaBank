using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Playground.SharedResources.Helpers
{
    public class JsonHelper
    {
        #region Constructor

        public JsonHelper() 
        {
            //default constructor
        }

        #endregion

        #region Helpers

        public static string ReadSetting(string key)
        {
            string json = System.IO.File.ReadAllText(@"AppSettings.json");
            var data = (JObject)JsonConvert.DeserializeObject(json);
            return data[key].Value<string>();

        }

        #endregion

    }
}
