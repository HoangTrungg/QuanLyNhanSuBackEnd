using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class ChucVu
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(255)]
        public string TenChucVu { get; set; }
        
        [Required]
        public decimal LuongCoBan { get; set; }
        
        [Required]
        public decimal LuongTheoGio { get; set; }
        
        public decimal? LuongTangThem { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhieuLuong> PhieuLuongs { get; set; }
    }
}