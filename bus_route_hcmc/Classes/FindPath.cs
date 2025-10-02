using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_PROJECT_GRAPH_THEORY
{
    public static class FindPath
    {

        //MAIN ALGORITHM: BFS
        public static List<KeyValuePair<string, string>> FindShortestPathBFS(Graph g, string start, string end)
        {
            // Initialize the queue and visited set
            // Queue: current station and path taken to reach it
            Queue<KeyValuePair<string, List<KeyValuePair<string, string>>>> q = new Queue<KeyValuePair<string, List<KeyValuePair<string, string>>>>();
            HashSet<string> visited = new HashSet<string>();

            // Add the start station with an empty path
            q.Enqueue(new KeyValuePair<string, List<KeyValuePair<string, string>>>(start, new List<KeyValuePair<string, string>>()));

            while (q.Count > 0)
            {
                var currentPair = q.Dequeue();
                string currentStation = currentPair.Key;
                List<KeyValuePair<string, string>> path = currentPair.Value;

                // If visited, skip
                if (visited.Contains(currentStation)) continue;
                visited.Add(currentStation);

                // If current is the end, include the end station and return the path
                if (currentStation == end)
                {
                    path.Add(new KeyValuePair<string, string>("", end)); // Add the ending station explicitly
                    return path;
                }

                // Check adjacent stations
                if (g.Station.ContainsKey(currentStation))
                {
                    foreach (var nextStation in g.Station[currentStation].AdjStation)
                    {
                        string nextName = nextStation.Name;      // Adjacent station name
                        string nextBusRoute = nextStation.BusRoute; // Bus route connecting two stations
                        var newPath = new List<KeyValuePair<string, string>>(path);  // Copy the current path

                        // Add the current station and bus route to the path
                        if (path.Count == 0)
                        {
                            newPath.Add(new KeyValuePair<string, string>("", start)); // Add the start station if the path is empty
                        }

                        newPath.Add(new KeyValuePair<string, string>(nextBusRoute, nextName)); // Add the next station and the bus route

                        // Add the adjacent station into the queue
                        q.Enqueue(new KeyValuePair<string, List<KeyValuePair<string, string>>>(nextName, newPath));
                    }
                }
            }

            // Return empty if the path is not found
            return null;
        }

        //USE BFS TO TRAVERSE THE GRAPH ONCE --> CHECK THE VISITED 
        public static string FindUnreachableStation(Graph g, string start)
        {
            //visited set
            HashSet<string> visited = new HashSet<string>();

            Queue<string> q = new Queue<string>();
            q.Enqueue(start);

            while (q.Count > 0)
            {
                var currentStation = q.Dequeue();

                if (visited.Contains(currentStation)) continue;

                visited.Add(currentStation);

                if (g.Station.ContainsKey(currentStation))
                {
                    foreach (var nextStation in g.Station[currentStation].AdjStation)
                    {
                        if (!visited.Contains(nextStation.Name))
                        {
                            q.Enqueue(nextStation.Name);
                        }
                    }
                }
            }

            foreach (var station in g.Station.Keys)
            {
                if (!visited.Contains(station))
                {
                    return station;
                }
            }

            return "All are connected";
        }

    }
}
