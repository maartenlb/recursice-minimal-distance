using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_Divide_and_Conquer
{
    class Program
    {
        static void Main(string[] args) // Main Method
        {
            string[] ninput = Console.ReadLine().Split(' '); // Read Input
            int n = Convert.ToInt32(ninput[0]);
            string[] stringarray;
            Point[] pointarray = new Point[n];
            for (int i = 0; i < n; i++)
            {
                pointarray[i] = new Point();
                stringarray = Console.ReadLine().Split();
                pointarray[i].x = Convert.ToInt64(stringarray[0]);
                pointarray[i].y = Convert.ToInt64(stringarray[1]);
                
            }
                     
                Array.Sort(pointarray, delegate (Point a, Point b) { return a.x.CompareTo(b.x); });
                
                long MinD = SmallestDistance(pointarray); // Start recursion
                
                Console.WriteLine(MinD);
                Console.ReadKey();
            
        }
        static long SmallestDistance(Point[] A)
        {
            if (A.Length <= 3) // Conquer - If the input can no longer be chopped up in multiple point arrays, calculate distance
            {
               return CalculateDistance(A);
            }
            Point[] LA = A.Take((A.Length) / 2).ToArray(); // Divide - Split the input in smaller point arrays
            Point[] RA = A.Skip((A.Length) / 2).ToArray();
            long belt_distance = Math.Min(SmallestDistance(LA), SmallestDistance(RA)); // Belt distance is neccessary for distances that are between point arrays

             List<Point> Slist = new List<Point>();
             long i;
             for (i = LA.Length-1; (LA[LA.Length-1].x - LA[i].x <= belt_distance); i--)
             {
                 Slist.Add(LA[i]);
                 if(i==0)
                 {
                     break;
                 }
             }
             for(i=0; (RA[i].x - LA[LA.Length - 1].x <= belt_distance); i++)
             {
                 Slist.Add(RA[i]);
                 if (i == RA.Length-1)
                 {
                     break;
                 }
             }
             if (Slist.Count <= 1)
             {
                 return belt_distance;
             }
             Point[] S = Slist.ToArray();
             return Math.Min(belt_distance, CalculateDistance(S));
                       
        }
        static long CalculateDistance(Point[] A) // Conquering method
        {
            long minimal_distance = ((A[0].y - A[1].y) * (A[0].y - A[1].y) + (A[0].x - A[1].x) * (A[0].x - A[1].x));
            long d;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i+1; j < A.Length; j++)
                {
                    d = ((A[i].y - A[j].y) * (A[i].y - A[j].y) + (A[i].x - A[j].x) * (A[i].x - A[j].x));
                    if (d < minimal_distance)
                    {
                        minimal_distance = d;
                    }
                }
            }
            return minimal_distance;
        }
    }

    public class Point 
    {
        public long x;
        public long y;
    }
}
