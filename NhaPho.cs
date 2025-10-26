using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    // Lớp Nhà Phố kế thừa từ Khu Đất
    public class NhaPho : KhuDat
    {
        public int NamXayDung { get; protected set; }
        public int SoTang { get; protected set; }

        // Ghi đè phương thức Nhập để thêm thông tin riêng cho Nhà Phố
        public override void Nhap()
        {
            base.Nhap(); // Gọi phương thức Nhập của lớp cha để nhập các thuộc tính chung

            // Nhập và kiểm tra năm xây dựng
            while (true)
            {
                Console.Write("Nhập năm xây dựng: ");
                if (int.TryParse(Console.ReadLine(), out int nam) && nam > 0)
                {
                    NamXayDung = nam;
                    break;
                }
                Console.WriteLine("Năm xây dựng không hợp lệ. Vui lòng nhập lại.");
            }
            while (true)
            {
                Console.Write("Nhập số tầng: ");
                if (int.TryParse(Console.ReadLine(), out int tang) && tang > 0)
                {
                    SoTang = tang;
                    break;
                }
                Console.WriteLine("Số tầng không hợp lệ. Vui lòng nhập lại.");
            }
        }

        // Ghi đè phương thức Xuất để hiển thị thông tin riêng cho Nhà Phố
        public override void Xuat()
        {
            Console.WriteLine("--- [Loại: Nhà Phố] ---");
            Console.WriteLine($"Địa điểm: {DiaDiem}");
            Console.WriteLine($"Giá bán: {GiaBan:N0} VND");
            Console.WriteLine($"Diện tích: {DienTich} m2");
            Console.WriteLine($"Năm xây dựng: {NamXayDung}");
            Console.WriteLine($"Số tầng: {SoTang}");
        }
    }
}
