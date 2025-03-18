using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.NhanVienDTO;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.DTO.PhongBanDTO
{
    public class GetPhongBanDto
    {
        public int Id { get; set; }
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
        public virtual ICollection<GetNhanVienDto> NhanVien { get; set; }
    }
}