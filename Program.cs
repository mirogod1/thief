using thief;

List<Item> Items = new List<Item>{
    new Item(1, 30, 10),
    new Item(2, 10, 20),
    new Item(3, 40, 30),
    new Item(4, 20, 40)


};
List<List<Item>> result = new List<List<Item>> ();

const int maxWeight = 40;

List<List<Item>> allCombinations(int index, List<Item> tempset)
{
    var ListOfSets = new List<List<Item>>();
    for(var i = index; i < Items.Count; i++ )
    {
        var newTempset = new List<Item>();
        newTempset.AddRange(tempset);
        newTempset.Add(Items[i]);
        ListOfSets.Add(newTempset);
        ListOfSets.AddRange(allCombinations(i+1, newTempset));
    }

    return ListOfSets;
}
result = allCombinations(0, new List<Item>());
var filteredResutls = result.Where(x => x.Sum(x => x.Weight) <= maxWeight).Select(result => result).ToList();

var maxValue = filteredResutls.Max(x => x.Sum(y => y.Value));
var maxResult = filteredResutls.Where(x => x.Sum(y => y.Value) == maxValue).Single();

Console.WriteLine("----------------------------------------------------------");

Console.Write($"highest profit is is {maxValue}. Weights are: ");
foreach(var item in maxResult)
{
    Console.Write(item.Weight + "kg, ");
}
Console.WriteLine("");
Console.WriteLine("----------------------------------------------------------");
