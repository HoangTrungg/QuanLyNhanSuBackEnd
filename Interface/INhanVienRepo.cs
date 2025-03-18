using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interface
{
    public interface INhanVienRepo
    {
        Task<List<NhanVien>> GetAllNhanVien();
        Task<NhanVien?> GetNhanVienByIdAsync(int id);
        Task<NhanVien?> CreateNhanVienAsync(NhanVien nhanVien);
        Task<NhanVien?> UpdateNhanVienAsync(int id , UpdateNhanVienDto update);
        Task<NhanVien?> DeleteNhanVienAsync(int id);
        Task<NhanVien> GetNhanVienByUserIdAsync(string userId);
        Task<bool> CheckNhanVienExistAsync(int id);
    }
}