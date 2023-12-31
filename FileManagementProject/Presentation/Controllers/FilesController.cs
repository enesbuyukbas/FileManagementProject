﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            //folder
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            //path
            var path = Path.Combine(folder, file.FileName);

            //stream
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //reponse body
            return Ok(new
            {
                file = file.FileName,
                path = path,
                size = file.Length
            });
        }
    }
}
