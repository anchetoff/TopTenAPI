using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace TopTenAPI.ApiProperties
{
    public class APIConnection
    {
        string key;
        string protocol;
        string host;
        string method;

        public APIConnection()
        {
        }

        public APIConnection(string key, string protocol, string host)
        {
            this.key = key;
            this.host = host;
            this.protocol = protocol;
        }

        
        public string Host 
        { 
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }
        public string Method 
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
            }
        
        }

        [JsonProperty]
        public string ApiKey 
        { 
            get 
            { 
                return key; 
            }
            set 
            { 
                key = value; 
            } 
        }

        public string Protocol 
        {
            get 
            { 
                return protocol; 
            }
            set
            {
                protocol = value;
            }
        }
        
        public string UrlCall()
        {
            return this.protocol + Host + Method;
        }
    }
}