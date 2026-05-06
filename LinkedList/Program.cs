using System.Globalization;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        MyLinkedList<int> my = new MyLinkedList<int>();
       
        
      


         
        my.AddLast(60); 
        my.AddFirst(10);
        my.AddFirst(20);
        my.AddFirst(30);
        my.AddFirst(40);
        my.AddFirst(50);
        my.AddFirst(10);
        my.AddLast(70);



        var nd1 = my.FindFirst(70);
        var nd2 = my.FindLast(10);

        Console.WriteLine($"Anterior {nd2.Previous.Value}");
        Console.WriteLine($"sucessor {nd2.Next.Value}");


        //var node = my.FindFirst(70);
        //Node<int> nd = new Node<int>();
        //var nd2 = new Node<int>();
        //nd.Value = 39;
        //nd2.Value = 22;

        //Console.WriteLine($"New Tail: {my.Last}");
         my.Remove(nd1);

        //Console.WriteLine(my.AddBefore(node, 115));
        // //Console.WriteLine(my.AddAfter(node, 11));
        // my.Remove(node);
          my.MostrarElementos();


        //if(node != null)
        //{
        //    Console.WriteLine($"Node.Value: {node.Value}");
        //    Console.WriteLine($"Node.Previous.Value: {node.Previous.Value}");
        //    Console.WriteLine($"Node.Next.Value: {node.Next.Value}");
        //}

        my.IsValid();


    }
}
class Node<T>
{
    T value;
    Node<T>  next;
    Node<T> previous;

    public Node()
    {
       
        next = null;
        previous = null;
    }
    public T Value 
    {
        get => value;

        set
        { 
            this.value = value;
        }
    }
    public Node<T> Next  
    {
        get => next;

        set
        {
            
            next = value;
        }
    }
    public Node<T> Previous
    {
        get => previous;

        set
        {
            previous = value;
        }
    }
}
class MyLinkedList<T>
{
    
    Node<T> Head;
    Node<T> tail;
    

    public Node<T> First => Head;
    public Node<T> Last => tail;

    public MyLinkedList()
    {
        Head = null;
        tail = null;
    }
    public void AddFirst(T value)
    {
        Node<T> n = new Node<T>();
        
        if (Head == null)
        {
             
            Head = new Node<T>();
            Head.Value = value;
            tail = Head;
            return;
        }
        
         
        n.Next = Head;
        var n2 = n.Next;
        n.Value = value;
        Head = n;
        n2.Previous = Head;

    }
    public void AddLast(T value)
    {
        if (Head == null)
        {
            var nod = new Node<T>();
            nod.Value = value;
            Head = nod;
            tail = nod;
            return;
        }

        var chain = new Node<T>();

        chain.Value = value;
        chain.Previous = tail;
        tail.Next = chain; 
        tail = tail.Next;
        

       
        

    }
    public void MostrarElementos()
    {
        if (Head == null)
            return;
        Node<T> n = Head;
      

        while (n != null)
        {
            Console.Write($"Value: {n.Value}\n");
            n = n.Next;
        }
    }

    public Node<T> FindFirst(T value)
    {
        if (Head == null) return Head;
        Node<T> n = Head;
        
        while(!EqualityComparer<T>.Default.Equals(n.Value, value))
        {
            if (n.Next == null)
                break;
             
            n = n.Next;
        }

        if (n.Value.Equals( value))
            return n;
        
        return null;

    }
    public Node<T> FindLast(T value)
    {
        if (Head == null) return Head;
        Node<T> n = tail;

        while (!EqualityComparer<T>.Default.Equals(n.Value, value))
        {
            if (n.Previous == null)
                break;

            if (n.Previous.Value.Equals(value))
            {
                n = n.Previous;
                break;
            }

            n = n.Previous;
        }

        if (n.Value.Equals(value))
            return n;

        return null;

    }


    public bool Remove( Node<T> n)
    {
        if(Head == null)
        {
            throw new ArgumentException("You are trying to iterate an empty list...");

        }
        if (n == null)
        {
            throw new ArgumentException("You are trying to pass a null object...");

        }

        if (Head == n && Head.Next == null)
        {
            Head = null;
            tail = null;

            return true;
        }
        if (tail == n)
        {
            
            tail.Next = tail.Previous;
            tail = tail.Next;
            tail.Next = null;
   
            return true;
        }
     
        else if(Head == n && Head.Next != null)
        {
            
                Head = Head.Next;
                Head.Previous = null;
                return true;
            
        }
         
        if(n.Next != null)
        {
            n.Previous.Next = n.Next;

            n.Next.Previous = n.Previous;
             
            return true;
        }
        
        return false;
         

    }

    private bool VerifyNode(Node<T> node)
    {
        if (node == null)
            return false;
        var n = Head;
        while(n != node)
        {
            if (n.Next == null)
                break;
            n = n.Next;
        }

        if(n == node)
        {
            return true;
        }

        return false;

    }
    public bool AddBefore(Node<T> node,T value)
    {
        var newnode = new Node<T>();
        newnode.Value = value;

        if (node == Head)
        {
            newnode.Next = Head;
            Head.Previous = newnode;
            Head = newnode;

            return true;
        }
         
        if (!VerifyNode(node) )
        {
            return false;
        }

         

        newnode.Previous = node.Previous;
        node.Previous.Next = newnode;
        node.Previous = newnode;
        newnode.Next = node;
        
        return true ;
    }
    public bool AddAfter(Node<T> node, T value)
    {
        var newnode = new Node<T>();
        newnode.Value = value;
       
        if (node == tail)
        {
            newnode.Previous = tail;
            tail.Next = newnode;
            tail = tail.Next;
            

            return true;
        }

        if (node == Head && Head.Next == null)
        {
            newnode.Previous = Head;
            Head.Next = newnode;
          
            return true;
        }

        if (node == Head && Head.Next != null)
        {
            newnode.Next = Head.Next;
            newnode.Previous = Head;
            Head.Next.Previous = newnode;
            Head.Next = newnode;

            return true;
        }
        if (!VerifyNode(node))
        {
            return false;
        }
        newnode.Next = node.Next;
        node.Next.Previous = newnode;
        newnode.Previous = node;
        node.Next = newnode;

      

        return true;
    }

   



}