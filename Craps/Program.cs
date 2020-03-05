using System;
using System.Threading;

namespace Craps
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); // declaring varables
            int dice1;
            int dice2;
            int sum;
            int reward;
            bool Play = true;
            int coin = 100;
            int point;
            bool fin = false;
            Console.WriteLine("Rules of Craps: The player places a wager then" +
                " rolls two dice and takes the sum of both rolls. If the player " +
                "rolls a 7 or 11 they win and get twice the amount they wagered. " +
                "If they roll a 2 , 3 , or 12 they lose. If they roll anything else they must keep " +
                "rolling until they either match their first rolls sum or roll a 7 and lose.");
            Thread.Sleep(2000);
            Console.WriteLine("You have 100 chips to start");
            do
            { // loop for entire program, loops as long as 'Play' is true
                int wager; //variable
                Console.WriteLine("Choose an amount to wager: "); //prompts user to enter a wager
                String input = Console.ReadLine(); // takes in input
                wager = int.Parse(input); // parses input into an int from a string
                reward = wager * 2; //reward variable which is wager multiplied by 2
                coin = (coin - wager); // remove wager chips from total chips
                if (coin < 0) //if you have no chips end the game (break from loop)
                    break;
                Console.WriteLine("You now have: {0} chips ", coin); // tells user chip total after betting
                Thread.Sleep(1000); // I added Thread.Sleep throughout the program to make it easier to take in what was happening
                dice1 = rand.Next(1, 7); // roll 2 die
                dice2 = rand.Next(1, 7);
                sum = dice1 + dice2; // takes sum of 2 die
                Console.WriteLine("You rolled a sum of: {0} ", sum); // tells user what they rolled
                Thread.Sleep(1000);
                if ((sum == 7) || sum == 11)
                { //if they rolled 7 or 11 they win and get the reward added to chip total
                    coin += reward;
                    Console.WriteLine("You win! Your new chip total is: {0}", coin);
                }
                else if ((sum == 2) || (sum == 12) || (sum == 3))
                { // if they roll 2 or 12 they lost
                    Console.WriteLine("You lost! ");
                }
                else
                { // if they didnt win or lose their point is taken and they roll until they win or lose
                    point = sum;
                    Console.WriteLine("Your point is: {0}", point);
                    Thread.Sleep(1000);
                    do // roll until they win or lose (fin == true)
                    {
                        dice1 = rand.Next(1, 7); // roll 2 die then add them together
                        dice2 = rand.Next(1, 7);
                        sum = dice1 + dice2;
                        if (point == sum) // if they roll their point they win and get a reward and break out into the main game loop
                        {
                            Console.Write("You rolled: {0}", sum);
                            Console.WriteLine(" You rolled your point, you win!");
                            coin += reward;
                            Console.WriteLine("Your new chip total is: {0}", coin);
                            fin = true;
                        }
                        else if (sum == 7) // if they roll a 7 before they roll their point they lose 
                        {
                            Console.WriteLine("You rolled a 7! You lose! ");
                            fin = true;
                        }
                        else
                        { // if they dont roll their point or a 7 they are shown what they rolled and they roll again
                            Console.WriteLine("You rolled a(n): {0}", sum + " Rolling again to try to match your point...");
                            Thread.Sleep(2000);
                            fin = false;
                        }
                    } while (fin == false);
                }
                Console.WriteLine("Would you like to continue playing? "); // asks the user if they are done playing
                String answer = Console.ReadLine(); // gets the input
                if (!answer.Equals("yes", StringComparison.InvariantCultureIgnoreCase)) // if the answer is anything but yes the game ends
                    break;
            } while (Play == true);
            if (coin < 0)
            { // after the game is over the program checks chips, if the user has ran out of chips they are told this is why it ended
                Console.WriteLine("No more chips!");
            }
            else
            { // if the game ended with chips remaining this means they said they were done playing
                Console.WriteLine("Thanks for playing");
            }
        }
    }
}
