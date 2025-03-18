using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.GetTinhTienLuongDTO;
using QuanLyNhanSu.DTO.TinhTienLuongDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Mappers;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin,FManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class TinhTienLuongController : ControllerBase
    {
        private readonly ITinhTienLuongRepo _repository;

        public TinhTienLuongController(ITinhTienLuongRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTinhTienLuongDto>>> GetAll()
        {
            var tinhTienLuongs = await _repository.GetAllTinhTienLuong();
            return Ok(tinhTienLuongs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTinhTienLuongDto>> GetById([FromRoute]int id)
        {
            var tinhTienLuong = await _repository.GetTinhTienLuongByIdAsync(id);
            if (tinhTienLuong == null)
            {
                return NotFound();
            }
            return Ok(tinhTienLuong.ToThuongPhatDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GetTinhTienLuongDto>> Create([FromBody]CreateTinhTienLuongDto createDto)
        {
            var tinhTienLuong = createDto.ToTinhTienLuongFromCreateDTO();
            var createdTinhTienLuong = await _repository.CreateTinhTienLuongAsync(tinhTienLuong);
            return CreatedAtAction(nameof(GetById), new { id = createdTinhTienLuong.Id }, createdTinhTienLuong.ToThuongPhatDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetTinhTienLuongDto>> Update([FromRoute]int id,[FromBody] UpdateTinhTienLuongDto updateDto)
        {
            var updatedTinhTienLuong = await _repository.UpdateTinhTienLuongAsync(id, updateDto);
            if (updatedTinhTienLuong == null)
            {
                return NotFound();
            }
            return Ok(updatedTinhTienLuong.ToThuongPhatDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GetTinhTienLuongDto>> Delete([FromRoute] int id)
        {
            var deletedTinhTienLuong = await _repository.DeleteTinhTienLuongAsync(id);
            if (deletedTinhTienLuong == null)
            {
                return NotFound();
            }
            return Ok(deletedTinhTienLuong.ToThuongPhatDTO());
        }
    }
}