using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSumConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stillGoing = true;
            while (stillGoing)
            {
                Console.WriteLine("Enter the numbers for the set with a space between each number: (Enter 'exit' to quit)");
                string nums = Console.ReadLine();

                if (nums == "exit")
                {
                    stillGoing = false;
                    break;
                }

                List<Int32> set = nums.Split(' ').Select(Int32.Parse).ToList();

                Console.WriteLine("Enter a sum to try and find: ");

                int sum = Int32.Parse(Console.ReadLine());

                int n = set.Count;

                List<List<Int32>> allSums = isSubsetSum(set, n, sum);


                if (allSums.Count != 0)
                {
                    foreach (List<Int32> sums in allSums)
                    {
                        string printString = "{";

                        foreach (Int32 num in sums)
                        {
                            printString += num + ",";
                        }

                        printString = printString.TrimEnd(',');
                        printString += "}";
                        Console.WriteLine(printString);

                    }
                }
                else
                {
                    Console.WriteLine("There is no combination of numbers that equal that sum");
                }
            }
        }

        static List<List<Int32>> isSubsetSum(List<Int32> set, int n, int sum)
        {

            List<List<Int32>> numSums = new List<List<Int32>>();

            for (int i = 0; i < set.Count; i++)
            {

                List<Int32> currentNumbers = new List<Int32>();

                Int32 curNum = set[i];
                set.RemoveAt(i);
                set.Add(curNum);

                bool exhausted = false;
                int startPointer = 0;

                while (!exhausted)
                {
                    int index = startPointer;
                    int curSum = curNum;
                    currentNumbers.Add(curNum);
                    int counter = 0;

                    startPointer++;

                    if (startPointer == set.Count - 1)
                    {
                        exhausted = true;
                        break;
                    }

                    while (counter != set.Count - 1)
                    {
                        if (curSum + set[index] > sum)
                        {
                            currentNumbers.Clear();
                            counter = set.Count;
                            break;

                        } else if(curSum + set[index] < sum)
                        {
                            currentNumbers.Add(set[index]);
                            curSum += set[index];
                            if (index + 1 == set.Count - 1)
                            {
                                index = 0;
                            } else
                            {
                                index++;
                            }
                            counter++;
                        } else
                        {
                            currentNumbers.Add(set[index]);
                            numSums.Add(currentNumbers);
                            counter = set.Count;
                            break;
                        }
                    }
                }
            }

            return numSums;
        }
    }
}
