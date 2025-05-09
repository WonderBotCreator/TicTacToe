public class TicTacToe
{
    int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[,] box = new int[3, 3];
    int order = 0;
    string[,] box2 = new string[3, 3];


    int round = 1;
    int x = 0;
    int o = 0;
    bool assigned = false;
    string winner = "";


    public TicTacToe(){
        
    }


    bool IsGameFinish()
    {
        for (int i = 0; i < 3; i++)
        {
            if (box2[0, i] == "X" && box2[1, i] == "X" && box2[2, i] == "X")
            {
                winner = "X";
                return true;
            }
            if (box2[0, i] == "O" && box2[1, i] == "O" && box2[2, i] == "O")
            {
                winner = "O";
                return true;
            }
            if (box2[i, 0] == "X" && box2[i, 1] == "X" && box2[i, 2] == "X")
            {
                winner = "X";
                return true;
            }
            if (box2[i, 0] == "O" && box2[i, 1] == "O" && box2[i, 2] == "O")
            {
                winner = "O";
                return true;
            }
        }

        if (box2[0, 0] == "X" && box2[1, 1] == "X" && box2[2, 2] == "X")
        {
            winner = "X";
            return true;
        }

        if (box2[0, 0] == "O" && box2[1, 1] == "O" && box2[2, 2] == "O")
        {
            winner = "O";
            return true;
        }
        if (box2[2, 0] == "X" && box2[1, 1] == "X" && box2[0, 2] == "X")
        {
            winner = "X";
            return true;
        }

        if (box2[2, 0] == "O" && box2[1, 1] == "O" && box2[0, 2] == "O")
        {
            winner = "O";
            return true;
        }


        if (round > 9)
        {
            return true;
        }
        return false;
    }


    void AssignValToTable()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (x == box[j, i] && box2[j, i] != "X" && box2[j, i] != "O" && round % 2 != 0)
                {
                    box2[j, i] = "X";
                    assigned = true;
                }
                else if (o == box[j, i] && box2[j, i] != "X" && box2[j, i] != "O" && round % 2 == 0)
                {
                    box2[j, i] = "O";
                    assigned = true;
                }
            }
        }
    }


    void GetPlayerInput()
    {
        if (round % 2 != 0)
        {
            
            Console.Write("Player X turn: ");
            x = int.Parse(Console.ReadLine());
        }
        else
        {
            Console.Write("Player O turn: ");
            o = int.Parse(Console.ReadLine());
        }
    }


    void ShowTable()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(box2[j, i] + "|");
            }
            Console.WriteLine("");
            Console.WriteLine("_______");
        }
    }

    public void Run()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                box[j, i] = num[order];
                order++;
            }
        }




        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                box2[j, i] = " ";
            }
        }

        






        while (!IsGameFinish())
        {
            ShowTable();
            GetPlayerInput();
            AssignValToTable();
            if (assigned)
            {
                round++;
                assigned = false;
            }
        }

        ShowTable();
        if (winner == "")
        {
            Console.WriteLine("Draw");
        }
        else
        {
            Console.WriteLine($"The winner is {winner}");
        }
    }
}



