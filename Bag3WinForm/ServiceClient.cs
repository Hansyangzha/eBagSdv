using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bag3WinForm
{
 public class ServiceClient
    {
        internal async static Task<List<clsBrand>> GetBrandNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsBrand>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Bag/GetBagBrands/"));
        }

        internal async static Task<List<clsBag>> GetBrandBagsAsync(string b)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsBag>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Bag/GetBrandBags?b=" + b));
        }

        internal async static Task<List<clsOrder>> GetAllOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/Bag/GetAllOrders/"));
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                 HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage); return await lcRespMessage.Content.ReadAsStringAsync(); }
        }

        internal async static Task<string> UpdateBagAsync(clsBag _Bag)
        {
            return await InsertOrUpdateAsync(_Bag, "http://localhost:60064/api/Bag/PutBag", "PUT");
        }

        internal async static Task<string> InsertBagAsync(clsBag _Bag)
        {
            return await InsertOrUpdateAsync(_Bag, "http://localhost:60064/api/Bag/PostBag", "POST");
        }

        internal async static Task<string> InsertBrandAsync(clsBrand prBrand)
        {
            return await InsertOrUpdateAsync(prBrand, "http://localhost:60064/api/Bag/PostBrand", "POST");
        }

        internal async static Task<string> UpdateBrandAsync(clsBrand prBrand)
        {
            return await InsertOrUpdateAsync(prBrand, "http://localhost:60064/api/Bag/PutBrand", "PUT");
        }

        internal async static Task<string> DeleteBagAsync(clsBag prBag)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
            ($"http://localhost:60064/api/Bag/DeleteBag?Name={prBag.bag_name}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }

        }

        internal async static Task<string> DeleteOrderAsync(clsOrder prOrder)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
            ($"http://localhost:60064/api/Bag/DeleteOrder?Name={prOrder.order_id}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }

        }

        internal async static Task<string> DeleteBrandAsync(string prName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
            ($"http://localhost:60064/api/Bag/DeleteBrand?Name={prName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
            throw new NotImplementedException();
        }
    }
}
