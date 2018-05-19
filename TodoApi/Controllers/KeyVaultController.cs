using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using TodoApi.Models;
using static TodoApi.Models.KeyVaultModel;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/keyvault")]
    public class KeyVaultController : Controller
    {
        // /api/KeyVault/{secretName} - GET - return a secret that is register with secret Name
        [HttpGet("{secretName}", Name = "GetSecret")]
        public string GetToken(string secretName)
        {
            KeyVaultModel kv = new KeyVaultModel();
            Task<string> task = Task.Run(async () =>
            {
                return await kv.GetSecret(secretName);
            });
            return task.Result;
        }

        // /api/KeyVault - POST - create new secret
        [HttpPost()]
        public string CreateSecret([FromBody] MyKeySecrets item)
        {
            KeyVaultModel kv = new KeyVaultModel();
            Task task = Task.Run(() =>
            {
                kv.SetSecret(item.SecretName, item.SecretContent);
            });

            return "{ \"status\": \"OK\" }";
        }

        // /api/KeyVault - PUT - update secret
        [HttpPut()]
        public string UpdateSecret([FromBody] MyKeySecrets item)
        {
            KeyVaultModel kv = new KeyVaultModel();
            Task task = Task.Run(() =>
            {
                kv.UpdateSecret(item.SecretName, item.SecretContent);
            });

            return "{ \"status\": \"OK\" }";
        }
    }
}