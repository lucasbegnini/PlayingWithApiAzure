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
    [Route("api/KeyVault")]
    public class KeyVaultController : Controller
    {
        // /api/todo - GET - All elements
        [HttpGet]
        public string GetToken()
        {
            KeyVaultModel kv = new KeyVaultModel();
            Task<string> task = Task.Run(async () =>
            {
                return await kv.GetKeyVaultInfo();
            });
            return task.Result;
        }
    }
}