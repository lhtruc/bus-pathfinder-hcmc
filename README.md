# 🚌 [HCMUTE] Bus Pathfinder HCMC 

**Bus Pathfinder HCMC** is a Windows Forms application (C# / .NET Framework) that helps users find optimal bus routes in Ho Chi Minh City (minimum number of stations). The project models the bus network as a graph and uses graph algorithms to compute shortest paths between stations.

This project is a **final project** of **Discrete Mathematics and Graph Theory**  course, author group includes: 
- Le Huu Truc - 23110068
- Hoang Duc Tuan - 23110069
- Do Huynh Dai Duong - 23110012

*Present video:* https://youtu.be/RpxGVZdumX4?si=O4GV-hAcHQ8V9HDK
<img width="1384" height="740" alt="image" src="https://github.com/user-attachments/assets/6deb9dad-f13b-45db-b4c6-7166d96181f4" />

---

## 🚀 Key Features

* Find the shortest route (minimum number of stations) between two bus stations (BFS).
* Display bus lines and station information.
* Load and parse station and route data from text files.
* Simple and user-friendly Windows Forms UI.

---

## 🧭 Architecture Overview

The app represents the bus network using standard graph concepts:

* **Node / Station**: represents a bus stop. Each node stores coordinates and its adjacency list (neighboring stations).
* **Graph**: a collection of nodes and operations to build the network (add routes/edges, export data, create graph from input).
* **AdjStationData**: container for adjacency-related data (station name, coordinates, routes that pass through it).
* **BusData**: holds bus line names and lists used for mapping and display.
* **FileProcessing**: responsible for reading/parsing input files, validating data, and mapping coordinates to stations.
* **FindPath (static)**: contains algorithms for finding paths — currently BFS for unweighted shortest paths. Easily extendable to Dijkstra or A* when using weighted edges.

---

## 📁 Project Structure

```
bus_route_hcmc/
├── Classes/          
├── Properties/        
├── MainForm.cs      
├── Program.cs         # Entry point
├── Stations.txt       # All stations (Raw data for reprocessing)
├── .sln / .csproj     # Visual Studio solution/project <-- Open this one to start the project
```

---

## 🧩 Classes

### `AdjStationData`

* **Fields**: `busRoute` (collection), `name`, `x`, `y`.
* **Properties**: `BusRoute`, `Name`, `X`, `Y`.
* **Purpose**: Stores adjacency-related station information (which bus routes pass through, coordinates, etc.).

### `BusData`

* **Fields**: many bus line identifiers (e.g. `bus1`, `bus10`, `bus100`, ...).
* **Purpose**: Keeps available bus line definitions/name lists used for mapping and display.

### `Node`

* **Fields**: `adjStation` (adjacency list), `x`, `y`.
* **Properties**: `AdjStation`, `X`, `Y`.
* **Methods**: `isExisted()`, constructors.
* **Purpose**: Graph vertex representing a station and its neighbors.

### `Graph`

* **Fields**: `station` (collection of nodes/stations).
* **Methods**: `AddRoute(...)`, `Create(...)`, `CreateGraphSyntax(...)`, `ExportStation(...)`, constructor `Graph()`.
* **Purpose**: Manages the entire network: building edges, initializing from files, and exporting station lists.

### `FindPath` (static)

* **Methods**: `FindShortestPathBFS(...)`, `FindUnreachableStation(...)`.
* **Purpose**: Implements pathfinding algorithms. Currently BFS for unweighted shortest path

### `FileProcessing`

* **Methods**: `CheckError(...)`, `CreateListOfBus(...)`, `GetBusName(...)`, `LoadDataFromFiles(...)`, `SetCoordToStation(...)`, `WriteDataToCsFile(...)`.
* **Purpose**: Handles I/O, parsing the input `Stations.txt` and converting file content into in-memory models (`AdjStationData` / `Node`) for `Graph`.

<img width="920" height="666" alt="image" src="https://github.com/user-attachments/assets/71474566-eefb-4dc3-9865-c97b78afbe9a" />

---

## ⚙️ Algorithms

* **BFS** — finds the shortest path in an unweighted graph (minimum number of station).
* **Unreachable stations** — detected via BFS.

---

## 🛠 How to run

1. Clone the repository:

```bash
git clone https://github.com/lhtruc/bus-pathfinder-hcmc.git
```

2. Open the `.sln` file with Visual Studio (Windows).
3. Make sure the target .NET Framework version matches your environment.
4. Build and run.
5. Put `Stations.txt` in the required path (project folder or configured data folder).

---

## 🔭 Possible improvements

* Implement Dijkstra or A* for weighted pathfinding using geographical coordinates as edge weights.
* Add a transfer-minimizing shortest-path mode (minimize number of route changes).
* Integrate real-time public transport data (if APIs are available).
* Add a map UI (tile provider) and draw route overlays (zoom/pan support).
* Cache indexes and speed up station name lookups.

---

## 📬 Contributing

Open an issue or submit a pull request if you'd like to contribute or suggest improvements.
