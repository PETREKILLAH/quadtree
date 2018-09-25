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
        
        public Quad NW, NE, SW, SE;
        public float x1, x2, y1, y2;

        //test2
        public Quad(Point[] point,float x1,float y1,float x2,float y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            if (point.Length > 1)
            {
                float nwx1 = this.x1;
                float nwy1 = this.y1;
                float nwx2 = this.x1 + (this.x2-this.x1) /2 ;
                float nwy2 = this.y1 + (this.y2 - this.y1) / 2;
                Point[] nw = new Point[10];
                int nwindex = 0;

                float nex1 = this.x1 + (this.x2 - this.x1) / 2;
                float ney1 = this.y1;
                float nex2 = this.x2;
                float ney2 = this.y1 + (this.y2 - this.y1) / 2;
                Point[] ne = new Point[10];
                int neindex = 0;

                float swx1 = this.x1;
                float swy1 = this.y1 + (this.y2 - this.y1) / 2;
                float swx2 = this.x1 + (this.x2 - this.x1) / 2;
                float swy2 = this.y2;
                Point[] sw = new Point[10];
                int swindex = 0;

                float sex1 = this.x1 + (this.x2 - this.x1) / 2;
                float sey1 = this.y1 + (this.y2 - this.y1) / 2;
                float sex2 = this.x2;
                float sey2 = this.y2;
                Point[] se = new Point[10];
                int seindex = 0;

                for (int z = 0; z < point.Length; z++)
                {
                    if (
                        point[z].x >= nwx1 &&
                        point[z].x <= nwx2 &&
                        point[z].y >= nwy1 &&
                        point[z].y <= nwy2
                        )
                    {
                        nw[nwindex] = point[z];
                        nwindex++;
                    }
                    else if (
                        point[z].x >= nex1 &&
                        point[z].x <= nex2 &&
                        point[z].y >= ney1 &&
                        point[z].y <= ney2
                        )
                    {
                        ne[neindex] = point[z];
                        neindex++;
                    }
                    else if (
                        point[z].x >= swx1 &&
                        point[z].x <= swx2 &&
                        point[z].y >= swy1 &&
                        point[z].y <= swy2
                        )
                    {
                        sw[swindex] = point[z];
                        swindex++;
                    }
                    else if (
                       point[z].x >= sex1 &&
                       point[z].x <= sex2 &&
                       point[z].y >= sey1 &&
                       point[z].y <= sey2
                       )
                    {
                        se[seindex] = point[z];
                        seindex++;
                    }
                }

                
                Array.Resize(ref nw, nwindex);

                Array.Resize(ref ne, neindex);

                Array.Resize(ref sw, swindex);
                
                Array.Resize(ref se, seindex);

                NW = new Quad(nw,nwx1,nwy1,nwx2,nwy2);
                NE = new Quad(ne, nex1, ney1, nex2, ney2);
                SW = new Quad(sw, swx1, swy1, swx2, swy2);
                SE = new Quad(se, sex1, sey1, sex2, sey2);
            }
            else if (point.Length == 1)
            {

                Console.WriteLine("THIS IS A LEAF!!!({0},{1})",point[0].x,point[0].y);
                
                
            }
            
        }
        public Point FindNearestPoint(Point userPoint)
        {
            return userPoint ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Point[] point = new Point[10];

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
            Console.WriteLine("----------------------------------------");
            Quad root = new Quad(point,0,0,50,12);
            int userx;
            int usery;
            Console.WriteLine("Enter a cartesian point(x)");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a cartesian point(y)");
            int y = int.Parse(Console.ReadLine());
            


        }
    }
}
