using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.NhanVienDTO;

namespace QuanLyNhanSu.DTO.ChucVuDTO
{
    public class ChucVuDto
    {
        public int Id { get; set; }
        public string TenChucVu { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal LuongTheoGio { get; set; }
        public decimal? LuongTangThem { get; set; }
        public virtual ICollection<GetNhanVienDto> NhanViens { get; set; }
        public virtual ICollection<GetNhanVienDto> PhieuLuongs { get; set; }
    }
}