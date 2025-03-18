using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.DTO.TinhTienLuongDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Repository
{
    public class TinhTienLuongRepository : ITinhTienLuongRepo
    {
        private readonly ApplicationDbContext _context;

        public TinhTienLuongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TinhTienLuong?> CreateTinhTienLuongAsync(TinhTienLuong tinhTienLuong)
        {
            _context.TinhTienLuongs.Add(tinhTienLuong);
            await _context.SaveChangesAsync();
            return tinhTienLuong;
        }

        public async Task<TinhTienLuong?> DeleteTinhTienLuongAsync(int id)
        {
            var thuongPhat = await _context.TinhTienLuongs.FindAsync(id);
            if (thuongPhat == null)
            {
                return null;
            }

            _context.TinhTienLuongs.Remove(thuongPhat);
            await _context.SaveChangesAsync();
            return thuongPhat;
        }

        public async Task<List<TinhTienLuong>> GetAllTinhTienLuong()
        {
            return await _context.TinhTienLuongs
            .Include(tinhTienLuong => tinhTienLuong.PhieuLuong)
            .ToListAsync();
        }

        public async Task<TinhTienLuong?> GetTinhTienLuongByIdAsync(int id)
        {
            return await _context.TinhTienLuongs
            .Include(tinhTienLuong => tinhTienLuong.PhieuLuong)
            .FirstOrDefaultAsync(tt => tt.Id == id);
        }

        public async Task<TinhTienLuong?> UpdateTinhTienLuongAsync(int id, UpdateTinhTienLuongDto update)
        {
            var thuongPhat = await _context.TinhTienLuongs.FindAsync(id);
            if (thuongPhat == null)
            {
                return null;
            }

            thuongPhat.TongSoGioLam = update.TongSoGioLam;
            thuongPhat.Thuong = update.Thuong;
            thuongPhat.TruLuong = update.TruLuong;
            thuongPhat.UpdatedAt = update.UpdatedAt;
            thuongPhat.PhieuLuongId = update.PhieuLuongId;
            thuongPhat.GhiChu = update.GhiChu;

            await _context.SaveChangesAsync();
            return thuongPhat;
        }
    }
}