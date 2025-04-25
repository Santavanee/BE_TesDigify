using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity.ViewModel
{
    public class CustomerVM
    {
        public string CompanyName { get; set; }
        public string NPWP { get; set; }
        public string DirectorName { get; set; }
        public string PICName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool AllowAccess {  get; set; }

    }
}
