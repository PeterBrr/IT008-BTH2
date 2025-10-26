using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Bai03
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            MatrixHandler handler = new MatrixHandler(); // Tạo đối tượng MatrixHandler để xử lý ma trận
            int choice = -1; // Biến để lưu lựa chọn của người dùng

            do
            {
                // Hiển thị menu
                Console.WriteLine("\n--- CHƯƠNG TRÌNH XỬ LÝ MA TRẬN ---");
                Console.WriteLine("1. Nhập ma trận");
                Console.WriteLine("2. Xuất ma trận");
                Console.WriteLine("3. Tìm kiếm một phần tử");
                Console.WriteLine("4. Xuất các số nguyên tố");
                Console.WriteLine("5. Dòng có nhiều số nguyên tố nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Vui lòng nhập lựa chọn của bạn: ");

                // Đặt lại choice nếu nhập không hợp lệ
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1; 
                }

                Console.WriteLine();

                // Xử lý lựa chọn của người dùng
                switch (choice)
                {
                    case 1:
                        handler.InputMatrix();
                        break;

                    case 2:
                        handler.OutputMatrix();
                        break;

                    case 3:
                        Console.Write("Nhập giá trị bạn muốn tìm: ");
                        if (int.TryParse(Console.ReadLine(), out int valueToFind))
                        {
                            handler.SearchElement(valueToFind);
                        }
                        else
                        {
                            Console.WriteLine("Giá trị tìm kiếm không hợp lệ.");
                        }
                        break;

                    case 4:
                        handler.PrintPrimes();
                        break;

                    case 5:
                        handler.FindRowWithMostPrimes();
                        break;

                    case 0:
                        Console.WriteLine("Thoát chương trình");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 0 đến 5.");
                        break;
                }
            } while (choice != 0);
        }
    }
}
