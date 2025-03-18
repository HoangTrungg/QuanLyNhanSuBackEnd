using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.PhieuLuongDto;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.DTO.GetTinhTienLuongDTO
{
    public class GetTinhTienLuongDto
    {
        public int Id { get; set; }
        public string GhiChu { get; set; } = "Lương Tháng";
        public double TongSoGioLam { get; set; }
        public decimal? Thuong { get; set; }
        public decimal? TruLuong { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? PhieuLuongId { get; set; }
        [ForeignKey("PhieuLuongId")]
        public virtual PhieuLuong PhieuLuong { get; set; }
    }
}