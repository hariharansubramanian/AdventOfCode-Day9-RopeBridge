using RopeBridge_AdventOfCodeDay9.Models;

Console.WriteLine("Analysing movements...");
var instructions = File.ReadAllLines("motion_instructions.txt");

/*================== Puzzle 1 =================*/
var rope = new Rope(2);
rope.PerformMotions(instructions);
var tail = rope.Knots.Last();

Console.WriteLine($"Tail visited {tail.Visited.Count} unique positions.");

/*================== Puzzle 2 =================*/
rope = new Rope(10);
rope.PerformMotions(instructions);
tail = rope.Knots.Last();

Console.WriteLine($"The last tail visited {tail.Visited.Count} unique positions.");
Console.WriteLine("Finished performing movements");