using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.HopDongDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Mappers
{
    public static class HopDongMapper
    {
        public static GetHopDongDto ToPhongBanDTO(this HopDong hopDong)
        {
            return new GetHopDongDto
            {
                Id = hopDong.Id,
                LoaiHopDong = hopDong.LoaiHopDong,
                NgayBatDau = hopDong.NgayBatDau,
                NgayKetThuc = hopDong.NgayKetThuc,
                NhanVien = hopDong.NhanVien.ToNhanVienDTO()
            };
        }

        public static HopDong ToPhongBanFromCreateDTO(this CreateHopDongDto hopDong)
        {
            return new HopDong
            {
                LoaiHopDong = hopDong.LoaiHopDong,
                NgayBatDau = hopDong.NgayBatDau,
                NgayKetThuc = hopDong.NgayKetThuc,
            };
        }
    }
}