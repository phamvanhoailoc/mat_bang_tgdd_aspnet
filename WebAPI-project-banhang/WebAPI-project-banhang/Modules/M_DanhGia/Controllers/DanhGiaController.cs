using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebAPI_project_banhang.Attributes;
using WebAPI_project_banhang.Config.Athor;
using WebAPI_project_banhang.Modules.M_DanhGia.ViewModels;
using WebAPI_project_banhang.Modules.M_DanhGia.Services;

namespace WebAPI_project_banhang.Modules.M_DanhGia.Controllers
{
    [ApiController]
    [Route("api/danhgia")]
    public class DanhGiaController : Controller
    {
        public readonly IDanhGiaService _iDanhGiaService;

        public DanhGiaController(IDanhGiaService iDanhGiaService)
        {
            _iDanhGiaService = iDanhGiaService;
        }

        [JwtAuthorize(Role.SIEUTHI)]
        [HttpPost("get")]
        public async Task<IActionResult> getDanhGia([FromBody] FilterDanhGiaViewModel filterDanhGiaViewModel)
        {
            try
            {
                GetDanhGiaListViewModel danhgias = await _iDanhGiaService.getListDanhGia(filterDanhGiaViewModel);
                return Ok(danhgias);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        
    }
}
