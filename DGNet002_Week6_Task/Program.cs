using System;
using System.Collections.Generic;

namespace DGNet002_Week6_Task
{
    internal class Program
    {
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
