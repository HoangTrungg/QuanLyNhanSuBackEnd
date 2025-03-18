using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.PhongBanDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interface
{
    public interface IPhongBanRepo
    {
        Task<List<PhongBan>> GetAllPhongBan();
        Task<PhongBan?> GetPhongBanByIdAsync(int id);
        Task<PhongBan?> CreatePhongBanAsync(PhongBan phongBan);
        Task<PhongBan?> UpdatePhongBanAsync(int id , UpdatePhongBanDto update);
        Task<PhongBan?> DeletePhongBanAsync(int id);
        Task<bool> RemoveNhanVienFromPhongBanAsync(int phongBanId, int nhanVienId);
        Task<bool> AddNhanVienToPhongBanAsync(int phongBanId, int nhanVienId);
    }
}