using BL;
using Common.Entity;
using Common.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using Newtonsoft.Json;

namespace RestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerBL _bussLogic;
        private readonly ILogger<CustomerController> _logger;
        private readonly IWebHostEnvironment _env;


        public CustomerController(ILogger<CustomerController> logger, IWebHostEnvironment env)
        {
            _bussLogic = new CustomerBL(logger,env);
            _logger = logger;
            _env = env;

        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Insert([FromForm] CustomerInsertRequest request)
        {
            var apiDat = new ClsGlobalAPIResponse();
            try
            {
                var customerViewModel = JsonConvert.DeserializeObject<CustomerVM>(request.JsonData);


                var returnData = _bussLogic.Insert(customerViewModel, request.FileNPWP, request.FilePowerOfAttorey);
                apiDat = ClsGlobalAPIResponse.CreateResult(new ClsGlobalAPIResponse(), true, returnData, string.Empty);
            }
            catch (Exception ex)
            {

                apiDat = ClsGlobalAPIResponse.CreateError(new ClsGlobalAPIResponse(), false, null, ex.Message);
            }
            return Ok(apiDat);
        }
        
    }
}
