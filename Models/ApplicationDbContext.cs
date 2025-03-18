using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanSu.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<TinhTienLuong> TinhTienLuongs { get; set; }
        public DbSet<PhieuLuong> PhieuLuongs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public ApplicationDbContext()
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer("Data Source=HOANGTRUNG\\SQLSERVERDB;Initial Catalog=QLNS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. ApplicationUser - NhanVien: quan hệ 1-1 qua UserID
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(au => au.NhanVien)
                .WithOne(nv => nv.User)
                .HasForeignKey<NhanVien>(nv => nv.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. ChucVu - NhanVien: quan hệ 1-n
            modelBuilder.Entity<ChucVu>()
                .HasMany(cv => cv.NhanViens)
                .WithOne(nv => nv.ChucVu)
                .HasForeignKey(nv => nv.ChucVuID)
                .OnDelete(DeleteBehavior.SetNull);

            // 3. PhongBan - NhanVien: quan hệ 1-n
            modelBuilder.Entity<PhongBan>()
                .HasMany(pb => pb.NhanViens)
                .WithOne(nv => nv.PhongBan)
                .HasForeignKey(nv => nv.PhongBanID)
                .OnDelete(DeleteBehavior.SetNull);

            // 4. HopDong - NhanVien: quan hệ 1-n
            modelBuilder.Entity<NhanVien>()
               .HasMany(nv => nv.HopDongs)
               .WithOne(hd => hd.NhanVien)
               .HasForeignKey(hd => hd.NhanVienID)
               .OnDelete(DeleteBehavior.Cascade);

            // 5. Quan hệ 1-N: Một NhanVien có nhiều PhieuLuongs
                modelBuilder.Entity<NhanVien>()
                .HasMany(nv => nv.PhieuLuongs)
                .WithOne(pl => pl.NhanVien)
                .HasForeignKey(pl => pl.NhanVienId)
                .OnDelete(DeleteBehavior.Restrict);

            // 6. PhieuLuong - ChucVu: quan hệ nhiều - 1
            modelBuilder.Entity<PhieuLuong>()
                .HasOne(pl => pl.ChucVu)
                .WithMany(cv => cv.PhieuLuongs)
                .HasForeignKey(pl => pl.ChucVuID)
                .OnDelete(DeleteBehavior.Restrict);

            // 7. Cấu hình quan hệ 1-1 giữa PhieuLuong và ThuongPhat:
            modelBuilder.Entity<PhieuLuong>()
                .HasOne(pl => pl.TinhTienLuong)
                .WithOne(ttp => ttp.PhieuLuong)
                .HasForeignKey<PhieuLuong>(pl => pl.TinhTienLuongID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TinhTienLuong>()
                .HasOne(pl => pl.PhieuLuong)
                .WithOne(ttp => ttp.TinhTienLuong)
                .HasForeignKey<TinhTienLuong>(pl => pl.PhieuLuongId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed admin account
            var adminRoleId = "admin-role-id";
            var adminUserId = "admin-user-id";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminUserId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        }
    }
}