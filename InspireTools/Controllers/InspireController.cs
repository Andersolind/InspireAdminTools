using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InspireTools.Models;
using InspireTools.Repositories.Interfaces;

namespace InspireTools.Controllers {
    public class InspireController : ApiController {
        private readonly IInspireAdmin _inspireAdmin;

        public InspireController(IInspireAdmin inspire) {
            _inspireAdmin = inspire;
        }

        [HttpPost]
        [ResponseType(typeof(InspireController))]
        [Route("SearchForCoachesInCCInspire")]
        public IHttpActionResult SearchForCoachesInCcInspire(CCInspire data) {
            var getSearchResults = _inspireAdmin.SearchForCoachesInCcInspire(data);
            return Content(HttpStatusCode.OK, new { Data = getSearchResults });

        }
    }
}
