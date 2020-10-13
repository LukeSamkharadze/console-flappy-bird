using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleFlappyBird.Objects;

namespace ConsoleFlappyBird.Game
{
	class FlappyBird
	{
		private const int length = 15;

		private Bird Bird { get; set; }
		private int Score { get; set; }

		private Tube tube;

		private char KeyPressed { get; set; }

		public FlappyBird()
        {
			Bird = new Bird();
			ResetGame();
        }

		public void ResetGame()
        {
			Bird.X = 1;
			Bird.Y = 1;
            Bird.Dy = 1;

            Score = 0;
			tube = new Tube(length, 0, length, 2, 5);
		}

		public void UpdateBirdPosition()
        {
			if (KeyPressed == 'w')
				Bird.Dy = -3;

			Bird.Y += Math.Sign(Bird.Dy);

			if (Bird.Dy != 1)
				Bird.Dy += 1;
		}

		public void UpdateObsticles()
		{
			tube.X--;
		}

		public void CheckObsticles()
		{
			if (tube.X == -2)
			{
				tube = new Tube(length, 0, length, 2, 5);
				Score++;
			}
		}

		public bool CheckGame()
		{
			if (Bird.Y == length || Bird.Y == -1 || Bird.X == length || Bird.X == -1)
            {
				Console.Write("\n\nPress ENTER to restart");
				Console.ReadLine();
				ResetGame();
			}

			for (int x = 0; x < tube.Hitbox.GetLength(1); x++)
				for (int y = 0; y < tube.Hitbox.GetLength(0); y++)
					if (tube.Hitbox[y,x] == true && Bird.Y == tube.Y + y && Bird.X == tube.X + x)
					{
                        Console.Write("\n\nPress ENTER to restart");
						Console.ReadLine();
						ResetGame();
					}

			return true;
		}

		public void StartGettingInput()
		{
			while (true)
				KeyPressed = System.Console.ReadKey(true).KeyChar;
		}

		public void ResetMovementKeyPress()
		{
			KeyPressed = ' ';
		}

		public void PrintGame()
		{
			Console.Clear();

			for (int i = 0; i < length + 2; i++)
				Console.Write("■ ");

			Console.WriteLine();

			bool isEmptySpace;

			for (int i = 0; i < length; i++)
			{
				Console.Write("■ ");

				for (int j = 0; j < length; j++)
				{
					isEmptySpace = true;

					for (int x = 0; x < tube.Hitbox.GetLength(1); x++)
						for (int y = 0; y < tube.Hitbox.GetLength(0); y++)
							if (tube.X + x == j && tube.Y + y == i && tube.Hitbox[y, x] == true)
							{
								Console.Write("■ ");
								isEmptySpace = false;
							}

					if (Bird.Y == i && Bird.X == j && isEmptySpace)
					{
						Console.Write("# ");
						isEmptySpace = false;
					}

					if (isEmptySpace)
						Console.Write("  ");
				}

				Console.WriteLine("■");
			}

			for (int i = 0; i < length + 2; i++)
				Console.Write("■ ");

			Console.Write($"\n\nSCORE: {Score}");
		}
	}
}
