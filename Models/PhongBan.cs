using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class PhongBan
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(255)]
        public string TenPhongBan { get; set; }
        
        [Required, MaxLength(255)]
        public string MoTa { get; set; }
        
        [Required, MaxLength(255)]
        public string TrangThai { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}