using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.PhieuLuongDto;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interface
{
    public interface IPhieuLuongRepo
    {
        Task<List<PhieuLuong>> GetAllPhieuLuong();
        Task<PhieuLuong?> GetPhieuLuongByIdAsync(int id);
        Task<PhieuLuong?> CreatePhieuLuongAsync(PhieuLuong phieuLuong);
        Task<PhieuLuong?> UpdatePhieuLuongAsync(int id , UpdatePhieuLuongDto update);
        Task<PhieuLuong?> DeletePhieuLuongAsync(int id);
    }
}