using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Bai05
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tạo đối tượng quản lý địa ốc
            QuanLyDiaOc ql = new QuanLyDiaOc();

            int choice = -1; // Biến để lưu lựa chọn của người dùng
            do
            {
                // Hiển thị menu
                Console.WriteLine("======= CHƯƠNG TRÌNH QUẢN LÝ ĐỊA ỐC ĐẠI PHÚ =======");
                Console.WriteLine("1. Nhập danh sách Bất Động Sản");
                Console.WriteLine("2. Xuất danh sách Bất Động Sản");
                Console.WriteLine("3. Xem tổng giá bán cho từng loại BĐS");
                Console.WriteLine("4. Lọc BĐS (Khu đất > 100m2 hoặc Nhà phố > 60m2 & xây từ 2019)");
                Console.WriteLine("5. Tìm kiếm Nhà phố/Chung cư nâng cao");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Vui lòng nhập lựa chọn của bạn: ");

                // Đặt lại choice nếu nhập không hợp lệ
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                try
                {
                    // Xử lý lựa chọn của người dùng
                    switch (choice)
                    {
                        case 1:
                            ql.NhapDanhSach();
                            break;

                        case 2:
                            ql.XuatDanhSach();
                            break;

                        case 3:
                            ql.TinhTongGiaBan();
                            break;

                        case 4:
                            ql.LocTheoYeuCau();
                            break;
                        case 5:
                            ql.TimKiemNangCao();
                            break;

                        case 0:
                            Console.WriteLine("Đang thoát chương trình...");
                            break;

                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nĐã xảy ra lỗi: {ex.Message}. Vui lòng thử lại.");
                }
            } while (choice != 0); // Tiếp tục hiển thị menu cho đến khi người dùng chọn thoát
        }
    }
}
