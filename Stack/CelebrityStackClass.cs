class CelebrityStackClass
{
    int[] celebrityStack;
    int[] tempCelebrityStack;
    int[,] celebrityStatus;
    int numOfPeopleInParty;
    int top = -1;
    int count = 0;
    int onTop;
    int numOfTempStackComponent;
   

    void Push(int value, int[] celebrityStack)
    {
        if (top == numOfPeopleInParty - 1)  //numOfPeopleInParty : capacity here
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

    int Peek(int[] celebrityStack)
    {
        if (top != -1)
        {
            return celebrityStack[top];
        }
        return -1;
    }

    int Count()
    {
        int count = 0;
        int toKnowTop = top;
        while (toKnowTop != -1)
        {
            toKnowTop--;
            count++;
        }
        return count;
    }

    public void CelebrityOrNot(int[] celebrityStack, int[,] celebrityStatus)
    {
        if (Count() > 1)
        {
            int specificOne = Pop(celebrityStack);
            int specificTwo = Pop(celebrityStack);

            if (celebrityStatus[specificOne, specificTwo] == 1)
            {
                Push(specificTwo, celebrityStack);
            }
            else if(celebrityStatus[specificOne, specificTwo] == 0)
            {
                Push(specificOne, celebrityStack);
            }
        }
    }

    public int ToEnsure()
    {
        CelebrityOrNot(celebrityStack , celebrityStatus);
        onTop = Peek(celebrityStack);
        for (int i = 0; i < numOfPeopleInParty; i++) {  
            if (celebrityStatus[onTop, i] == 1)
                return -1;   
        }
        return 1;
    }
    public int Celebrity(int[,] celebrityStatus)
    {
        InvitePeople();
        CelebrityOrNot(celebrityStack, celebrityStatus);
        onTop = Peek(celebrityStack);
        for (int i = 0; i < numOfPeopleInParty; i++)
        {
            if (celebrityStatus[onTop, i] == 1)
                return -1;
        }
        return 1;
    }

    int Position(int[] tempCelebrityStack)
    {
        while (tempCelebrityStack[numOfTempStackComponent-1] != onTop)
        {
            numOfTempStackComponent--;
        }
        return numOfTempStackComponent;

    }

    public void InvitePeople()
    {
        numOfPeopleInParty = celebrityStatus.GetLength(0);
        numOfTempStackComponent = numOfPeopleInParty;
        celebrityStack = new int[numOfPeopleInParty];
        tempCelebrityStack = new int[numOfPeopleInParty];
        //to add people in stack
        for (int i = 0; i < numOfPeopleInParty; i++)
        {
            Push(i, celebrityStack);
        }
        Array.Copy(celebrityStack, tempCelebrityStack, numOfPeopleInParty);
    }

    public static void Main()
    {
        Console.WriteLine("Give matrix size 'N'");
        int N = Convert.ToInt32(Console.ReadLine());
        CelebrityStackClass cSC = new CelebrityStackClass();
        //int N = 3;
        //cSC.celebrityStatus = new int[,]{
        //                        {0,1,0},
        //                        {0,0,0},
        //                        {0,1,0}
        //                      };
        cSC.celebrityStatus = new int[N, N];
        Console.WriteLine("Give matrix components: ");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                cSC.celebrityStatus[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        cSC.numOfPeopleInParty = cSC.celebrityStatus.GetLength(0);
        cSC.numOfTempStackComponent = cSC.numOfPeopleInParty;
        cSC.celebrityStack = new int[cSC.numOfPeopleInParty];
        cSC.tempCelebrityStack = new int[cSC.numOfPeopleInParty];
        //to add people in stack
        for (int i = 0; i < cSC.numOfPeopleInParty; i++)
        {
            cSC.Push(i, cSC.celebrityStack);
        }
        Array.Copy(cSC.celebrityStack, cSC.tempCelebrityStack, cSC.numOfPeopleInParty);
        int val = cSC.ToEnsure();
        Console.WriteLine(val);
        int position = cSC.Position(cSC.tempCelebrityStack);
        Console.WriteLine($"I am at index {position}");

    }

   


}