using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Management;

namespace BTH2
{
    public class DirectoryLister
    {
        // Phương thức liệt kê nội dung thư mục
        public void ListContents(string path)
        {
            DirectoryInfo dirInfo;

            // Kiểm tra tính hợp lệ của đường dẫn
            try
            {
                dirInfo = new DirectoryInfo(path);
                if(!dirInfo.Exists)
                {
                    Console.WriteLine("Thư mục không tồn tại.");
                    return;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Đường dẫn không hợp lệ.");
                return;
            }

            // Bắt đầu liệt kê nội dung thư mục
            try
            {
                // Lấy thông tin ổ đĩa
                string rootPath = dirInfo.Root.FullName;
                DriveInfo drive = new DriveInfo(rootPath);
                Console.WriteLine($"\n Volume in drive {drive.Name[0]} is {drive.VolumeLabel}");

                // Lấy số serial của ổ đĩa
                string serialNumber = GetVolumeSerialNumber(drive.Name);
                if (!string.IsNullOrEmpty(serialNumber))
                {
                    Console.WriteLine($" Volume Serial Number is {serialNumber}\n");
                }
                Console.WriteLine($" Directory of {dirInfo.FullName}\n");

                // Lấy tất cả các mục trong thư mục
                FileSystemInfo[] items = dirInfo.GetFileSystemInfos();

                // Đếm số lượng tệp và thư mục, cũng như tổng kích thước tệp
                long fileCount = 0;
                long dirCount = 0;
                long totalFileSize = 0;

                // Hiển thị thông tin từng mục
                foreach (FileSystemInfo item in items)
                {
                    // Định dạng ngày sửa đổi
                    string modifiedDate = item.LastWriteTime.ToString("MM/dd/yyyy  hh:mm tt", CultureInfo.InvariantCulture);
                    string typeOrSize;

                    // Kiểm tra xem mục là thư mục hay tệp
                    if (item.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        typeOrSize = "<DIR>";
                        dirCount++; // Đếm thư mục
                    }
                    else
                    {
                        // Mục là tệp và lấy kích thước
                        FileInfo file = (FileInfo)item;
                        typeOrSize = file.Length.ToString("N0", CultureInfo.InvariantCulture);
                        fileCount++;
                        totalFileSize += file.Length;
                    }

                    // Hiển thị thông tin mục theo định dạng
                    Console.WriteLine(string.Format("{0, -27} {1, 18} {2}", modifiedDate, typeOrSize, item.Name));
                }

                // Hiển thị tổng kết
                Console.WriteLine($"\n{fileCount,16:N0} File(s) {totalFileSize,18:N0} bytes");
                Console.WriteLine($"{dirCount,16:N0} Dir(s)  {drive.AvailableFreeSpace,18:N0} bytes free");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Không có quyền truy cập vào thư mục này.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        // Phương thức lấy số serial của ổ đĩa
        private string GetVolumeSerialNumber(string driveName)
        {
            try
            {
                // Loại bỏ dấu gạch chéo cuối cùng nếu có 
                string deviceId = driveName.TrimEnd('\\');

                string query = $"SELECT VolumeSerialNumber FROM Win32_LogicalDisk WHERE DeviceID = '{deviceId}'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject obj in searcher.Get())
                {
                    string serial = obj["VolumeSerialNumber"]?.ToString();
                    if (!string.IsNullOrEmpty(serial) && serial.Length == 8)
                    {
                        // Định dạng serial thành dạng XXXX-XXXX
                        return $"{serial.Substring(0, 4)}-{serial.Substring(4, 4)}";
                    }
                    return serial; // Trả về serial nếu không đủ 8 ký tự
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi và trả về null
            }
            return null;
        }
    }
}
