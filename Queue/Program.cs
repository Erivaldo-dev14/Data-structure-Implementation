class Program
{
    static void Main(string[] args)
    {
        MyQueue<string> m = new MyQueue<string>();

        m.Enqueue("10");
         

        m.Enqueue("20");
      
        m.Enqueue("30");
        

        //for(int i = 0; i < 3; i++)
        //{
        //    Console.WriteLine("Count: " + m.Dequeue());
        //}

       // Console.WriteLine(m.Peek());
         
        if(m.TryDequeue(out string v))
        {
            Console.WriteLine($"Valor Removido: {v} ");
        }
        else
        {
            Console.WriteLine($"Lista Vazia...");
        }
        Console.WriteLine(m.Peek());


    }
}

class Node<T>
{
    Node<T> next;
    Node<T> previous;
    T value;
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

    public T Value
    {
        get => value;
        set
        {
            this.value = value;
        }
    }

    public Node()
    {
        next = null;
        previous = null;
    }
}
class MyQueue<T>
{
    int count;
    Node<T> tail;
    Node<T> Head;
    public int Count => count;
     


    public MyQueue()
    {
        tail = null;
        Head = null;
        count = 0;
    }
    public void Enqueue(T value)
    {
        var n = new Node<T>();
        n.Value = value;
        if (Head == null)
        {
             
           
            Head = n;
            tail = n;
            count++;
            return;
        }

        
        n.Previous = Head;
        Head = n;
        Head.Previous.Next = Head;

        count++;
    }
    public T Peek()
    {
        if(tail == null)
        {
            throw new InvalidOperationException("trying to get value from an empty list...");
        }

        return tail.Value;
    }

    public T Dequeue()
    {
        
        if (tail == null)
        {
            throw new InvalidOperationException("trying to remove value from an empty list...");
        }
        var p = tail.Value;

        if (tail == Head)
        {
             
            tail = null;
            Head = null;
            count--;
            return p;
        }

         
         
        tail = tail.Next;
        tail.Previous = null;
        count--;
        return p;
    }
    public bool TryDequeue(out T result)
    {
        if(tail == null)
        {
            result = default;
            return false;
             
        } 
           

         
        result = Dequeue();
        return true;

    }
   
}