using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.DTO.HopDongDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Repository
{
    public class HopDongRepository : IHopDongRepo
    {
        private readonly ApplicationDbContext _context;

        public HopDongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HopDong?> CreateHopDongAsync(HopDong hopDong)
        {
            _context.HopDongs.Add(hopDong);
            await _context.SaveChangesAsync();
            return hopDong;
        }

        public async Task<HopDong?> DeleteHopDongAsync(int id)
        {
            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong == null)
            {
                return null;
            }

            _context.HopDongs.Remove(hopDong);
            await _context.SaveChangesAsync();
            return hopDong;
        }

        public async Task<List<HopDong>> GetAllHopDong()
        {
            return await _context.HopDongs
            .Include(nv => nv.NhanVien)
            .ToListAsync();
        }

        public async Task<HopDong?> GetHopDongByIdAsync(int id)
        {
            return await _context.HopDongs
            .Include(nv => nv.NhanVien)
            .FirstOrDefaultAsync(hd => hd.Id == id);
        }

        public async Task<HopDong?> UpdateHopDongAsync(int id, UpdateHopDongDto update)
        {
            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong == null)
            {
                return null;
            }

            hopDong.LoaiHopDong = update.LoaiHopDong;
            hopDong.NgayBatDau = update.NgayBatDau;
            hopDong.NgayKetThuc = update.NgayKetThuc;
            hopDong.NhanVienID = update.NhanVienID;

            _context.HopDongs.Update(hopDong);
            await _context.SaveChangesAsync();
            return hopDong;
        }
    }
}