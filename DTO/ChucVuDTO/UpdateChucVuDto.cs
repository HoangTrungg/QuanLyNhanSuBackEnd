using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DTO.ChucVuDTO
{
    public class UpdateChucVuDto
    {
        public string TenChucVu { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal LuongTheoGio { get; set; }
        public decimal? LuongTangThem { get; set; }
    }
}