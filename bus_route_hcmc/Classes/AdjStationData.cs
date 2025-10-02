using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_PROJECT_GRAPH_THEORY
{
    public class AdjStationData
    {
        private string name;
        private double x;
        private double y;
        private string busRoute;

        public string Name { get => name; set => name = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public string BusRoute { get => busRoute; set => busRoute = value; }

        public AdjStationData() { }
        public AdjStationData(string name, double x, double y, string busRoute)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.busRoute = busRoute;
        }

    }
}
