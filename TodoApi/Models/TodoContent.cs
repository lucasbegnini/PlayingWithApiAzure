using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoContent
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TimestampUpdate { get; set; }
    }
}
