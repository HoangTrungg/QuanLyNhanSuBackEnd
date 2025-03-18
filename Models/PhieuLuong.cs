using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class PhieuLuong
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime NgayNhan { get; set; }
        public decimal TongTien { get; set; }
        [Required]
        public int ChucVuID { get; set; }
        public int? TinhTienLuongID { get; set; }
        [Required]
        public int NhanVienId { get; set; }
        
        [ForeignKey("ChucVuID")]
        public virtual ChucVu ChucVu { get; set; }
        [ForeignKey("TinhTienLuongID")]
        public virtual TinhTienLuong TinhTienLuong { get; set; }
        
        [ForeignKey("NhanVienId")]
        public virtual NhanVien NhanVien { get; set; }
    }
}