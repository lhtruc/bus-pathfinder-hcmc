using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FINAL_PROJECT_GRAPH_THEORY.Classes
{
    public class FileProcessing
    {
        public static void GetBusName(string routeNumber)
        {
            string inputPath = $@"D:\bus_data\raw_route\raw_route_{routeNumber}.txt";
            string outputPath = $@"D:\bus_data\route\route_{routeNumber}.txt";
            try
            {
                var content = File.ReadAllLines(inputPath);

                var stationNames = content.Where(line => line.Contains(']'))
                    .Select(line => line.Split(']')[1].Trim())
                    .ToList();

                File.WriteAllLines(outputPath, stationNames);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //FROM DATA FILE --> LIST SYNTAX
        public static void SetCoordToStation(string routeNumber)
        {
            string inputFilePath = $@"D:\bus_data\full_bus_data\data\raw_coord\coordinates{routeNumber}.txt"; // File chứa dữ liệu kết hợp
            string outputFilePath = $@"D:\bus_data\complete\bus_{routeNumber}.txt"; // File xuất ra

            try
            {
                routeNumber = routeNumber.Replace('-', '_');
                // Đọc dữ liệu từ file đầu vào
                var inputLines = File.ReadAllLines(inputFilePath);

                // Tạo danh sách để ghi vào file
                var outputLines = new List<string>
                {
                    $"public static List<(string stationName, double x, double y)> bus{routeNumber} = new List<(string stationName, double x, double y)>",
                    "{"
                };

                // Xử lý từng dòng dữ liệu
                foreach (var line in inputLines)
                {
                    // Tách dữ liệu bằng dấu ':'
                    var parts = line.Split(':');
                    if (parts.Length != 2)
                    {
                        throw new Exception($"Dòng dữ liệu không hợp lệ trong file '{routeNumber}': " + line);
                    }

                    string stationName = parts[0].Trim();
                    var coordinates = parts[1].Split(',');

                    if (coordinates.Length != 2)
                    {
                        throw new Exception($"Tọa độ không hợp lệ trong file '{routeNumber}': " + parts[1]);
                    }

                    double latitude = double.Parse(coordinates[0].Trim());
                    double longitude = double.Parse(coordinates[1].Trim());

                    // Thêm dòng dữ liệu vào danh sách
                    string outputLine = $"        (\"{stationName}\", {latitude}, {longitude}),";
                    outputLines.Add(outputLine);
                }

                // Đóng danh sách
                outputLines.Add("};");

                // Ghi dữ liệu vào file
                File.WriteAllLines(outputFilePath, outputLines);

                //MessageBox.Show($"File đã được ghi thành công tại: {outputFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra trong file '{routeNumber}': " + ex.Message);
            }
        }
       

        //CHECK THE FILE NAME --> GET BUS DATA --> CALL SET COORD METHOD 
        public static void CreateListOfBus()
        {
            string folderPath = @"D:\bus_data\full_bus_data\data\raw_coord";

            // Lấy tất cả các file .txt trong folder
            string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

            // Biểu thức chính quy để lấy chuỗi sau "coordinates"
            Regex regex = new Regex(@"coordinates([A-Za-z0-9\-]+)");

            foreach (string filePath in txtFiles)
            {
                // Lấy tên file (không bao gồm đường dẫn)
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                // Tìm chuỗi sau "coordinates"
                Match match = regex.Match(fileName);
                if (match.Success)
                {
                    // Lấy chuỗi sau từ "coordinates"
                    string extractedString = match.Groups[1].Value;

                    try
                    {
                        // Gọi phương thức SetCoordToStation cho mỗi tuyến xe buýt
                        SetCoordToStation(extractedString);
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi trong quá trình xử lý SetCoordToStation, hiển thị tên xe buýt
                        MessageBox.Show($"Lỗi xảy ra khi xử lý tuyến xe buýt '{extractedString}': {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"Tên file '{fileName}' không khớp với mẫu.");
                }
            }
        }

        //USE TO DOUBLE CHECK THE DATA VALIDATION
        public static void CheckError()
        {
            string filePath = @"D:\bus_data\full_bus_data\data\raw_coord\coordinates60-7.txt"; // Đường dẫn file cần kiểm tra
            try
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    // Kiểm tra sự tồn tại của dấu ':'
                    if (!line.Contains(":"))
                    {
                        MessageBox.Show($"Dòng {i + 1} không hợp lệ: Thiếu dấu ':'");
                        continue;
                    }

                    // Tách dữ liệu thành 2 phần
                    var parts = line.Split(':');
                    if (parts.Length != 2)
                    {
                        MessageBox.Show($"Dòng {i + 1} không hợp lệ: Số phần tách không đúng");
                        continue;
                    }

                    string stationName = parts[0].Trim();
                    string coordinatePart = parts[1].Trim();

                    // Kiểm tra tọa độ
                    var coordinates = coordinatePart.Split(',');
                    if (coordinates.Length != 2)
                    {
                        MessageBox.Show($"Dòng {i + 1} không hợp lệ: Tọa độ không đủ");
                        continue;
                    }

                    // Kiểm tra xem tọa độ có phải số hợp lệ không
                    if (!double.TryParse(coordinates[0].Trim(), out double latitude) ||
                        !double.TryParse(coordinates[1].Trim(), out double longitude))
                    {
                        MessageBox.Show($"Dòng {i + 1} không hợp lệ: Tọa độ không phải số hợp lệ");
                    }
                }

                     MessageBox.Show("Kiểm tra hoàn tất!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi đọc file: {ex.Message}");
            }
        }

        //LOAD ALL DATA FROM A TXT FILE --> STRING
        public static string LoadDataFromFiles()
        {
            try
            {
                // Get all .txt files in the folder
                string[] files = Directory.GetFiles(@"D:\bus_data\complete", "*.txt");

                string AllFileContents;
                // Clear the existing content
                AllFileContents = string.Empty;

                // Read content from the first four files and concatenate
                int i = 0;
                foreach (string txtFile in files)
                {
                    string content = File.ReadAllText(txtFile);
                    AllFileContents += $"\n//--- File {i++ + 1}: {Path.GetFileName(txtFile)} ---\n";
                    AllFileContents += content + "\n";
                }

                MessageBox.Show("Data loaded successfully from files.");
                return AllFileContents;
            }
            catch 
            {
                throw new Exception("An error occurred");
            }
           
        }

        //WRITE A STRING --> CS FILE
        public static void WriteDataToCsFile(string outputFilePath)
        {
            try
            {
                // Write AllFileContents to the specified .cs file
                File.WriteAllText(outputFilePath, LoadDataFromFiles());
                Console.WriteLine($"Data successfully written to {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }
    }

}
