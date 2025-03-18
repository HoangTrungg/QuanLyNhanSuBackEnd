using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.DTO.PhongBanDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Mappers
{
    public static class PhongBanMapper
    {
        public static GetPhongBanDto ToPhongBanDTO(this PhongBan phongBan)
        {
            return new GetPhongBanDto
            {
                Id = phongBan.Id,
                TenPhongBan = phongBan.TenPhongBan,
                MoTa = phongBan.MoTa,
                TrangThai = phongBan.TrangThai,
                NhanVien = phongBan.NhanViens?.Select(nv => nv.ToNhanVienDTO()).ToList() ?? new List<GetNhanVienDto>()
            };
        }

        public static PhongBan ToPhongBanFromCreateDTO(this CreatePhongBanDto phongBanDTO)
        {
            return new PhongBan
            {
                TenPhongBan = phongBanDTO.TenPhongBan,
                MoTa = phongBanDTO.MoTa,
                TrangThai = phongBanDTO.TrangThai
            };
        }
    }
}