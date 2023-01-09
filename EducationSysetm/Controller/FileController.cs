using AutoMapper;
using Core.Entity;
using Core.IRepository;
using EducationSysetm.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private List<string> _allowedImagesExtenstions = new List<string> { ".jpg", ".png" };
        private List<string> _allowedFilesExtenstions = new List<string> { ".pdf" };
        private long _maxAllowedPosterSize = 1048576;
        string path = "";
        public FileController(IUnitOfWork uow, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _uow = uow;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        [HttpPost("AddFile {userName}")]
        public async Task<IActionResult> AddFileByUserAsync(string userName, [FromForm] AddFileDto addFileDto)
        {

            var user = await _uow.ApplicationUsers.GetAsync(x => x.UserName == userName);
            if (user == null)
            {
                return NotFound("it's not found in the database");

            }

            user.Files = new List<Core.Entity.File>();
            for (int i = 0; i < addFileDto.FilePath.Count; i++)
            {

                if (_allowedImagesExtenstions.Contains(Path.GetExtension(addFileDto.FilePath[i].FileName).ToLower()))
                {
                    path = Path.Combine(_webHostEnvironment.WebRootPath, "Images", addFileDto.FilePath[i].FileName);

                }

                if (_allowedFilesExtenstions.Contains(Path.GetExtension(addFileDto.FilePath[i].FileName).ToLower()))
                {
                    path = Path.Combine(_webHostEnvironment.WebRootPath, "Files", addFileDto.FilePath[i].FileName);

                }
                if (addFileDto.FilePath[i].Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");

                var file = _mapper.Map<Core.Entity.File>(addFileDto);

                var fileName = addFileDto.FilePath[i].FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await addFileDto.FilePath[i].CopyToAsync(stream);

                }

                file.FilePath = path;
                file.FileName = fileName;
                file.InsertOn = DateTime.Now;
                var addFile = await _uow.Files.AddAsync(file);
                user.Files.Add(addFile);
            }

            _uow.ApplicationUsers.Update(user);
            await _uow.Save();
            return Ok("Success");


        }

        [HttpDelete("{userName}/DeleteFile{id}")]
        public async Task<IActionResult> DeleteFileAsync(string userName, int id)
        {
            var file = await _uow.Files.GetAsync(x => x.User.UserName == userName);
            if (file == null)
            {
                return NotFound("it's not found in the database");

            }
            var fileId = file.Id;
            System.IO.File.Delete(file.FilePath);
            await _uow.Files.Delete(fileId);
            await _uow.Save();
            return NoContent();
        }

        [HttpGet("{userName}/GetFile{id}")]
        public async Task<IActionResult> GetFileAsync(string userName, int id)
        {
            var file = await _uow.Files.GetAsync(x => x.User.UserName == userName);
            if (file == null)
            {
                return NotFound("it's not found in the database");

            }
            var fileId = file.Id;
            var path = file.FilePath;

            byte[] b = System.IO.File.ReadAllBytes(path);

            return File(b, GetContentType(file.FileName));
        }

        [HttpGet("{userName}/Download{id}")]
        public async Task<IActionResult> DownloadFileAsync(string userName, int id)
        {

            var file = await _uow.Files.GetAsync(x => x.User.UserName == userName);
            if (file == null)
            {
                return NotFound("it's not found in the database");

            }
            var fileId = file.Id;
            var path = file.FilePath;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }


        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };

        }
    }
}
