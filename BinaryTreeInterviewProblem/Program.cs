using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeInterviewProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(5);
            root.left = new Node(10);
            root.right = new Node(15);
            root.left.left = new Node(20);
            Node x = new Node(25);
            root.left.right = x;
            root.left.right.left = new Node(35);
            NodeHeight i = new NodeHeight();
            // first we found the height of our node
            int heightOfMyNode = i.getNodeHeight(root, x, 1);
            //then we print all the nodes in the same depth as my node
            PrintNodesAtKDistance j = new PrintNodesAtKDistance();
            Console.WriteLine("Nodes at x distance from root: ");
            j.Print(root,heightOfMyNode);
            Console.ReadLine();
        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }
        }

        public class NodeHeight
        {
            public int getNodeHeight(Node root, Node x, int height)
            {
                if (root == null) return 0;
                if (root == x) return height;

                //check if it finds the node in the left side
                int level = getNodeHeight(root.left, x, height + 1);

                if (level != 0) return level;

                return getNodeHeight(root.right, x, height + 1);
            }

        }

        public class PrintNodesAtKDistance
        {
            public void Print(Node root, int k)
            {
                if (root != null)
                {
                    if (k == 0)
                    {
                        Console.WriteLine(" " + root.data);
                    }
                    Print(root.left, --k);
                    Print(root.right, k);
                }
            }
        }
    }
}
