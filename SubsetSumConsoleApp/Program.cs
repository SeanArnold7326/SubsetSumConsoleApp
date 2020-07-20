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
                int pointer = 0;

                while (!exhausted)
                {
                    int curSum = curNum;
                    currentNumbers.Add(curNum);
                    int counter = 0;

                    while(counter != set.Count)
                    {
                        if (curSum + set[pointer] > sum)
                        {
                            currentNumbers.Clear();
                            continue;
                        } else if(curSum + set[pointer] < sum)
                        {
                            currentNumbers.Add(set[pointer]);
                            curSum += set[pointer];
                            counter++;
                        }
                        else
                        {
                            currentNumbers.Add(set[pointer]);
                            numSums.Add(currentNumbers);
                            counter = set.Count;
                        }
                    }
                    if (pointer == set.Count)
                    {
                        exhausted = true;
                    }
                    else
                    {
                        pointer++;
                    }
                    //for (int j = 0; j < set.Count; j++)
                    //{
                    //    if (i != j)
                    //    {
                    //        if (curSum + set[j] > sum)
                    //        {
                    //            currentNumbers.Clear();
                    //            currentNumbers.Add(set[i]);
                    //            continue;
                    //        }
                    //        else if (curSum + set[j] < sum)
                    //        {
                    //            currentNumbers.Add(set[j]);
                    //            curSum += set[j];
                    //        }
                    //        else
                    //        {
                    //            currentNumbers.Add(set[j]);
                    //            numSums.Add(currentNumbers);
                    //            //bool alreadyExists = false;
                    //            //foreach (List<Int32> existingSet in numSums)
                    //            //{
                    //            //    alreadyExists = (existingSet.All(currentNumbers.Contains));
                    //            //}
                    //            //if (!alreadyExists)
                    //            //{
                    //            //    numSums.Add(currentNumbers);
                    //            //}
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }

            return numSums;
        }
    }
}
