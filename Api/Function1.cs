using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api
{
    public class Function1
    {
        private readonly IProductData _productData;

        public Function1(IProductData productData)
        {
            _productData = productData;
        }
        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            var product = await _productData.GetProducts();

            return new OkObjectResult(product);
        }
    }
}
