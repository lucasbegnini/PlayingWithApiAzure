using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
        const string clientSecret = "MojioTestClientSecret";
        const string vaultBaseUrl = "https://mojiotestkv.vault.azure.net/";
        const string clientId = "a9ce8b9b-86c9-4bc1-8839-3a0dc5b654b5";

        public class MyKeySecrets
        {
            public string SecretName { get; set; }
            public string SecretContent { get; set; }

        }

        //the method that will be provided to the KeyVaultClient
        public async Task<string> GetSecret(string secretId)
        {
            KeyVaultClient kvClient = AuthUsingADALCallback(vaultBaseUrl);
            SecretBundle s = await kvClient.GetSecretAsync(vaultBaseUrl, secretId);
            return s.Value;
        }

        public void SetSecret(string secretId, string secret)
        {
            KeyVaultClient kvClient = AuthUsingADALCallback(vaultBaseUrl);
            Task task = Task.Run(async () =>
            {
                await kvClient.SetSecretAsync(vaultBaseUrl, secretId, secret);
            });
        }

        public void UpdateSecret(string secretId, string secret)
        {
            KeyVaultClient kvClient = AuthUsingADALCallback(vaultBaseUrl);
            Task task = Task.Run(async () =>
            {
                await kvClient.UpdateSecretAsync(vaultBaseUrl, secretId, secret);
            });
        }

        private KeyVaultClient AuthUsingADALCallback(string vaultBaseURL)
        {
            // Set up a KV Client with an ADAL authentication callback function
            KeyVaultClient kvClient = new KeyVaultClient(
                async (string authority, string resource, string scope) =>
                {
                    var authContext = new AuthenticationContext(authority);
                    ClientCredential clientCred = new ClientCredential(clientId, clientSecret);
                    AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
                    if (result == null)
                    {
                        throw new InvalidOperationException("Failed to retrieve access token for Key Vault");
                    }

                    return result.AccessToken;
                }
            );

            return kvClient;
        }
    }
}
