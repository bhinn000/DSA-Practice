//Question
//Note: The string may contain leading or trailing spaces, or multiple spaces between two words. The returned string should
//only have a single space separating the words, and no extra spaces should be included.
using System.Text;

class Solution1
{
    int top = -1;
    public string reverseWords(string s)
    {
        List<char> myStack = new List<char>();
        string trimmed =s.Trim();
        StringBuilder reversedWord = new StringBuilder();
        char[] characs = trimmed.ToCharArray();
        for (int cp = 0; cp < characs.Length; cp++)
        {
            if (characs[cp] != ' ')
            {
                myStack.Add(characs[cp]);
                top++;

                if (cp < characs.Length - 1)
                {
                    if (characs[cp + 1] == ' ')
                    {
                        while (top != -1)
                        {
                            reversedWord.Append(Pop(myStack));
                        }
                        reversedWord.Append(' ');
                    }
                }
                else
                {
                    while (top != -1)
                    {
                        reversedWord.Append(Pop(myStack));
                    }
                }
            }
        }
        return reversedWord.ToString().Trim();
    }
    
    char Pop(List<char> givenStack)
    {
        char poppedOut = givenStack[top];
        givenStack.RemoveAt(top--);
        return poppedOut;
    }

    static void Main(string[] args)
    {
        Solution1 reverseString = new Solution1();
        string sentence = " i hate";
        //string sentence = reverseString.InputString();
        //string trimmedSentence = sentence.Trim();

        string result = reverseString.reverseWords(sentence);
        Console.WriteLine(result);
    }

}
