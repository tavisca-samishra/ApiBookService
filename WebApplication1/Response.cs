using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Response
    {
        public List<string> Message { get; set; } = new List<string>();
        public Book Book { get; set; }
        public int Status { get; set; } = 200;
    }
}
