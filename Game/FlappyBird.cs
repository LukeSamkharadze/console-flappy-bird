using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleFlappyBird.Game
{
    class FlappyBird
    {
		public const int length = 15;

        public int[] bird_ij = new int[2];
        public int[,,,] obsticles_n_x_y_ij = new int[2,2,10,2];

	    public int score;
        public int moving_up;
        public char movement;

        public void reset_game()
        {
            bird_ij[0] = 1;
            bird_ij[1] = 1;

            moving_up = 0;

            score = 0;

            create_obsticles();
		}

		public void zdarova()
        {
			while(true)
				movement = System.Console.ReadKey(true).KeyChar;
		}

        internal void move_bird()
        {
			if (movement == 'w')
			{
				moving_up = 3;
				bird_ij[0]--;
			}
			else
			{
				if (moving_up == 0)
					bird_ij[0]++;

				if (moving_up != 0)
					moving_up--;

				if (moving_up != 0)
					bird_ij[0]--;
			}
		}

        public void print_game()
		{
			Console.Clear();

			for (int i = 0; i < length + 2; i++)
                Console.Write("■ ");

			Console.WriteLine();

			bool flag;

			for (int i = 0; i < length; i++)
			{
				Console.Write("■ ");

				for (int j = 0; j < length; j++)
				{
					flag = true;

					for (int n = 0; n < 2; n++)
						for (int x = 0; x < 2; x++)
							for (int y = 0; y < 10; y++)
								if (obsticles_n_x_y_ij[n,x,y,0] == i && obsticles_n_x_y_ij[n,x,y,1] == j)
								{
									Console.Write("■ ");
									flag = false;
								}

					if (bird_ij[0] == i && bird_ij[1] == j && flag)
					{
						Console.Write("^ ");
						flag = false;
					}

					if (flag)
						Console.Write("  ");
				}

                Console.WriteLine("■");
			}

			for (int i = 0; i < length + 2; i++)
				Console.Write("■ ");

			Console.WriteLine("\n\nSCORE: " + score + "\n");
		}

		public void move_obsticles()
		{
			for (int n = 0; n < 2; n++)
				for (int x = 0; x < 2; x++)
					for (int y = 0; y < 10; y++)
						obsticles_n_x_y_ij[n,x,y,1]--;
		}


		public void check_obsticles()
		{
			if (obsticles_n_x_y_ij[0,1,0,1] == 0)
				create_obsticles();
		}


		public void create_obsticles()
		{
			int rand_1 = new Random().Next(2, 8+1);

			int rand_2 = new Random().Next(3, 5+1);

			int[] move_tunnels_i = { rand_1, length - rand_1 - rand_2 };

			int i = 0;

			for (int n = 0; n < 2; n++)
			{
				for (int x = 0; x < 2; x++)
				{
					if (n == 0)
						i = 0;
					else
						i = length - 1;

					for (int y = 0; y != move_tunnels_i[n]; y++)
					{
						obsticles_n_x_y_ij[n,x,y,0] = i;
						obsticles_n_x_y_ij[n,x,y,1] = length + x;

						if (n == 0)
							i++;
						else
							i--;
					}
				}
			}
			score++;
		}

		public void reset_movement()
		{
			movement = ' ';
		}

		public bool check_game()
		{
			if (bird_ij[0] == length || bird_ij[0] == -1 || bird_ij[1] == length || bird_ij[1] == -1)
				return false;

			for (int n = 0; n < 2; n++)
				for (int x = 0; x < 2; x++)
					for (int y = 0; y < 10; y++)
						if (bird_ij[0] == obsticles_n_x_y_ij[n,x,y,0] && bird_ij[1] == obsticles_n_x_y_ij[n,x,y,1])
						{
                            Console.Write("\n\nPress ENTER to contine");
							Console.ReadLine();
							reset_game();
						}

			return true;
		}
	}
}
