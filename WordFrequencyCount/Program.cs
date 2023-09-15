WordFrequencyCounter wordCounter = new WordFrequencyCounter();

Console.Write("Please Enter The String: ");


string? word;
word  = Console.ReadLine();

if (word == null)
{
    throw new ArgumentNullException("word must be not null");
}

Dictionary<string, int> wordFrequency = wordCounter.CountWordFrequency(word);

foreach (KeyValuePair<string, int> pair in wordFrequency)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}
