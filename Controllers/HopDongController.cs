using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.HopDongDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Mappers;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin,HRManager")]
    [ApiController]
    [Route("api/[controller]")]
    public class HopDongController : ControllerBase
    {
        private readonly IHopDongRepo _hopDongRepo;

        public HopDongController(IHopDongRepo hopDongRepo)
        {
            _hopDongRepo = hopDongRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHopDongDto>>> GetAllHopDong()
        {
            var hopDongs = await _hopDongRepo.GetAllHopDong();
            return Ok(hopDongs.Select(hd => hd.ToPhongBanDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetHopDongDto>> GetHopDongById([FromRoute] int id)
        {
            var hopDong = await _hopDongRepo.GetHopDongByIdAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            return Ok(hopDong.ToPhongBanDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GetHopDongDto>> CreateHopDong([FromBody] CreateHopDongDto createHopDongDto)
        {
            var hopDong = createHopDongDto.ToPhongBanFromCreateDTO();
            var createdHopDong = await _hopDongRepo.CreateHopDongAsync(hopDong);
            return CreatedAtAction(nameof(GetHopDongById), new { id = createdHopDong.Id }, createdHopDong.ToPhongBanDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetHopDongDto>> UpdateHopDong([FromRoute]int id,[FromBody] UpdateHopDongDto updateHopDongDto)
        {
            var updatedHopDong = await _hopDongRepo.UpdateHopDongAsync(id, updateHopDongDto);
            if (updatedHopDong == null)
            {
                return NotFound();
            }
            return Ok(updatedHopDong.ToPhongBanDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHopDong([FromRoute] int id)
        {
            var deletedHopDong = await _hopDongRepo.DeleteHopDongAsync(id);
            if (deletedHopDong == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}