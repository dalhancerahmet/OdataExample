using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace OdataExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdataExampleController : ControllerBase
    {
        private OdataContext _context;

        public OdataExampleController(OdataContext dbContext)
        {
            this._context = dbContext;

        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetOdata()
        {
            var result =_context.Products.AsQueryable();
            return Ok(result);
        }
    }
}
#region Odata Nedir?
// Odata farklı farklı endpointlere ihtiyaç duymadan client tarafından dönen json formatındaki datalara manipülasyon yapmayı sağlayan teknolojidir.
#endregion
#region Odata Configuration
/*
 Program cs üzerinden aşağıdaki gibi configuration yapılır:

 builder.Services.AddControllers()
    .AddJsonOptions(i => i.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
    .AddOData(options =>
    {
        options.EnableQueryFeatures();// Bununla birlikte ODatanın tüm özelliklerini/metotlarını kullanabiliyoruz.
    });
 */
#endregion
/* Odata sayesinde api tarafına aşağıdaki gibi requestler oluşturabiliriz.
 https://localhost:44393/api/OdataExample?select=productName 
 https://localhost:44393/api/OdataExample?filter=productId eq 17
 https://localhost:44393/api/OdataExample?orderby=id desc
 https://localhost:44393/api/OdataExample?filter=id in(17,18)
 https://localhost:44393/api/OdataExample?filter=id eq 17 &select=productName
 */
#region Bazı Odata Endpointleri
 /*
  1- select ==> istediğimiz propertileri seçmemizi sağlar.
  2- filter ==> filtreleme yapmamızı sağlar
  3- orderby==> sıralama yapmamızı sağlar.
  ...
  */
#endregion
