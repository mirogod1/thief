using thief;

List<Item> data = new List<Item>{
    new Item(1, 30, 10),
    new Item(2, 10, 20),
    new Item(3, 40, 30),
    new Item(4, 20, 40),
};
List<List<Item>> result = new List<List<Item>> ();

const int maxWeight = 40;
var resIndex = 0;

void GenerateItemsSet(ref int resIndex, int index, int weight)
{
    if(index > data.Count-1)
    {
        resIndex++;
        return;
    }
    var setweight = weight;
    for (int i = index; i < data.Count; i++)
    {
   // int i = index;
        setweight = setweight + data[i].Weight;
        if (setweight < maxWeight)
        {
            if(resIndex < result.Count)
            {
                result[resIndex].Add(data[i]);
            }
            else
            {
                result.Add(new List<Item>());
                result[resIndex].Add(data[i]);
            }
            GenerateItemsSet(ref resIndex, i + 1, setweight);
            
        }
        if(setweight == maxWeight)
        {
            if (resIndex < result.Count)
            {
                result[resIndex].Add(data[i]);
            }
            else
            {
                result.Add(new List<Item>());
                result[resIndex].Add(data[i]);
            }
            resIndex++;
            GenerateItemsSet(ref resIndex, i + 1, 0);
        }
        if (setweight > maxWeight)
        {
           
            GenerateItemsSet(ref resIndex, i + 1, weight);
            //return;
        }
    }
}
GenerateItemsSet(ref resIndex,0,0);
Console.WriteLine(result.Count);
foreach (var itemList in result) {
    Console.WriteLine("-------");
    foreach (var item in itemList)
    {
        Console.WriteLine(item.Weight);
    }    
}