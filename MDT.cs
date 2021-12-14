using System;

class Program {
  public static void Main (string[] args) {

    int minDistance(int[] dist, int V, bool[] sptSet)
    {
        int min = int.MaxValue, min_index = -1;
        for (int i = 0; i < V; i++)
            if (sptSet[i] == false && dist[i] <= min) {
                min = dist[i];
                min_index = i;
            }
        return min_index;
    }
    
    void shortest(int[, ] graph, int V, int des)
    {
      int[] dist = new int[V]; 
      bool[] sptSet = new bool[V];
      for (int i = 0; i < V; i++) 
      {
        dist[i] = int.MaxValue;
        sptSet[i] = false;
      }
      dist[0] = 0;
      for (int count = 0; count < V - 1; count++) 
      {
        int i = minDistance(dist, V, sptSet);
        sptSet[i] = true;
        for (int j = 0; j < V; j++)
        {
          if (!sptSet[j] && graph[i, j] != 0 && graph[i, j] != -1 &&
            dist[i] != int.MaxValue && dist[i] + graph[i, j] < dist[j])
            {
              dist[j] = dist[i] + graph[i, j];
            }
        }
      }
      Console.WriteLine(dist[des]);
    }

    Console.WriteLine ("node number : ");
    int n = Convert.ToInt32(Console.ReadLine());
    string[] cities = new string[n];

    for(int i = 0; i < n; i++)
    {
      cities[i] = Console.ReadLine();
    }

    int[,] path = new int[n,n]; 

    for(int i = 0; i < n; i++)
    {
      for(int j = 0; j < i+1; j++)
      {
        if(i==j){ path[i,j] = 0; }
        else 
        { 
          int p = Convert.ToInt32(Console.ReadLine()); 
          path[i,j] = p; path[j,i] = p;
        }
      }
    }

    int des = 0;
    string d = Console.ReadLine();
    for(int i = 0; i < n; i++)
    {
      if(cities[i]==d)
      {
        des = i;
        break;
      }
    }
    shortest(path,n,des);
  }
}