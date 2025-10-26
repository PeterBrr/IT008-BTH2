using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    // Xử lý mảng phân số
    public class PhanSoArrayHandler
    {
        private PhanSo[] _mangPhanSo; // Mảng phân số

        // Nhập dãy phân số
        public void NhapDayPhanSo()
        {
            int n; // Số lượng phân số

            // Nhập số lượng phân số với kiểm tra hợp lệ
            while (true)
            {
                Console.Write("Bạn muốn nhập bao nhiêu phân số: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    break; 
                }
                Console.WriteLine("Lỗi: Số lượng phải là một số nguyên lớn hơn 0.");
            }

            // Khởi tạo mảng phân số
            _mangPhanSo = new PhanSo[n];

            // Nhập từng phân số
            for (int i = 0; i < n; i++)
            {
                // Gọi thẳng phương thức static từ lớp PhanSo
                _mangPhanSo[i] = PhanSo.NhapPhanSo($"Nhập phân số thứ {i + 1}");
            }
        }

        // Kiểm tra xem mảng phân số đã được khởi tạo chưa
        private bool CheckInitialized()
        {
            if (_mangPhanSo == null || _mangPhanSo.Length == 0)
            {
                Console.WriteLine("Loi: Mang phan so chua duoc nhap. Vui long chon chuc nang 2 truoc.");
                return false;
            }
            return true;
        }

        // Tìm phân số lớn nhất trong mảng
        public void TimPhanSoLonNhat()
        {
            if (!CheckInitialized()) return; // Kiểm tra mảng đã được khởi tạo chưa

            PhanSo max = _mangPhanSo.Max(); // Sử dụng LINQ để tìm phân số lớn nhất
            // Hiển thị kết quả
            Console.WriteLine($"Phan so lon nhat trong day la: {max}");
        }

        // Sắp xếp mảng phân số theo thứ tự tăng dần
        public void SapXepTangDan()
        {
            if (!CheckInitialized()) return;

            Array.Sort(_mangPhanSo); // Sắp xếp mảng sử dụng IComparable đã được định nghĩa trong lớp PhanSo

            // Hiển thị mảng sau khi sắp xếp
            Console.WriteLine("Day phan so sau khi sap xep tang dan:");
            Console.WriteLine(string.Join(" ; ",(object[]) _mangPhanSo));
            //Console.WriteLine(string.Join(" ; ", _mangPhanSo.Select(ps => ps.ToString())));
        }
    }
}
