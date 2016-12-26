using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Entites
{
    public partial class ShopGiayDBContext : DbContext
    {
        public virtual DbSet<CtdonHang> CtdonHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<LoaiGiay> LoaiGiay { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=LVD-MUC0126ZAF\SQLEXPRESS;Initial Catalog=ShopGiay;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtdonHang>(entity =>
            {
                entity.HasKey(e => new { e.IdSanPham, e.IdDonHang })
                    .HasName("PK_CTDonHang");

                entity.ToTable("CTDonHang");

                entity.Property(e => e.IdSanPham).HasColumnName("Id_SanPham");

                entity.Property(e => e.IdDonHang).HasColumnName("Id_DonHang");

                entity.HasOne(d => d.IdDonHangNavigation)
                    .WithMany(p => p.CtdonHang)
                    .HasForeignKey(d => d.IdDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CTDonHang_DonHang");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.CtdonHang)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CTDonHang_SanPham");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.IdKhachHang).HasColumnName("Id_KhachHang");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.NguoiNhan).HasMaxLength(100);

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);
                entity.Property(e=>e.TongTien).HasColumnType("decimal");

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.DonHang)
                    .HasForeignKey(d => d.IdKhachHang)
                    .HasConstraintName("FK_DonHang_TaiKhoan");
            });

            modelBuilder.Entity<LoaiGiay>(entity =>
            {
                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.Gia).HasColumnType("decimal");

                entity.Property(e => e.HinhAnh).HasColumnType("varchar(50)");

                entity.Property(e => e.TenSanPham).HasMaxLength(250);

                entity.HasOne(d => d.LoaiNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.Loai)
                    .HasConstraintName("FK_SanPham_LoaiGiay");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.TaiKhoan1)
                    .HasColumnName("TaiKhoan")
                    .HasMaxLength(50);
            });
        }
    }
}