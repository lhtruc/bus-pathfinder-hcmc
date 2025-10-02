using FINAL_PROJECT_GRAPH_THEORY.Classes;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace FINAL_PROJECT_GRAPH_THEORY
{
    public partial class MainForm : Form
    {
        private GMapOverlay markersOverlay;
        Graph p = new Graph();
        //FOR DRAGGING
        private bool dragging = false; //check if the mouse is in dragging state
        private Point dragCursorPoint; //save the current pos of the mouse
        private Point dragFormPoint;   //save the current pos of the form
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Graph.Create(ref p);
            LoadDataToSearchBox();

            gMapControl1.MapProvider = GMapProviders.GoogleMap;  // Sử dụng Google Map
            GMaps.Instance.Mode = AccessMode.ServerOnly; // Chế độ online
            gMapControl1.Position = new PointLatLng(10.7769, 106.7009); // Tâm TP.HCM
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 13; // Mức zoom ban đầu
            gMapControl1.ShowCenter = false;
            markersOverlay = new GMapOverlay("markers");
            gMapControl1.Overlays.Add(markersOverlay);

            busRouteTB.Text = "Enter Bus ID";
            busRouteTB.ForeColor = Color.Silver;
        }

        #region MAP METHODS

        //CLEAN ALL MARKERS
        public void ClearMarkers()
        {
            markersOverlay.Markers.Clear();
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(markersOverlay);
        }

        //ADD MARKERS FROM PATH TO MAP
        public void AddMarkersToMap(Graph p, List<KeyValuePair<string, string>> busStops)
        { 
            // Thêm markers vào bản đồ
            foreach (var busStop in busStops)
            {
                var name = busStop.Value;
                var coord = p.Station[name];
                var latitude = coord.X;
                var longitude = coord.Y;

                var point = new PointLatLng(latitude, longitude);
                var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                marker.ToolTipText = name;  // Gắn tên trạm vào tooltip

                // Thêm marker vào overlay
                markersOverlay.Markers.Add(marker);
            }

            // Vẽ các đường nối giữa các trạm
            for (int i = 0; i < busStops.Count - 1; i++)
            {
                var name1 = busStops[i].Value;
                var coord1 = p.Station[name1];
                var x1 = coord1.X;
                var y1 = coord1.Y;

                var name2 = busStops[i + 1].Value;
                var coord2 = p.Station[name2];
                var x2 = coord2.X;
                var y2 = coord2.Y;
                // Tạo một danh sách các điểm nối giữa các trạm
                List<PointLatLng> routePoints = new List<PointLatLng>
                {
                    new PointLatLng(x1, y1),
                    new PointLatLng(x2, y2)
                };

                // Tạo một đối tượng GMapRoute với tên và các điểm nối
                GMapRoute route = new GMapRoute(routePoints, "Route" + i)
                {
                    Stroke = new Pen(Color.Blue, 2)
                };

                // Tạo overlay để vẽ route
                GMapOverlay routeOverlay = new GMapOverlay("routes");
                routeOverlay.Routes.Add(route);

                // Thêm overlay vào bản đồ
                gMapControl1.Overlays.Add(routeOverlay);
            }
        }

        //ADD MARKERS FROM BUS ROUTE TO MAP
        public void AddMarkersToMap(Graph p, List<(string stationName, double x, double y)> busRoute)
        {
            // Thêm markers vào bản đồ
            foreach (var busStop in busRoute)
            {
                var (name, X, Y) = busStop;
                
                var point = new PointLatLng(X, Y);
                var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                marker.ToolTipText = name;  // Gắn tên trạm vào tooltip

                // Thêm marker vào overlay
                markersOverlay.Markers.Add(marker);
            }

            // Vẽ các đường nối giữa các trạm
            for (int i = 0; i < busRoute.Count - 1; i++)
            {
                var (name1, X1, Y1) = busRoute[i];
                var (name2, X2, Y2) = busRoute[i + 1];

                // Tạo một danh sách các điểm nối giữa các trạm
                List<PointLatLng> routePoints = new List<PointLatLng>
                {
                    new PointLatLng(X1, Y1),
                    new PointLatLng(X2, Y2)
                };

                // Tạo một đối tượng GMapRoute với tên và các điểm nối
                GMapRoute route = new GMapRoute(routePoints, "Route" + i)
                {
                    Stroke = new Pen(Color.Blue, 2)
                };

                // Tạo overlay để vẽ route
                GMapOverlay routeOverlay = new GMapOverlay("routes");
                routeOverlay.Routes.Add(route);

                // Thêm overlay vào bản đồ
                gMapControl1.Overlays.Add(routeOverlay);
            }
        }

        private void LoadDataToSearchBox()
        {
            // Path to the text file
            string filePath = "Stations.txt";

            // Check if file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the file and add them to the ComboBox
                string[] lines = File.ReadAllLines(filePath);

                // Clear existing items in ComboBox (if any)
                startCB.Items.Clear();
                endCB.Items.Clear();

                // Add each line to the ComboBox
                foreach (string line in lines)
                {
                    startCB.Items.Add(line);
                    endCB.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }
        }

        #endregion

        #region FORM ACTIONS
        private void showBT_Click(object sender, EventArgs e)
        {
            try
            {
                ClearMarkers();
                string start = startCB.SelectedItem.ToString();
                string end = endCB.SelectedItem.ToString();
                var a = FindPath.FindShortestPathBFS(p, start, end);
                string path = "";
                for (int i = 0; i < a.Count; i++)
                {
                    var station = a[i];
                    if (i == 0)
                    {
                        path += "Start at: " + station.Value + "\n";
                    }
                    else if (i == a.Count - 1)
                    {
                        path += "Arrived at: " + station.Value + "\n";
                    }
                    else
                    {
                        path += "Take " + station.Key + " to " + station.Value + "\n";
                    }
                }
                pathInformationLB.Text = path;
                gMapControl1.Position = new PointLatLng(p.Station[start].X, p.Station[start].Y); 
                AddMarkersToMap(p, a);
            }
            catch
            {
                MessageBox.Show("Invalid station", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closePIC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizePIC_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topPN_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true; //in dragging state
            dragCursorPoint = System.Windows.Forms.Cursor.Position; //update cursor pos
            dragFormPoint = this.Location; //update form pos
        }

        private void topPN_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                //calculate the displacement between init pos and current pos
                Point dif = Point.Subtract(System.Windows.Forms.Cursor.Position, new Size(dragCursorPoint));
                //add the displacement into the location of the form
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void topPN_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void clearBT_Click(object sender, EventArgs e)
        {
            ClearMarkers();
            pathInformationLB.Text = "";
        }

        private void showBusRouteBT_Click(object sender, EventArgs e)
        {
            try
            {
                string busRoute = busRouteTB.Text;
                var stations = BusData.GetListByName(busRoute);
                ClearMarkers();
                AddMarkersToMap(p, stations);
            }
            catch
            {
                MessageBox.Show("Invalid Bus ID (bus<number>)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void busRouteTB_Enter(object sender, EventArgs e)
        {
            if (busRouteTB.Text == "Enter Bus ID") { 
                busRouteTB.Text = "";
                busRouteTB.ForeColor = Color.Black;
            }
        }

        private void busRouteTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(busRouteTB.Text))
            {
                busRouteTB.Text = "Enter Bus ID";
                busRouteTB.ForeColor = Color.Silver;
            }
        }

        #endregion

        private void topPN_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
