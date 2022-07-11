using gaming1.crossCutting;
using gaming1.crossCutting.DTO;
using gaming1.executor;
using gaming1.iexecutor;
using Microsoft.Extensions.DependencyInjection;

public class Mistery
{
    private static int players = 0;
    private static int playerIndex = 1;
    private static List<UserAnswerDto> userAnswers = new List<UserAnswerDto>();

    public static void Main()
    {
        try
        {
            Console.WriteLine("In this game, you should select the right between 0 and 100. \n " +
                "Please, choose 1 if you want a single player mode or 2 if you want a mult-player mode.");

            string? mode = Console.ReadLine();

            switch (mode)
            {
                case "1":
                    Console.WriteLine("Please, try your number.");

                    SingleMode();

                    break;
                case "2":
                    Console.WriteLine("Please, type how many players will be playing.");
                    string? result = Console.ReadLine();

                    if (!string.IsNullOrEmpty(result))
                    {
                        players = int.Parse(result);
                        MultMode();
                    }

                    break;
                default:
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Sorry, we foung a error! Please try again.");
        }
    }

    private static void SingleMode()
    {
        string? result = Console.ReadLine();
        int number;

        if (!string.IsNullOrEmpty(result))
        {
            if(int.TryParse(result, out number))
            {
                GameSingleMode(number);
                return;
            }

            Console.WriteLine($"You need to set a valid number. Try again!");
            SingleMode();
        }
    }

    private static void MultMode()
    {
        if(playerIndex == 1)
            userAnswers = new List<UserAnswerDto>();

        for (int i = playerIndex; i <= players; i++)
        {
            playerIndex = i;
            Console.WriteLine($"Player {i} choose your number.");

            string? result = Console.ReadLine();
            int number;

            if (!string.IsNullOrEmpty(result)) 
            {
                if (int.TryParse(result, out number))
                    userAnswers.Add(new UserAnswerDto($"Player {i}", number));
                else
                {
                    Console.WriteLine($"You need to set a valid number. Try again!");
                    MultMode();
                    return;
                }
            }
        }

        if(userAnswers.Any() && userAnswers.Count() == players)
            GameMultMode(userAnswers);
    }

    private static void GameMultMode(IList<UserAnswerDto> answers)
    {
        var _multPlayerGameResultExecutor = ServiceProvider().GetService<IMultPlayerGameResultExecutor>();
        UserAnswerDto? result = _multPlayerGameResultExecutor.Winner(answers);

        if (result != null)
        {
            Console.WriteLine($"Congrats player {result.Name}! You win!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"No one win this time, try again!");
            playerIndex = 1;
            userAnswers = new List<UserAnswerDto>();
            MultMode();
        }
    }

    private static void GameSingleMode(int number)
    {
        var _singlePlayerGameExecutor = ServiceProvider().GetService<ISinglePlayerGameExecutor>();
        string result = _singlePlayerGameExecutor.ValidateResult(number);

        if (result == "=")
        {
            Console.WriteLine("Congrats!! You win!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"The mistery number is {result} the player's guess. Try again");
            SingleMode();
        }
    }

    private static ServiceProvider ServiceProvider()
    {
        return new ServiceCollection()
           .AddSingleton<ISinglePlayerGameExecutor, SinglePlayerGameExecutor>()
           .AddSingleton<IMultPlayerGameResultExecutor, MultPlayerGameResultExecutor>()
           .AddSingleton<IMistery, gaming1.crossCutting.Mistery>()
           .BuildServiceProvider();
    }
}