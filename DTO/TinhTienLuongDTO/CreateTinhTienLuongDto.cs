using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DTO.TinhTienLuongDTO
{
    public class CreateTinhTienLuongDto
    {
        public int Id { get; set; }
        public string GhiChu { get; set; } = "Lương Tháng";
        public double TongSoGioLam { get; set; }
        public decimal? Thuong { get; set; }
        public decimal? TruLuong { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? PhieuLuongId { get; set; }
    }
}