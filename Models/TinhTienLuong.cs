using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class TinhTienLuong
    {
        [Key]
        public int Id { get; set; }
        public string GhiChu { get; set; } = "Lương Tháng";
        [Required]
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