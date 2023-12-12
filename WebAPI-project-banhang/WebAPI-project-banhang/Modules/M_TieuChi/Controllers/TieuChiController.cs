using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_TieuChi.Services;
using WebAPI_project_banhang.Modules.M_TieuChi.ViewModels;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Controllers
{
    [ApiController]
    [Route("api/tieuchi")]
    public class TieuChiController : Controller
    {
        public readonly ITieuChiService _iTieuChiService;

        public TieuChiController(ITieuChiService iTieuChiService)
        {
            _iTieuChiService = iTieuChiService;
        }

        [HttpPost("get")]
        public async Task<IActionResult> getTieuChi([FromBody] InputTieuChiViewModel inputTieuChiViewModel)
        {
            try
            {
                OutputTieuChiViewModel tieuchis = await _iTieuChiService.GetListTieuChi(inputTieuChiViewModel);
                return Ok(tieuchis);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
