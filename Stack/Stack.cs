class Stack
{
    int[] myStack=new int[5];
    int top = -1;
    int capacity;

    static void Main()
    {
        Stack stack = new Stack();
        stack.capacity = stack.myStack.Length;
        stack.Push(3);
        stack.Push(4);
        stack.Push(50);
        stack.Display();
        stack.Pop();
        stack.Peek();
    }
    
    void Push(int value)
    {
        if (top == capacity - 1)
        {
            Console.WriteLine("The capacity is full");
        }
        else
        {
            myStack[++top] = value;
        }
    }

    void Pop()
    {
        if (top != -1)
        {
            top--;
        }
        else
        {
            Console.WriteLine("The stack is empty");
        }
    }

    void Peek()
    {
        if (top != -1)
        {
            Console.WriteLine($"At the top {myStack[top]}");
        }
    }

    void Display()
    {
        Console.Write("This stack contains ");
        for (int i = top; i >= 0; i--)
        {
            Console.Write(myStack[i] + " ");
        }
    }
    
}
