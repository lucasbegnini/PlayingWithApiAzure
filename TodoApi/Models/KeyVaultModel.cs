using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TodoApi.Models
{

    public class KeyVaultModel
    {
        const string resourceGroupName = "MojioTestRG";
        const string vaultName = "MojioTestKV";
        const string apiVersion = "2016-10-01";
        const string subscriptionId = "889e6a2d-569d-4786-be1c-6420a51ee9f8";
        const string appId = "a9ce8b9b-86c9-4bc1-8839-3a0dc5b654b5";
        const string uriId = "http://urimojiotest1EncryptApp";
        const string directoryId = "common";
        const string kvToken = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImlCakwxUmNxemhpeTRmcHhJeGRacW9oTTJZayIsImtpZCI6ImlCakwxUmNxemhpeTRmcHhJeGRacW9oTTJZayJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9jNmFlYTkxZS01ZDYzLTQ1NmYtODAwYS0zN2FmYmYzNjZhMTMvIiwiaWF0IjoxNTI2NDMzMDY0LCJuYmYiOjE1MjY0MzMwNjQsImV4cCI6MTUyNjQzNjk2NCwiYWNyIjoiMSIsImFpbyI6IlkyZGdZTEQwVHpBUzI3ZmxXY0VsL1NkQ2I0VGVoMjY1L0hCaXBkUDBtV1paM2lLdlpQTUIiLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwNjAwMDA4QzAxNjQ4NiIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiI3ZjU5YTc3My0yZWFmLTQyOWMtYTA1OS01MGZjNWJiMjhiNDQiLCJhcHBpZGFjciI6IjIiLCJlX2V4cCI6MjYyODAwLCJlbWFpbCI6ImJlZ25pbmkxM0Bob3RtYWlsLmNvbSIsImZhbWlseV9uYW1lIjoiQmVnbmluaSIsImdpdmVuX25hbWUiOiJMdWNhcyIsImdyb3VwcyI6WyJlY2JjYmYyNC05NmZjLTQyNzQtOTMxMy00OWRhZjljNjM1ZDYiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiIyMDEuODYuMzEuMTY5IiwibmFtZSI6Ikx1Y2FzIEJlZ25pbmkiLCJvaWQiOiI1Zjk3MjU1My1kNmRhLTRhMjEtOTM3NS1jODdhZjYzMGFlYzEiLCJwdWlkIjoiMTAwM0JGRkRBQTlCNzhDQyIsInNjcCI6InVzZXJfaW1wZXJzb25hdGlvbiIsInN1YiI6InJ4dTRGWjlIVXRwUTJFTml4aTB1Q3ZhcnR5QnpXbS04bERZbnBGT0huZDQiLCJ0aWQiOiJjNmFlYTkxZS01ZDYzLTQ1NmYtODAwYS0zN2FmYmYzNjZhMTMiLCJ1bmlxdWVfbmFtZSI6ImxpdmUuY29tI2JlZ25pbmkxM0Bob3RtYWlsLmNvbSIsInV0aSI6ImgyNExJMVNlMlVDRXVDRF9BUTRBQUEiLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbIjYyZTkwMzk0LTY5ZjUtNDIzNy05MTkwLTAxMjE3NzE0NWUxMCJdfQ.kZc4pepvkvAGO-WlHilJvEwrnazLGXdXZM6P8zjon5M05nJwUBx61wEByZo-KSUrhrCBGVQxpmtrpkZpXQ5pEB2YngXY2urkYN1bPOwkG3nbMBWszomcy4dh8AbhG6QN6NV1a0-zk8q_utHfLdQxny3qWSoppP3gkSBNRBYLDrbWsX8pawQ3g9qbQttPOi3xNOCm-5yrbeQqwGZtcbb9wxEc7hmYgxda6MIFaLPBItrtIs-K9R0O82MmTk3gBQCXsq7SJUQM0MVya1a1myc53nFfgE030LfRW9R9rENAeBD39ohm9xg2u6bwt4wId-cvSupyFgSZB12zbQfkwye77g";

        public async Task<string> GetKeyVaultInfo()
        {
             string url = "https://management.azure.com/subscriptions/" + subscriptionId + 
                "/resourceGroups/" + resourceGroupName + 
                "/providers/Microsoft.KeyVault/vaults/" + vaultName + 
                "?api-version="+apiVersion;
           
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", kvToken);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        // TODO : IMPLEMENT SCREEN TO CONNECT WITH USER ACCOUNT
        public async Task<string> GetOAuthToken()
        {
            string url = "https://login.microsoftonline.com/"+ directoryId + "/oauth2/authorize?" +
                    "client_id = " + appId +
                    "& response_type = code" +
                    "& response_mode = query" +
                    "& resource = " + uriId +
                    "& state = 12345";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = response.Headers.GetValues("Location").First();

            return responseBody;

        }
    }
}
