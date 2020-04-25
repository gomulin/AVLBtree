using System;
using System.Linq;
using System.Collections.Generic;
public class Node
{
    public int key;
    public Node left;
    public Node right;
    public int height;
    public Node(int x)
    {
        height = 1;
        key = x;
    }
}
public class Avl
{
    public Node root;
    public Avl() { }

    public void Insert(int x)
    {
        root = insert(root, x);
    }

    private int height(Node p)
    {
        return p == null ? 0 : p.height;
    }

    private int getBalance(Node p)
    {
        return p == null ? 0 : height(p.left) - height(p.right);
    }
    private Node insert(Node p, int x)
    {
        if (p == null)
            return new Node(x);
        if (x < p.key)
            p.left = insert(p.left, x);
        else
            p.right = insert(p.right, x);

        p.height = 1 + Math.Max(height(p.left), height(p.right));

        int balance = getBalance(p);

        if (balance < -1 && x > p.right.key)
        {
            return lRot(p);
        }

        if (balance > 1 && x < p.left.key)
        {
            return rRot(p);
        }

        if (balance > 1 && x > p.left.key)
        {
            p.left = lRot(p.left);
            return rRot(p);
        }

        if (balance < -1 && x < p.right.key)
        {
            p.right = rRot(p.right);
            return lRot(p);
        }

        return p;
    }
    public void Print()
    {
        print(root, 0);
    }
    private void print(Node p, int shift)
    {
        if (p.left != null)
            print(p.left, shift + 1);
        for (int i = 0; i != shift; i++)
            Console.Write("  ");
        Console.WriteLine(p.key);
        if (p.right != null)
            print(p.right, shift + 1);
    }
    public void store(Node p, List<Node> nodes)
    {
        if (p == null)
            return;
        store(p.left, nodes);
        nodes.Add(p);
        store(p.right, nodes);
    }
    public Node buildtree(Node p)
    {
        var nodes = new List<Node>();
        store(p, nodes);
        return buildit(nodes, 0, nodes.Count - 1);
    }
    public Node buildit(List<Node> nodes, int start, int end)
    {
        if (start > end)
            return null;
        int mid = (start + end) / 2;
        Node p = nodes[mid];
        p.left = buildit(nodes, start, mid - 1);
        p.right = buildit(nodes, mid + 1, end);
        return p;
    }

    public Node RotateLeft(Node rt)
    {
        var piv = rt.right;
        rt.right = piv.left;
        piv.left = rt;
        return piv;
    }
    public Node RotateRight(Node rt)
    {
        var piv = rt.left;
        rt.left = piv.right;
        piv.right = rt;
        return piv;
    }

    public Node rRot(Node y)
    {
        var x = y.left;
        var T2 = x.right;

        x.right = y;
        y.left = T2;

        y.height = 1 + Math.Max(height(y.left), height(y.right));
        x.height = 1 + Math.Max(height(x.left), height(x.right));

        return x;
    }

    public Node lRot(Node x)
    {
        var y = x.left;
        var T2 = y.right;

        y.right = x;
        x.left = T2;

        x.height = 1 + Math.Max(height(x.left), height(x.right));
        y.height = 1 + Math.Max(height(y.left), height(y.right));

        return y;
    }

}
class pr
{
    static void Main()
    {
        var obj = new Avl();

        var rnd = new System.Random(1);
        //var init = Enumerable.Range(0, 9) .OrderBy(x => rnd.Next())
        int[] init = { 5, 6, 7, 8, 9, 10, 11, 12, 4, 3 };

        foreach (var i in init)
        {
            obj.Insert(i);
        }

        //obj.Insert(5);
        //obj.Insert(3);
        //obj.Insert(7);
        //obj.Insert(2);
        //obj.Insert(4);

        //obj.Print();

        //obj.root = obj.RotateRight(obj.root);

        //obj.Print();

        //obj.root = obj.RotateLeft(obj.root);

        obj.Print();







        //var rnd = new System.Random(1);
        //var init = Enumerable.Range(0, 15).OrderBy(x => rnd.Next()).ToArray();
        //foreach (var i in init)
        //    obj.Insert(i);



        ////obj.Print();

        //obj.root = obj.buildtree(obj.root);

        //obj.Print();


        // var lst = new LinkedList<int>();
        // lst.FindIndex(); // FindIndex List

        // k7k
        // kk6
        // 5kk
        // kk3
        // k2k
        // kk1

        //     10
        //  5     15
        //2  8   12

    }
}
