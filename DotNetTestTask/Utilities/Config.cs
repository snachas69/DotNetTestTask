using Newtonsoft.Json.Linq;

namespace DotNetTestTask.Utilities
{
    public class Config
    {
        public static string BaseUrl => "https://www.saucedemo.com/";
        private static JObject settings = JObject.Parse(File.ReadAllText("Config/WebDriverConfig.json"));

        public static string? Browser => settings["browser"]?.ToString();
    }
}
