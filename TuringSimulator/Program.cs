using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuringSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.txt", SearchOption.TopDirectoryOnly);

            while (true)
            {

                Console.WriteLine("Welcome to Turing Machine! This program will simulate turing machine. \nTo stop working turing machine simply press 'esc' button! \n");
                for (int i = 0; i < inputs.Length; i++)
                {
                    Console.WriteLine(i + "  " + inputs[i]);
                }
                Console.WriteLine(inputs.Length + "  Thread all of inputs");
                Console.WriteLine(inputs.Length + 1 + "  Thread certain inputs");
                Console.WriteLine(inputs.Length + 2 + "  Exit program");
                Console.WriteLine("\nWhich File do you want to use for turing machine? Please enter the digit:\n");

                int pick = Convert.ToInt32(Console.ReadLine());

                if (pick >= 0 && pick < inputs.Length)
                {
                    TuringMachine turingMachine = new TuringMachine(inputs[pick]);
                    turingMachine.Start();
                }
                else if (pick == inputs.Length)
                {

                    Parallel.ForEach(inputs, (input) =>
                    {
                        TuringMachine turingMachine = new TuringMachine(input);
                        turingMachine.Start();
                    }
                    );
                }
                else if (pick == inputs.Length+1)
                {
                    List<string> ThreadInputs = new List<string>();
                    int i = 0;
                    Console.WriteLine("Please choose file which you want to Thread and hit enter, type 'done' when you want to thread your choices");
                    while (true)
                    {
                        string ThreadInput = Console.ReadLine();
                        if (ThreadInput == "done")
                            break;
                        else
                        {
                            ThreadInputs.Add(inputs[Convert.ToInt32(ThreadInput)]);
                        }
                    }

                    Parallel.ForEach(ThreadInputs, (input) =>
                    {
                        TuringMachine turingMachine = new TuringMachine(input);
                        turingMachine.Start();
                    }
                     );
                }
                else if (pick == inputs.Length+2)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wronge choce, please try again \n");
                }
            }
        }
    }

    public class TuringMachine
    {
        public List<Instruction> Instructions = new List<Instruction>();
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        public int Head;
        public string Tape;
        public string Status = "0";
        bool ValidInstructions = true;

        public TuringMachine(string FileName)
        {

            var lines = File.ReadAllLines(FileName).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            String HeadPosition = int.Parse(lines.First()).ToString();

            Tape = lines.Skip(1).First();
            Instructions = lines.Skip(2).Select(line => Instruction.Parse(line)).ToList();
            Head = Convert.ToInt32(HeadPosition);

            Dict();
        }

        public void Start()
        {
            Console.WriteLine("Press ESC to stop");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) && ValidInstructions == true && Head >= 0 && Head < Tape.Length)
            {
                StartTuring();
            }
        }
        public void StartTuring()
        {
            int pick = 0;

            if (Head >= 0 && Head < Tape.Length)
            {
                PrintTape();
            }

            while (Head >= 0 && Head < Tape.Length && ValidInstructions == true && !Console.KeyAvailable)
            {
                String find = Status + Tape[Head];

                if (ValidInstructions != dict.ContainsKey(find))
                {
                    ValidInstructions = false;
                    break;
                }
                pick = dict[find];
                Status = Instructions[pick].NewStatus;

                ChangeTape(ref Tape, Head, Convert.ToChar(Instructions[pick].NewSymbol));
                HeadChange(pick, Instructions[pick].Direction);

                PrintTape();
            }
        }

        public int HeadChange(int pick, string Direction)
        {
            return Instructions[pick].Direction == "R" ? Head++ : Head--;
        }
        public void ChangeTape(ref string Input, int head, char NewElement)
        {

            char[] chr = Input.ToCharArray();
            chr[head] = NewElement;
            Input = new string(chr);
        }

        public void PrintTape()
        {
;            Console.WriteLine(Tape);
            if (Head >= 0)
                Console.WriteLine(new string(' ', Head) + '^');
        }


        public void Dict()
        {
            for (int i = 0; i < Instructions.Count; i++)
            {
                string key = Instructions[i].CurrentStatus + Instructions[i].CurrentSymbol;
                dict.Add(key, i);
            }
        }
    }

    public class Instruction
    {
        public string CurrentStatus;
        public string CurrentSymbol;
        public string NewSymbol;
        public string Direction;
        public string NewStatus;

        public Instruction(string currentStatus, string currentSymbol, string newSymbol, string direction, string newStatus)
        {
            CurrentStatus = currentStatus;
            CurrentSymbol = currentSymbol;
            NewSymbol = newSymbol;
            Direction = direction;
            NewStatus = newStatus;
        }

        public static Instruction Parse(string instructionString)
        {
            var tokens = instructionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return new Instruction(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]);
        }
    }
}
