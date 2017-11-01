using System.Text;

namespace Java_app
{
    /// <summary>
    /// Operates the same way as a java Scanner.
    /// </summary>
    class Scanner : System.IO.StringReader
    {
        /// <summary>
        /// Current word
        /// </summary>
        string currentWord;


        /// <summary>
        /// Where it gets all the input.
        /// </summary>
        /// <param name="source">The source of input.</param>
        public Scanner(string source) : base(source)
        {
            ReadNextWord();
        }


        /// <summary>
        /// Reads the next element of the scanner.
        /// </summary>
        private void ReadNextWord()
        {
            StringBuilder sb = new StringBuilder();
            char nextChar;
            int next;
            do
            {
                next = this.Read();
                if (next < 0)
                    break;
                nextChar = (char)next;
                if (char.IsWhiteSpace(nextChar))
                    break;
                sb.Append(nextChar);
            } while (true);
            while ((this.Peek() >= 0) && (char.IsWhiteSpace((char)this.Peek())))
                this.Read();
            if (sb.Length > 0)
                currentWord = sb.ToString();
            else
                currentWord = null;
        }


        /// <summary>
        /// Checks if it has a next string.
        /// </summary>
        /// <returns>The next string.</returns>
        public string HasNextStr()
        {
            ReadNextWord();
            return currentWord;
        }


        /// <summary>
        /// Checks whether or not it has a next int.
        /// </summary>
        /// <returns>
        /// <c>true</c>, if true, returns next in, 
        /// <c>false</c> otherwise, return null.
        /// </returns>
        public bool HasNextInt()
        {
            if (currentWord == null)
                return false;
            return int.TryParse(currentWord, out int dummy);
        }


        /// <summary>
        /// Gives next int.
        /// </summary>
        /// <returns>Next int.</returns>
        public int NextInt()
        {
            try
            {
                return int.Parse(currentWord);
            }
            finally
            {
                ReadNextWord();
            }
        }


        /// <summary>
        /// Checks if it has next double.
        /// </summary>
        /// <returns>
        /// <c>true</c>, if true, return next double. 
        /// <c>false</c> otherwise, null.
        /// </returns>
        public bool HasNextDouble()
        {
            if (currentWord == null)
                return false;
            return double.TryParse(currentWord, out double dummy);
        }


        /// <summary>
        /// Grabs next double
        /// </summary>
        /// <returns>Next double.</returns>
        public double NextDouble()
        {
            try
            {
                return double.Parse(currentWord);
            }
            finally
            {
                ReadNextWord();
            }
        }


        /// <summary>
        /// checks if it has next element
        /// </summary>
        /// <returns>
        /// <c>true</c>, if next was hased, 
        /// <c>false</c> otherwise.
        /// </returns>
        public bool HasNext()
        {
            return currentWord != null;
        }
    }
}