using CoinWatch.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinWatch.Repositories
{
    public class AssetRepository
    {
        private const string _BASEURI = "https://api.kraken.com/0/public/";
        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public static async Task<List<CustomAsset>> GetAssets(List<string> assets)
        {
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string assetstring = "";
                    foreach (var item in assets)
                    {
                        assetstring += item + "USD" + ",";
                    }
                    assetstring = assetstring.Remove(assetstring.Length - 1);
                    string url = $"{_BASEURI}Ticker?pair={assetstring}";
                    string url_v2 = $"{_BASEURI}AssetPairs?pair={assetstring}";

                    string json = await client.GetStringAsync(url);
                    string json_v2 = await client.GetStringAsync(url_v2);
                    if (json != null && json_v2 != null)
                    {
                        List<CustomAsset> assetlist = new List<CustomAsset>();
                        foreach (var item in assets)
                        {
                            JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);
                            JObject fullObject_v2 = JsonConvert.DeserializeObject<JObject>(json_v2);
                            try
                            {
                                JToken data = fullObject.SelectToken("result." + item + "USD");
                                TickerInfo info = data.ToObject<TickerInfo>();

                                JToken data_v2 = fullObject_v2.SelectToken("result." + item + "USD");
                                AssetPair info_v2 = data_v2.ToObject<AssetPair>();

                                CustomAsset asset = new CustomAsset
                                {
                                    TickerName = item,
                                    AssetName = item,
                                    KrakenName = "",
                                    Opening = decimal.Parse(info.o.Replace(".", ",")),
                                    Price = decimal.Parse(info.c[0].Replace(".", ",")),
                                    Volume = decimal.Parse(info.v[1].Replace(".", ",")),
                                    Leverage = info_v2.leverage_buy,
                                    MinOrder = decimal.Parse(info_v2.ordermin.Replace(".", ","))
                                };
                                assetlist.Add(asset);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("Asset Does NOT exist");
                                Debug.WriteLine("error: " + ex);
                            }
                        }

                        return assetlist;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("error: " + ex);
                    throw ex;
                }
            }
        }
    }
}
