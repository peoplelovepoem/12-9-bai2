using System;
using System.Collections.Generic;

namespace CSLab02
{
    struct HangHoa
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public double DonGia;

        public HangHoa(int maMH, string tenMH, int soLuong, double donGia)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public double TinhThanhTien()
        {
            return SoLuong * DonGia;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} cai x {3} = {4}", MaMH, TenMH, SoLuong, DonGia, TinhThanhTien());
        }
    }

    class Program
    {
        static void ThemMatHang(List<HangHoa> ds)
        {
            Console.WriteLine("\n--- NHAP THONG TIN MAT HANG ---");
            Console.Write("Nhap ma mat hang (so nguyen): ");
            int ma = int.Parse(Console.ReadLine());

            Console.Write("Nhap ten mat hang: ");
            string ten = Console.ReadLine();

            Console.Write("Nhap so luong: ");
            int sl = int.Parse(Console.ReadLine());

            Console.Write("Nhap don gia: ");
            double gia = double.Parse(Console.ReadLine());

            ds.Add(new HangHoa(ma, ten, sl, gia));
        }

        static bool TimMatHang(List<HangHoa> ds, int maCanTim)
        {
            foreach (HangHoa hh in ds)
            {
                if (hh.MaMH == maCanTim)
                {
                    return true;
                }
            }
            return false;
        }

        static void XuatDanhSach(List<HangHoa> ds)
        {
            Console.WriteLine("\n--- DANH SACH MAT HANG ---");
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach hien tai dang trong.");
                return;
            }

            foreach (HangHoa hh in ds)
            {
                Console.WriteLine(hh.ToString());
            }
        }

        static void XoaMatHang(List<HangHoa> ds, int maCanXoa)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaMH == maCanXoa)
                {
                    ds.RemoveAt(i);
                    Console.WriteLine($"Da xoa thanh cong mat hang co ma: {maCanXoa}");
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            List<HangHoa> danhSach = new List<HangHoa>();
            string luaChon;

            do
            {
                ThemMatHang(danhSach);
                Console.Write("Ban co muon tiep tuc nhap nua khong? (y/n): ");
                luaChon = Console.ReadLine().ToLower();
            } while (luaChon == "y");

            XuatDanhSach(danhSach);

            Console.Write("\nNhap ma mat hang can tim: ");
            int maTimKiem = int.Parse(Console.ReadLine());

            if (TimMatHang(danhSach, maTimKiem))
            {
                Console.WriteLine($"Tim thay mat hang mang ma so {maTimKiem}. Tien hanh xoa...");
                XoaMatHang(danhSach, maTimKiem);

                Console.WriteLine("\nDanh sach MAT HANG SAU KHI XOA:");
                XuatDanhSach(danhSach);
            }
            else
            {
                Console.WriteLine($"Khong tim thay mat hang nao co ma {maTimKiem} trong danh sach.");
            }

            Console.ReadLine();
        }
    }
}