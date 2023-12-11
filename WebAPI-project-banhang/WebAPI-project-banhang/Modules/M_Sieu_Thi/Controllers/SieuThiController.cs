using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using System.Collections.Generic;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Services;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Controllers
{
    [ApiController]
    [Route("api/sieuthi")]
    public class SieuThiController : Controller
    {
        public readonly ISieuThiService sieuThiService;

        public SieuThiController(ISieuThiService iSieuThiService)
        {
            sieuThiService = iSieuThiService;
        }


        [HttpPost("get")]
        public async Task<IActionResult> getSieuThi([FromBody] FilterSieuThiViewModel filterSieuThiViewModel)
        {
            try
            {
                GetSieuThiListViewModel sieuthis = await sieuThiService.getListSieuThi(filterSieuThiViewModel);
                return Ok(sieuthis);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getSieuThiById(int id)
        {
            try
            {
                OutputGetSieuThiByIdViewModel sieuthi = await sieuThiService.getSieuThiById(id);
                return Ok(sieuthi);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateSieuThiById([FromBody] InputCapNhatSieuThiViewModel inputCapNhatSieuThiViewModel, int id)
        {
            try
            {
                bool result = await sieuThiService.updateSieuThiById(inputCapNhatSieuThiViewModel, id);
                if (result == false) return BadRequest();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
