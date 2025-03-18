using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.ChucVuDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Interface
{
    public interface IChucVuRepo
    {
        Task<List<ChucVu>> GetAllChucVu();
        Task<ChucVu?> GetChucVuByIdAsync(int id);
        Task<ChucVu?> CreateChucVuAsync(ChucVu chucVu);
        Task<ChucVu?> UpdateChucVuAsync(int id , UpdateChucVuDto update);
        Task<ChucVu?> DeleteChucVuAsync(int id);
        Task ChangeChucVuForNhanVienAsync(int nhanVienId, int newChucVuId);
    }
}