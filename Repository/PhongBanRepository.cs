using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.DTO.PhongBanDTO;
using QuanLyNhanSu.Interface;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Repository
{
    public class PhongBanRepository : IPhongBanRepo
    {
        private readonly ApplicationDbContext _context;

        public PhongBanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhongBan>> GetAllPhongBan()
        {
            return await _context.PhongBans
            .Include(pb => pb.NhanViens)
            .ToListAsync();
        }

        public async Task<PhongBan?> GetPhongBanByIdAsync(int id)
        {
            return await _context.PhongBans
            .Include(nv => nv.NhanViens)
            .FirstOrDefaultAsync(pb => pb.Id == id);
        }

        public async Task<PhongBan?> CreatePhongBanAsync(PhongBan phongBan)
        {
            _context.PhongBans.Add(phongBan);
            await _context.SaveChangesAsync();
            return phongBan;
        }

        public async Task<PhongBan?> DeletePhongBanAsync(int id)
        {
            var phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return null;
            }

            _context.PhongBans.Remove(phongBan);
            await _context.SaveChangesAsync();
            return phongBan;
        }

        public async Task<PhongBan?> UpdatePhongBanAsync(int id, UpdatePhongBanDto update)
        {
            var phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return null;
            }

            phongBan.TenPhongBan = update.TenPhongBan;
            phongBan.MoTa = update.MoTa;
            phongBan.TrangThai = update.TrangThai;

            _context.PhongBans.Update(phongBan);
            await _context.SaveChangesAsync();

            return phongBan;
        }

        public async Task<bool> RemoveNhanVienFromPhongBanAsync(int phongBanId, int nhanVienId)
        {
            var phongBan = await _context.PhongBans
                .Include(pb => pb.NhanViens)
                .FirstOrDefaultAsync(pb => pb.Id == phongBanId);

            if (phongBan == null)
            {
                return false;
            }

            var nhanVien = phongBan.NhanViens.FirstOrDefault(nv => nv.Id == nhanVienId);
            if (nhanVien == null)
            {
                return false;
            }

            phongBan.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddNhanVienToPhongBanAsync(int phongBanId, int nhanVienId)
        {
            var phongBan = await _context.PhongBans
                .Include(pb => pb.NhanViens)
                .FirstOrDefaultAsync(pb => pb.Id == phongBanId);

            if (phongBan == null)
            {
                return false;
            }

            var nhanVien = await _context.NhanViens.FindAsync(nhanVienId);
            if (nhanVien == null || nhanVien.PhongBanID != null)
            {
                return false;
            }

            nhanVien.PhongBanID = phongBanId;
            phongBan.NhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}