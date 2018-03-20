using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeGuise.Cookies
{
    public class AppCookies : IAppCookies
    {
        public AppCookies(HttpRequestBase request, HttpResponseBase response)
        {
            this._request = request;
            this._response = response;
        }
        private HttpRequestBase _request;
        private HttpResponseBase _response;
        private HttpCookie _cookie;

        public bool ClientAccepts()
        {
            throw new NotImplementedException();
        }
        private void AddValuesToCookie(IDictionary<string, string> keys)
        {
            foreach (var item in keys)
            {
                _cookie.Values[item.Key] = item.Value;
            }
        }
        private void AddAttributesToCookie(bool secure, bool accessibleClientSide, bool cacheInResponseToMultipleClients)
        {
            _cookie.Secure = secure;
            _cookie.HttpOnly = accessibleClientSide;
            _cookie.Shareable = cacheInResponseToMultipleClients;            
        }

        public void Create(string name, IDictionary<string, string> keys, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            _cookie = new HttpCookie(name);
            AddValuesToCookie(keys);
            AddAttributesToCookie(secure, accessibleClientSide, cacheInResponseToMultipleClients);
            _response.Cookies.Add(_cookie);
        }

        public void Create(string name, IDictionary<string, string> keys, Int16 daysTillExpires, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            _cookie = new HttpCookie(name);
            AddValuesToCookie(keys);
            AddAttributesToCookie(secure, accessibleClientSide, cacheInResponseToMultipleClients);
            _cookie.Expires = DateTime.Now.AddDays(daysTillExpires);
            _response.Cookies.Add(_cookie);
        }

        public void Create(string name, IDictionary<string, string> keys, string path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            _cookie = new HttpCookie(name);
            AddValuesToCookie(keys);
            AddAttributesToCookie(secure, accessibleClientSide, cacheInResponseToMultipleClients);
            _cookie.Path = path;
            _response.Cookies.Add(_cookie);
        }

        public void Create(string name, IDictionary<string, string> keys, Int16 daysTillExpires, string path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            _cookie = new HttpCookie(name);
            AddValuesToCookie(keys);
            AddAttributesToCookie(secure, accessibleClientSide, cacheInResponseToMultipleClients);
            _cookie.Expires = DateTime.Now.AddDays(daysTillExpires);
            _cookie.Path = path;
            _response.Cookies.Add(_cookie);
        }

        public void Create(string name, IDictionary<string, string> keys, Int16 daysTillExpires, string path, string domain, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            _cookie = new HttpCookie(name);
            AddValuesToCookie(keys);
            AddAttributesToCookie(secure, accessibleClientSide, cacheInResponseToMultipleClients);
            _cookie.Expires = DateTime.Now.AddDays(daysTillExpires);
            _cookie.Path = path;
            _cookie.Domain = domain;
            _response.Cookies.Add(_cookie);
        }

        public void Delete(string name)
        {
            var cookieName = string.Empty;
            int limit = _request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = _request.Cookies[i].Name;
                _cookie = new HttpCookie(cookieName)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                _response.Cookies.Add(_cookie);
            }
        }

        public Dictionary<string, string> Read(string name)
        {
            var info = new Dictionary<string, string>();
            _cookie = _request.Cookies[name];
            if (_cookie != null)
            {
                System.Collections.Specialized.NameValueCollection props = _cookie.Values;
                foreach (var key in props.AllKeys )
                {
                    info.Add(key, _cookie[key]);
                }
                return info;
            }
            return null;
        }

        public String ReadCookieProperty(string name, string property)
        {
            var cookie = Read(name);
            var propertyValue = cookie.Where(kv => kv.Key.Equals(property)).Select(kv => kv.Value).FirstOrDefault();
            return propertyValue;
        }

        public void Update(string name, IDictionary<string, string> keys, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            this.Create(name, keys, secure, accessibleClientSide, cacheInResponseToMultipleClients);
        }

        public void Update(string name, IDictionary<string, string> keys, Int16 daysTillExpires, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            this.Create(name, keys, daysTillExpires, secure, accessibleClientSide, cacheInResponseToMultipleClients);
        }

        public void Update(string name, IDictionary<string, string> keys, string path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            this.Create(name, keys, path, secure, accessibleClientSide, cacheInResponseToMultipleClients);
        }

        public void Update(string name, IDictionary<string, string> keys, Int16 daysTillExpires, string path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            this.Create(name, keys, daysTillExpires, path, secure, accessibleClientSide, cacheInResponseToMultipleClients);
        }

        public void Update(string name, IDictionary<string, string> keys, Int16 daysTillExpires, string path, string domain, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false)
        {
            this.Create(name, keys, daysTillExpires, path, domain, secure, accessibleClientSide, cacheInResponseToMultipleClients);
        }
    }
}
