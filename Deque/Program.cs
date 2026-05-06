class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Deque Implementation");
     Console.WriteLine("AddFirst;  AddLast; RemoveFirst;  RemoveLast;  PeekFirst; PeekLast");

        Deque<int> d = new Deque<int>();

     
        d.AddFirst(3);
        d.AddFirst(6);
        d.AddFirst(9);
        d.AddFirst(15);
        d.AddLast(8);

          
      
        Console.WriteLine($"RemoveLast: {d.RemoveLast()}");
        Console.WriteLine($"RemoveLast: {d.RemoveLast()}");
        Console.WriteLine($"RemoveLast: {d.RemoveLast()}");
        Console.WriteLine($"RemoveLast: {d.RemoveLast()}");
 
        
        Console.WriteLine($"PeekFirst: {d.PeekFirst()}");
        Console.WriteLine($"PeekLast: {d.PeekLast()}");
    }
}

class Node<T>
{
    Node<T> next;
    Node<T> previous;
    T value;


    public T Value{
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


    public Node(T value)
    {
        this.value = value;
        next = null;
        previous = null;
    }

}
class Deque<T>
{
    Node<T> Head;
    Node<T> Tail;
    int count;


    public int Count => count;
    public Deque()
    {
        Head = null;
        Tail = null;
        count = 0;
    }

    public void AddFirst(T value)
    {
        var n = new Node<T>(value);
  
        
        if(Head == null)
        {
            Head = n;
            Tail = n;
            count++;
            return;    
        }

        n.Next = Head;
        Head.Previous = n;
        Head = n;
        count++;
    }
    public  void AddLast(T value)
    {
        var n = new Node<T>(value);
      
        if (Head == null)
        {
            Head = n;
            Tail = n;
            count++;
            return;
        }
         
        n.Previous = Tail;
        Tail.Next = n;
        Tail = Tail.Next;
        count++;
    } 
    public T PeekFirst()
    {
        if(Head == null)
        {
            throw new InvalidOperationException("Empty list...");
        }
        return Head.Value;
    }
    public T PeekLast()
    {
        if (Tail == null)
        {
            throw new InvalidOperationException("Empty list...");
        }
        return Tail.Value;
    }
    public T RemoveFirst()
    {
        if(Head == null)
        {
            throw new InvalidOperationException("Empty list...");
        }
        if (Head.Next == null)
        {
            var H = Head.Value;
            Head = null;
            Tail = null;
            count--;
            return H;
        }

        T h = Head.Value;
        Head.Next.Previous = null;
        Head = Head.Next;
        count--;
        return h;
    }
    public T RemoveLast()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("Empty list...");
        }
        if(Head.Next == null)
        {
            var H = Head.Value;
            Head = null;
            Tail = null;
            count--;
            return H;
        }

        T t = Tail.Value; 
        Tail = Tail.Previous;
        Tail.Next = null;
        count--;
        return t;
    }


}