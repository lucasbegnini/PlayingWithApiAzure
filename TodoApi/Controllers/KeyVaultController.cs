using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/keyvault")]
    public class KeyVaultController : Controller
    {
        // /api/KeyVault - GET - All elements
        [HttpGet]
        public string GetToken()
        {
            KeyVaultModel kv = new KeyVaultModel();
            Task<string> task = Task.Run(async () =>
            {
                return await kv.GetKeyVaultInfo();
            });
            var result = task.Wait(10000);
            return task.Result;
        }
    }
}