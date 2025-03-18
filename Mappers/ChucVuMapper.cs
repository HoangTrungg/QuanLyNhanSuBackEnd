using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.ChucVuDTO;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Mappers
{
    public static class ChucVuMapper
    {
        public static ChucVuDto ToChucVuDTO(this ChucVu chucVu)
        {
            return new ChucVuDto
            {
                Id = chucVu.Id,
                TenChucVu = chucVu.TenChucVu,
                LuongCoBan = chucVu.LuongCoBan,
                LuongTheoGio = chucVu.LuongTheoGio,
                LuongTangThem = chucVu.LuongTangThem,
                NhanViens = chucVu.NhanViens?.Select(nv => nv.ToNhanVienDTO()).ToList() ?? new List<GetNhanVienDto>()
            };
        }

        public static ChucVu ToChucVuFromCreateDTO(this CreateChucVuDto chucVu)
        {
            return new ChucVu
            {
                TenChucVu = chucVu.TenChucVu,
                LuongCoBan = chucVu.LuongCoBan,
                LuongTheoGio = chucVu.LuongTheoGio,
                LuongTangThem = chucVu.LuongTangThem,
            };
        }
    }
}