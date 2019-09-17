using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace TuringSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            TuringMachine t = new TuringMachine();
            t.Check();

        }
    }
    public class TuringMachine
    {
        public List<Instruction> Instructions = new List<Instruction>();
        public string Head;
        public string Tape;


        public TuringMachine()
        {
            var lines = File.ReadAllLines("input.txt").Select(x => x.Replace(" ", string.Empty));
            (int head, string tape, List<string> Input) = (int.Parse(lines.First()), lines.Skip(1).First(), lines.Skip(2).ToList());

            Head = head.ToString();
            Tape = tape;

            Console.WriteLine(Input[1]);
            Console.WriteLine(Input.Count);
        }

        public void Check()
        {
            Console.WriteLine(Instructions.Count);
            Console.WriteLine(Head);
            Console.WriteLine(Tape);
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

        public Instruction() { }
    }

}
