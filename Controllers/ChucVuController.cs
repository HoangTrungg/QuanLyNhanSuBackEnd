using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.ChucVuDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Mappers;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin,HRManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuRepo _chucVuRepo;

        public ChucVuController(IChucVuRepo chucVuRepo)
        {
            _chucVuRepo = chucVuRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVu>>> GetAllChucVu()
        {
            var chucVus = await _chucVuRepo.GetAllChucVu();
            return Ok(chucVus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVu>> GetChucVuById([FromRoute]int id)
        {
            var chucVu = await _chucVuRepo.GetChucVuByIdAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }
            return Ok(chucVu);
        }

        [HttpPost]
        public async Task<ActionResult<ChucVu>> CreateChucVu([FromBody]CreateChucVuDto createChucVuDto)
        {
            var chucVu = createChucVuDto.ToChucVuFromCreateDTO();
            var createdChucVu = await _chucVuRepo.CreateChucVuAsync(chucVu);
            return CreatedAtAction(nameof(GetChucVuById), new { id = createdChucVu.Id }, createdChucVu);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChucVu>> UpdateChucVu([FromRoute]int id,[FromBody] UpdateChucVuDto updateChucVuDto)
        {
            var updatedChucVu = await _chucVuRepo.UpdateChucVuAsync(id, updateChucVuDto);
            if (updatedChucVu == null)
            {
                return NotFound();
            }
            return Ok(updatedChucVu);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ChucVu>> DeleteChucVu([FromRoute]int id)
        {
            var deletedChucVu = await _chucVuRepo.DeleteChucVuAsync(id);
            if (deletedChucVu == null)
            {
                return NotFound();
            }
            return Ok(deletedChucVu);
        }

        [HttpPut("changeChucVuForNhanVien")]
        public async Task<IActionResult> ChangeChucVuForNhanVien([FromRoute]int nhanVienId,[FromRoute] int newChucVuId)
        {
            await _chucVuRepo.ChangeChucVuForNhanVienAsync(nhanVienId, newChucVuId);
            return NoContent();
        }
    }
}