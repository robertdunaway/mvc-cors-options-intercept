using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization; // added to allow Authorize attribute to work.


namespace Mashup.Api.Quality.api
{
    [Authorize]
    public class HeartBeatController : Controller
    {

        [Route("api/HeartBeat/")]
        [HttpGet]
        public bool HeartBeat()
        {
            // Later, add server performance metrics allowing the client
            // to decide if you want to trouble the server with information.

            // Can also return false if the WebApi server doesn't have enough
            // resources to satisfy the client.  This will cause the client
            // dip into it's cache.

            return true;
        }
    }
}
