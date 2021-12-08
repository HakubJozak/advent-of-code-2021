using System;
using System.Collections.Generic;
using System.IO;

class Submarine
{
    public int Depth = 0;
    public int X = 0;
    public int Aim = 0;
    
    public void Up(int amount)
    {
        Aim -= amount;
    }

    public void Down(int amount)
    {
        Aim += amount;
    }

    public void Forward(int amount)
    {
        Depth += Aim * amount;
        X += amount;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Submarine sub = new Submarine();
        move(sub);
        
        Console.Out.WriteLine("Hello!");
        Console.Out.WriteLine("Submarine.depth = {0}", sub.Depth);
        Console.Out.WriteLine("Submarine.x = {0}", sub.X);
        Console.Out.WriteLine("Result = {0}", sub.Depth * sub.X);
    }
    
    private static void move(Submarine submarine) {
        IEnumerable<string> lines = File.ReadLines("./input.txt");
        foreach (string line in lines) {
            string[] fields = line.Split(' ');
            string direction = fields[0];
            int amount = Convert.ToInt32(fields[1]);
            
            switch (direction) {
                case "forward":
                    submarine.Forward(amount);
                    break;
                case "down": 
                    submarine.Down(amount);
                    break;
                case "up": 
                    submarine.Up(amount);
                    break;
                default:
                    throw new ArgumentException($"{direction} is not a valid direction");
            }
        }
    }
}

