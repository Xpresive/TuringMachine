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
            t.Tell();

        }
    }
    public class TuringMachine
    {
        //public List<Instruction> Instructions = new List<Instruction>();
        List<Instruction> Instructions = File.ReadLines("input.txt").Skip(2).Take(20).ToList();
        public string Head;
        public string Tape;

        //Items[j].Code

        public TuringMachine()
        {
            /* need input here */
            string[] rest = new string[100];
            /*File.ReadAllText("input.txt").Replace(" ", string.Empty);
            string head = File.ReadLines("input.txt").Take(1).First();
            string tape = File.ReadLines("input.txt").Skip(1).Take(1).First();
            string rest[] = File.ReadAllText("input.txt").Replace(" ", string.Empty).Skip(2);
            Console.WriteLine(head);
            Console.WriteLine(tape);*/

            var lines = File.ReadAllLines("input.txt").Select(x => x.Replace(" ", string.Empty));
            (int head, string tape, List<string> Instructions) = (int.Parse(lines.First()), lines.Skip(1).First(), lines.Skip(2).ToList());
           
            Console.WriteLine(head);
            Console.WriteLine(tape);
           

        }

        public void Tell()
        {
            Console.WriteLine(Instructions[0].CurrentStatus);
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

/*
 * File.ReadAllText("input.txt").ToCharArray().Where(x => x != ' ').ToArray();
No spaces no more
Could've just done File.ReadAllText("input.txt").Replace(" ", string.Empty)
*
*/
