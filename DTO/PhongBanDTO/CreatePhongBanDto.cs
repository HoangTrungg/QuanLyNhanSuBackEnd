using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.DTO.PhongBanDTO
{
    public class CreatePhongBanDto
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
    }

}