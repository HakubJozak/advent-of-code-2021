using System.IO;
using System.Collections.Generic;

string fileName = "./input.txt";
IEnumerable<string> lines = File.ReadLines(fileName);

static int simpleIncreases(IEnumerable<string> lines)
{
    int? old = null;
    int increasesCount = 0;

    foreach (string line in lines)
    {
        int num = Convert.ToInt32(line);

        if (old != null)
        {
            if (num > old)
            {
                increasesCount++;
            }

        }

        old = num;
    }

    return increasesCount;
}

static void printQueue(IEnumerable<int> queue)
{
    IEnumerable<string> strings = queue.Select(i => i.ToString());
    Console.WriteLine($"({String.Join(",", strings)}) = {sumQueue(queue)}");

}

static int sumQueue(IEnumerable<int> queue)
{
    int sum = 0;

    foreach (int num in queue)
    {
        sum += num;
    }

    return sum;
}

static int windowIncreases(IEnumerable<string> lines)
{
    Queue<int> queue = new Queue<int>();
    int i = 0;
    int? oldSum = null;
    int increasesCount = 0;

    foreach (string line in lines)
    {
        // printQueue(queue);

        if (i > 2)
        {
            queue.Dequeue();
        }

        queue.Enqueue(Convert.ToInt32(line));
        var currentSum = sumQueue(queue);

        if (i > 2 && oldSum != null && currentSum > oldSum) {
             increasesCount++;
        }

        i++;
        oldSum = currentSum;
    }

    return increasesCount;
}

Console.WriteLine($"Increases count: {simpleIncreases(lines)}");
Console.WriteLine($"Increases by window: {windowIncreases(lines)}");
