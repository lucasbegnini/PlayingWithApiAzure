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
        const string kvToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImlCakwxUmNxemhpeTRmcHhJeGRacW9oTTJZayIsImtpZCI6ImlCakwxUmNxemhpeTRmcHhJeGRacW9oTTJZayJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9jNmFlYTkxZS01ZDYzLTQ1NmYtODAwYS0zN2FmYmYzNjZhMTMvIiwiaWF0IjoxNTI2MzQzNzk4LCJuYmYiOjE1MjYzNDM3OTgsImV4cCI6MTUyNjM0Nzk5NywiYWNyIjoiMSIsImFpbyI6IlkyZGdZTkJTMUhQY28xWHR4Zkx5Y3Yyek9Td1RwOWl6WkgvVHZXUm1kZUZVM3BmdGd1WUEiLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwNjAwMDA4QzAxNjQ4NiIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiJiNjc3YzI5MC1jZjRiLTRhOGUtYTYwZS05MWJhNjUwYTRhYmUiLCJhcHBpZGFjciI6IjIiLCJlX2V4cCI6MjYzMDk5LCJlbWFpbCI6ImJlZ25pbmkxM0Bob3RtYWlsLmNvbSIsImZhbWlseV9uYW1lIjoiQmVnbmluaSIsImdpdmVuX25hbWUiOiJMdWNhcyIsImdyb3VwcyI6WyJlY2JjYmYyNC05NmZjLTQyNzQtOTMxMy00OWRhZjljNjM1ZDYiXSwiaWRwIjoibGl2ZS5jb20iLCJpcGFkZHIiOiIxODcuMTEyLjE4MC4xMDUiLCJuYW1lIjoiTHVjYXMgQmVnbmluaSIsIm9pZCI6IjVmOTcyNTUzLWQ2ZGEtNGEyMS05Mzc1LWM4N2FmNjMwYWVjMSIsInB1aWQiOiIxMDAzQkZGREFBOUI3OENDIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoicnh1NEZaOUhVdHBRMkVOaXhpMHVDdmFydHlCeldtLThsRFlucEZPSG5kNCIsInRpZCI6ImM2YWVhOTFlLTVkNjMtNDU2Zi04MDBhLTM3YWZiZjM2NmExMyIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20jYmVnbmluaTEzQGhvdG1haWwuY29tIiwidXRpIjoiTmxURjVmR01XRXlfWUpxaHhuODZBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIl19.Da4GRySDSnGa4tS8pxC1r5Cr3uVm9SuP-zOCVncxMw3xvCAJKPR4DaQakoBmYySP8N_6bOG6f9KyHOFEmSnlDSLKM9GFhELO9IqFoQKTgryeftRbgU25etuvo6GKE69efi4w2dmb6bOWtHkylcdxwhc6B2elhCg1IbKkSeNjeaKIav_XHAX07kyj1Qa8zhs05dVrUq_nsU47_mHoLeAB18Lb0ZHDfIFqsOO5wnACY7_qaP5gpE9ScWFhhxrcm06-MEteobjE2DSSlI1kHAUPomp82Xv7sCv4Ba_1w97kvWXvtyUiHM9rQZbS9G6QoUAQTahAocd9zXk44UYrJItPgQ";

        public async Task<string> GetKeyVaultInfo()
        {
            string url = "https://management.azure.com/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.KeyVault/vaults/" + vaultName;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", kvToken);
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
