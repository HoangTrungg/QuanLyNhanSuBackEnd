using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.GetTinhTienLuongDTO;
using QuanLyNhanSu.DTO.TinhTienLuongDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Mappers
{
    public static class TinhTienLuongMapper
    {
        public static GetTinhTienLuongDto ToThuongPhatDTO(this TinhTienLuong tinhTienLuong)
        {
            return new GetTinhTienLuongDto
            {
                Id = tinhTienLuong.Id,
                TongSoGioLam = tinhTienLuong.TongSoGioLam,
                Thuong = tinhTienLuong.Thuong,
                TruLuong = tinhTienLuong.TruLuong,
                CreatedAt = tinhTienLuong.CreatedAt,
                UpdatedAt = tinhTienLuong.UpdatedAt,
                PhieuLuongId = tinhTienLuong.PhieuLuongId,
                GhiChu = tinhTienLuong.GhiChu,
                PhieuLuong = tinhTienLuong.PhieuLuong,
            };
        }
        public static TinhTienLuong ToTinhTienLuongFromCreateDTO(this CreateTinhTienLuongDto thuongPhatDto)
        {
            return new TinhTienLuong
            {
                TongSoGioLam = thuongPhatDto.TongSoGioLam,
                Thuong = thuongPhatDto.Thuong,
                TruLuong = thuongPhatDto.TruLuong,
                CreatedAt = thuongPhatDto.CreatedAt,
                UpdatedAt = thuongPhatDto.UpdatedAt,
                PhieuLuongId = thuongPhatDto.PhieuLuongId,
                GhiChu = thuongPhatDto.GhiChu,
            };
        }
    }
}