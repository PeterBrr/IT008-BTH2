using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    public class QuanLyDiaOc
    {
        // Danh sách Bất Động Sản
        // Dùng KhuDat làm kiểu cơ sở để lưu trữ tất cả các loại BĐS
        private List<KhuDat> _danhSachBDS = new List<KhuDat>();

        // Nhập danh sách BĐS
        public void NhapDanhSach()
        {
            Console.WriteLine("--- NHẬP DANH SÁCH BẤT ĐỘNG SẢN ---");
            Console.Write("Bạn muốn nhập bao nhiêu BĐS: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập BĐS thứ {i + 1} ---");
                Console.WriteLine("Chọn loại BĐS: ");
                Console.WriteLine("1. Khu Đất");
                Console.WriteLine("2. Nhà Phố");
                Console.WriteLine("3. Chung Cư");
                Console.Write("Lựa chọn của bạn: ");
                string choice = Console.ReadLine();

                KhuDat bds;

                switch (choice)
                {
                    case "2":
                        bds = new NhaPho();
                        break;
                    case "3":
                        bds = new ChungCu();
                        break;
                    default: 
                        bds = new KhuDat();
                        break;
                }

                bds.Nhap(); // Gọi phương thức Nhap tương ứng
                _danhSachBDS.Add(bds);
            }
        }

        // Xuất danh sách BĐS
        public void XuatDanhSach()
        {
            Console.WriteLine("--- XUẤT DANH SÁCH BẤT ĐỘNG SẢN ---");
            if (_danhSachBDS.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }

            foreach (var bds in _danhSachBDS)
            {
                bds.Xuat(); // Gọi phương thức Xuat tương ứng
                Console.WriteLine("--------------------------------");
            }
        }

        // Tính tổng giá bán theo từng loại BĐS
        public void TinhTongGiaBan()
        {
            Console.WriteLine("--- TỔNG GIÁ BÁN THEO TỪNG LOẠI ---");

            // Kiểm tra danh sách rỗng
            if (_danhSachBDS.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }

            // Tính tổng giá bán cho từng loại BĐS
            // Dùng LINQ để lọc và tính tổng
            double tongGiaKhuDat = _danhSachBDS
                .Where(bds => bds.GetType() == typeof(KhuDat))
                .Sum(bds => bds.GiaBan); // Dùng GetType để chỉ lấy đúng KhuDat

            double tongGiaNhaPho = _danhSachBDS
                .Where(bds => bds is NhaPho)
                .Sum(bds => bds.GiaBan); // Dùng is để lấy cả lớp con

            double tongGiaChungCu = _danhSachBDS
                .Where(bds => bds is ChungCu)
                .Sum(bds => bds.GiaBan); // Dùng is để lấy cả lớp con

            // Hiển thị kết quả
            Console.WriteLine($"Tổng giá bán [Khu Đất]:   {tongGiaKhuDat:N0} VND");
            Console.WriteLine($"Tổng giá bán [Nhà Phố]:   {tongGiaNhaPho:N0} VND");
            Console.WriteLine($"Tổng giá bán [Chung Cư]: {tongGiaChungCu:N0} VND");
            Console.WriteLine("------------------------------------------");

            double tongChung = tongGiaKhuDat + tongGiaNhaPho + tongGiaChungCu;
            Console.WriteLine($"TỔNG CỘNG (cả 3 loại): {tongChung:N0} VND");
        }

        // Lọc BĐS theo yêu cầu
        public void LocTheoYeuCau()
        {
            Console.WriteLine("--- DANH SÁCH BĐS THEO ĐIỀU KIỆN ---");
            Console.WriteLine("(Khu đất > 100m2 HOẶC Nhà phố > 60m2 và xây từ 2019)");

            bool found = false;
            foreach (var bds in _danhSachBDS)
            {
                // Kiểm tra điều kiện lọc
                // Dùng GetType để chỉ lấy đúng KhuDat
                if (bds.GetType() == typeof(KhuDat) && bds.DienTich > 100)
                {
                    bds.Xuat();
                    Console.WriteLine("--------------------------------");
                    found = true;
                }
                // Dùng is để kiểm tra Nhà Phố
                else if (bds is NhaPho np)
                {
                    if (np.DienTich > 60 && np.NamXayDung >= 2019)
                    {
                        np.Xuat();
                        Console.WriteLine("--------------------------------");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy BĐS nào phù hợp điều kiện.");
            }
        }

        // Tìm kiếm Nhà phố / Chung cư nâng cao
        public void TimKiemNangCao()
        {           
            Console.WriteLine("--- TÌM KIẾM NHÀ PHỐ / CHUNG CƯ ---");
            Console.Write("Nhập địa điểm cần tìm: ");
            string diaDiemTim = Console.ReadLine();

            Console.Write("Nhập giá bán tối đa (VND): ");
            double giaMax = double.Parse(Console.ReadLine());

            Console.Write("Nhập diện tích tối thiểu (m2): ");
            double dienTichMin = double.Parse(Console.ReadLine());

            Console.WriteLine("\n--- KẾT QUẢ TÌM KIẾM ---");

            bool found = false;
            foreach (var bds in _danhSachBDS)
            {
                // Chỉ tìm Nhà phố hoặc Chung cư
                if (bds.GetType() == typeof(KhuDat))
                {
                    continue; 
                }

                // Kiểm tra các điều kiện tìm kiếm
                bool matchDiaDiem = bds.DiaDiem.IndexOf(diaDiemTim, StringComparison.OrdinalIgnoreCase) >= 0;

                bool matchGia = bds.GiaBan <= giaMax;

                bool matchDienTich = bds.DienTich >= dienTichMin;

                if (matchDiaDiem && matchGia && matchDienTich)
                {
                    bds.Xuat();
                    Console.WriteLine("--------------------------------");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy BĐS nào phù hợp yêu cầu.");
            }
        }
    }
}
