using ConsoleFlappyBird.Game;
using System;
using System.Threading.Tasks;

namespace ConsoleFlappyBird
{
    class Program
    {
        static void Main(string[] args)
        {
			FlappyBird flappy_bird_game_1 = new FlappyBird();
			flappy_bird_game_1.reset_game();

			flappy_bird_game_1.print_game();

			Console.Write("\n\nPress ENTER to contine");
			Console.ReadLine();

			Task.Run(flappy_bird_game_1.zdarova);

			while (true)
			{
				flappy_bird_game_1.print_game();

				flappy_bird_game_1.check_obsticles();

				flappy_bird_game_1.move_bird();

				flappy_bird_game_1.move_obsticles();

				flappy_bird_game_1.reset_movement();

				if (!flappy_bird_game_1.check_game())
					break;

				System.Threading.Thread.Sleep(75);
			}

			Console.Write("\n\nPress ENTER to contine");
			Console.ReadLine();
		}
    }
}
