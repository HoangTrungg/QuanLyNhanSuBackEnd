using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Mappers
{
    public static class NhanVienMapper
    {
        public static GetNhanVienDto ToNhanVienDTO(this NhanVien nhanVien)
        {
            return new GetNhanVienDto
            {
                Id = nhanVien.Id,
                HoTen = nhanVien.HoTen,
                Birthday = nhanVien.Birthday,
                GioiTinh = nhanVien.GioiTinh,
                DiaChi = nhanVien.DiaChi,
                NgayBatDau = nhanVien.NgayBatDau,
                TrangThai = nhanVien.TrangThai,
                Email = nhanVien.Email,
                Phone = nhanVien.Phone,
                PhongBanID = nhanVien.PhongBanID,
                ChucVuID = nhanVien.ChucVuID,
            };
        }

        public static NhanVien ToNhanVienFromCreateDTO(this CreateNhanVienDto nhanVienDTO, string userId)
        {
            return new NhanVien
            {
                HoTen = nhanVienDTO.HoTen,
                Birthday = nhanVienDTO.Birthday,
                GioiTinh = nhanVienDTO.GioiTinh,
                DiaChi = nhanVienDTO.DiaChi,
                NgayBatDau = nhanVienDTO.NgayBatDau,
                TrangThai = nhanVienDTO.TrangThai,
                Email = nhanVienDTO.Email,
                Phone = nhanVienDTO.Phone,
                UserID = userId,
                PhongBanID = nhanVienDTO.PhongBanID,
                ChucVuID = nhanVienDTO.ChucVuID,
            };
        }
    }
}