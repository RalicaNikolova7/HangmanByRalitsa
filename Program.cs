using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Hangman;
class Program
{
    static void Main(string[] args)
    {

        string[] wrongGuessesFrames =
        {

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      |\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"       \  ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══"

        };

        const string WinScreenText = @"
        ┌───────────────────────────┐
        │                           │
        │ WW       WW  **  NN   N   │
        │ WW       WW  ii  NNN  N   │
        │  WW  WW WW   ii  N NN N   │
        │   WWWWWWW    ii  N  NNN   │
        │    WW  W     ii  N   NN   │
        │                           │
        │         Good job!         │
        │   You guessed the word!   │
        └───────────────────────────┘
        ";

        const string LossScreenTest = @"
        ┌────────────────────────────────────┐
        │  LLL          OOOO    SSSS   SSSS  │
        │  LLL         OO  OO  SS  SS SS  SS │
        │  LLL        OO    OO SS     SS     │
        │  LLL        OO    OO  SSSS   SSSS  │
        │  LLL        OO    OO     SS     SS │
        │  LLLLLLLLLL  OO  OO  SS  SS SS  SS │
        │   LLLLLLLLL   OOOO    SSSS   SSSS  │
        │                                    |
        │        You were so close.          │
        │ Next time you will guess the word! │
        └────────────────────────────────────┘
        ";



        string[] deathAnimationsFrames =
        {
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o>  ║   " + '\n' +
            @"     /|   ║   " + '\n' +
            @"      >\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"     <o   ║   " + '\n' +
            @"      |\  ║   " + '\n' +
            @"     /<   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o>  ║   " + '\n' +
            @"     /|   ║   " + '\n' +
            @"      >\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o>  ║   " + '\n' +
            @"     /|   ║   " + '\n' +
            @"      >\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"     <o   ║   " + '\n' +
            @"      |\  ║   " + '\n' +
            @"     /<   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"     <o   ║   " + '\n' +
            @"      |\  ║   " + '\n' +
            @"     /<   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"     <o   ║   " + '\n' +
            @"      |\  ║   " + '\n' +
            @"     /<   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      o   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      /   ║   " + '\n' +
            @"      \   ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    |__   ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    \__   ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"   ____   ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"    __    ║   " + '\n' +
            @"   /══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    _ '   ║   " + '\n' +
            @"  _/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"      _   ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"      _   ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @"      _   ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      .   ║   " + '\n' +
            @"          ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      '   ║   " + '\n' +
            @" __/══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"      _   ║   " + '\n' +
            @" __/══════╩═══"

        };
        const string Underscore = "_";

        void DrawCurrentGameState(bool inputIsInvalid, int incorrectGuess, string guessedWord, List<char> playerUsedLetters)
        {
            Console.Clear();
            Console.WriteLine(wrongGuessesFrames[incorrectGuess]);
            Console.WriteLine($"Guess: {guessedWord}");
            Console.WriteLine($"You have to guess {guessedWord.Length} symbols");
            Console.WriteLine($"Used letters: {String.Join(", ", playerUsedLetters)}");

            if (inputIsInvalid)
            {
                Console.WriteLine("Only a single char!");
            }

            Console.Write("Your symbol: ");
        }

        static bool CheckIfSymbolIsContained(string word, char playerLetter)
        {
            if (!word.Contains(playerLetter))
            {
                return false;
            }
            return true;
        }

        static string AddLetterToGuessWord(string word, char playerLetter, string wordToGuess)
        {
            char[] wordToGuessCharArr = wordToGuess.ToCharArray();
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (playerLetter == word[i])
                {
                    wordToGuessCharArr[i] = playerLetter;
                }
            }
            return new String(wordToGuessCharArr);
        }

        static bool CheckIfPlayerWins(string wordToGuess)
        {
            if (wordToGuess.Contains(Underscore))
            {
                return false;
            }
            return true;
        }

        static bool CheckIfPlayerLoses(int incorrectGuessCount)
        {
            const int MaxCount = 6;
            if (incorrectGuessCount == MaxCount)
            {
                return true;
            }
            return false;
        }

        static string GetRandomWord(string[] words)
        {
            Random random = new Random();
            string word = words[random.Next(words.Length)];
            return word.ToLower();
        }

        void PlayGame(string word, string wordToGuess, int incorrectGuessCount, List<char> playerUsedLetters)
        {

            while(true)
            {

                string playerInput = Console.ReadLine().ToLower();

                if (playerInput.Length != 1)
                {
                    DrawCurrentGameState(true, incorrectGuessCount, wordToGuess, playerUsedLetters);
                    continue;
                }

                char playerLetter = char.Parse(playerInput);
                playerUsedLetters.Add(playerLetter);
                bool playerLetterIsContained = CheckIfSymbolIsContained(word, playerLetter);

                if (playerLetterIsContained)
                {
                    wordToGuess = AddLetterToGuessWord(word, playerLetter, wordToGuess);
                }
                else
                {
                    incorrectGuessCount++;
                }
                DrawCurrentGameState(false, incorrectGuessCount, wordToGuess, playerUsedLetters);

                bool playerWins = CheckIfPlayerWins(wordToGuess);

                if (playerWins)
                {

                    Console.Clear();
                    Console.WriteLine(WinScreenText);
                    break;
                }

                bool playerLoses = CheckIfPlayerLoses(incorrectGuessCount);
                if (playerLoses)
                {
                    Console.SetCursorPosition(0, 0);
                    DrawDeathAnimation(deathAnimationsFrames);
                    Console.Clear();
                    Console.WriteLine(LossScreenTest);
                    Console.WriteLine($"{word}");
                    break;
                }
            }


            Console.Write("If you want to play again, press [Enter]. Else, type 'quit': ");
            string playerGames = Console.ReadLine();

            if (playerGames == "quit")
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing! Hangman was closed.");
            }

            Console.Clear();
        }

        static string[] ReadWordsFromFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            const string WordsFileName = "words.txt";
            string path = Path.Combine(projectDirectory, WordsFileName);
            string[] words = File.ReadAllLines(path);
            return words;
        }

        static void DrawDeathAnimation(string[] deathAnimation)
        {
            for (int i = 0; i < deathAnimation.Length; i++ )
            {
                Console.WriteLine(deathAnimation[i]);
                Thread.Sleep(200);
                Console.SetCursorPosition(0, 0);
            }
        }


        string[] words = ReadWordsFromFile();

        Console.CursorVisible = false;

        while (true)
        {
            string word = GetRandomWord(words);
            string wordToGuess = "";
            for (var i = 0; i < word.Length; i++)
            {
                wordToGuess += Underscore;
            }

            int incorrectGuessCount = 0;
            List<char> playerUsedLetters = new List<char>();

            DrawCurrentGameState(false, incorrectGuessCount, wordToGuess, playerUsedLetters);

            PlayGame(word, wordToGuess, incorrectGuessCount, playerUsedLetters);

        }
    }    
}

    

