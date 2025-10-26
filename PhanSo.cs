using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    public class PhanSo : IComparable<PhanSo>
    {
        // Thuộc tính
        public int TuSo { get; private set; }
        public int MauSo { get; private set; }

        // Hàm khởi tạo
        public PhanSo(int tu = 0, int mau = 1)
        {
            // Kiểm tra mẫu số khác 0
            if (mau == 0)
            {
                throw new ArgumentException("Mẫu số không thể là 0.");
            }

            // Đảm bảo mẫu số luôn dương
            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }

            TuSo = tu;
            MauSo = mau;

            RutGon(); // Rút gọn phân số ngay sau khi khởi tạo
        }

        // Phương thức tính Ước số chung lớn nhất (GCD)
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Phương thức rút gọn phân số
        private void RutGon()
        {
            // Nếu tử số là 0, đặt mẫu số là 1
            if (TuSo == 0)
            {
                MauSo = 1;
                return;
            }

            int gcd = GCD(Math.Abs(TuSo), MauSo);
            TuSo /= gcd;
            MauSo /= gcd;
        }

        // Phương thức nhập phân số từ người dùng
        public static PhanSo NhapPhanSo(string prompt)
        {     
            Console.WriteLine(prompt);
            while (true) 
            {
                try
                {
                    Console.Write("  + Nhập tử số: ");
                    int tu = int.Parse(Console.ReadLine());

                    Console.Write("  + Nhập mẫu số: ");
                    int mau = int.Parse(Console.ReadLine());

                    return new PhanSo(tu, mau);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Dữ liệu nhập phải là số nguyên. Vui lòng nhập lại.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"LỖI: {ex.Message}. Vui lòng nhập lại.");
                }
            }
        }

        // Nạp chồng toán tử cộng
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mau = a.MauSo * b.MauSo;
            return new PhanSo(tu, mau);
        }

        // Nạp chồng toán tử trừ
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int tu = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
            int mau = a.MauSo * b.MauSo;
            return new PhanSo(tu, mau);
        }

        // Nạp chồng toán tử nhân
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int tu = a.TuSo * b.TuSo;
            int mau = a.MauSo * b.MauSo;
            return new PhanSo(tu, mau);
        }

        // Nạp chồng toán tử chia
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.TuSo == 0)
            {
                throw new DivideByZeroException("Không thể chia cho phân số có tử số bằng 0.");
            }
            int tu = a.TuSo * b.MauSo;
            int mau = a.MauSo * b.TuSo;
            return new PhanSo(tu, mau);
        }

        // Triển khai IComparable để so sánh phân số
        public int CompareTo(PhanSo other)
        {
            int left = this.TuSo * other.MauSo;
            int right = other.TuSo * this.MauSo;
            
            if(left < right) return -1;
            if(left > right) return 1;
            return 0;
        }

        // Ghi đè phương thức ToString để hiển thị phân số
        public override string ToString()
        {
            if(MauSo == 1)
            {
                return TuSo.ToString();
            }

            return $"{TuSo}/{MauSo}";
        }
    }
}
