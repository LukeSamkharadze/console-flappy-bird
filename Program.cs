using System;
using System.Threading.Tasks;
using ConsoleFlappyBird.Game;

namespace ConsoleFlappyBird
{
    class Program
    {
        static void Main(string[] args)
        {
			FlappyBird flappyBird = new FlappyBird();
			flappyBird.ResetGame();

			flappyBird.PrintGame();

			Console.Write("\n\nPress ENTER to contine");
			Console.ReadLine();

			Task.Run(flappyBird.StartGettingInput);

			while (true)
			{
				flappyBird.PrintGame();
				flappyBird.CheckObsticles();
				flappyBird.UpdateBirdPosition();
				flappyBird.UpdateObsticles();
				flappyBird.ResetMovementKeyPress();

				if (!flappyBird.CheckGame())
					break;

				System.Threading.Thread.Sleep(33);
			}
		}
    }
}
