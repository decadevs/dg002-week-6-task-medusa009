using System;
using System.Collections.Generic;

namespace DGNet002_Week6_Task
{
    internal class Program
    {

public class Item
{
    public int ItemId { get; set; }
    public string ItemDes { get; set; }
}

public class Sales
{
    public int InvNo { get; set; }
    public int ItemId { get; set; }
    public int Qty { get; set; }
}




        static void Main(string[] args)
        {
            List<string> states = new List<string>
        {
            "Abia", "Adamawa", "Akwa Ibom", "Anambra", "Bauchi", "Bayelsa", "Benue", "Borno",
            "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Enugu", "Gombe", "Imo",
            "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos",
            "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers",
            "Sokoto", "Taraba", "Yobe", "Zamfara"
        };

        // Prompt the user for the number of groups
        Console.Write("Enter the number of groups: ");
        if (!int.TryParse(Console.ReadLine(), out int numberOfGroups) || numberOfGroups <= 0)
        {
            Console.WriteLine("Invalid input. Number of groups must be a positive integer.");
            return;
        }

        // Split the states into groups
        var groups = SplitIntoGroups(states, numberOfGroups);

        // Display the groups
        for (int i = 0; i < groups.Count; i++)
        {
            Console.WriteLine($"Group {i + 1}:");
            foreach (var state in groups[i])
            {
                Console.WriteLine($"- {state}");
            }
            Console.WriteLine();
        }


        // 2 

        List<Item> itemList = new List<Item>
        {
            new Item { ItemId = 1, ItemDes = "Bag" },
            new Item { ItemId = 2, ItemDes = "Pen" },
            new Item { ItemId = 3, ItemDes = "Book" },
            new Item { ItemId = 4, ItemDes = "Shoe" },
            new Item { ItemId = 5, ItemDes = "Pin" }
        };

        List<Sales> salesList = new List<Sales>
        {
            new Sales { InvNo = 1, ItemId = 3, Qty = 10 },
            new Sales { InvNo = 2, ItemId = 2, Qty = 20 },
            new Sales { InvNo = 3, ItemId = 3, Qty = 500 },
            new Sales { InvNo = 4, ItemId = 4, Qty = 20 },
            new Sales { InvNo = 5, ItemId = 3, Qty = 100 },
            new Sales { InvNo = 6, ItemId = 4, Qty = 50 }
        };

        // Perform inner join and get distinct items
        var distinctItemsInSales = (from item in itemList
                                    join sale in salesList
                                    on item.ItemId equals sale.ItemId
                                    select item)
                                    .Distinct()
                                    .ToList();

        // Output the results
        Console.WriteLine("Distinct Items In Sales:");
        foreach (var item in distinctItemsInSales)
        {
            Console.WriteLine($"ItemId: {item.ItemId}, Description: {item.ItemDes}");
        }
        }

        static List<List<string>> SplitIntoGroups(List<string> items, int numberOfGroups)
    {
        var result = new List<List<string>>();
        int itemsPerGroup = items.Count / numberOfGroups;
        int remainder = items.Count % numberOfGroups;

        int index = 0;
        for (int i = 0; i < numberOfGroups; i++)
        {
            int groupSize = itemsPerGroup + (i < remainder ? 1 : 0);
            var group = new List<string>();

            for (int j = 0; j < groupSize; j++)
            {
                if (index < items.Count)
                {
                    group.Add(items[index++]);
                }
            }

            result.Add(group);
        }

        return result;
    }
    }
}
