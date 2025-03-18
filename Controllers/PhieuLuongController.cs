using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.PhieuLuongDto;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Mappers;
using QuanLyNhanSu.DTO.PhongBanDTO;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin,FManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class PhieuLuongController : ControllerBase
    {
        private readonly IPhieuLuongRepo _phieuLuongRepo;
        private readonly INhanVienRepo _nhanVienRepo;

        public PhieuLuongController(IPhieuLuongRepo phieuLuongRepo, INhanVienRepo nhanVienRepo)
        {
            _phieuLuongRepo = phieuLuongRepo;
            _nhanVienRepo = nhanVienRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPhieuLuongDto>>> GetAll()
        {
            var phieuLuongs = await _phieuLuongRepo.GetAllPhieuLuong();
            return Ok(phieuLuongs.Select(pl => pl.ToPhieuLuongDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPhieuLuongDto>> GetById([FromRoute]int id)
        {
            var phieuLuong = await _phieuLuongRepo.GetPhieuLuongByIdAsync(id);
            if (phieuLuong == null)
            {
                return NotFound();
            }
            return Ok(phieuLuong.ToPhieuLuongDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GetPhieuLuongDto>> Create([FromRoute]int NhanVienID,[FromBody] CreatePhieuLuongDto phieuLuongDto)
        {
            if (!await _nhanVienRepo.CheckNhanVienExistAsync(NhanVienID))
            {
                return BadRequest("Không tìm thấy nhân viên");
            }

            var phieuLuong = phieuLuongDto.ToPhieuLuongFromCreateDTO();
            var createdPhieuLuong = await _phieuLuongRepo.CreatePhieuLuongAsync(phieuLuong);
            return CreatedAtAction(nameof(GetById), new { id = createdPhieuLuong.Id }, createdPhieuLuong.ToPhieuLuongDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetPhieuLuongDto>> Update([FromRoute]int id,[FromBody] UpdatePhieuLuongDto updateDto)
        {
            var updatedPhieuLuong = await _phieuLuongRepo.UpdatePhieuLuongAsync(id, updateDto);
            if (updatedPhieuLuong == null)
            {
                return NotFound();
            }
            return Ok(updatedPhieuLuong.ToPhieuLuongDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GetPhieuLuongDto>> Delete([FromRoute] int id)
        {
            var deletedPhieuLuong = await _phieuLuongRepo.DeletePhieuLuongAsync(id);
            if (deletedPhieuLuong == null)
            {
                return NotFound();
            }
            return Ok(deletedPhieuLuong.ToPhieuLuongDTO());
        }
    }
}