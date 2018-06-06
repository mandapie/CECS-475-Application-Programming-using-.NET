using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public class TicTacToe
        {
            private const int BOARDSIZE = 3; // size of the board
            private int[,] board; // board representation
            
            /// <summary>
            /// class constructor that initializes a board for tic tac toe
            /// </summary>
            public TicTacToe()
            {
                board = new int[BOARDSIZE, BOARDSIZE] { { 1, 2, 3 }, { 4, 5, 6}, { 7, 8, 9 } };
            }
            
            /// <summary>
            /// prints the tic tac toe board
            /// </summary>
            public void PrintBoard()
            {
                Console.Write("     |     |     \n");
                Console.Write("  {0}  |  {1}  |  {2}  \n", convertChar(board[0, 0]), convertChar(board[0, 1]), convertChar(board[0, 2]));
                Console.Write("_____|_____|_____\n");
                Console.Write("     |     |     \n");
                Console.Write("  {0}  |  {1}  |  {2}  \n", convertChar(board[1, 0]), convertChar(board[1, 1]), convertChar(board[1, 2]));
                Console.Write("_____|_____|_____\n");
                Console.Write("     |     |     \n");
                Console.Write("  {0}  |  {1}  |  {2}  \n", convertChar(board[2, 0]), convertChar(board[2, 1]), convertChar(board[2, 2]));
                Console.Write("     |     |     \n");
            }

            /// <summary>
            /// takes in an integer and returns a string 
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public string convertChar(int number)
            {
                if(number == -1)
                {
                    return "X";
                }
                if(number == 0)
                {
                    return "O";
                }
                else
                {
                    return number.ToString();
                }
            }

            /// <summary>
            /// starts the game with a max of 9 turns.
            /// each case is a position of the board.
            /// </summary>
            public void Play()
            {
                for(int i=0;i<9;i++)
                {
                    int player = i % 2 + 1;
                    Console.Write("Player {0} chance:\n", player);
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (board[0,0] != -1 && board[0, 0] != 0)
                            {
                                if (i % 2 == 0) { board[0, 0] = -1; }
                                if (i % 2 == 1) { board[0, 0] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 2:
                            if (board[0, 1] != -1 && board[0, 1] != 0)
                            {
                                if (i % 2 == 0) { board[0, 1] = -1; }
                                if (i % 2 == 1) { board[0, 1] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 3:
                            if (board[0, 2] != -1 && board[0, 2] != 0)
                            {
                                if (i % 2 == 0) { board[0, 2] = -1; }
                                if (i % 2 == 1) { board[0, 2] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 4:
                            if (board[1, 0] != -1 && board[1, 0] != 0)
                            {
                                if (i % 2 == 0) { board[1, 0] = -1; }
                                if (i % 2 == 1) { board[1, 0] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 5:
                            if (board[1, 1] != -1 && board[1, 1] != 0)
                            {
                                if (i % 2 == 0) { board[1, 1] = -1; }
                                if (i % 2 == 1) { board[1, 1] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 6:
                            if (board[1, 2] != -1 && board[1, 2] != 0)
                            {
                                if (i % 2 == 0) { board[1, 2] = -1; }
                                if (i % 2 == 1) { board[1, 2] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 7:
                            if (board[2, 0] != -1 && board[2, 0] != 0)
                            {
                                if (i % 2 == 0) { board[2, 0] = -1; }
                                if (i % 2 == 1) { board[2, 0] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 8:
                            if (board[2, 1] != -1 && board[2, 1] != 0)
                            {
                                if (i % 2 == 0) { board[2, 1] = -1; }
                                if (i % 2 == 1) { board[2, 1] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        case 9:
                            if (board[2, 2] != -1 && board[2, 2] != 0)
                            {
                                if (i % 2 == 0) { board[2, 2] = -1; }
                                if (i % 2 == 1) { board[2, 2] = 0; }
                            }
                            else
                            {
                                Console.Write("This spot is already marked\n");
                                i--;
                            }
                            break;
                        default:
                            Console.Write("only 1-9");
                            i--;
                            break;
                    }
                    PrintBoard();
                    checkToWin();
                    if(checkToWin() == 1)
                    {
                        Console.Write("Player {0} won!\n ", player);
                        break;
                    }
                    if (checkToWin() == -1)
                    {
                        Console.Write("Draw\n");
                    }
                }
            }

            /// <summary>
            /// checks if there is 3 of the same type in a row
            /// </summary>
            /// <returns></returns>
            public int checkToWin()
            {
                if ((board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]) || (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2]) ||
                    (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2]) || (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0]) ||
                    (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1]) || (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2]) ||
                    (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]))
                {
                    return 1;
                }
                if(board[0,0] != 1 && board[0, 1] != 2 && board[0, 2] != 3 && board[1, 0] != 4 && board[1, 1] != 5 && board[1, 2] != 6 && board[2, 0] != 7 && board[2, 1] != 8 && board[2, 2] != 9)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }//end class
       
        /// <summary>
        /// calls all the Play and PrintBoard function to start the game.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            Console.Write("Player 1: X  and  Player 2: O\n\n");
            game.PrintBoard();
            game.Play();
            Console.ReadKey();
        }
    }
}