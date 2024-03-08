var denominations = new int[] { 10, 50, 100 };
var amount = 0;
var memo = new Dictionary<string, List<List<int>>>();

Console.WriteLine("Enter an amount:");
while (!int.TryParse(Console.ReadLine(), out amount))
    Console.WriteLine("Amount need to be a number!");

var combinations = AllCombinations(denominations, amount, 0);

Console.WriteLine($"All possible combinations for {amount}:");
foreach (var combination in combinations)
    Console.WriteLine(string.Join(", ", combination));

List<List<int>> AllCombinations(int[] denominations, int amount, int index)
{
    string key = $"{amount}-{index}";
    if (memo.TryGetValue(key, out var value))
        return value;

    var ret = new List<List<int>>();

    if (amount == 0)
    {
        ret.Add([]);
        return ret;
    }

    for (int i = index; i < denominations.Length; i++)
    {
        if (amount >= denominations[i])
        {
            var nextCombinations = AllCombinations(denominations, amount - denominations[i], i);
            foreach (var next in nextCombinations)
            {
                List<int> currentCombination = [denominations[i], .. next];
                ret.Add(currentCombination);
            }
        }
    }

    memo[key] = ret;
    return ret;
}