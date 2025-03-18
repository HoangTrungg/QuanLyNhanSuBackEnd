using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INhanVienRepo _nhanVienRepo;

        public AdminController(UserManager<ApplicationUser> userManager, INhanVienRepo nhanVienRepo)
        {
            _userManager = userManager;
            _nhanVienRepo = nhanVienRepo;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateNhanVienDto request)
        {
            var newUser = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.EmailUser
            };

            var userResult = await _userManager.CreateAsync(newUser, request.Password);
            if (!userResult.Succeeded)
            {
                return BadRequest(userResult.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(newUser, "User");
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }

            var employee = new NhanVien
            {
                HoTen = request.HoTen,
                GioiTinh = request.GioiTinh,
                DiaChi = request.DiaChi,
                NgayBatDau = request.NgayBatDau,
                Email = request.Email,
                Phone = request.Phone,
                Birthday = request.Birthday,
                UserID = newUser.Id,
                PhongBanID = request.PhongBanID,
                ChucVuID = request.ChucVuID,
                TrangThai = request.TrangThai
            };

            await _nhanVienRepo.CreateNhanVienAsync(employee);

            return Ok(new { message = "Tạo nhân viên thành công", employeeId = employee.Id });
        }

    }
}