using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_PROJECT_GRAPH_THEORY
{
    public class Node
    {
        private double x;
        private double y;
        private List<AdjStationData> adjStation;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public List<AdjStationData> AdjStation { get => adjStation; set => adjStation = value; }

        public Node() 
        { 
            adjStation = new List<AdjStationData>();
        }
        public Node(double x, double y, List<AdjStationData> adjStation)
        {
            X = x;
            Y = y;
            AdjStation = adjStation;
        }
        public Node(double x, double y)
        {
            X = x;
            Y = y;
            adjStation = new List<AdjStationData>();
        }

        public bool isExisted(string stationName)
        {
            if (string.IsNullOrEmpty(stationName) || adjStation == null) return false;

            foreach (var x in AdjStation)
            {
                if (x.Name == stationName) return true;
            }
            return false;
        }

    }
}
