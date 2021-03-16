
using System.Configuration;
using TopTenService.Client.Interface;

namespace TopTenService.Client
{
    public class ApiSettingsProvider : IUrlProvider
    {
        public string GetUrl(string controllerName)
        {
            return $"{ConfigurationManager.AppSettings["Covid19APIUrl"]}/{controllerName}";
        }

        public string GetKey(string keyName)
        {
            string value = ConfigurationManager.AppSettings[keyName];
            return value;
        }
    }
}
