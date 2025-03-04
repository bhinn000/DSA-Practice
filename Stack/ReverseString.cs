//Input: s = " i like this program very much "
//Output: "i ekil siht margorp yrev hcum"

class ReverseString
{
    List<char> myStack = new List<char>();
    List<char> myAnotherStack = new List<char>();
    int top = -1;
    int topAnother = -1;
    string InputString()
    {
        Console.WriteLine("Say Something");
        string sentence = Console.ReadLine();
        return sentence;
    }

    void PushEachWord(string sentence, List<char> givenStack)
    {
        for (int cp = 0; cp < sentence.Length; cp++)
         {
            if (sentence[cp] != ' ')
            {
                givenStack.Add(sentence[cp]);
                top++;

                if (cp < sentence.Length - 1)
                {
                    if (sentence[cp + 1] == ' ')
                    {
                        while (top != -1)
                        {
                            ReverseThis(Pop(givenStack));
                        }
                        ReverseThis(' ');
                    }
                }
                else
                {
                    while (top != -1)
                    {
                        ReverseThis(Pop(givenStack));
                    }
                }
            }
        }

    }

    void ReverseThis(char charac)
    {
        myAnotherStack.Add(charac);
        topAnother++;
    }

    char Pop(List<char> givenStack)
    {
        char poppedOut = givenStack[top];
        givenStack.RemoveAt(top--);
        return poppedOut;
    }

    void Display()
    {
        myAnotherStack.ForEach(x => Console.Write(x));
    }

    static void Main(string[] args)
    {
        ReverseString reverseString = new ReverseString();
        string sentence = " i like this program very much ";
        string trimmedSentence = sentence.Trim();
        //string sentence = reverseString.InputString();

        reverseString.PushEachWord(trimmedSentence, reverseString.myStack);
        reverseString.Display();
    }

}
