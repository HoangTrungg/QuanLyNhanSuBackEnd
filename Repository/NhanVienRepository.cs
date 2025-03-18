using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Repository
{
    public class NhanVienRepository : INhanVienRepo
    {
        private readonly ApplicationDbContext _context;

        public NhanVienRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> CheckNhanVienExistAsync(int id)
        {
            return _context.NhanViens.AnyAsync(i => i.Id == id);
        }

        public async Task<NhanVien?> CreateNhanVienAsync(NhanVien nhanVien)
        {
            _context.NhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();
            return nhanVien;
        }

        public async Task<NhanVien?> DeleteNhanVienAsync(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return null;
            }

            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return nhanVien;
        }

        public async Task<List<NhanVien>> GetAllNhanVien()
        {
            return await _context.NhanViens
                .Include(nv => nv.ChucVu)
                .Include(nv => nv.PhongBan)
                .ToListAsync();
        }

        public async Task<NhanVien?> GetNhanVienByIdAsync(int id)
        {
            return await _context.NhanViens
                .Include(nv => nv.ChucVu)
                .Include(nv => nv.PhongBan)
                .FirstOrDefaultAsync(nv => nv.Id == id);
        }

        public async Task<NhanVien> GetNhanVienByUserIdAsync(string userId)
        {
            return await _context.NhanViens
                .Include(nv => nv.ChucVu)
                .Include(nv => nv.PhongBan)
                .FirstOrDefaultAsync(nv => nv.UserID == userId) ?? throw new InvalidOperationException("Không tìm thấy nhân viên");
        }

        public async Task<NhanVien?> UpdateNhanVienAsync(int id, UpdateNhanVienDto update)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return null;
            }

            nhanVien.HoTen = update.HoTen;
            nhanVien.Birthday = update.Birthday;
            nhanVien.GioiTinh = update.GioiTinh;
            nhanVien.DiaChi = update.DiaChi;
            nhanVien.NgayBatDau = update.NgayBatDau;
            nhanVien.TrangThai = update.TrangThai;
            nhanVien.Email = update.Email;
            nhanVien.Phone = update.Phone;
            nhanVien.PhongBanID = update.PhongBanID;
            nhanVien.ChucVuID = update.ChucVuID;

            _context.NhanViens.Update(nhanVien);
            await _context.SaveChangesAsync();
            return nhanVien;
        }
    }
}