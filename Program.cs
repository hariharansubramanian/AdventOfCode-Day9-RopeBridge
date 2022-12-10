Console.WriteLine("Analysing head movements...");
var moves = File.ReadAllLines("head_movements.txt");

var headPosition = (X: 0, Y: 0);
var tailPosition = (X: 0, Y: 0);

var headVisited = new HashSet<(int X, int Y)> {headPosition};
var tailVisited = new HashSet<(int x, int y)> {tailPosition};

// Puzzle 1
foreach (var move in moves)
{
    var instruction = move.Split(" ");
    var direction = instruction[0];
    var steps = int.Parse(instruction[1]);

    for (var i = 0; i < steps; i++)
    {
        // Move head
        switch (direction)
        {
            case "L":
                headPosition.X--;
                break;
            case "R":
                headPosition.X++;
                break;
            case "U":
                headPosition.Y++;
                break;
            case "D":
                headPosition.Y--;
                break;
        }

        headVisited.Add(headPosition);

        // Move tail to follow head
        if (Math.Abs(headPosition.X - tailPosition.X) >= 2 || Math.Abs(headPosition.Y - tailPosition.Y) >= 2)
        {
            if (headPosition.X == tailPosition.X) // if same row, move across column
            {
                if (headPosition.Y > tailPosition.Y) tailPosition.Y++;
                else tailPosition.Y--;
            }
            else if (headPosition.Y == tailPosition.Y) // if same column, move across row
            {
                if (headPosition.X > tailPosition.X) tailPosition.X++;
                else tailPosition.X--;
            }
            else // move diagonally
            {
                if (headPosition.X > tailPosition.X) tailPosition.X++;
                else tailPosition.X--;

                if (headPosition.Y > tailPosition.Y) tailPosition.Y++;
                else tailPosition.Y--;
            }
        }

        tailVisited.Add(tailPosition);
    }
}

Console.WriteLine($"Tail visited {tailVisited.Count} unique positions.");