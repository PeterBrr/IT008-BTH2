using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int choice = -1;
            do
            {
                Console.WriteLine("------Menu------:");
                Console.WriteLine("1. Bài 1");
                Console.WriteLine("2. Bài 2");
                Console.WriteLine("3. Bài 3");
                Console.WriteLine("4. Bài 4");
                Console.WriteLine("5. Bài 5");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn bài để chạy: ");
               
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        Bai01.Run();
                        break;

                    case 2:
                        Bai02.Run();
                        break;

                    case 3:
                        Bai03.Run();
                        break;

                    case 4:
                        Bai04.Run();
                        break;

                    case 5:
                        Bai05.Run();
                        break;

                    case 0:
                        Console.WriteLine("Thoát chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập số từ 0 đến 5.");
                        break;
                }
            } while (choice != 0);

        }
    }
}
