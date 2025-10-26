using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    public class Bai02
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Yêu cầu người dùng nhập đường dẫn thư mục
            Console.Write("Nhập đường dẫn thư mục (ví dụ D:\\ hoặc C:\\Users): ");
            string path = Console.ReadLine();

            // Xử lý trường hợp người dùng chỉ nhập ổ đĩa (ví dụ "D:")
            if (string.IsNullOrEmpty(path) && path.Length == 2 && path[1] == ':')
            {
                path += '\\';
            }

            // Tạo đối tượng DirectoryLister và liệt kê nội dung thư mục
            DirectoryLister lister = new DirectoryLister();
            lister.ListContents(path);
        }
    }
}
