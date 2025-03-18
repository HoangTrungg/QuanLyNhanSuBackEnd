using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.PhieuLuongDto;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Mappers
{
    public static class PhieuLuongMapper
    {
        public static GetPhieuLuongDto ToPhieuLuongDTO(this PhieuLuong phieuLuong)
        {
            return new GetPhieuLuongDto
            {
                Id = phieuLuong.Id,
                NhanVienID = phieuLuong.NhanVienId,
                NgayNhan = phieuLuong.NgayNhan,
                TongTien = phieuLuong.TongTien,
                ChucVuID = phieuLuong.ChucVuID,
                TinhTienLuongID = phieuLuong.TinhTienLuongID,
                NhanVien = phieuLuong.NhanVien,
                ChucVu = phieuLuong.ChucVu,
                TinhTienLuong = phieuLuong.TinhTienLuong
            };
        }

        public static PhieuLuong ToPhieuLuongFromCreateDTO(this CreatePhieuLuongDto phieuLuongDto)
        {
            return new PhieuLuong
            {
                NhanVienId = phieuLuongDto.NhanVienId,
                NgayNhan = phieuLuongDto.NgayNhan,
                TongTien = phieuLuongDto.TongTien,
                ChucVuID = phieuLuongDto.ChucVuID,
                TinhTienLuongID = phieuLuongDto.TinhTienLuongID,
            };
        }
    }
}