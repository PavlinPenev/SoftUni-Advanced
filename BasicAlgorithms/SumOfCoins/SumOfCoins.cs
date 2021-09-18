using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        try
        {
            var selectedCoins = ChooseCoins(availableCoins, targetSum);
            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        int currentSum = 0;
        int sumLeft = targetSum;
        coins = coins.OrderByDescending(x => x).ToList();

        for (int i = 0; i < coins.Count; i++)
        {
            int currentCoinValue = coins[i];
            int currentCoinCount = sumLeft / currentCoinValue;

            if (currentSum + currentCoinValue * currentCoinCount > targetSum)
            {
                continue;
            }

            sumLeft -= currentCoinValue * currentCoinCount;
            currentSum += currentCoinValue * currentCoinCount;

            if (currentCoinCount != 0)
            {
                result.Add(currentCoinValue, currentCoinCount);
            }
        }

        if (sumLeft != 0)
        {
            throw new InvalidOperationException("Error");
        }

        return result;
    }
}