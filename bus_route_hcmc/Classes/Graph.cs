using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_GRAPH_THEORY
{
    public class Graph
    {
        private Dictionary<string, Node> station;
        public Dictionary<string, Node> Station { get => station; set => station = value; }
        public Graph() 
        { 
            Station = new Dictionary<string, Node>();
        }

        //CREATE THE GRAPH (ADJACENT LIST)
        public void AddRoute(string busRoute, List<(string stationName, double x, double y)> values)
        {
            int n = values.Count;
            for (int i = 0; i < n - 1; i++)
            {
                (string key1, double x1, double y1) = values[i];
                (string key2, double x2, double y2) = values[i + 1];

                //check if the key is not avaiable --> create new, add coord of the station
                if (!station.ContainsKey(key1))
                {
                    station.Add(key1, new Node(x1, y1));
                }
                if (!station.ContainsKey(key2))
                {
                    station.Add(key2, new Node(x2, y2));
                }
                //add info into the adj_list
                if (!station[key1].isExisted(key2))
                    station[key1].AdjStation.Add(new AdjStationData(key2, x2, y2, busRoute));
                if (!station[key2].isExisted(key1))
                    station[key2].AdjStation.Add(new AdjStationData(key1, x1, y1, busRoute));

            }
        }

        //ADD ALL BUS ROUTES TO THE GRAPH
        public static Graph Create(ref Graph myGraph)
        {
            myGraph.AddRoute("1", BusData.bus1);
            myGraph.AddRoute("10", BusData.bus10);
            myGraph.AddRoute("100", BusData.bus100);
            myGraph.AddRoute("101", BusData.bus101);
            myGraph.AddRoute("102", BusData.bus102);
            myGraph.AddRoute("103", BusData.bus103);
            myGraph.AddRoute("104", BusData.bus104);
            myGraph.AddRoute("107", BusData.bus107);
            myGraph.AddRoute("109", BusData.bus109);
            myGraph.AddRoute("110", BusData.bus110);
            myGraph.AddRoute("122", BusData.bus122);
            myGraph.AddRoute("126", BusData.bus126);
            myGraph.AddRoute("127", BusData.bus127);
            myGraph.AddRoute("128", BusData.bus128);
            myGraph.AddRoute("13", BusData.bus13);
            myGraph.AddRoute("139", BusData.bus139);
            myGraph.AddRoute("14", BusData.bus14);
            myGraph.AddRoute("140", BusData.bus140);
            myGraph.AddRoute("141", BusData.bus141);
            myGraph.AddRoute("145", BusData.bus145);
            myGraph.AddRoute("146", BusData.bus146);
            myGraph.AddRoute("148", BusData.bus148);
            myGraph.AddRoute("15", BusData.bus15);
            myGraph.AddRoute("150", BusData.bus150);
            myGraph.AddRoute("151", BusData.bus151);
            myGraph.AddRoute("152", BusData.bus152);
            myGraph.AddRoute("16", BusData.bus16);
            myGraph.AddRoute("18", BusData.bus18);
            myGraph.AddRoute("19", BusData.bus19);
            myGraph.AddRoute("20", BusData.bus20);
            myGraph.AddRoute("22", BusData.bus22);
            myGraph.AddRoute("23", BusData.bus23);
            myGraph.AddRoute("24", BusData.bus24);
            myGraph.AddRoute("25", BusData.bus25);
            myGraph.AddRoute("27", BusData.bus27);
            myGraph.AddRoute("28", BusData.bus28);
            myGraph.AddRoute("29", BusData.bus29);
            myGraph.AddRoute("3", BusData.bus3);
            myGraph.AddRoute("30", BusData.bus30);
            myGraph.AddRoute("31", BusData.bus31);
            myGraph.AddRoute("32", BusData.bus32);
            myGraph.AddRoute("33", BusData.bus33);
            myGraph.AddRoute("34", BusData.bus34);
            myGraph.AddRoute("36", BusData.bus36);
            myGraph.AddRoute("38", BusData.bus38);
            myGraph.AddRoute("39", BusData.bus39);
            myGraph.AddRoute("4", BusData.bus4);
            myGraph.AddRoute("41", BusData.bus41);
            myGraph.AddRoute("43", BusData.bus43);
            myGraph.AddRoute("44", BusData.bus44);
            myGraph.AddRoute("45", BusData.bus45);
            myGraph.AddRoute("46", BusData.bus46);
            myGraph.AddRoute("47", BusData.bus47);
            myGraph.AddRoute("48", BusData.bus48);
            myGraph.AddRoute("5", BusData.bus5);
            myGraph.AddRoute("50", BusData.bus50);
            myGraph.AddRoute("52", BusData.bus52);
            myGraph.AddRoute("53", BusData.bus53);
            myGraph.AddRoute("55", BusData.bus55);
            myGraph.AddRoute("56", BusData.bus56);
            myGraph.AddRoute("57", BusData.bus57);
            myGraph.AddRoute("58", BusData.bus58);
            myGraph.AddRoute("59", BusData.bus59);
            myGraph.AddRoute("6", BusData.bus6);
            myGraph.AddRoute("60_1", BusData.bus60_1);
            myGraph.AddRoute("60_2", BusData.bus60_2);
            myGraph.AddRoute("60_3", BusData.bus60_3);
            myGraph.AddRoute("60_5", BusData.bus60_5);
            myGraph.AddRoute("60_7", BusData.bus60_7);
            myGraph.AddRoute("61_3", BusData.bus61_3);
            myGraph.AddRoute("61_7", BusData.bus61_7);
            myGraph.AddRoute("61_8", BusData.bus61_8);
            myGraph.AddRoute("61", BusData.bus61);
            myGraph.AddRoute("62_1", BusData.bus62_1);
            myGraph.AddRoute("62_10", BusData.bus62_10);
            myGraph.AddRoute("62_11", BusData.bus62_11);
            myGraph.AddRoute("62_2", BusData.bus62_2);
            myGraph.AddRoute("62_4", BusData.bus62_4);
            myGraph.AddRoute("62_5", BusData.bus62_5);
            myGraph.AddRoute("62_6", BusData.bus62_6);
            myGraph.AddRoute("62_7", BusData.bus62_7);
            myGraph.AddRoute("62_8", BusData.bus62_8);
            myGraph.AddRoute("62_9", BusData.bus62_9);
            myGraph.AddRoute("62", BusData.bus62);
            myGraph.AddRoute("63_1", BusData.bus63_1);
            myGraph.AddRoute("64", BusData.bus64);
            myGraph.AddRoute("65", BusData.bus65);
            myGraph.AddRoute("67", BusData.bus67);
            myGraph.AddRoute("68", BusData.bus68);
            myGraph.AddRoute("69", BusData.bus69);
            myGraph.AddRoute("7", BusData.bus7);
            myGraph.AddRoute("70_1", BusData.bus70_1);
            myGraph.AddRoute("70_2", BusData.bus70_2);
            myGraph.AddRoute("70_5", BusData.bus70_5);
            myGraph.AddRoute("70", BusData.bus70);
            myGraph.AddRoute("71", BusData.bus71);
            myGraph.AddRoute("72_1", BusData.bus72_1);
            myGraph.AddRoute("72", BusData.bus72);
            myGraph.AddRoute("73", BusData.bus73);
            myGraph.AddRoute("74", BusData.bus74);
            myGraph.AddRoute("75", BusData.bus75);
            myGraph.AddRoute("76", BusData.bus76);
            myGraph.AddRoute("77", BusData.bus77);
            myGraph.AddRoute("78", BusData.bus78);
            myGraph.AddRoute("79", BusData.bus79);
            myGraph.AddRoute("8", BusData.bus8);
            myGraph.AddRoute("81", BusData.bus81);
            myGraph.AddRoute("84", BusData.bus84);
            myGraph.AddRoute("85", BusData.bus85);
            myGraph.AddRoute("87", BusData.bus87);
            myGraph.AddRoute("88", BusData.bus88);
            myGraph.AddRoute("89", BusData.bus89);
            myGraph.AddRoute("9", BusData.bus9);
            myGraph.AddRoute("90", BusData.bus90);
            myGraph.AddRoute("91", BusData.bus91);
            myGraph.AddRoute("93", BusData.bus93);
            myGraph.AddRoute("94", BusData.bus94);
            myGraph.AddRoute("99", BusData.bus99);
            myGraph.AddRoute("D2", BusData.busD2);
            myGraph.AddRoute("D3", BusData.busD3);
            myGraph.AddRoute("D4", BusData.busD4);
            myGraph.AddRoute("GRP03", BusData.busGRP03);
            return myGraph;
        }

        //AUTO CREATE 150 ADD ROUTE LINE
        public static void CreateGraphSyntax()
        {
            string folderPath = @"D:\bus_data\full_bus_data\data\raw_coord";
            string outputLine = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n\r\nnamespace FINAL_PROJECT_GRAPH_THEORY\r\n{\r\n    public class GraphCreating\r\n    {\r\n   ";
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
                    extractedString = extractedString.Replace('-', '_');
                    try
                    {
                        outputLine += $"myGraph.AddRoute(\"{extractedString}\", BusData.bus{extractedString});\n";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while writing to the file: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"Tên file '{fileName}' không khớp với mẫu.");
                }
            }
            outputLine += " }\\r\\n}\\r\\n\";";
            // Write AllFileContents to the specified .cs file
            File.WriteAllText(@"E:\GraphTheory\FINAL_PROJECT_GRAPH_THEORY\Classes\GraphCreating.cs", outputLine);
            MessageBox.Show($"Data successfully");
        }

        //EXPORT ALL STATIONS FROM A GRAPH
        public static void ExportStation(Graph p)
        {
            string filePath = @"C:\Users\lehuu\Desktop\StationsList.txt";  // Specify the path to your text file

            try
            {
                string output = "";
                foreach (var a in p.Station)
                {
                    output += a.Key + "\n";
                }
                // Open the file (will create it if it doesn't exist) and write to it
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(output);
                }
                MessageBox.Show("Text has been written to the file successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        
           
        }
    }
}
