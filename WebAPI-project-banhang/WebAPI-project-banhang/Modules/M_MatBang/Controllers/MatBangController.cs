using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
using WebAPI_project_banhang.Modules.M_MatBang.Services;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;

namespace WebAPI_project_banhang.Modules.M_MatBang.Controllers
{
    [ApiController]
    [Route("api/matbang")]
    public class MatBangController : ControllerBase
    {
        private readonly IMatBangService _matBangService;

        public MatBangController(IMatBangService matBangService)
        {
            _matBangService = matBangService;
        }

        //https://localhost:44389/api/matbang/get
        [HttpPost("get")]
        public async Task<IActionResult> GetMatBangList(MatBangInputViewModel matBangInputViewModel)
        {
            try
            {
                MatBangOutputViewModel matbang = await _matBangService.GetMatBangList(matBangInputViewModel);
                return Ok(matbang);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
