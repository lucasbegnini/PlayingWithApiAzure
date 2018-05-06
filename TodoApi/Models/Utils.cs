using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class Utils
    {
        public String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public String DataToJson(TodoItem item)
        {
            TodoContent _content = new TodoContent
            {
                Name = item.Name,
                TimestampUpdate = item.TimestampUpdate,
                Id = item.Id
            };

            return JsonConvert.SerializeObject(_content);
        }
    }
}
