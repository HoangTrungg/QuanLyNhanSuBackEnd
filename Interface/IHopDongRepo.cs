using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.HopDongDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interface
{
    public interface IHopDongRepo
    {
        Task<List<HopDong>> GetAllHopDong();
        Task<HopDong?> GetHopDongByIdAsync(int id);
        Task<HopDong?> CreateHopDongAsync(HopDong hopDong);
        Task<HopDong?> UpdateHopDongAsync(int id, UpdateHopDongDto update);
        Task<HopDong?> DeleteHopDongAsync(int id);
    }
}