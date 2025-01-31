
//Question
//A celebrity is a person who is known to all but does not know anyone at a party.
//A party is being organized by some people.  A square matrix mat (n*n) is used to represent people at the party such that
//if an element of row i and column j is set to 1 it means ith person knows jth person.
//You need to return the index of the celebrity in the party, if the celebrity does not exist, return -1.

class CelebrityStackProblem
{
    //lets say 3*3 matrix as it is 3 by 3 , it contains celebrity {0,1,2}
    //peek then study the combination

    int top = -1;
    int capacity;
    int count;
    int[] celebrityStack;
    int[] tempCelebrityStack;
    int numOfStackComponent;
    int N;

    public void CelebrityOrNot(int[,] celebrityStatus, int[]celebrityStack)
    {
        int specificOne = Pop(celebrityStack);
        //Console.WriteLine(specificOne);
        
        int specificTwo = Pop(celebrityStack);
        //Console.WriteLine(specificTwo);

        Push(specificTwo, celebrityStack);
        Push(specificOne, celebrityStack);

        if (celebrityStatus[specificOne,specificTwo] == 1)
        {
            //Console.WriteLine($"{specificTwo} is known");
            //Console.WriteLine($"{specificOne} is not a celebrity");
            int removedOne;
            do
            {
                removedOne = Pop(celebrityStack);
            }
            while (removedOne != specificOne);
            Push(specificTwo, celebrityStack);

        }
        else if (celebrityStatus[specificOne,specificTwo] == 0)
        {
            //Console.WriteLine($"{specificTwo} is  not a celebrity");
            //Console.WriteLine($"{specificOne} may be a celebrity");
            int removedOne;
            do
            {
                if (Pop(celebrityStack) == -1)
                {
                    return;
                }
                removedOne = Pop(celebrityStack);
            }
            while (removedOne != specificTwo);
            Push(specificOne, celebrityStack);
        }

    }

    public int ToEnsure(CelebrityStackProblem celebrityStackProblem, int[,] celebrityStatus)
    {
        int lastPerson=celebrityStackProblem.Peek(celebrityStack);
        int celebrity = 0;
        //CelebrityStackProblem s2 = new CelebrityStackProblem();
        for (int i = 0; i < celebrityStatus.GetLength(0); i++)
        {
            if (celebrityStatus[i,lastPerson] == 1)
            {
                celebrity++;
            }
        }
        if (celebrity==0)//if still it is known by anyone
        {
            Console.WriteLine("No there is no any celebrity");
            return -1;
        }
            //Console.WriteLine($"Hurray ! {lastPerson} is celebrity at {numOfStackComponent}");
            return numOfStackComponent;
    }

    public void invitePeople(int[] celebrityStack)
    {
        Push(0, celebrityStack);
        Push(1, celebrityStack);
        Push(2, celebrityStack);
        Push(3, celebrityStack);
    }

    void Push(int value, int[] celebrityStack)
    {
        if (top == capacity - 1)
        {
            Console.WriteLine("The capacity is full");
        }
        else
        {
            top++;
            celebrityStack[top] = value;
            count++;
        }
    }

    int Pop(int[] celebrityStack)
    {
        if (top != -1)
        {
            int atTop = celebrityStack[top];
            top--;
            count--;
            return atTop;
        }
        else
        {
            Console.WriteLine("The stack is empty");
            return -1;
        }
    }

    int Count()
    {
        int count = 0;
        int toKnowTop=top;
        while (toKnowTop != -1)
        {
            toKnowTop--;
            count++;
        }
        return count;
    }

    int Peek(int[] celebrityStack)
    {
        if (top != -1)
        {
            //Console.WriteLine($"There is {celebrityStack[top]} at the top");
            return celebrityStack[top];
        }
        return -1;
    }

    int Position(CelebrityStackProblem s1, int[] celebrityStack)
    {
        numOfStackComponent = N-1;
        int lastPerson = s1.Peek(celebrityStack);
        while (celebrityStack[numOfStackComponent] != lastPerson)
        {
            numOfStackComponent--;
        }
        return numOfStackComponent;

    }
    static void Main()
    {
        CelebrityStackProblem s1 = new CelebrityStackProblem();
        //int[,] celebrityStatus = {
        //                          {0,0,1},
        //                          {1,0,1},
        //                          {0,0,0}
        //CelebrityStackProblem s2 = new CelebrityStackProblem();
        //                         };
        //int[,] celebrityStatus = {
        //                          {0,1,0},
        //                          {0,0,0},
        //                          {0,1,0}
        //                         };
        int[,] celebrityStatus = {
                                  {0,1,0,0},
                                  {0,0,0,0},
                                  {0,1,0,0},
                                  {0,1,0,0}
                                 };
        s1.N=celebrityStatus.GetLength(0);
        s1.celebrityStack = new int[s1.N];//define according to celebrityStatus , number of rows
        s1.capacity= s1.celebrityStack.Length;
        s1.invitePeople(s1.celebrityStack);
        s1.tempCelebrityStack = new int[s1.N]; 
        s1.tempCelebrityStack = s1.celebrityStack;
        s1.count = s1.Count();
        while (s1.count > 1)
        {
            s1.CelebrityOrNot(celebrityStatus , s1.celebrityStack);
        }

        //s1.ToEnsure(s1,celebrityStatus);
        if(s1.ToEnsure(s1, celebrityStatus) != -1)
        {
            Console.WriteLine( s1.Position(s1,s1.tempCelebrityStack));
        }

    }


}

//Output: 
//Hurray! 1 is celebrity