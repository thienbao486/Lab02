using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Lab02_OOP
{
    // BAI 1-5: LOP SINH VIEN
    public class SinhVien
    {
        public string MaSV { get; set; }

        private string _hoTen = "Chưa có";
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }

        public DateTime NgaySinh { get; set; }

        private double _diemTB;
        public double DiemTB
        {
            get { return _diemTB; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException(
                        "DiemTB", "Điểm phải nằm trong khoảng 0 đến 10.");
                _diemTB = value;
            }
        }

        // Bai 2: constructor khong tham so
        public SinhVien()
        {
            MaSV = "Chưa có";
            HoTen = "Chưa có";
            NgaySinh = DateTime.Today;
            DiemTB = 0;
        }

        // Bai 2: constructor co tham so
        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        // Bai 1: hien thi thong tin
        public void HienThi()
        {
            Console.WriteLine(
                "{0} - {1} - {2:dd/MM/yyyy} - {3:N2}",
                MaSV, HoTen, NgaySinh, DiemTB);
        }

        // Bai 4: tinh tuoi
        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi))
                tuoi--;
            return tuoi;
        }

        // Bai 4: xep loai
        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";
            return "Yếu";
        }
    }

    // BAI 6: SAN PHAM
    public class SanPham
    {
        public string MaSP { get; set; }

        private string _tenSP = "";
        public string TenSP
        {
            get { return _tenSP; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sản phẩm không được rỗng.");
                _tenSP = value.Trim();
            }
        }

        private decimal _donGia;
        public decimal DonGia
        {
            get { return _donGia; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Đơn giá không được âm.");
                _donGia = value;
            }
        }

        private int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng không được âm.");
                _soLuong = value;
            }
        }

        public SanPham(string maSP, string tenSP, decimal donGia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public decimal TinhThanhTien()
        {
            return DonGia * SoLuong;
        }

        public void HienThi()
        {
            Console.WriteLine($"Mã SP: {MaSP} | Tên: {TenSP} | Đơn giá: {DonGia:N0} | Số lượng: {SoLuong} | Thành tiền: {TinhThanhTien():N0}");
        }
    }

    // BAI 7: TAI KHOAN NGAN HANG
    public class TaiKhoanNganHang
    {
        public string SoTaiKhoan { get; set; }
        public string ChuTaiKhoan { get; set; }

        public decimal SoDu { get; private set; }

        public TaiKhoanNganHang(string soTaiKhoan, string chuTaiKhoan, decimal soDuBanDau)
        {
            if (soDuBanDau < 0)
                throw new ArgumentException("Số dư ban đầu không được âm.");
            SoTaiKhoan = soTaiKhoan;
            ChuTaiKhoan = chuTaiKhoan;
            SoDu = soDuBanDau;
        }

        public void NapTien(decimal soTien)
        {
            if (soTien <= 0) throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");
            SoDu += soTien;
        }

        public void RutTien(decimal soTien)
        {
            if (soTien <= 0) throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
            if (soTien > SoDu) throw new ArgumentException("Số dư không đủ.");
            SoDu -= soTien;
        }

        public void ChuyenTien(TaiKhoanNganHang taiKhoanNhan, decimal soTien)
        {
            if (taiKhoanNhan == null) throw new ArgumentNullException(nameof(taiKhoanNhan));
            if (taiKhoanNhan == this) throw new ArgumentException("Không thể chuyển cho chính mình.");
            if (soTien <= 0) throw new ArgumentException("Số tiền chuyển phải lớn hơn 0.");
            if (soTien > SoDu) throw new ArgumentException("Số dư không đủ để chuyển.");

            SoDu -= soTien;
            taiKhoanNhan.SoDu += soTien;
        }

        public void HienThi()
        {
            Console.WriteLine($"Số TK: {SoTaiKhoan} | Chủ TK: {ChuTaiKhoan} | Số dư: {SoDu:N0} đồng");
        }
    }

    // BAI 8: NHAN VIEN
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public decimal LuongCoBan { get; set; }
        public double HeSo { get; set; }
        public decimal PhuCap { get; set; }

        public NhanVien(string maNV, string hoTen, decimal luongCoBan, double heSo, decimal phuCap)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã nhân viên không được rỗng.");
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Họ tên không được rỗng.");
            if (luongCoBan < 0 || heSo < 0 || phuCap < 0)
                throw new ArgumentException("Thông tin lương không được âm.");

            MaNV = maNV;
            HoTen = hoTen.Trim();
            LuongCoBan = luongCoBan;
            HeSo = heSo;
            PhuCap = phuCap;
        }

        // Cong thuc trien khai: luong co ban * he so + phu cap
        public decimal TinhLuong()
        {
            return LuongCoBan * (decimal)HeSo + PhuCap;
        }

        public void HienThi()
        {
            Console.WriteLine($"{MaNV,-8} | {HoTen,-18} | Lương cơ bản: {LuongCoBan,12:N0} | Hệ số: {HeSo,4:N2} | Phụ cấp: {PhuCap,10:N0} | Tổng lương: {TinhLuong(),12:N0}");
        }
    }

    // BAI 9: HINH CHU NHAT
    public class HinhChuNhat
    {
        private double _chieuDai;
        private double _chieuRong;

        public double ChieuDai
        {
            get { return _chieuDai; }
            set
            {
                if (value <= 0) throw new ArgumentException("Chiều dài phải lớn hơn 0.");
                _chieuDai = value;
            }
        }

        public double ChieuRong
        {
            get { return _chieuRong; }
            set
            {
                if (value <= 0) throw new ArgumentException("Chiều rộng phải lớn hơn 0.");
                _chieuRong = value;
            }
        }

        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            ChieuDai = chieuDai;
            ChieuRong = chieuRong;
        }

        public double TinhChuVi() => 2 * (ChieuDai + ChieuRong);
        public double TinhDienTich() => ChieuDai * ChieuRong;
    }

    // CHUONG TRINH CHINH: CHI CO MOT HAM Main
    internal class Program
    {
        private static readonly List<SinhVien> DanhSachSinhVien = new List<SinhVien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n========== LAB 02 - OOP C# ==========");
                Console.WriteLine("1. Bài 1 - Khai báo lớp SinhVien");
                Console.WriteLine("2. Bài 2 - Constructor");
                Console.WriteLine("3. Bài 3 - Đóng gói và kiểm tra dữ liệu");
                Console.WriteLine("4. Bài 4 - Tính tuổi và xếp loại");
                Console.WriteLine("5. Bài 5 - Danh sách SinhVien và tìm theo mã");
                Console.WriteLine("6. Bài 6 - Lớp SanPham");
                Console.WriteLine("7. Bài 7 - Lớp TaiKhoanNganHang");
                Console.WriteLine("8. Bài 8 - Lớp NhanVien");
                Console.WriteLine("9. Bài 9 - Lớp HinhChuNhat");
                Console.WriteLine("10. Bài 10 - Ứng dụng quản lý sinh viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn bài: ");

                string chon = Console.ReadLine() ?? "";
                try
                {
                    switch (chon)
                    {
                        case "1": Bai1(); break;
                        case "2": Bai2(); break;
                        case "3": Bai3(); break;
                        case "4": Bai4(); break;
                        case "5": Bai5(); break;
                        case "6": Bai6(); break;
                        case "7": Bai7(); break;
                        case "8": Bai8(); break;
                        case "9": Bai9(); break;
                        case "10": Bai10(); break;
                        case "0": return;
                        default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }

                Console.WriteLine("\nNhấn Enter để quay lại menu...");
                Console.ReadLine();
            }
        }

        private static void Bai1()
        {
            Console.WriteLine("\n--- BAI 1: KHAI BAO LOP SINH VIEN ---");
            SinhVien sv = new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2);
            sv.HienThi();
        }

        private static void Bai2()
        {
            Console.WriteLine("\n--- BAI 2: CONSTRUCTOR ---");
            SinhVien macDinh = new SinhVien();
            SinhVien coThamSo = new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8);
            Console.WriteLine("Sinh viên tạo bằng constructor không tham số:");
            macDinh.HienThi();
            Console.WriteLine("Sinh viên tạo bằng constructor có tham số:");
            coThamSo.HienThi();
        }

        private static void Bai3()
        {
            Console.WriteLine("\n--- BAI 3: DONG GOI VA KIEM TRA DU LIEU ---");
            SinhVien sv = new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2);
            sv.HienThi();

            try { sv.DiemTB = 11; }
            catch (Exception ex) { Console.WriteLine("Kiểm tra điểm 11: " + ex.Message); }

            try { sv.HoTen = ""; }
            catch (Exception ex) { Console.WriteLine("Kiểm tra họ tên rỗng: " + ex.Message); }
        }

        private static void Bai4()
        {
            Console.WriteLine("\n--- BAI 4: TINH TUOI VA XEP LOAI ---");
            SinhVien sv = new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2);
            sv.HienThi();
            Console.WriteLine("Tuổi: " + sv.TinhTuoi());
            Console.WriteLine("Xếp loại: " + sv.XepLoai());
        }

        private static void ThemDuLieuMauNeuCan()
        {
            if (DanhSachSinhVien.Count > 0) return;
            DanhSachSinhVien.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2));
            DanhSachSinhVien.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));
            DanhSachSinhVien.Add(new SinhVien("SV03", "Lê Chi", new DateTime(2004, 12, 20), 9.1));
            DanhSachSinhVien.Add(new SinhVien("SV04", "Phạm Dũng", new DateTime(2005, 2, 15), 7.5));
            DanhSachSinhVien.Add(new SinhVien("SV05", "Hoàng Hà", new DateTime(2005, 7, 8), 5.5));
        }

        private static void Bai5()
        {
            Console.WriteLine("\n--- BAI 5: DANH SACH SINH VIEN ---");
            ThemDuLieuMauNeuCan();
            foreach (SinhVien sv in DanhSachSinhVien) sv.HienThi();

            Console.Write("Mã cần tìm: ");
            string ma = Console.ReadLine() ?? "";
            SinhVien? ketQua = DanhSachSinhVien.Find(
                x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(ketQua == null ? "Không tìm thấy" : ketQua.HoTen);
        }

        private static void Bai6()
        {
            Console.WriteLine("\n--- BAI 6: SAN PHAM ---");
            SanPham sp = new SanPham("SP01", "Bàn phím", 250000m, 3);
            sp.HienThi();
        }

        private static void Bai7()
        {
            Console.WriteLine("\n--- BAI 7: TAI KHOAN NGAN HANG ---");
            TaiKhoanNganHang tk1 = new TaiKhoanNganHang("1001", "Nguyễn An", 2000000m);
            TaiKhoanNganHang tk2 = new TaiKhoanNganHang("1002", "Trần Bình", 500000m);

            Console.WriteLine("Ban đầu:");
            tk1.HienThi();
            tk2.HienThi();

            tk1.NapTien(500000m);
            tk1.RutTien(200000m);
            tk1.ChuyenTien(tk2, 300000m);

            Console.WriteLine("Sau giao dịch:");
            tk1.HienThi();
            tk2.HienThi();
        }

        private static void Bai8()
        {
            Console.WriteLine("\n--- BAI 8: NHAN VIEN ---");
            Console.WriteLine("Mã NV   | Họ tên             | Lương cơ bản | Hệ số | Phụ cấp | Tổng lương");
            NhanVien nv1 = new NhanVien("NV01", "Nguyễn An", 5000000m, 2.2, 500000m);
            NhanVien nv2 = new NhanVien("NV02", "Trần Bình", 4800000m, 1.8, 300000m);
            nv1.HienThi();
            nv2.HienThi();
            Console.WriteLine("Công thức triển khai: Lương cơ bản * Hệ số + Phụ cấp.");
        }

        private static void Bai9()
        {
            Console.WriteLine("\n--- BAI 9: HINH CHU NHAT ---");
            HinhChuNhat hcn = new HinhChuNhat(10, 5);
            Console.WriteLine("Chiều dài: " + hcn.ChieuDai);
            Console.WriteLine("Chiều rộng: " + hcn.ChieuRong);
            Console.WriteLine("Chu vi: " + hcn.TinhChuVi());
            Console.WriteLine("Diện tích: " + hcn.TinhDienTich());
        }

        private static void Bai10()
        {
            while (true)
            {
                Console.WriteLine("\n--- BAI 10: QUAN LY SINH VIEN ---");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Sửa sinh viên");
                Console.WriteLine("3. Xóa sinh viên");
                Console.WriteLine("4. Tìm kiếm theo mã");
                Console.WriteLine("5. Sắp xếp theo mã");
                Console.WriteLine("6. Sắp xếp theo họ tên");
                Console.WriteLine("7. Hiển thị danh sách");
                Console.WriteLine("8. Thống kê điểm");
                Console.WriteLine("0. Quay lại menu bài tập");
                Console.Write("Chọn chức năng: ");

                string chon = Console.ReadLine() ?? "";
                if (chon == "0") return;

                try
                {
                    switch (chon)
                    {
                        case "1": ThemSinhVien(); break;
                        case "2": SuaSinhVien(); break;
                        case "3": XoaSinhVien(); break;
                        case "4": TimSinhVien(); break;
                        case "5":
                            DanhSachSinhVien.Sort((a, b) => string.Compare(a.MaSV, b.MaSV, StringComparison.OrdinalIgnoreCase));
                            HienThiDanhSach();
                            break;
                        case "6":
                            DanhSachSinhVien.Sort((a, b) => string.Compare(a.HoTen, b.HoTen, StringComparison.CurrentCulture));
                            HienThiDanhSach();
                            break;
                        case "7": HienThiDanhSach(); break;
                        case "8": ThongKe(); break;
                        default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }

        private static void ThemSinhVien()
        {
            Console.Write("Mã sinh viên: ");
            string ma = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                Console.WriteLine("Mã sinh viên không được rỗng.");
                return;
            }
            if (DanhSachSinhVien.Exists(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Mã sinh viên đã tồn tại.");
                return;
            }

            Console.Write("Họ tên: ");
            string ten = Console.ReadLine() ?? "";

            Console.Write("Ngày sinh (dd/MM/yyyy): ");
            string ngayText = Console.ReadLine() ?? "";
            if (!DateTime.TryParseExact(ngayText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                Console.WriteLine("Ngày sinh không hợp lệ.");
                return;
            }

            double diem = NhapDiem();
            DanhSachSinhVien.Add(new SinhVien(ma, ten, ngaySinh, diem));
            Console.WriteLine("Thêm sinh viên thành công.");
        }

        private static void SuaSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần sửa: ");
            string ma = Console.ReadLine() ?? "";
            SinhVien? sv = DanhSachSinhVien.Find(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            Console.Write("Họ tên mới: ");
            string ten = Console.ReadLine() ?? "";
            Console.Write("Ngày sinh mới (dd/MM/yyyy): ");
            string ngayText = Console.ReadLine() ?? "";
            if (!DateTime.TryParseExact(ngayText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                Console.WriteLine("Ngày sinh không hợp lệ.");
                return;
            }

            double diem = NhapDiem();
            sv.HoTen = ten;
            sv.NgaySinh = ngaySinh;
            sv.DiemTB = diem;
            Console.WriteLine("Cập nhật thành công.");
        }

        private static void XoaSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string ma = Console.ReadLine() ?? "";
            SinhVien? sv = DanhSachSinhVien.Find(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }
            DanhSachSinhVien.Remove(sv);
            Console.WriteLine("Xóa sinh viên thành công.");
        }

        private static void TimSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string ma = Console.ReadLine() ?? "";
            SinhVien? sv = DanhSachSinhVien.Find(s => s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }
            sv.HienThi();
            Console.WriteLine("Tuổi: " + sv.TinhTuoi());
            Console.WriteLine("Xếp loại: " + sv.XepLoai());
        }

        private static void HienThiDanhSach()
        {
            if (DanhSachSinhVien.Count == 0)
            {
                Console.WriteLine("Danh sách đang trống.");
                return;
            }
            foreach (SinhVien sv in DanhSachSinhVien) sv.HienThi();
        }

        private static double NhapDiem()
        {
            while (true)
            {
                Console.Write("Điểm trung bình (0-10): ");
                string input = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem)
                    && diem >= 0 && diem <= 10)
                    return diem;
                Console.WriteLine("Điểm không hợp lệ. Vui lòng nhập lại.");
            }
        }

        private static void ThongKe()
        {
            if (DanhSachSinhVien.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu để thống kê.");
                return;
            }

            Console.WriteLine("Số sinh viên: " + DanhSachSinhVien.Count);
            Console.WriteLine("Điểm trung bình chung: " + DanhSachSinhVien.Average(s => s.DiemTB).ToString("N2"));
            Console.WriteLine("Điểm cao nhất: " + DanhSachSinhVien.Max(s => s.DiemTB).ToString("N2"));
            Console.WriteLine("Điểm thấp nhất: " + DanhSachSinhVien.Min(s => s.DiemTB).ToString("N2"));
        }
    }
}
