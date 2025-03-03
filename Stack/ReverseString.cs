//Input: s = " i like this program very much "
//Output: "i ekil siht margorp yrev hcum"

class ReverseString
{
    //string sentence= " I  am  Bh";
    string sentence = "I am Bhintuna";
    //void InputString()
    //{
    //    Console.WriteLine("Say Something");
    //    sentence=Console.ReadLine();
    //}

    //int[] myStack = new int[5];
    List<char> myStack = new List<char>();
    int top = -1;
    //int capacity;//length of the words

    void Push(char charac) //to push the character to the stack
    {
            myStack.Add(charac);
            top++;
        
    }

    int CountWords(string sentence)
    {
        int count = 0;
        string trimmedSentence = sentence.Trim();

        for (int charac = 0; charac < trimmedSentence.Length; charac++)
        {
            if (trimmedSentence[charac] == ' ' && trimmedSentence[charac+1] != ' ')
            {
                count++;
               
            }
        }
        return count;
    }

    int StackMaxCapacity(string sentence) // to define the capacity of the stack depending upon the largest requirement , if array had been used
    {
        string trimmedSentence = sentence.Trim();
        string[] words = trimmedSentence.Split(" ");

        List<int> eachWordsLength =words.Select(word => word.Length).ToList();
        eachWordsLength.ForEach(wordLength=>Console.WriteLine($"Its length is {wordLength}"));
        int capacity = eachWordsLength.Max();
        return capacity;
    }
    
    void PushEachWordInStack()
    {

    }

    //"I am Bhintuna"
    //" I am Bhintuna " : leading and trailing space around the sentence
    //"I  am  Bhintuna" : double space 
    

    static void Main(string[] args)
    {
        ReverseString reverseString = new ReverseString();
        int wordCount = reverseString.CountWords(reverseString.sentence);
        int stackCapacity=reverseString.StackMaxCapacity(reverseString.sentence);
        reverseString.Push('a');
    }



}