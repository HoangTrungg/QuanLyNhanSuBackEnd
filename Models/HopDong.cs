using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class HopDong
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(255)]
        public string LoaiHopDong { get; set; }
        [Required, MaxLength(255)]
        public string NgayBatDau { get; set; }
       
        public DateTime? NgayKetThuc { get; set; }
        [Required]
        public int NhanVienID { get; set; }
        [ForeignKey("NhanVienID")]
        public virtual NhanVien NhanVien { get; set; }
    }
}