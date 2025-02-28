//Input: s = " i like this program very much "
//Output: "i ekil siht margorp yrev hcum"

class ReverseString
{
    string sentence= " I  am  Bh";
    //void InputString()
    //{
    //    Console.WriteLine("Say Something");
    //    sentence=Console.ReadLine();
    //}

    void CountWords()
    {
        int count = 0;
        string trimmedSentence=sentence.Trim();
        
        for (int charac = 0; charac < trimmedSentence.Length; charac++)
        {
            if (trimmedSentence[charac] == ' ' && trimmedSentence[charac+1] != ' ')
            {
                count++;
            }

        }
        Console.WriteLine($"Here , the count is {count+1}");
    }

    void DisplayEachWords()
    {

    }
    
    //"I am Bhintuna"
    //" I am Bhintuna " : leading and trailing space around the sentence
    //"I  am  Bhintuna" : double space 


    static void Main(string[] args)
    {
        ReverseString reverseString = new ReverseString();
        reverseString.CountWords();
    }



}