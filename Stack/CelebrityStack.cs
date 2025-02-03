
//Question
//A celebrity is a person who is known to all but does not know anyone at a party.
//A party is being organized by some people.  A square matrix mat (n*n) is used to represent people at the party such that
//if an element of row i and column j is set to 1 it means ith person knows jth person.
//You need to return the index of the celebrity in the party, if the celebrity does not exist, return -1.

//Compilation Completed
//For Input: 
//3
//0 1 0
//0 0 0
//0 1 0
//Your Output: 
//1
//Expected Output: 
//1

//Answer: 
public class Program
{
    public static void Main(string[] args)
    {
        int t=int.Parse(Console.ReadLine());
        while (t-- > 0)
        {

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            // Reading matrix values
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(); 
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
            Solution solution =new Solution();
            Console.WriteLine(solution.celebrity(matrix));
            Console.WriteLine("~");
        }
    }
}
class Solution
{
    // Function to find if there is a celebrity in the party or not.
    // public int celebrity(int[,] mat) {
    //     // code here
    // }
    int[] celebrityStack;
    int[] tempCelebrityStack;
    // int[,] celebrityStatus;
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
            else if (celebrityStatus[specificOne, specificTwo] == 0)
            {
                Push(specificOne, celebrityStack);
            }
        }
    }


    public int celebrity(int[,] celebrityStatus)
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

        CelebrityOrNot(celebrityStack, celebrityStatus);
        onTop = Peek(celebrityStack);
        for (int i = 0; i < numOfPeopleInParty; i++)
        {
            if (celebrityStatus[onTop, i] == 1)
                return -1;
        }
        // return Position();
        return onTop;
    }

    int Position()
    {
        while (tempCelebrityStack[numOfTempStackComponent - 1] != onTop)
        {
            numOfTempStackComponent--;
        }
        return numOfTempStackComponent;

    }


}



