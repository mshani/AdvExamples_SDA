string sentence = "Simply type in the word you want to explore the meaning of and find your screen filled with countless examples of that word in a sentence.";

List<string> words = sentence.Split(' ').ToList();

bool FindWord (string word)
{
    bool found = false;
    foreach(string element in words)
    {
        if (string.Equals(element, word, StringComparison.OrdinalIgnoreCase)) { 
            found = true; 
            break; 
        }
    }
    return found;
}

var isFound = FindWord("simply");
//Console.WriteLine(isFound.ToString());
void PrintWords(List<string> words)
{
    foreach (string element in words)
    {
        Console.WriteLine(element);
    }
}
List<string> OrderWords(List<string> words, string direction)
{
    var list = new List<string>();
    foreach (var element in words)
    {
        list.Add(element);
    }
    if (direction == "asc")
    {
        list.Sort();
    }
    else if (direction == "desc")
    {
        list.Sort();
        list.Reverse();
    }
    return list;
}

Dictionary<string, int> CreateDictionary(List<string> words)
{
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    foreach (var word in words) {
        bool success = dictionary.TryAdd(word, 1);
        if (!success)
        {
            dictionary[word]++;
        }
    }
    return dictionary;
}

//var list = OrderWords(words, "desc");
//PrintWords(words);
//Console.WriteLine("------------------------");
//PrintWords(list);

var dictionary = CreateDictionary(words);
foreach (var element in dictionary)
{
    Console.WriteLine($"{element.Key} - {element.Value}");
}