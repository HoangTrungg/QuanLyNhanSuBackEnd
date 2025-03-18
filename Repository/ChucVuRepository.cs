using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.ChucVuDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanSu.Repository
{
    public class ChucVuRepository : IChucVuRepo
    {
        private readonly ApplicationDbContext _context;

        public ChucVuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ChangeChucVuForNhanVienAsync(int nhanVienId, int newChucVuId)
        {
            var nhanVien = await _context.NhanViens.FindAsync(nhanVienId);
            if (nhanVien == null)
            {
                throw new KeyNotFoundException("NhanVien not found");
            }

            var newChucVu = await _context.ChucVus.FindAsync(newChucVuId);
            if (newChucVu == null)
            {
                throw new KeyNotFoundException("ChucVu not found");
            }

            nhanVien.ChucVuID = newChucVuId;
            await _context.SaveChangesAsync();
        }

        public async Task<ChucVu?> CreateChucVuAsync(ChucVu chucVu)
        {
            _context.ChucVus.Add(chucVu);
            await _context.SaveChangesAsync();
            return chucVu;
        }

        public async Task<ChucVu?> DeleteChucVuAsync(int id)
        {
            var chucVu = await _context.ChucVus.FindAsync(id);
            if (chucVu == null)
            {
                return null;
            }

            _context.ChucVus.Remove(chucVu);
            await _context.SaveChangesAsync();
            return chucVu;
        }

        public async Task<List<ChucVu>> GetAllChucVu()
        {
            return await _context.ChucVus
            .Include(cv => cv.NhanViens)
            .ToListAsync();
        }

        public async Task<ChucVu?> GetChucVuByIdAsync(int id)
        {
            return await _context.ChucVus
            .Include(cv => cv.NhanViens)
            .FirstOrDefaultAsync(cv => cv.Id == id);
        }

        public async Task<ChucVu?> UpdateChucVuAsync(int id, UpdateChucVuDto update)
        {
            var chucVu = await _context.ChucVus.FindAsync(id);
            if (chucVu == null)
            {
                return null;
            }

            chucVu.TenChucVu = update.TenChucVu;
            chucVu.LuongCoBan = update.LuongCoBan;
            chucVu.LuongTheoGio = update.LuongTheoGio;
            chucVu.LuongTangThem = update.LuongTangThem;

            await _context.SaveChangesAsync();
            return chucVu;
        }
    }
}