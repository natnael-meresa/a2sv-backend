using System.Text.RegularExpressions;

public class WordFrequencyCounter
{
    public Dictionary<string, int> CountWordFrequency(string input)
    {
        string[] words = Regex.Split(input, @"\W+");
        Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts.Add(word, 1);
                }
            }
        }
        

        return wordCounts;

    }
}