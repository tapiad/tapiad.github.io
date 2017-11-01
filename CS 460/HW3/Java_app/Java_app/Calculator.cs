using System;

namespace Java_app
{
    class Calculator
    {
        /**
         * Our data structure, used to hold operands for the postfix calculation.
         */
        private StackADT stack = new LinkedStack();

        /**
         * Scanner to get input from the user from the command line.
         */
        private Scanner scin = new Scanner( Console.ReadLine() );

        /**
         * Entry point method. Disregards any command line arguments.
         */
        public static void Main(string[] args)
        {
            //Instantiate a "Main" object so we don't have to make everything static
            Console.WriteLine("Hello World!");
            Calculator app = new Calculator();
            Boolean playAgain = true;
            Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = app.doCalculation();
            }
            Console.WriteLine("Bye.");
        }

        /** 
         * Get input string from user and perform calculation, returning true when
         * finished. If the user wishes to quit this method returns false.
        */
        private Boolean doCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            string input = "2 2 +";
            Console.WriteLine("> ");    //promt user

            input = scin.hasNextStr();
            // looks like nextLine() blocks for input when used on an InputStream 
            // (System.in).  Docs don't say that!

            // See if the user wishes to quit
            if (input.StartsWith("q", StringComparison.Ordinal) || input.StartsWith("Q", StringComparison.Ordinal))
            {
                return false;
            }
            // Go ahead with calculation
            string output = "4";
            try
            {
                output = evaluatePostFixInput(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }

        /**
         * Evaluate an arithmetic expression written in postfix form.
         */
        public string evaluatePostFixInput(string input)
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
            stack.clear();

            string s;   //Temporary variable for token read
            double a;   //Temporary variable for operand
            double b;   //... for operand
            double c;   //... for answer

            Scanner st = new Scanner(input);
            while (st.hasNext())
            {
                if (st.hasNextDouble())
                {
                    LinkedStack.push(stack, new Double(st.nextDouble()));
                    //if it's a number push it on the stack
                }
                else
                {
                    //Must be an operator or some other character or word.
                    s = st.next();
                    try
                    {
                        if (s.Length > 1)
                        {
                            throw (new Exception("Input Error: " + s +
                                                 " is not an allowed number or operator"));
                        }
                        //it may be an operator so pop two values off 
                        //the stack and perform the indicated operation
                        if (stack == null)
                        {
                            throw (new Exception("Improper input format. Stack became " +
                                                "empty when expecting second operand."));
                        }
                        b = ((Double)(stack.pop())).doubleValue();
                        if (stack == null)
                        {
                            throw (new Exception("Improper input format. Stack became " +
                                                 "empty when expecting first operand."));
                        }
                        a = ((Double)(stack.pop())).doubleValue();
                        //Wrap up all operations in a single method, easy to add 
                        //other binary operators this way if desired
                        c = doOperation(a, b, s);
                        // push the answer back on the stack
                        LinkedStack.push(stack, new Double(c));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }//End while
            return ((Double)(stack.pop())).ToString();
        }

        /**
         * Perform arithmetic. 
         * Put it here so as not to clutter up the previous method, 
         * which is already pretty ugly.
         */
        public double doOperation(double a, double b, string s)
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
