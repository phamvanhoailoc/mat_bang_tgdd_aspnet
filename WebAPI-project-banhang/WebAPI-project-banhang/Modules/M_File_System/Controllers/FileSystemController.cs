using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Attributes;
using WebAPI_project_banhang.Modules.M_File_System.Models;
using WebAPI_project_banhang.Modules.M_File_System.Services;
using WebAPI_project_banhang.Modules.M_File_System.ViewModels;

namespace WebAPI_project_banhang.Modules.M_File_System.Controllers
{
    [ApiController]
    [Route("api/file-system")]
    public class FileSystemController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileSystemController(IFileService fileService)
        {
            _fileService = fileService;
        }

        //https://localhost:44389/api/file-system/upload
        [JwtAuthorize]
        [HttpPost("upload")]
        public async Task<IActionResult> FileUpload([FromForm] FileUploadViewModel body)
        {
            try
            {
                // Lấy userId từ request
                body.UserId = Convert.ToString(HttpContext.Items["UserId"]) ?? "1";

                List<ResFileUpload> fileUploaded = await _fileService.FileUpload(body);
                return Ok(fileUploaded);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        //https://localhost:44389/api/file-system/delete
        [JwtAuthorize("103")]
        [HttpPost("delete")]
        public async Task<IActionResult> FileDelete([FromBody] FileDeleteViewModel body)
        {
            try
            {
                // Lấy userId từ request
                body.UserId = Convert.ToString(HttpContext.Items["UserId"]) ?? "1";

                await _fileService.FileDelete(body);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
