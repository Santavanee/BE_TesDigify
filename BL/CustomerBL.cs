using Common.Entity.Entity;
using Common.Entity.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RestAPI;


namespace BL
{
    public class CustomerBL
    {
        private readonly ILogger _Logger;
        private readonly IWebHostEnvironment _env;

        public CustomerBL(ILogger logger, IWebHostEnvironment env)
        {
            _Logger = logger;
            _env = env;
        }      
        public Customer Insert(CustomerVM customerVM, IFormFile FileNPWP, IFormFile FilePowerOfAttorey)
        {

            TesDigifyContext db = new TesDigifyContext();
            var trans = db.Database.BeginTransaction();

            var result = new Customer();
            try
            {
                InsertValidation(customerVM, FileNPWP, FilePowerOfAttorey);
                result = Insert(db, customerVM, FileNPWP, FilePowerOfAttorey);
                trans.Commit();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                db.SaveChanges();
                db.Dispose();
            }
            return result;
        }
        public Customer Insert(TesDigifyContext db, CustomerVM customerVM, IFormFile FileNPWP, IFormFile FilePowerOfAttorey)
        {
            string uploadsFolder = Path.Combine(_env.ContentRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string npwpPath = string.Empty;
            string powerPath = string.Empty;

     
            npwpPath = Path.Combine(uploadsFolder, Guid.NewGuid().ToString() + "_" + FileNPWP.FileName);
            //NPWP
            using (var stream = new FileStream(npwpPath, FileMode.Create))
            {
                FileNPWP.CopyTo(stream);
            }
            //FilePowerOfAttorey
            powerPath = Path.Combine(uploadsFolder, Guid.NewGuid().ToString() + "_" + FilePowerOfAttorey.FileName);
            using (var stream = new FileStream(powerPath, FileMode.Create))
            {
                FilePowerOfAttorey.CopyTo(stream);
            }

            Customer newCustomer = new Customer()
            {
                DirectorName = customerVM.DirectorName,
                CompanyName = customerVM.CompanyName,
                Email = customerVM.Email,
                Npwp = customerVM.NPWP,
                PhoneNumber = customerVM.PhoneNumber,
                Picname = customerVM.PICName,
                AllowAccess = customerVM.AllowAccess,
                FileNpwp = npwpPath,
                FilePowerOfAttorey = powerPath
            };

            db.Customers.Add(newCustomer);
            db.SaveChanges();

            return newCustomer;
        }
        public void InsertValidation(CustomerVM customerVM, IFormFile FileNPWP, IFormFile FilePowerOfAttorey)
        {
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(customerVM.CompanyName))
            {
                errorMessage += " Company Name must be filled,";
            }
            if (string.IsNullOrEmpty(customerVM.NPWP))
            {
                errorMessage += " NPWP must be filled,";
            }
            if (string.IsNullOrEmpty(customerVM.DirectorName))
            {
                errorMessage += " Director Name must be filled,";
            }
            if (string.IsNullOrEmpty(customerVM.PICName))
            {
                errorMessage += " PIC Name must be filled,";
            }
            if (string.IsNullOrEmpty(customerVM.Email))
            {
                errorMessage += " Email must be filled,";
            }
            if (string.IsNullOrEmpty(customerVM.PhoneNumber))
            {
                errorMessage += " Phone Number must be filled,";
            }
          
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage.Substring(0, errorMessage.Length - 1));
            }
        }
      
    }
}
