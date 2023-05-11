namespace Deykstra
{
    internal class Program
    {
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < verticesCount; ++i)
            {
                if (shortestPathTreeSet[i] == false && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Вершина    Расстояние до заданной стартовой вершины");

            for (int i = 0; i < verticesCount; ++i)
            {
                Console.WriteLine($"{i}\t   {distance[i]}");
            }
        }

        public static void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int A_index = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[A_index] = true;

                for (int i = 0; i < verticesCount; ++i)
                {
                    if (!shortestPathTreeSet[i] && graph[A_index, i] != 0 && distance[A_index] != int.MaxValue &&
                        distance[A_index] + graph[A_index, i] < distance[i])
                    {
                        distance[i] = distance[A_index] + graph[A_index, i];
                    }
                }
            }

            Print(distance, verticesCount);
        }

        public static void Main()
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            Console.WriteLine("Введите стартовой вершину(от 0 до 8): ");
            int start = int.Parse(Console.ReadLine());


            Dijkstra(graph, start, Convert.ToInt32(Math.Sqrt(graph.Length)));

            Console.ReadKey();
        }
    }
}