using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.DTO.NhanVienDTO;

namespace QuanLyNhanSu.DTO.HopDongDTO
{
    public class GetHopDongDto
    {
        public int Id { get; set; }
        public string LoaiHopDong { get; set; }
        public string NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int NhanVienID { get; set; }
        public virtual GetNhanVienDto NhanVien { get; set; }
    }
}