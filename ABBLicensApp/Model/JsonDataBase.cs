
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinyJson;
using Windows.Storage;

namespace ABBLicensApp.Model
{
    static class JsonDataBase
    {
        static private StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        static public async Task<Customer> GetCustomerAsync(string id)
        {
            var file = await localFolder.GetFileAsync(id + ".json");
            string text = await FileIO.ReadTextAsync(file);
            Customer c = JsonConvert.DeserializeObject<Customer>(text);

            return c;
        }

        static public async void SetCustomerAsync(string id, Customer c)
        {
            var file = await localFolder.GetFileAsync(id + ".json");
            await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(c));
        }

    }
}
