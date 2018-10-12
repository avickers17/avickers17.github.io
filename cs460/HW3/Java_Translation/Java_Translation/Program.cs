using System;
using System.Collections.Generic;
using System.Text;



namespace Java_Translation
{/// <summary>
/// Original by Sumit Ghosh "An Interesting Method to Generate Binary Numbers from 1 to n"
/// at https://www.geeksforgeeks.org/interesting-method-generate-binary-numbers-1-n/
///
///Adapted for CS 460 HW3.This simple example demonstrates the rather powerful
///application of Breadth-First Search to enumeration of states problems.
///There are easier ways to generate a list of binary values, but this technique
///is very general and a good one to remember for other uses.
/// </summary>
	public class Program
    {/// <summary>
     ///Print the binary representation of all numbers from 1 up to n.
     ///This is accomplished by using a FIFO queue to perform a level
     ///order(i.e.BFS) traversal of a virtual binary tree that
     ///looks like this:
     ///                 1
     ///             /       \
     ///            10       11
     ///           /  \     /  \
     ///         100  101  110  111
     ///          etc.
     ///and then storing each "value" in a list as it is "visited".
     /// </summary>
     /// <param name="n">Int value provided by the user at run time, passed in as the first argument when program is ran</param>
     /// <returns>Returns a link list of Strings up to the specified arguement provided by the user</returns>
        static LinkedList<String> GenerateBinaryList(int n)
        {
            //create a new queue of strings used for the BFS traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();
            //Linked list used to provide the binary representation of each number in the queue
            LinkedList<string> output = new LinkedList<string>();
            if (n < 1)
            {
                //This list will not support negative number values, in this case simply return an empty list
                return output;
            }
            //enqueue the first binary number starting with 1, using dynamic stringbuilder as to not concat
            q.Push(new StringBuilder("1"));

            //Breath First Search stops when the number received from user reaches 0
            while (n-- > 0)
            {
                //Grab the end of the queue and put that value into the value of the linked list FIFO fashion as a string
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                //Creates a copy of the first value above
                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Update sb to reflect the next number in binary, then push it into the queue
                sb.Append('0');
                q.Push(sb);

                //Update the copy to reflect the following number in binary, and push that number into the queue
                sbc.Append('1');
                q.Push(sbc);
            }
            //Return the linked list of strings that holds all binary number representations
            return output;
        }
        //Main program that runs function and checks for input error from user
        static void Main(string[] args)
        {
            //Initialize int n
            int n = 10;
            //Check to make sure user provided argument
            if (args.Length < 1)
            {
                //If user did not provide argument, return error message
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("Main.exe 12");
            }
            try
            {
                //Attempt to cast received argument into an int and set to "int n"
                n = int.Parse(args[0]);
            }
            catch (FormatException e)
            {
                //If excetpion is caugt, return console information to the user and end program
                Console.WriteLine("Sorry, I can't understand the number: " + args[0]);
                return;
            }
            //If n is parsed correctly, run function to generate Binary list and return list
            LinkedList<string> output = Program.GenerateBinaryList(n);

            //Int used for spacing when writting out list, set to the maximum length of the longest string within the list 
            int maxLength = output.Last.Value.Length;

            //Loop that cycles through output list and ends when reaches the last string in the list
            foreach (string s in output)
            {
                //Inside Loop for adding space before the shorter strings in output to add a clean output look to the user  
                for (int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
            //Keeps console open for user to view until enter is pressed.
            Console.Read();
        }
    }
}
