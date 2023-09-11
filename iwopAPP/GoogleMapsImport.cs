using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections;
using System.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HTML = HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace iwopAPP
{
    public class gmImport
    {        
        public string result = string.Empty;
        public static int dictionarySize;
        public string emailList = string.Empty;

        public async Task Import(string oppName, List<string> webList, string apiKEY)
        {
            dictionarySize = webList.Count;
            foreach (var key in webScrapResults.Keys.ToList())
            {
                webScrapResults[key] = new int[dictionarySize];
            }

            string placeID = await GetPlace(apiKEY, oppName);
            string summary = await GetSummary(apiKEY, placeID, webList);

            string hrefString = string.Empty;
            int[] hrefResults = GetScrapResults("href");
            foreach (int href in hrefResults)
            {
                hrefString = hrefString + "; " + href;
            }

            string srcString = string.Empty;
            int[] srcResults = GetScrapResults("src");
            foreach (int src in srcResults)
            {
                srcString = srcString + "; " + src;
            }

            if (srcResults.Any(value => value > 0) || hrefResults.Any(value => value > 0))
            {
                result = $"{oppName}; {summary} ;{emailList}{hrefString}{srcString}";
            }
            else
            {
                result = $"{oppName}; {summary};{emailList};";
            }
            foreach (var key in webScrapResults.Keys.ToList())
            {
                webScrapResults[key] = new int[dictionarySize+1];
            }
            emailList = string.Empty;
        }

        public bool errorBool = false;

        public async Task<string> GetPlace(string apiKey, string addressToSearch)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={addressToSearch}&key={apiKey}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(responseBody);

                        if (responseBody.Contains("error_message"))
                        {
                            string errormessage = json["error_message"].ToString();
                            MessageBox.Show($"{errormessage}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorBool = true;
                            return null;
                        }

                        // Deserializacja odpowiedzi JSON
                        PlaceResult placeResult = JsonConvert.DeserializeObject<PlaceResult>(responseBody);

                        // Teraz możemy uzyskać dostęp do danych
                        foreach (var result in placeResult.Results)
                        {
                            return result.PlaceId;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error occured by Google Maps API.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return null;
        }

        public async Task<string> GetSummary(string apiKey, string PlaceID, List<string> webList)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://maps.googleapis.com/maps/api/place/details/json?placeid={PlaceID}&key={apiKey}";

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        ResultSummary resultSummary = JsonConvert.DeserializeObject<ResultSummary>(responseBody);
                        if (resultSummary.Result != null)
                        {
                            if (resultSummary.Result.Website != null)
                            {
                                await webscrapp(resultSummary.Result.Website, webList);
                            }
                            return $"{resultSummary.Result.Address}; {resultSummary.Result.PhoneNumber}; {resultSummary.Result.Website}";
                        }
                        else
                        {
                            return "Not found";
                        }
                    }
                    else
                    {
                       Console.WriteLine("Error occured by Google Maps API.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return null;
        }


        public async Task webscrapp(string website, List<string> webList)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(website);

                HTML.HtmlDocument doc = new HTML.HtmlDocument();
                doc.LoadHtml(html);
                int c = 0;
                var linksHref = doc.DocumentNode.SelectNodes("//a[@href]");
                var linksSrc = doc.DocumentNode.SelectNodes("//img[@src]");

                if (linksHref != null)
                {
                    foreach (var link in linksHref)
                    {
                        string href = link.GetAttributeValue("href", "");
                        if (href.Contains("http") || href.Contains("https")) await WebScrapResult(href, "href", webList);
                    }
                }
                if (linksSrc != null)
                {
                    foreach (var link in linksSrc)
                    {
                        string src = link.GetAttributeValue("src", "");
                        if (src.Contains("http") || src.Contains("https")) await WebScrapResult(src, "src", webList);
                    }
                }


                string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b";
                Regex regex = new Regex(emailPattern);

                var mailtoLinks = doc.DocumentNode.SelectNodes("//a[contains(@href, 'mailto:')]");
                if (mailtoLinks != null)
                {
                    foreach (var link in mailtoLinks)
                    {
                        string href = link.GetAttributeValue("href", "");
                        string email = href.Replace("mailto:", "");

                        MatchCollection mailto = regex.Matches(email);
                        foreach (Match match in mailto)
                        {
                            string fvalue = match.Value;
                            emailList = $"{fvalue} {emailList}";
                        }
                    }
                }

                string pageText = doc.DocumentNode.InnerText;
                string scriptText = String.Join(" ", doc.DocumentNode.SelectNodes("//script").Select(s => s.InnerText));

                MatchCollection matches = regex.Matches(pageText + scriptText);

                foreach (Match match in matches)
                {
                    string email = match.Value;
                    emailList = $"{email} {emailList}";
                }
                emailList.TrimEnd();
            }
        }

        private async Task WebScrapResult(string web, string attr, List<string> webList)
        {
            if (webScrapResults.TryGetValue(attr, out int[] results))
            {
                for (int i = 0; i < dictionarySize; i++)
                {
                    if (web.Contains(webList[i].ToString())) results[i]++;
                }
            }
        }

        private Dictionary<string, int[]> webScrapResults = new Dictionary<string, int[]>
        {
            { "href", new int[dictionarySize] },
            { "src", new int[dictionarySize] }
        };

        public int[] GetScrapResults(string attr)
        {
            if (webScrapResults.TryGetValue(attr, out int[] results))
            {
                return results;
            }
            return new int[dictionarySize];
        }

        public class PlaceResult
        {
            public List<ResultPlace> Results { get; set; }
        }

        public class ResultPlace
        {
            [JsonProperty("place_id")]
            public string PlaceId { get; set; }
        }

        public class ResultSummary
        {
            [JsonProperty("result")]
            public PlaceDetails Result { get; set; }
        }
        public class PlaceDetails
        {
            [JsonProperty("formatted_address")]
            public string Address { get; set; }

            [JsonProperty("formatted_phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("website")]
            public string Website { get; set; }
        }
    }
}
