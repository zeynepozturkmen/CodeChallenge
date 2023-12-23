using CodeChallenge.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly IDrawService _drawService;

        public DrawController(IDrawService drawService)
        {
            _drawService = drawService;
        }

        [HttpGet]
        public async  Task<IActionResult> DrawGroups(int groupCount, string drawerName)
        {
            if (groupCount != 4 && groupCount != 8)
            {
                return BadRequest("Grup sayısı 4 veya 8 olmalıdır.");
            }

            var groups =await _drawService.DrawGroups(groupCount, drawerName);

            return Ok(new { groups });
        }
    }
}
