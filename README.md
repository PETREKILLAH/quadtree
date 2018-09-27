# Pete's Quadtree Project
A program that places a bunch of random 2D points on a plane and puts them into a quadtree and then returns the nearest random 
point to a point that the player inputs

# What is a Quadtree?
A quadtree is a type of data structure. All trees consist of a root, branches, and leaves. Every point on a tree is called a node.
A nodes have branches while others don't. If a node doesn't have branches, it is a leaf. The root it the highest level of a tree.
Quadtrees are trees that specifically have 4 branches per node.
An example of this is show below...
![a quadtree](https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/Quad_tree_bitmap.svg/1280px-Quad_tree_bitmap.svg.png "A quadtree")

# Why use a Quadtree?
Quadtrees are great for representing 2D space. Because of this, many video games utilize quadtrees, or octotrees, the 3D alternative, for
rendering, and collisions. This is achieved by dividing a space into four quads and then quads that are intercepting points of collision
are further subdivided until the desired resolution is reached.
A visualization of this below
![A quadtree implement](https://www.degruyter.com/view/j/jisys.2014.23.issue-1/jisys-2013-0014/graphic/jisys-2013-0014_fig10.jpg "A Quad tree implementation")

# How do I use this?
1. Download Visual Studio 2017
2. Open up Quadtree_project
3. Open up Quadtree_project.sln with visual studio
4. Hit ctrl+F5 to start the program
5. At this point, the program should start displaying a few things
The randomly generated points
Where these points are being stored in the tree
My tree's nodes have four possible names

    + North West
  
    + North East

    + South West

    + South East

    When points are stored into those quads, they are stored in that order. As the tree is being constructed, the point's locations
    are displayed to the console. The way to read it goes as follows.
    If North West is displayed along with its points, and then North West is displayed again, that means the points displayed under
    the second North West is a subquad belonging to the previous North West quad.
    ![A quadtree implement](https://i.imgur.com/cFBE3qB.png "A Quad tree implementation")
    
    
6. Type in a positive integer 0-50. This is your x coordinate. Then, type in a positive integer 0-20. This is your y coordinate
7. At this point, the console should display what the nearest point is to the point that you entered.

# How it works
Firstly, 10 points are generated randomly. Then, they are placed in instances of the quad class whose constructor recursively
creates more subquads and places points into them.
After the user's points is stored, a member function of quad is used which recursively searches for the nearest point by grabbing the points in the parent quad of the leaf that the point belongs to, along with the adjecent quads. After all of the points in those quads are stored, a simple distance formula calculation is done to find which of those points are closer. Finally, the result is pushed to
the console.

# Closing Remarks
While making this project, I learned some of the basics of data structures and trees. I learned many of the great functionalities of classes and recursion. I can safely say that while making this project, I have strengthened my skills as a programmer.


