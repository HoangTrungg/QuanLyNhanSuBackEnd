using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.TinhTienLuongDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interface
{
    public interface ITinhTienLuongRepo 
    {
        Task<List<TinhTienLuong>> GetAllTinhTienLuong();
        Task<TinhTienLuong?> GetTinhTienLuongByIdAsync(int id);
        Task<TinhTienLuong?> CreateTinhTienLuongAsync(TinhTienLuong tienLuong);
        Task<TinhTienLuong?> UpdateTinhTienLuongAsync(int id , UpdateTinhTienLuongDto update);
        Task<TinhTienLuong?> DeleteTinhTienLuongAsync(int id);
    }
}