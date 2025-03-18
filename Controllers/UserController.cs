using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using QuanLyNhanSu.Interface;
using Microsoft.Extensions.Logging;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly INhanVienRepo _nhanVienRepo;

        public UserController(INhanVienRepo nhanVienRepo)
        {
            _nhanVienRepo = nhanVienRepo;
        }

        
        [HttpGet("Profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var nhanVien = await _nhanVienRepo.GetNhanVienByUserIdAsync(userId);
            if (nhanVien == null)
            {
                return NotFound("Không tìm thấy thông tin nhân viên.");
            }

            return Ok(nhanVien);
        }
    }
}