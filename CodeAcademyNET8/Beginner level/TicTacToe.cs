namespace CodeAcademyNET8;

internal class TicTacToe
{
    private static readonly char[,] Board = new char[3, 3];
    private static string _playerOne = string.Empty;
    private static string _playerTwo = string.Empty;

    public static void StartGame()
    {
        Console.WriteLine("New Game - Two Players");

        Console.Write("Enter name for Player 1: ");
        var input = Console.ReadLine();
        _playerOne = string.IsNullOrEmpty(input) ? "Player 1" : input;

        Console.Write("Enter name for Player 2: ");
        input = Console.ReadLine();
        _playerTwo = string.IsNullOrEmpty(input) ? "Player 2" : input;

        var difficulty = string.Empty;
        if (_playerOne.StartsWith("AI ") || _playerTwo.StartsWith("AI "))
        {
            Console.WriteLine("Difficulty options:");
            Console.WriteLine("\tEasy");
            Console.WriteLine("\tMedium");
            Console.WriteLine("\tHard");
            Console.WriteLine("\tI am better than machine");
            Console.Write("Choose difficulty: ");
            difficulty = Console.ReadLine();
        }

        Console.WriteLine($"Alrighty! {_playerOne} against {_playerTwo}!");

        InitializeBoard();
        var turns = 0;
        var isPlayerOneTurn = true;

        while (true)
        {
            DisplayBoard();

            if (isPlayerOneTurn && _playerOne.ToUpper().StartsWith("AI "))
            {
                var (aiRow, aiCol) = AIPickMove(difficulty);
                Board[aiRow, aiCol] = 'X';
                Console.WriteLine($"{_playerOne} chose row {aiRow}, column {aiCol}");
            }
            else if (!isPlayerOneTurn && _playerTwo.ToUpper().StartsWith("AI "))
            {
                var (aiRow, aiCol) = AIPickMove(difficulty);
                Board[aiRow, aiCol] = 'O';
                Console.WriteLine($"{_playerTwo} chose row {aiRow}, column {aiCol}");
            }
            else
            {
                if (isPlayerOneTurn)
                    Console.WriteLine($"{_playerOne}'s turn (❌)!");
                else
                    Console.WriteLine($"{_playerTwo}'s turn (⭕)!");

                Console.Write("Enter the column number (\u23ea\u23e9) (0 - 2): ");
                var colInput = ParseConsoleInputInt();

                Console.Write("Enter the row number (\u23eb\u23ec) (0 - 2): ");
                var rowInput = ParseConsoleInputInt();

                if (rowInput < 0 || rowInput > 2 || colInput < 0 || colInput > 2 || Board[rowInput, colInput] != ' ')
                {
                    Console.WriteLine("Invalid move. Try again!");
                    continue;
                }

                Board[rowInput, colInput] = isPlayerOneTurn ? 'X' : 'O';
            }

            turns++;

            isPlayerOneTurn = !isPlayerOneTurn;

            if (CheckWin() || turns == 9)
            {
                Console.Clear();
                DisplayBoard();

                if (CheckWin())
                {
                    var winner = isPlayerOneTurn ? _playerTwo : _playerOne;
                    Console.WriteLine($"Game over! {winner} wins!");
                }
                else
                {
                    Console.WriteLine("Game over! It's a draw!");
                }

                return;
            }

            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.Clear();
        }
    }

    private static (int, int) AIPickMove(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                return RandomMove();
                break;
            case "medium":
                return NormalMove();
                break;
            case "hard":
            //return DeffensiveMove();
            //break;
            case "i am better than a machine":
            //return UnbeatableMove();
            //break;
            default:
                throw new ArgumentException("Invalid difficulty level");
        }
    }

    private static (int, int) NormalMove()
    {
        // First, check for any defensive moves needed
        var defensiveMove = FindDefensiveMove();
        if (defensiveMove != null) return defensiveMove.Value;

        // If no defensive moves, make a random move
        return RandomMove();
    }

    private static (int, int)? FindDefensiveMove()
    {
        // Loop through the board to find if the opponent is about to win
        for (var row = 0; row < 3; row++)
        for (var col = 0; col < 3; col++)
            // Check if making a move in (row, col) will block the opponent from winning
            if (CanBlockOpponentWin(row, col))
                return (row, col);
        return null;
    }

    private static bool CanBlockOpponentWin(int row, int col)
    {
        if (Board[row, col] != ' ') return false; // Spot already taken

        // Temporarily make the move
        Board[row, col] = 'O'; // Or 'X', depending on the AI's symbol

        var canWin = CheckWin(); // Use the existing CheckWin method to see if this move blocks a win

        // Undo the move
        Board[row, col] = ' ';

        return canWin;
    }

    private static (int, int) RandomMove()
    {
        var rnd = new Random();
        int row, col;

        do
        {
            row = rnd.Next(3);
            col = rnd.Next(3);
        } while (Board[row, col] != ' ');

        return (row, col);
    }

    private static int ParseConsoleInputInt()
    {
        var input = -1;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out input))
                Console.WriteLine("Something went wrong. Try again!");
        } while (input < 0);

        return input;
    }

    private static void DisplayBoard()
    {
        Console.WriteLine("  0 1 2");
        for (var i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (var j = 0; j < 3; j++)
            {
                Console.Write(Board[i, j]);
                if (j < 2) Console.Write("|");
            }

            Console.WriteLine();
            if (i < 2) Console.WriteLine("  —----");
        }
    }

    private static void InitializeBoard()
    {
        for (var i = 0; i < 3; i++)
        for (var j = 0; j < 3; j++)
            Board[i, j] = ' ';
    }

    private static bool CheckWin()
    {
        for (var i = 0; i < 3; i++)
        {
            if (Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != ' ')
                return true;

            if (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != ' ')
                return true;
        }

        if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != ' ')
            return true;

        if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[0, 2] != ' ')
            return true;

        return false;
    }
}