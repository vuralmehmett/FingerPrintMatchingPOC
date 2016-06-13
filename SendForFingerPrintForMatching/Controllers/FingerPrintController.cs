using System.Web.Http;
using SendForFingerPrintForMatching.Business.Business;
using SendForFingerPrintForMatching.Models;

namespace SendForFingerPrintForMatching.Controllers
{
    public class FingerPrintController : ApiController
    {
        [HttpPost]
        public IHttpActionResult MatchFingerPrint(FingerPrintRequest request)
        {
            MatchFunction matchFunction = new MatchFunction();
            var similartyRate = matchFunction.Matching(request.ImagePath);
            return Ok("Similarty Rate is : " + " " + "%" + similartyRate);
        }

        [HttpGet]
        public IHttpActionResult Test()
        {
            MatchFunction matchFunction = new MatchFunction();
            //var similartyRate = matchFunction.Matching(@"D:\Projects\FingerprintRecognition_v2.2\Fingerprint_Database\FVC2000\DB1_B\101_2.tif");
            //var similartyRate = matchFunction.Matching(request.ImagePath);
            return Ok("Similarty Rate is : " + " " + "%" );
        }

       
    }
}
