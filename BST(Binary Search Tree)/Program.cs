class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("BST(Binary Search Tree) Implementation");

        BST b = new BST();

        b.Insert(20);
        b.Insert(180);
        b.Insert(18);
        b.Insert(10);
        b.Insert(19);
        b.Insert(80);
        b.Insert(200);
        b.Insert(11);
        b.Insert(9);
        b.Insert(9.5f);
        b.Insert(12);
        var a = b.Get(9);

        Console.WriteLine($"value: {a.Value}");
        // Console.WriteLine($"Value.Left: {a.Left.Value}");
        // Console.WriteLine($"Value.Right: {a.Right.Value}");
        Console.WriteLine($"Value.Height-Left: {a.HeightLeft}");
        Console.WriteLine($"Value.Height-Right: {a.HeightRight}");
        Console.WriteLine($"Value.Height: {a.B_Factor}");


    }
}

class Node
{
    float value;
    Node right;
    Node left;
    int heightRigt;
    int heightLeft;
    int b_factor;

    public float Value
    {
        get => value;

        set => this.value = value;
    }
    public int HeightRight
    {
        get => heightRigt;

        set => heightRigt = value;
    }
    public int HeightLeft
    {
        get => heightLeft;

        set => heightLeft = value;
    }

    public int B_Factor
    {
        get => b_factor;

        set => b_factor = value;
    }

    public Node Right
    {
        get => right;

        set => right = value;
    }
    public Node Left
    {
        get => left;

        set => left = value;
    }
    public Node()
    {
        value = default;
        right = null;
        left = null;
        heightRigt = default;
        heightLeft = default;
        b_factor = default;

    }

}

class BST
{
    Node root;
    
    int count;
    

    public float Value => root.Value;
    public int Count => count;

    public BST()
    {
        root = null;
        count = 0;
       
    }
     
    public void Insert(float value)
    {

        root = Insert(value, root);
    }
    public Node Insert(float value, Node n)
    {

        if(n == null)
        {
            n = new Node();
            n.Value = value;
            count++;
            return n;
        }
        if(n.Value > value)
        {
            
            n.Left = Insert(value, n.Left);
             
        }
        else
        {
            
            n.Right = Insert(value, n.Right);
             
        }
         
        n.HeightLeft = (n.Left == null) ? -1 : Math.Max(n.Left.HeightLeft, n.Left.HeightRight) + 1;
        n.HeightRight = (n.Right == null) ? -1 : Math.Max(n.Right.HeightLeft, n.Right.HeightRight) + 1;

        n.B_Factor = n.HeightLeft - n.HeightRight;

        if(n.B_Factor  == 2)
        {
            var n2 = n;

            
            

        }


        return n;
    }

    public void RotateLeft(Node n)
    {

    
    }
    public void RotateRight() { }
   
    public Node Get(float value)
    {
        if(root == null)
        {
            throw new InvalidOperationException("You're trying to iterate an empty tree...");
        }
        if(root.Value == value)
        {
            return root;
        }


        return Get(value, root);
    }
    private Node Get(float value, Node r)
    {
        if(r == null)
        {
            throw new InvalidOperationException("THE VALUE WAS NOT FOUND");
        }

        if(r.Value == value)
        {
            return r;
        }

        if (r.Value > value)
            return Get(value, r.Left);

        return Get(value, r.Right);

    }


}