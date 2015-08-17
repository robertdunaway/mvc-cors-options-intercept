using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Configuration;
using Mashup.Api.Quality.Entities;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Authorization; // added to allow Authorize attribute to work.
// Adding for configuration management.  The Web.Config is gone and now JSON files are used.
using Microsoft.Framework.Configuration;  // was ConfigurationModel but the name was changed.

namespace Mashup.Api.Quality.api.Controllers
{

    [Authorize]
    public class QualityController : Controller
    {
        [Route("api/Quality/CQTSAdHocQuality")]
        [HttpPost]
        public List<CQTSAdHocQualityEntity> GetCQTSAdHocQuality(IConfiguration Configuration, [FromBody]JObject paramsJSON)
        {
            var x = new List<CQTSAdHocQualityEntity>();
            return x;
        }

        [Route("api/Quality/CQTSAdHocTrans")]
        [HttpPost]
        public List<CQTSAdHocTransEntity> GetCQTSAdHocTrans(IConfiguration Configuration, [FromBody]JObject paramsJSON)
        {
            var x = new List<CQTSAdHocTransEntity>();
            return x;
        }

    }
}
