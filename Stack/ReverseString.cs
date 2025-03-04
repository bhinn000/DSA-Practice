//Input: s = " i like this program very much "
//Output: "i ekil siht margorp yrev hcum"

class ReverseString
{
    string InputString()
    {
        Console.WriteLine("Say Something");
        string sentence = Console.ReadLine();
        return sentence;
    }

    List<char> myStack = new List<char>();
    List<char> myAnotherStack = new List<char>();
    int top = -1;
    int topAnother = -1;

    void PushEachWord(string sentence, List<char> givenStack)
    {
        string trimmedSentence = sentence.Trim();

        for (int cp = 0; cp < trimmedSentence.Length; cp++)
         {
            if (trimmedSentence[cp] != ' ')
            {
                givenStack.Add(trimmedSentence[cp]);
                top++;

                if (cp < trimmedSentence.Length - 1)
                {
                    if (trimmedSentence[cp + 1] == ' ')
                    {
                        while (top != -1)
                        {
                            PushReverseString(Pop(givenStack));
                        }
                        PushReverseString(' ');

                    }
                }
                else
                {
                    while (top != -1)
                    {
                        PushReverseString(Pop(givenStack));
                    }
                }
            }
        }

    }

    void PushReverseString(char charac)
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
        Console.Write("This stack contains ");
        myAnotherStack.ForEach(x => Console.Write(x));
    }

    static void Main(string[] args)
    {
        ReverseString reverseString = new ReverseString();
        string sentence = " i like this program very much ";
        //string sentence = reverseString.InputString();

        reverseString.PushEachWord(sentence , reverseString.myStack);
        reverseString.Display();
    }

}


//"I am Bhintuna"
//" I am Bhintuna " : leading and trailing space around the sentence
//"I  am  Bhintuna" : double space 