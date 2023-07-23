using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace OneOfTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// returnType : default, error
        /// </summary>
        /// <param name="returnType"></param>
        /// <returns></returns>
        [HttpGet("data/{returnType}")]
        public IActionResult GetData([FromRoute] string returnType ="default")
        {

            var data = GetDataByType(returnType);
            

            return Ok(data.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordType"></param>
        /// <returns></returns>
            private OneOf<MyDataModel,ErrorViewModel> GetDataByType(string recordType)
            {

                try
                {
                    if (recordType == "error")
                        throw new Exception("Returning Error View Model");
                    var data = new MyDataModel
                    {
                        Id = 1,
                        Name = "default message"
                    };
                    return data;
                }
                catch (Exception ex)
                {
                    // Handle errors and return ErrorViewModel
                    var errorViewModel = new ErrorViewModel
                    {
                        StatusCode = 500,
                        ErrorMessage = ex.Message
                    };
                    return errorViewModel;

                }

            }
             
        }

        public class MyDataModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }

        public class ErrorViewModel
        {
            public int StatusCode { get; set; }
            public string? ErrorMessage { get; set; }
        }
    

}
