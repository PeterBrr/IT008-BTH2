using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    public class MatrixHandler
    {
        private int[,] _matrix;
        private int _rows;
        private int _cols;
        private bool _isInitialized = false; // Biến để kiểm tra ma trận đã được nhập hay chưa

        // Kiểm tra số nguyên tố
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Nhập số nguyên với kiểm tra hợp lệ
        private int GetValidInterger(string prompt, int min = int.MinValue)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number >= min)
                {
                    return number;
                }
                Console.WriteLine($"Lỗi: Vui lòng nhập một số nguyên hợp lệ (>= {min}).");
            }
        }

        // Nhập ma trận
        public void InputMatrix()
        {
            _rows = GetValidInterger("Nhập số dòng: ", 1);
            _cols = GetValidInterger("Nhập số cột: ", 1);

            _matrix = new int[_rows, _cols];

            Console.WriteLine("Nhập các phần tử của ma trận:");
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _matrix[i, j] = GetValidInterger($"Phần tử [{i},{j}]: ");
                }
            }
            _isInitialized = true; // Đánh dấu ma trận đã được nhập
        }

        // Xuất ma trận
        public void OutputMatrix()
        {
            if (!_isInitialized)
            {
                Console.WriteLine("Ma trận chưa được khởi tạo. Vui lòng nhập ma trận trước.");
                return;
            }

            Console.WriteLine("Ma trận đã nhập:");
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    // Xuất với định dạng căn lề
                    Console.Write($"{_matrix[i, j], 6}");
                }
                Console.WriteLine();
            }
        }

        // Tìm kiếm phần tử
        public void SearchElement(int valueToFind)
        {
            if (!_isInitialized)
            {
                Console.WriteLine("Lỗi: Ma trận chưa được nhập. Vui lòng chọn chức năng 1 trước.");
                return;
            }

            bool found = false;
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (_matrix[i, j] == valueToFind)
                    {
                        Console.WriteLine($"Tìm thấy tại vị trí: [Dòng {i}, Cột {j}]");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"Không tìm thấy giá trị {valueToFind} trong ma trận.");
            }
        }

        // Xuất các số nguyên tố trong ma trận
        public void PrintPrimes()
        {
            if (!_isInitialized)
            {
                Console.WriteLine("Lỗi: Ma trận chưa được nhập. Vui lòng chọn chức năng 1 trước.");
                return;
            }
            
            List<int> primes = new List<int>();
            for(int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (IsPrime(_matrix[i, j]))
                    {
                        primes.Add(_matrix[i, j]);
                    }
                }
            }

            if(primes.Count == 0)
            {
                Console.WriteLine("Không có số nguyên tố trong ma trận.");
            }
            else
            {
                Console.WriteLine("Các số nguyên tố trong ma trận:");
                Console.WriteLine(string.Join(", ", primes));
            }
        }

        // Tìm dòng có nhiều số nguyên tố nhất
        public void FindRowWithMostPrimes()
        {
            if (!_isInitialized)
            {
                Console.WriteLine("Lỗi: Ma trận chưa được nhập. Vui lòng chọn chức năng 1 trước.");
                return;
            }

            int maxPrimeCount = 0;
            int[] primeCountsPerRow = new int[_rows]; // Mảng lưu số lượng số nguyên tố cho mỗi dòng

            // Đếm số lượng số nguyên tố cho mỗi dòng
            for (int i = 0; i < _rows; i++)
            {
                int primeCount = 0;
                for (int j = 0; j < _cols; j++)
                {
                    if (IsPrime(_matrix[i, j]))
                    {
                        primeCount++;
                    }
                }
                primeCountsPerRow[i] = primeCount;

                // Cập nhật số lượng số nguyên tố lớn nhất
                if (primeCount > maxPrimeCount)
                {
                    maxPrimeCount = primeCount;
                }
            }

            // Hiển thị kết quả
            if (maxPrimeCount == 0)
            {
                Console.WriteLine("Không có hàng nào chứa số nguyên tố.");
            }
            else
            {
                Console.WriteLine($"Số lượng số nguyên tố nhiều nhất trên một dòng là: {maxPrimeCount}");
                Console.WriteLine("Các dòng có nhiều số nguyên tố nhất là:");
                for (int i = 0; i < _rows; i++)
                {
                    if (primeCountsPerRow[i] == maxPrimeCount)
                    {
                        Console.WriteLine($"- Dòng {i}");
                    }
                }
            }
        }
    }
}
