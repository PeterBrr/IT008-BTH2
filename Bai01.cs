using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    public class Bai01
    {
        private static int month, year;
        public static void Run()
        {
            do
            {
                // 1. Nhập tháng và năm từ người dùng
                Console.Write("Nhập tháng và năm (mm/yyyy): ");
                string input = Console.ReadLine();

                string[] parts = input.Split('/');

                if (parts.Length != 2 ||
                    !int.TryParse(parts[0], out month) ||
                    !int.TryParse(parts[1], out year))
                {
                    Console.WriteLine("Định dạng không hợp lệ. Vui lòng nhập theo định dạng mm/yyyy.");
                    continue;
                }

                if (month < 1 || month > 12 || year < 1)
                {
                    Console.WriteLine("Lỗi: Tháng năm không hợp lệ");
                    continue; 
                }
                break;
            } while (true);

            Print();
        }

        public static void Print()
        {
            // 2. Lấy thông tin về ngày đầu tiên của tháng
            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            // 3. Lấy tổng số ngày trong tháng (tự động xử lý năm nhuận)
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // 4. Xác định "thứ" của ngày đầu tiên (Chủ nhật = 0, Thứ 2 = 1, ..., Thứ 7 = 6)
            int startingDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            // In tiêu đề Tháng/Năm
            Console.WriteLine($"Month: {month:00}/{year}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Sun   Mon   Tue   Wed   Thu   Fri   Sat");
            Console.WriteLine("-------------------------------------------");

            // 5. In các khoảng trắng ở đầu dòng cho tuần đầu tiên
            // Ví dụ: Nếu ngày 1 là thứ Sáu (giá trị 5), ta cần in 5 khoảng trắng cho các ngày trước đó
            for (int i = 0; i < startingDayOfWeek; i++)
            {
                Console.Write("      "); // 6 ký tự trắng để căn lề
            }

            // 6. Vòng lặp để in các ngày trong tháng
            for (int day = 1; day <= daysInMonth; day++)
            {
                // In ngày, căn lề trái trong 3 ký tự, theo sau là 3 khoảng trắng
                Console.Write($"{day,-3}   ");

                // Nếu là thứ Bảy thì xuống dòng mới
                if ((day + startingDayOfWeek) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            // Thêm một dòng trống ở cuối để giao diện đẹp hơn
            Console.WriteLine("\n-------------------------------------------");
        }
    }
}
