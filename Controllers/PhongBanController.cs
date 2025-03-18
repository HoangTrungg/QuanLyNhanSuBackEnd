using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.PhongBanDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Mappers;
using QuanLyNhanSu.Repository;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin,HRManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanRepo _repository;

        public PhongBanController(IPhongBanRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPhongBanDto>>> Get()
        {
            var phongBans = await _repository.GetAllPhongBan();
            return Ok(phongBans.Select(pb => pb.ToPhongBanDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPhongBanDto>> GetById([FromRoute] int id)
        {
            var phongBan = await _repository.GetPhongBanByIdAsync(id);
            if (phongBan == null)
            {
                return NotFound();
            }
            return Ok(phongBan.ToPhongBanDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GetPhongBanDto>> Create([FromBody] CreatePhongBanDto createPhongBanDto)
        {
            var phongBan = createPhongBanDto.ToPhongBanFromCreateDTO();
            var createdPhongBan = await _repository.CreatePhongBanAsync(phongBan);
            return CreatedAtAction(nameof(GetById), new { id = createdPhongBan.Id }, createdPhongBan.ToPhongBanDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetPhongBanDto>> Update([FromRoute]int id,[FromBody] UpdatePhongBanDto updatePhongBanDto)
        {
            var updatedPhongBan = await _repository.UpdatePhongBanAsync(id, updatePhongBanDto);
            if (updatedPhongBan == null)
            {
                return NotFound();
            }
            return Ok(updatedPhongBan.ToPhongBanDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var deletedPhongBan = await _repository.DeletePhongBanAsync(id);
            if (deletedPhongBan == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{phongBanId}/nhanVien/{nhanVienId}")]
        public async Task<ActionResult> RemoveNhanVienFromPhongBan(int phongBanId, int nhanVienId)
        {
            var result = await _repository.RemoveNhanVienFromPhongBanAsync(phongBanId, nhanVienId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{phongBanId}/nhanVien/{nhanVienId}")]
        public async Task<ActionResult> AddNhanVienToPhongBan(int phongBanId, int nhanVienId)
        {
            var result = await _repository.AddNhanVienToPhongBanAsync(phongBanId, nhanVienId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}