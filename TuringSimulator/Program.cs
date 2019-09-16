using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TuringSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            TuringMachine t;

            /*
            int a, b;
            char c;


            string Input = Console.ReadLine();
            char[] Tape = Input.ToCharArray();
            // Console.WriteLine(Input);
            int TapeLength = Input.Length;
            int Head = 0;


            while (true)
            {
                string Command = Console.ReadLine();
                string[] split = Command.Split(' ');
                a = Int32.Parse(split [0]);
                b = Int32.Parse(split[1]);
                c = Char.Parse(split[2]);
                /*
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
                
                if (Tape[Head] == a)
                {
                    Tape[Head] = (char)b;
                    if (c == 'R')
                        Head++;
                    else Head--;
                }
                else
                    continue;


            }
        */
        }
    }
    public class TuringMachine
    {
        public List<Instruction> Instructions = new List<Instruction>();

        public TuringMachine()
        {
            /* need input here */
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
