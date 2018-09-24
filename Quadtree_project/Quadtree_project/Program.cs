using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadtree_project
{
    public struct Point
    {
        public int x;
        public int y;
    }


    class Quad
    {

        public Quad nw, ne, sw, se;
        public int x1, x2, y1, y2;
        //test
        public Quad(Point[] point,int x1,int y1,int x2,int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            if (point.Length > 1) 
            {
                int nwx1 = this.x1;
                int nwy1 = this.y1;
                int nwx2 = this.x1 / 2;
                int nwy2 = this.y1 / 2;

                int nex1 = this.x2/2;
                int ney1 = this.y1;
                int nex2 = this.x2;
                int ney2 = this.y2 / 2;

                int swx1 = this.x2 / 2;
                int swy1 = this.y1;
                int swx2 = this.x2;
                int swy2 = this.y2 / 2;
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Point[] point = new Point[10];
            string field = "" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------" +
                "--------------------------------------------------";
            //Create some points
            for (int z = 0; z < 10; z++)
            {
                //Make coords
                
                int x = rand.Next(0, 50);
                int y = rand.Next(0, 12);

                //Store them in array
                point[z] = new Point();
                point[z].x = x;
                point[z].y = y;

                Console.WriteLine("Point[{0}]({1},{2})",z,point[z].x,point[z].y);
            }
            Quad root = new Quad(point,0,0,50,12);
            

            
            
        }
    }
}
