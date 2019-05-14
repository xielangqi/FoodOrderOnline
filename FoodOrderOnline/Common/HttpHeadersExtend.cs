using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderOnline.Common
{
    public class HttpHeadersExtend
    {
        private IHttpContextAccessor accessor;
        public HttpHeadersExtend(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }

        public string GetString(string key)
        {

            var dic = accessor.HttpContext.Request.Headers;

            if (dic.ContainsKey(key))
            {
                return dic[key];
            }

            return null;
        }

        public string GetAuth()
        {
            var token = GetString("Authorization");
            token = token.Substring(7, token.Length - 7);
            var retString = token.Split('.');
            return Base64UrlEncoder.Decode(retString[1]);
        }

        public int GetUserId()
        {
            var headerDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(GetAuth());
            return Convert.ToInt32(headerDic["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]);
        }
        //TODO
        public int GetTeamId()
        {
            var headerDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(GetAuth());
            return Convert.ToInt32(headerDic["TeamId"]);
        }
    }
}
