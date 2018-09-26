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
        public string type;
        public Point[] point;
        public Quad parent;

        public Quad(Point[] point,float x1,float y1,float x2,float y2, string type = "root")
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.type = type;
            this.point = point;

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
                        this.point[z].x >= nwx1 &&
                        this.point[z].x <= nwx2 &&
                        this.point[z].y >= nwy1 &&
                        this.point[z].y <= nwy2
                        )
                    {
                        nw[nwindex] = point[z];
                        nwindex++;
                    }
                    else if (
                        this.point[z].x >= nex1 &&
                        this.point[z].x <= nex2 &&
                        this.point[z].y >= ney1 &&
                        this.point[z].y <= ney2
                        )
                    {
                        ne[neindex] = point[z];
                        neindex++;
                    }
                    else if (
                        this.point[z].x >= swx1 &&
                        this.point[z].x <= swx2 &&
                        this.point[z].y >= swy1 &&
                        this.point[z].y <= swy2
                        )
                    {
                        sw[swindex] = point[z];
                        swindex++;
                    }
                    else if (
                       this.point[z].x >= sex1 &&
                       this.point[z].x <= sex2 &&
                       this.point[z].y >= sey1 &&
                       this.point[z].y <= sey2
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
                Console.WriteLine("NorthWest");
                for (int d = 0; d < nw.Length; d++)
                {
                    Console.WriteLine("{0},{1}", nw[d].x, nw[d].y);
                }
                Console.WriteLine("NorthEast");
                for (int d = 0; d < ne.Length; d++)
                {
                    Console.WriteLine("{0},{1}", ne[d].x, ne[d].y);
                }
                Console.WriteLine("SouthWest");
                for (int d = 0; d < sw.Length; d++)
                {
                    Console.WriteLine("{0},{1}", sw[d].x, sw[d].y);
                }
                Console.WriteLine("SouthEast");
                for (int d = 0; d < se.Length; d++)
                {
                    Console.WriteLine("{0},{1}",se[d].x,se[d].y);
                }

                NW = new Quad(nw,nwx1,nwy1,nwx2,nwy2,"nw");
                NW.parent = this;
                NE = new Quad(ne, nex1, ney1, nex2, ney2,"ne");
                NE.parent = this;
                SW = new Quad(sw, swx1, swy1, swx2, swy2,"sw");
                SW.parent = this;
                SE = new Quad(se, sex1, sey1, sex2, sey2,"se");
                SE.parent = this;
            }
            else if (point.Length == 1)
            {

                Console.WriteLine("THIS IS A LEAF!!!({0},{1})",point[0].x,point[0].y);
                
                
            }
            
        }
        public Quad GetUp(Quad quad)
        {
            string debugType = this.type;
            if (this.type[0] == 'n')
            {
                Quad tempParent = this.parent;
                while (tempParent.type[0] == 'n'){

                    tempParent = tempParent.parent;
                    
                }
                if (tempParent.type == "root"){

                    return null;

                }
                else
                {
                    return tempParent.GetUp(tempParent);
                }
                

            }
            else if (this.type[0] == 's')
            {
                if (this.type == "sw")
                {
                    return this.parent.NW;

                }
                else if (this.type == "se")
                {
                    return this.parent.NE;
                }
            }
            else
            {
                Console.WriteLine("This shouldn't happen");
                return this.parent;
            }
            Console.WriteLine("This shouldn't happen");
            return this.parent;
        }
        public Quad GetDown(Quad quad)
        {
            if (this.type[0] == 's')
            {
                Quad tempParent = this.parent;
                while (tempParent.type[0] == 's')
                {

                    tempParent = tempParent.parent;

                }
                if (tempParent.type == "root")
                {

                    return null;

                }
                else
                {
                    return tempParent.GetDown(tempParent);
                }


            }
            else if (this.type[0] == 'n')
            {
                if (this.type == "nw")
                {
                    return this.parent.SW;

                }
                else if (this.type == "ne")
                {
                    return this.parent.SE;
                }
            }
            else
            {
                Console.WriteLine("This shouldn't happen");
                return this.parent;
            }
            Console.WriteLine("This shouldn't happen");
            return this.parent;
        }
        public Quad GetLeft(Quad quad)
        {

            if (this.type[1] == 'w')
            {
                Quad tempParent = this.parent;
                while (tempParent.type[1] == 'w')
                {

                    tempParent = tempParent.parent;

                }
                if (tempParent.type == "root")
                {

                    return null;

                }
                else
                {
                    return tempParent.GetLeft(tempParent);
                }


            }
            else if (this.type[1] == 'e')
            {
                if (this.type == "ne")
                {
                    return this.parent.NW;

                }
                else if (this.type == "se")
                {
                    return this.parent.SW;
                }
            }
            else
            {
                Console.WriteLine("This shouldn't happen");
                return this.parent;
            }
            Console.WriteLine("This shouldn't happen");
            return this.parent;
        }
        public Quad GetRight(Quad quad)
        {

            if (this.type[1] == 'e')
            {
                Quad tempParent = this.parent;
                while (tempParent.type[1] == 'e')
                {

                    tempParent = tempParent.parent;

                }
                if (tempParent.type == "root")
                {

                    return null;

                }
                else
                {
                    return tempParent.GetRight(tempParent);
                }


            }
            else if (this.type[1] == 'w')
            {
                if (this.type == "nw")
                {
                    return this.parent.NE;

                }
                else if (this.type == "sw")
                {
                    return this.parent.SE;
                }
            }
            else
            {
                Console.WriteLine("This shouldn't happen");
                return this.parent;
            }
            Console.WriteLine("This shouldn't happen");
            return this.parent;
        }


        public Point FindNearestPoint(Point point)
        {
            if (NW != null && NE != null && SW != null && SE != null)
            {

                if (
                    point.x >= NW.x1 &&
                    point.x <= NW.x2 &&
                    point.y >= NW.y1 &&
                    point.y <= NW.y2
                    )
                {
                    return NW.FindNearestPoint(point);
                }
                else if (
                    point.x >= NE.x1 &&
                    point.x <= NE.x2 &&
                    point.y >= NE.y1 &&
                    point.y <= NE.y2
                )
                {
                    return NE.FindNearestPoint(point);
                }
                else if (
                    point.x >= SW.x1 &&
                    point.x <= SW.x2 &&
                    point.y >= SW.y1 &&
                    point.y <= SW.y2
                )
                {
                    return SW.FindNearestPoint(point);
                }
                else if (
                   point.x >= SE.x1 &&
                   point.x <= SE.x2 &&
                   point.y >= SE.y1 &&
                   point.y <= SE.y2
                   )
                {
                    return SE.FindNearestPoint(point);
                }
                else
                {
                    Console.WriteLine("this shouldn't happen (returning the point you gave me");
                    return point;
                }
            }
            else//We have now reached a leaf
            {
                Console.WriteLine( "We are now in a leaf!!");
                Point[] toCompare = new Point[10];
                int index = 0;
                int lowestIndex = -1;
                double lowestDist = 1000;
                Quad above;
                Quad left;
                Quad below;
                Quad right;
                if (this.type == "nw")
                {
                    Console.WriteLine("The point was in a NW quad");
                    above = this.GetUp(this);
                    left = this.GetLeft(this);
                    if (above != null)
                    {
                        for (int i = 0; i < above.point.Length; i++)
                        {
                            toCompare[index] = above.point[i];
                            index++;
                        }
                    }
                    
                    for (int i = 0; i < parent.point.Length; i++)
                    {
                        toCompare[index] = parent.point[i];
                        index++;
                    }
                    if (left != null)
                    {
                        for (int i = 0; i < left.point.Length; i++)
                        {
                            toCompare[index] = left.point[i];
                            index++;
                        }
                    }
                    

                }
                else if (this.type == "ne")
                {
                    Console.WriteLine("The point was in a NE quad");
                    above = this.GetUp(this);
                    right = this.GetRight(this);

                    if (above != null)
                    {
                        for (int i = 0; i < above.point.Length; i++)
                        {
                            toCompare[index] = above.point[i];
                            index++;
                        }
                    }
                    
                    for (int i = 0; i < parent.point.Length; i++)
                    {
                        toCompare[index] = parent.point[i];
                        index++;
                    }
                    if (right != null)
                    {
                        for (int i = 0; i < right.point.Length; i++)
                        {
                            toCompare[index] = right.point[i];
                            index++;
                        }
                    }
                    
                }
                else if (this.type == "sw")
                {
                    Console.WriteLine("The point was in a SW quad");
                    below = this.GetDown(this);
                    left = this.GetLeft(this);


                    if (below != null)
                    {
                        for (int i = 0; i < below.point.Length; i++)
                        {
                            toCompare[index] = below.point[i];
                            index++;
                        }
                    }
                    
                    for (int i = 0; i < parent.point.Length; i++)
                    {
                        toCompare[index] = parent.point[i];
                        index++;
                    }

                    if (left != null)
                    {
                        for (int i = 0; i < left.point.Length; i++)
                        {
                            toCompare[index] = left.point[i];
                            index++;
                        }
                    }
                    

                }
                else if (this.type == "se")
                {

                    Console.WriteLine("The point was in a SE quad");
                    below = this.GetDown(this);
                    right = this.GetRight(this);
                    
                    if (below != null)
                    {
                        for (int i = 0; i < below.point.Length; i++)
                        {
                            toCompare[index] = below.point[i];
                            index++;
                        }
                    }
                    
                    for (int i = 0; i < parent.point.Length; i++)
                    {
                        toCompare[index] = parent.point[i];
                        index++;
                    }

                    if(right != null)
                    {
                        for (int i = 0; i < right.point.Length; i++)
                        {
                            toCompare[index] = right.point[i];
                            index++;
                        }
                    }
                    

                }
                else
                {
                    Console.WriteLine("You shouldn't be here");
                    return point;
                }
                for(int i = 0; i < index; i++)
                {
                    int tomultiplyx = point.x - toCompare[i].x;
                    int tomultiplyy = point.y - toCompare[i].y;
                    double newDist = Math.Sqrt((tomultiplyx * tomultiplyx) + (tomultiplyy * tomultiplyy));
                    if (newDist < lowestDist)
                    {
                        lowestDist = newDist;
                        lowestIndex = i;
                    }
                    
                    
                }
                return toCompare[lowestIndex]; ;
            }
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
            Console.WriteLine("Enter a cartesian point(x)(max:50)");
            userx = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a cartesian point(y)(max:12)");
            usery = int.Parse(Console.ReadLine());
            Point userPoint = new Point();
            userPoint.x = userx;
            userPoint.y = usery;
            root.parent = root;
            userPoint = root.FindNearestPoint(userPoint);
            Console.WriteLine("The nearest point is at ({0},{1})",userPoint.x,userPoint.y);


        }
    }
}
