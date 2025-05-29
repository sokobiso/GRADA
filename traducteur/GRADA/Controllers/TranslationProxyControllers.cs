    using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace TranslationProxy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetHtml([FromQuery] string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL manquante");

            try
            {
                var html = await _httpClient.GetStringAsync(url);
                return Content(html, "text/html");
            }
            catch
            {
                return BadRequest("Erreur lors de la récupération de l’URL.");
            }
        }
    }
}
