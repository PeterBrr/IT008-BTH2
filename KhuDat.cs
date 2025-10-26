using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    // Lớp Khu Đất
    public class KhuDat
    {
        // Thuộc tính
        // Dùng public get để cho phép truy cập từ bên ngoài
        // Dùng protected set để chỉ cho phép lớp con hoặc lớp hiện tại gán giá trị
        public string DiaDiem { get; protected set; }
        public double GiaBan { get; protected set; }
        public double DienTich { get; protected set; }

        // Phương thức nhập thông tin khu đất
        // Dùng virtual để cho phép lớp con ghi đè nếu cần
        public virtual void Nhap()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập địa điểm: ");
            DiaDiem = Console.ReadLine();

            // Nhập và kiểm tra giá bán
            while (true)
            {
                Console.Write("Nhập giá bán (VND): ");
                if (double.TryParse(Console.ReadLine(), out double gia) && gia >= 0)
                {
                    GiaBan = gia;
                    break;
                }
                Console.WriteLine("Giá bán không hợp lệ. Vui lòng nhập lại.");
            }

            while (true)
            {
                Console.Write("Nhập diện tích (m2): ");
                if (double.TryParse(Console.ReadLine(), out double dt) && dt > 0)
                {
                    DienTich = dt;
                    break;
                }
                Console.WriteLine("Diện tích không hợp lệ. Vui lòng nhập lại.");
            }
        }

        // Phương thức xuất thông tin khu đất
        public virtual void Xuat()
        {
            Console.WriteLine("--- [Loại: Khu Đất] ---");
            Console.WriteLine($"Địa điểm: {DiaDiem}");
            Console.WriteLine($"Giá bán: {GiaBan:N0} VND");
            Console.WriteLine($"Diện tích: {DienTich:N2} m²");
        }
    }
}
