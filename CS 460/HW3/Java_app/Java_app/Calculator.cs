using System;

namespace Java_app
{
    //*********************************************************************************
    /// <summary>
    /// Command line postfix calculator.  
    /// </summary>
    /// <creator> Daniel Tapia </creator>
    /// <date> 10.31.17 </date>
    //*********************************************************************************
    class Calculator
    {
        /// <summary>
        /// Our data structure, used to hold operands for the postfix calculation.
        /// </summary>
        private IStackADT IStack = new LinkedStack();


        /// <summary>
        /// Scanner to get input from the user from the command line.
        /// </summary>
        private Scanner scin = new Scanner( Console.ReadLine() );


        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        // <param name="args">The command-line arguments.</param>
        //public static void Main(string[] args)
        public static void Main()
        {
            //Instantiate a "Main" object so we don't have to make everything static
            Console.WriteLine("Hello World!");
            Calculator app = new Calculator();
            bool playAgain = true;
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = app.DoCalculation();
            }
            Console.WriteLine("Bye.");
        }


        /// <summary>
        /// Get input string from user and perform calculation, returning true when
        /// finished.If the user wishes to quit this method returns false.
        /// </summary>
        /// <returns><c>true</c>, if calculation succeeds, <c>false</c> if user quits.</returns>
        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            string input = "2 2 +";
            Console.WriteLine("> ");    //promt user

            input = scin.HasNextStr();
            // looks like nextLine() blocks for input when used on an InputStream 
            // (System.in).  Docs don't say that!

            // See if the user wishes to quit
            if (input.StartsWith("q", StringComparison.CurrentCulture) || 
                input.StartsWith("Q", StringComparison.Ordinal))
            {
                return false;
            }
            // Go ahead with calculation
            string output = "4";
            try
            {
                output = EvaluatePostFixInput(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }


        /// <summary>
        /// Evaluate an arithmetic expression written in postfix form.
        /// </summary>
        /// <returns>Answer as a string.</returns>
        /// <param name="input">Postfix mathematical expression as a string.</param>
        public string EvaluatePostFixInput(string input)
        {
            try
            {
                if (input == null || input.Equals(""))
                {
                    throw (new Exception("Null or the empty string are " +
                                        "not valid postfix expressions."));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Clear our stack before doing a new calculation
            IStack.Clear();

            string s;   //Temporary variable for token read
            double a;   //Temporary variable for operand
            double b;   //... for operand
            double c;   //... for answer

            Scanner st = new Scanner(input);
            while (st.HasNext())
            {
                if (st.HasNextDouble())
                {
                    //double.TryParse(string, double);
                    //double.TryParse(st.HasNextStr(), out a);
                    IStack.Push(double.TryParse(st.HasNextStr(), out a));
                    //LinkedStack.push(IStack, new Double(st.HasNextDouble()));
                    //if it's a number push it on the stack
                }
                else
                {
                    //Must be an operator or some other character or word.
                    s = st.HasNextStr();
                    try
                    {
                        if (s.Length > 1)
                        {
                            throw (new Exception("Input Error: " + s +
                                                 " is not an allowed number or operator"));
                        }
                        //it may be an operator so pop two values off 
                        //the stack and perform the indicated operation
                        if (IStack == null)
                        {
                            throw (new Exception("Improper input format. Stack became " +
                                                "empty when expecting second operand."));
                        }
                        //b = ((Double)(IStack.Pop())).doubleValue();
                        b = (double)IStack.Pop();
                        if (IStack == null)
                        {
                            throw (new Exception("Improper input format. Stack became " +
                                                 "empty when expecting first operand."));
                        }
                        //a = ((Double)(IStack.Pop())).doubleValue();
                        a = (double)IStack.Pop();
                        //Wrap up all operations in a single method, easy to add 
                        //other binary operators this way if desired
                        c = DoOperation(a, b, s);
                        // push the answer back on the stack
                        //LinkedStack.push(IStack, new Double(c));
                        IStack.Push(double.TryParse(st.HasNextStr(), out c));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }//End while
            return ((Double)(IStack.Pop())).ToString();
        }


        /// <summary>
        /// Performs arithmetic
        /// </summary>
        /// <returns>The answer.</returns>
        /// <param name="a">First operand.</param>
        /// <param name="b">Second operand.</param>
        /// <param name="s">Operator.</param>
        public double DoOperation(double a, double b, string s)
        {
            double c = 0.0;
            if (s.Equals("+"))//Can't use a switch-case with Strings, so we do if-else
            {
                c = (a + b);
            }
            else if (s.Equals("-"))
            {
                c = (a - b);
            }
            else if (s.Equals("*"))
            {
                c = (a * b);
            }
            else if (s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (double.IsNegativeInfinity(c) || double.IsPositiveInfinity(c))
                    {
                        throw (new Exception("Can't divide by zero"));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    throw (new Exception("Improper operator: " + s +
                                    ", is not one of +, -, *, or /"));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return c;
        }
    }//end class Calculator
}
