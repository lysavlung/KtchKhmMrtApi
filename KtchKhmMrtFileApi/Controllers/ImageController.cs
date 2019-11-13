using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KtchKhmMrtFileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        // Retrieve google image file path by fileId
        // api/image
        [HttpGet("{fileId}")]
        public ActionResult<string> GetGoogleImage(string fileId)
        {
            string apiKey = Properties.Resources.gdrive_api_key;
            string baseUrl = Properties.Resources.gdrive_base_url;
            string filePath = string.Format(baseUrl, fileId, apiKey);

            return filePath;
        }
    }
}