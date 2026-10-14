# LAB02_OOP — Bài tập C# 1–10

## Tệp đi kèm
- `Lab02_OOP_Bai1-10.cs`: mã nguồn C# gộp các lớp và menu chạy thử bài tập.

## Yêu cầu
- Visual Studio 2022
- .NET SDK tương thích với framework của project (project hiện tại có thể đang dùng `net10.0`).

## Cách mở và chạy trong Visual Studio 2022

### Cách 1: Chạy trong project hiện có
1. Mở solution `Lab02_OOP` bằng Visual Studio 2022.
2. Sao lưu nội dung `Program.cs` hiện tại nếu cần.
3. Mở `Program.cs`, nhấn `Ctrl + A` và thay bằng nội dung trong `Lab02_OOP_Bai1-10.cs`.
4. Nếu các file `.cs` cũ vẫn chứa các lớp `SinhVien`, `SanPham`, `NhanVien`, `HinhChuNhat` hoặc `TaiKhoanNganHang`, hãy xóa các lớp trùng hoặc loại các file đó khỏi project để tránh lỗi khai báo trùng tên. Chỉ giữ **một bản khai báo cho mỗi lớp** và **một hàm `Main()`**.
5. Chọn **Build → Rebuild Solution**.
6. Chạy bằng **Ctrl + F5**.
7. Ở menu, nhập số bài từ `1` đến `10`, rồi nhấn Enter. Nhập `0` để thoát.

### Cách 2: Tạo project Console mới
1. Chọn **Create a new project** → **Console App** (C#).
2. Đặt tên project, ví dụ `Lab02_OOP_Gop`.
3. Chọn framework được cài trên máy.
4. Mở `Program.cs`, thay toàn bộ nội dung bằng mã trong `Lab02_OOP_Bai1-10.cs`.
5. Build và chạy bằng **Ctrl + F5**.

## Các mục trong menu
| Lựa chọn | Nội dung |
|---|---|
| 1 | Bài 1 — Khởi tạo và hiển thị sinh viên |
| 2 | Bài 2 — Constructor không tham số và có tham số |
| 3 | Bài 3 — Kiểm tra họ tên và điểm trung bình |
| 4 | Bài 4 — Tính tuổi và xếp loại học lực |
| 5 | Bài 5 — Danh sách sinh viên mẫu và tìm theo mã |
| 6 | Bài 6 — Sản phẩm và tính thành tiền |
| 7 | Bài 7 — Tài khoản ngân hàng, nạp/rút/chuyển tiền |
| 8 | Bài 8 — Nhân viên và tính lương |
| 9 | Bài 9 — Hình chữ nhật, tính chu vi/diện tích |
| 10 | Bài 10 — Quản lý sinh viên |
| 0 | Thoát chương trình |

## Ghi chú sử dụng
- Bài 5 có dữ liệu mẫu được nạp khi danh sách đang trống; nhập mã như `SV01`, `SV02`, `SV03` để thử tìm kiếm.
- Bài 10 sử dụng danh sách trong bộ nhớ khi chương trình đang chạy; dữ liệu không được lưu vào tệp hoặc cơ sở dữ liệu và sẽ mất khi thoát chương trình.
- Ngày sinh nhập theo định dạng `dd/MM/yyyy`, ví dụ `12/05/2005`.
- Điểm trung bình phải từ `0` đến `10`.
- Nếu cửa sổ Console còn mở sau khi chạy, hãy đóng hoặc nhấn phím theo lời nhắc trước khi build lại. Nếu báo file `.exe` đang bị khóa, dừng chương trình bằng **Shift + F5** hoặc kết thúc tiến trình `Lab02_OOP.exe` trong Task Manager rồi build lại.
- File này là bản gộp mã nguồn để tiện nộp/xem. Hãy đối chiếu đề `Lab02(1).pdf` để chắc chắn tên bài và yêu cầu chi tiết khớp tài liệu gốc; phần mô tả menu ở đây phản ánh cách triển khai trong file mã nguồn.
