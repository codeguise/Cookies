using System;
using System.Collections.Generic;

namespace CodeGuise.Cookies
{
    public interface IAppCookies
    {
        
        void Create(String name, IDictionary<string, string> keys, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Create(String name, IDictionary<string, string> keys, Int16 daysTillExpires, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Create(String name, IDictionary<string, string> keys, String path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Create(String name, IDictionary<string, string> keys, Int16 daysTillExpires, String path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Create(String name, IDictionary<string, string> keys, Int16 daysTillExpires, String path, String domain, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);


        Dictionary<string, string> Read(String name) ;

        void Update(String name, IDictionary<string, string> keys, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Update(String name, IDictionary<string, string> keys, Int16 daysTillExpires, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Update(String name, IDictionary<string, string> keys, String path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Update(String name, IDictionary<string, string> keys, Int16 daysTillExpires, String path, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);
        void Update(String name, IDictionary<string, string> keys, Int16 daysTillExpires, String path, String domain, bool secure = false, bool accessibleClientSide = false, bool cacheInResponseToMultipleClients = false);

        void Delete(String name);

        bool ClientAccepts() ;
    }
}
