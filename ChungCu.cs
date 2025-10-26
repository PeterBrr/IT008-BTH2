using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    // Lớp Chung Cư kế thừa từ Khu Đất
    public class ChungCu : KhuDat
    {
        public int Tang { get; protected set; }

        // Ghi đè phương thức Nhập để thêm thông tin riêng cho Chung Cư
        public override void Nhap()
        {
            base.Nhap(); // Gọi phương thức Nhập của lớp cha để nhập các thuộc tính chung

            // Nhập và kiểm tra tầng
            while (true)
            {
                Console.Write("Nhập tầng: ");
                if (int.TryParse(Console.ReadLine(), out int tang) && tang > 0)
                {
                    Tang = tang;
                    break;
                }
                Console.WriteLine("Tầng không hợp lệ. Vui lòng nhập lại.");
            }
        }

        // Ghi đè phương thức Xuất để hiển thị thông tin riêng cho Chung Cư
        public override void Xuat()
        {
            Console.WriteLine("--- [Loại: Chung Cư] ---");
            Console.WriteLine($"Địa điểm: {DiaDiem}");
            Console.WriteLine($"Giá bán: {GiaBan:N0} VND");
            Console.WriteLine($"Diện tích: {DienTich} m2");
            Console.WriteLine($"Tầng: {Tang}");
        }
    }
}
