using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Bai04
    {
        // Tính Tổng, Hiệu, Tích, Thương của 2 phân số.
        private static void TinhToanHaiPhanSo()
        {
            // Sử dụng khối try-catch để xử lý ngoại lệ
            try
            {
                // Nhập phân số A và B
                PhanSo a = PhanSo.NhapPhanSo("Nhập phân số A");
                PhanSo b = PhanSo.NhapPhanSo("Nhập phân số B");

                // Hiển thị kết quả
                Console.WriteLine($"\n--- Kết quả tính toán (đã rút gọn) ---");
                Console.WriteLine($"A = {a} ; B = {b}");
                Console.WriteLine($"A + B = {a + b}");
                Console.WriteLine($"A - B = {a - b}");
                Console.WriteLine($"A * B = {a * b}");
                Console.WriteLine($"A / B = {a / b}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tạo đối tượng xử lý mảng phân số
            PhanSoArrayHandler arrayHandler = new PhanSoArrayHandler();
            int choice = -1; // Biến để lưu lựa chọn của người dùng

            do
            {
                // Hiển thị menu
                Console.WriteLine("\n======= MENU CHƯƠNG TRÌNH =======");
                Console.WriteLine("1. Tính Tổng, Hiệu, Tích, Thương của 2 phân số.");
                Console.WriteLine("2. Nhập vào một dãy phân số.");
                Console.WriteLine("3. Tìm phân số lớn nhất trong dãy.");
                Console.WriteLine("4. Sắp xếp dãy phân số tăng dần.");
                Console.WriteLine("0. Thoát chương trình.");
                Console.Write("Vui lòng nhập lựa chọn của bạn: ");

                // Đặt lại choice nếu nhập không hợp lệ
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                // Xử lý lựa chọn của người dùng
                switch (choice)
                {
                    case 1:
                        TinhToanHaiPhanSo();
                        break;

                    case 2:
                        arrayHandler.NhapDayPhanSo();
                        break;

                    case 3:
                        arrayHandler.TimPhanSoLonNhat();
                        break;

                    case 4:
                        arrayHandler.SapXepTangDan();
                        break;

                    case 0:
                        Console.WriteLine("Thoát chương trình");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 0 đến 4.");
                        break;
                }
            } while (choice != 0); // Tiếp tục hiển thị menu cho đến khi người dùng chọn thoát
        }
    }
}
