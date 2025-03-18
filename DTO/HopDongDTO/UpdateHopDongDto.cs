using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DTO.HopDongDTO
{
    public class UpdateHopDongDto
    {
        public string LoaiHopDong { get; set; }
        public string NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int NhanVienID { get; set; }
    }
}