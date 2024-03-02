using System;
using System.Collections.Generic;

public class DuocPham
{
    public string Ten { get; set; }
    public double SoLuong { get; set; }
    public double DonViTinh { get; set; }

    public DuocPham(string ten, double soLuong, double donViTinh)
    {
        Ten = ten;
        SoLuong = soLuong;
        DonViTinh = donViTinh;
    }
}

public enum DanhMucThuoc
{
    ThuocDau,
    ThuocHaSot,
    ThuocKhangSinh
}

public class Thuoc
{
    public string Ten { get; set; }
    public double SoLuong { get; set; }
    public decimal GiaBan { get; set; }
    public DanhMucThuoc DanhMuc { get; set; }
    public List<DuocPham> DuocPhams { get; set; }

    public Thuoc(string ten, double soLuong, decimal giaBan, DanhMucThuoc danhMuc)
    {
        Ten = ten;
        SoLuong = soLuong;
        GiaBan = giaBan;
        DanhMuc = danhMuc;
        DuocPhams = new List<DuocPham>();
    }
}

public class QuanLyThuoc
{
    private List<Thuoc> danhSachThuoc;

    public QuanLyThuoc()
    {
        danhSachThuoc = new List<Thuoc>();
    }

    public void ThemThuoc(Thuoc thuoc)
    {
        danhSachThuoc.Add(thuoc);
    }

    public void HienThiDanhSachTheoDanhMuc(DanhMucThuoc danhMuc)
    {
        var danhSachTheoDanhMuc = danhSachThuoc.FindAll(t => t.DanhMuc == danhMuc);
        foreach (var thuoc in danhSachTheoDanhMuc)
        {
            Console.WriteLine($"Tên: {thuoc.Ten}, Số lượng: {thuoc.SoLuong}, Giá bán: {thuoc.GiaBan:C}");
        }
    }

    public void HienThiChiTietThuoc(string tenThuoc)
    {
        var thuoc = danhSachThuoc.Find(t => t.Ten.Equals(tenThuoc, StringComparison.OrdinalIgnoreCase));
        if (thuoc != null)
        {
            Console.WriteLine($"Tên: {thuoc.Ten}, Số lượng: {thuoc.SoLuong}, Giá bán: {thuoc.GiaBan:C}");
            Console.WriteLine("Danh sách dược phẩm bên trong:");
            foreach (var duocPham in thuoc.DuocPhams)
            {
                Console.WriteLine($" - {duocPham.Ten}: {duocPham.SoLuong} mg");
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy thuốc.");
        }
    }

    public void TimKiemThuoc(string tenThuoc)
    {
        var ketQuaTimKiem = danhSachThuoc.Find(t => t.Ten.Equals(tenThuoc, StringComparison.OrdinalIgnoreCase));
        if (ketQuaTimKiem != null)
        {
            Console.WriteLine($"Tên: {ketQuaTimKiem.Ten}, Số lượng: {ketQuaTimKiem.SoLuong}, Giá bán: {ketQuaTimKiem.GiaBan:C}");
        }
        else
        {
            Console.WriteLine("Không tìm thấy thuốc.");
        }
    }

    public void CapNhatThongTinThuoc(string tenThuoc, double soLuongMoi, decimal giaBanMoi, List<DuocPham> duocPhamsMoi)
    {
        var thuoc = danhSachThuoc.Find(t => t.Ten.Equals(tenThuoc, StringComparison.OrdinalIgnoreCase));
        if (thuoc != null)
        {
            thuoc.SoLuong = soLuongMoi;
            thuoc.GiaBan = giaBanMoi;
            thuoc.DuocPhams = duocPhamsMoi;
            Console.WriteLine("Cập nhật thông tin thuốc thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy thuốc.");
        }
    }

    public void XoaThuoc(string tenThuoc)
    {
        var thuoc = danhSachThuoc.Find(t => t.Ten.Equals(tenThuoc, StringComparison.OrdinalIgnoreCase));
        if (thuoc != null)
        {
            danhSachThuoc.Remove(thuoc);
            Console.WriteLine("Xóa thuốc thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy thuốc.");
        }
    }
}

class Program
{
    static void Main()
    {
        QuanLyThuoc quanLyThuoc = new QuanLyThuoc();

        Thuoc thuoc1 = new Thuoc("Paracetamol", 100, 10.5m, DanhMucThuoc.ThuocDau);
        thuoc1.DuocPhams.Add(new DuocPham("Paracetamol 500", 50, 500));
        quanLyThuoc.ThemThuoc(thuoc1);

        Console.WriteLine("Danh sách thuốc đau:");
        quanLyThuoc.HienThiDanhSachTheoDanhMuc(DanhMucThuoc.ThuocDau);

        Console.WriteLine("\nChi tiết thuốc Paracetamol:");
        quanLyThuoc.HienThiChiTietThuoc("Paracetamol");

        Console.WriteLine("\nTìm kiếm thuốc Ibuprofen:");
        quanLyThuoc.TimKiemThuoc("Ibuprofen");

        Console.WriteLine("\nCập nhật thông tin thuốc Paracetamol:");
        quanLyThuoc.CapNhatThongTinThuoc("Paracetamol", 80, 12.0m, new List<DuocPham> { new DuocPham("Paracetamol 500", 40, 500) });
        quanLyThuoc.HienThiDanhSachTheoDanhMuc(DanhMucThuoc.ThuocDau);

        Console.WriteLine("\nXóa thuốc Paracetamol:");
        quanLyThuoc.XoaThuoc("Paracetamol");
        quanLyThuoc.HienThiDanhSachTheoDanhMuc(DanhMucThuoc.ThuocDau);
    }
}
