public class TicTacToe
{
    int size = 0;

    int[,] playerBlock = new int[3, 3];

    int numTurn;

    enum PlayerTurn
    {
        XTurn, OTurn
    }

    PlayerTurn currentTurn;
    public void Run()
    {
        GetInputSize();
        GenerateBlock();


        while (!IsFinish())
        {
            GetPlayerInput();
            ShowBlock();
        }
    }

    void GetInputSize()
    {
        Console.WriteLine("Please enters number of TicTacToe block size between 3 and 5");
        Console.WriteLine("If input size is 3, TicTacToe block size is 3x3");
        Console.WriteLine("If input size is 4, TicTacToe block size is 4x4");
        Console.WriteLine("If input size is 5, TicTacToe block size is 5x5");
        Console.Write("Input size: ");
        size = int.Parse(Console.ReadLine());


        if (size >= 3 && size <= 5)
        {
            playerBlock = new int[size, size];

            numTurn = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    playerBlock[i, j] = -1;
                }
            }

            currentTurn = PlayerTurn.XTurn;
        }
        else
        {
            GetInputSize();
        }



    }

    void GenerateBlock()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(" |");
            }
            Console.WriteLine();

            for (int j = 0; j < size; j++)
            {
                Console.Write("__");
            }
            Console.WriteLine();
        }
    }

    void GetPlayerInput()
    {
        int pos = 1;

        if (currentTurn == PlayerTurn.XTurn)
        {
            Console.Write("Player X turn: ");
            pos = int.Parse(Console.ReadLine());
        }
        else if (currentTurn == PlayerTurn.OTurn)
        {
            Console.Write("Player O turn: ");
            pos = int.Parse(Console.ReadLine());
        }



        int num = 1;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {

                if (pos == num && playerBlock[i, j] == -1)
                {
                    if (currentTurn == PlayerTurn.XTurn)
                    {
                        playerBlock[i, j] = 1;
                        currentTurn = PlayerTurn.OTurn;
                        numTurn++;
                        return;
                    }
                    else if (currentTurn == PlayerTurn.OTurn)
                    {
                        playerBlock[i, j] = 0;
                        currentTurn = PlayerTurn.XTurn;
                        numTurn++;
                        return;
                    }
                }
                num++;
            }
        }
    }


    void ShowBlock()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (playerBlock[i, j] == -1)
                {
                    Console.Write(" |");
                }
                else if (playerBlock[i, j] == 0)
                {
                    Console.Write("O|");
                }
                else if (playerBlock[i, j] == 1)
                {
                    Console.Write("X|");
                }

            }
            Console.WriteLine();


            for (int j = 0; j < size; j++)
            {
                Console.Write("__");
            }
            Console.WriteLine();
        }
    }

    bool IsFinish()
    {

        if (numTurn > size * size)
        {
            Console.WriteLine("Draw");
            return true;
        }

        for (int i = 0; i < size; i++)
        {
            int score = 1;
            int prevBlock = -1;

            //Horizontal
            for (int j = 0; j < size; j++)
            {

                if (prevBlock == -1)
                {
                    if (playerBlock[i, j] == 0)
                    {
                        prevBlock = 0;
                    }
                    else if (playerBlock[i, j] == 1)
                    {
                        prevBlock = 1;
                    }
                }
                if (j > 0 && playerBlock[i, j] == playerBlock[i, j - 1] && playerBlock[i, j] != -1 && playerBlock[i, j] == prevBlock)
                {
                    score++;
                    //Console.WriteLine(score);
                }

                if (score == size)
                {
                    //Console.WriteLine(score);
                    if (playerBlock[i, j] == 0)
                    {
                        Console.WriteLine("Player O win");
                        return true;
                    }
                    else if (playerBlock[i, j] == 1)
                    {
                        Console.WriteLine("Player X win");
                        return true;
                    }

                }
            }

            score = 1;
            prevBlock = -1;
            //Vertical
            for (int j = 0; j < size; j++)
            {
                if (prevBlock == -1)
                {
                    if (playerBlock[i, j] == 0)
                    {
                        prevBlock = 0;
                    }
                    else if (playerBlock[i, j] == 1)
                    {
                        prevBlock = 1;
                    }
                }
                if (j > 0 && playerBlock[j, i] == playerBlock[j - 1, i] && playerBlock[j, i] != -1)
                {
                    score++;
                    //Console.WriteLine(score);
                }

                if (score == size)
                {
                    //Console.WriteLine(score);
                    if (playerBlock[j, i] == 0)
                    {
                        Console.WriteLine("Player O win");
                        return true;
                    }
                    else if (playerBlock[j, i] == 1)
                    {
                        Console.WriteLine("Player X win");
                        return true;
                    }

                }
            }
        }

        int scoreCross = 1;
        int prevBlock2 = -1;

        for (int i = 0; i < size; i++)
        {

            if (prevBlock2 == -1)
            {
                if (playerBlock[i, i] == 0)
                {
                    prevBlock2 = 0;
                }
                else if (playerBlock[i, i] == 1)
                {
                    prevBlock2 = 1;
                }
            }

            if (i > 0 && playerBlock[i, i] == playerBlock[i - 1, i - 1] && playerBlock[i, i] != -1 && playerBlock[i, i] == prevBlock2)
            {
                scoreCross++;
            }

            if (scoreCross == size)
            {
                if (playerBlock[i, i] == 0)
                {
                    Console.WriteLine("Player O win");
                    return true;
                }
                else if (playerBlock[i, i] == 1)
                {
                    Console.WriteLine("Player X win");
                    return true;
                }
            }
        }

        scoreCross = 1;
        prevBlock2 = -1;

        int col2 = size - 1;

        for (int i = 0; i < size; i++)
        {

            if (prevBlock2 == -1)
            {
                if (playerBlock[i, col2] == 0)
                {
                    prevBlock2 = 0;
                }
                else if (playerBlock[i, col2] == 1)
                {
                    prevBlock2 = 1;
                }
            }

            if (col2 > -1 && i > 0 && playerBlock[i, col2] == playerBlock[i - 1, col2 + 1] && playerBlock[i, col2] != -1 && playerBlock[i, col2] == prevBlock2)
            {
                scoreCross++;
            }

            if (scoreCross == size)
            {
                if (playerBlock[i, col2] == 0)
                {
                    Console.WriteLine("Player O win");
                    return true;
                }
                else if (playerBlock[i, col2] == 1)
                {
                    Console.WriteLine("Player X win");
                    return true;
                }
            }
            col2--;
        }

        return false;
    }
}
