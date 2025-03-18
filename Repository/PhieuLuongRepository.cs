using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.DTO.PhieuLuongDto;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Repository
{
    public class PhieuLuongRepository : IPhieuLuongRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly INhanVienRepo _nhanVienRepo;
        public PhieuLuongRepository(ApplicationDbContext context, INhanVienRepo nhanVienRepo)
        {
            _context = context;
            _nhanVienRepo = nhanVienRepo;
        }

        public async Task<PhieuLuong?> CreatePhieuLuongAsync(PhieuLuong phieuLuong)
        {
            _context.PhieuLuongs.Add(phieuLuong);
            await _context.SaveChangesAsync();
            return phieuLuong;
        }

        public async Task<PhieuLuong?> DeletePhieuLuongAsync(int id)
        {
            var phieuLuong = await _context.PhieuLuongs.FindAsync(id);
            if (phieuLuong == null)
            {
                return null;
            }

            _context.PhieuLuongs.Remove(phieuLuong);
            await _context.SaveChangesAsync();
            return phieuLuong;
        }

        public async Task<List<PhieuLuong>> GetAllPhieuLuong()
        {
            return await _context.PhieuLuongs.ToListAsync();
        }

        public async Task<PhieuLuong?> GetPhieuLuongByIdAsync(int id)
        {
            return await _context.PhieuLuongs
                .Include(pl => pl.ChucVu)
                .Include(pl => pl.TinhTienLuong)
                .Include(pl => pl.NhanVien)
                .FirstOrDefaultAsync(pl => pl.Id == id);
        }

        public async Task<PhieuLuong?> UpdatePhieuLuongAsync(int id, UpdatePhieuLuongDto update)
        {
            var phieuLuong = await _context.PhieuLuongs.FindAsync(id);
            if (phieuLuong == null)
            {
                return null;
            }

            phieuLuong.NgayNhan = update.NgayNhan;
            phieuLuong.ChucVuID = update.ChucVuID;
            phieuLuong.TinhTienLuongID = update.TinhTienLuongID;
            phieuLuong.NhanVienId = update.NhanVienId;

            await _context.SaveChangesAsync();
            return phieuLuong;
        }
    }
}