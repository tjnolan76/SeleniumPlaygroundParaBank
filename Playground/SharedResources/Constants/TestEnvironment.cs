using AngleSharp.Text;
using Playground.SharedResources.Helpers;

namespace Playground.SharedResources.Constants
{
    public class TestEnvironment
    {
        public static string BaseUrl => JsonHelper.ReadSetting("FQDN");
        public static string DesignatedDriver => JsonHelper.ReadSetting("Browser");
        public static string IsHeadless => JsonHelper.ReadSetting("IsHeadless");
        public static string Timeout => JsonHelper.ReadSetting("Timeout");
    }
}
