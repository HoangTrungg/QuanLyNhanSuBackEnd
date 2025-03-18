using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Mappers;
using QuanLyNhanSu.Repository;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin,HRManager,FManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepo _repository;

        public NhanVienController(INhanVienRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetNhanVienDto>>> Get()
        {
            var nhanViens = await _repository.GetAllNhanVien();
            return Ok(nhanViens.Select(nv => nv.ToNhanVienDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetNhanVienDto>> GetById([FromRoute] int id)
        {
            var nhanVien = await _repository.GetNhanVienByIdAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return Ok(nhanVien.ToNhanVienDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetNhanVienDto>> Update([FromRoute] int id,[FromBody] UpdateNhanVienDto updateNhanVienDto)
        {
            var updatedNhanVien = await _repository.UpdateNhanVienAsync(id, updateNhanVienDto);
            if (updatedNhanVien == null)
            {
                return NotFound();
            }
            return Ok(updatedNhanVien.ToNhanVienDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deletedNhanVien = await _repository.DeleteNhanVienAsync(id);
            if (deletedNhanVien == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}