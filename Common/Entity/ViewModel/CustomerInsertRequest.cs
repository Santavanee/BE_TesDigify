using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity.ViewModel
{
    public class CustomerInsertRequest
    {
        public IFormFile FileNPWP { get; set; }
        public IFormFile FilePowerOfAttorey { get; set; }
        public string JsonData { get; set; }
    }
}
