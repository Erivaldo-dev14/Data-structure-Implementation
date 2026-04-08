using System.Net.WebSockets;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        MyStack<int> ms = new MyStack<int>();
        MyStack<string> ms2 = new MyStack<string>();

        ms2.Push("erivaldo: 10");
        ms2.Push("erivaldo: 2");
        ms2.Push("eri: 16");

        ms.Push(10);
        ms.Push(24);
        ms.Push(16);
      
        Console.WriteLine($"Count: {ms2.Count}");
        for (int i = 0; i< 3; i++)
        {
            Console.WriteLine($"peek: {ms2.Pop()}");
        }

        //Console.WriteLine($"peek: {ms.Pop()}");
        Console.WriteLine($"Count: {ms2.Count}");

    }
}


class Node<T>
{
     
    private Node<T> next;
    private T value_;

    public  T value
    {
        get => value_;
        set
        {
            if (value == null)
                return;
            value_ = value;
        }
    }  
    public Node()
    {
        
        next = null;
    }
    
    public Node<T> Next
    {
        get
        {
            return next;
        }
        set
        {
            next = value;
        }
    }
  

    

}
class MyStack<T>
{
    
    Node<T> Head;
    int count;


    public int Count => count;
    public MyStack()
    {
        Head = null;
        count = 0;
    }
    public void Push(T value)
    {
        var top = new Node<T>();
        top.value = value;

        if (Head == null)
        {
            

            Head = top;
            count++;
            return;
        }

        top.Next = Head; 
        Head = top;
        count++;

    }

    public T Pop()
    {
        if(Head == null)
        {
            throw new ArgumentException("Error: Empty Stack...");
        }

        var top = Head;
        Head = Head.Next;
        count--; 
        return top.value;
    }
    public T Peek()
    {
        if(Head == null)
            throw new ArgumentException("Error: Empty Stack...");

        return Head.value;
    }
    public void Clear()
    {
        count = 0; 
        Head = null;
    }

}