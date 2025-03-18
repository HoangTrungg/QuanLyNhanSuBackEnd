using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayBatDau { get; set; }
        [Required, MaxLength(255)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Phone { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required, MaxLength(450)]
        public string UserID { get; set; }

        public int? PhongBanID { get; set; }
        public int? ChucVuID { get; set; }

        [Required, MaxLength(255)]
        public string TrangThai { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ChucVuID")]
        public virtual ChucVu ChucVu { get; set; }

        [ForeignKey("PhongBanID")]
        public virtual PhongBan PhongBan { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual ICollection<PhieuLuong> PhieuLuongs { get; set; }
    }
}