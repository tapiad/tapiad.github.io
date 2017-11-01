

namespace Java_app
{
    //****************************************
    /// <summary>
    /// A simple singly linked node class.
    /// Represents the stack
    /// </summary>
    //****************************************
    class Node
    {
        public object data; //The Payload
        public Node next; //Reference to the next Node in the chain


        /// <summary>
        /// Initializes an empty stack <see cref="T:Java_app.Node"/> class.
        /// </summary>
        public Node()
        {
            data = null;
            next = null;
        }

        /// <summary>
        /// Initializes a stack <see cref="T:Java_app.Node"/> class.
        /// </summary>
        /// <param name="data">objects of the stack.</param>
        /// <param name="next">checks next object of the stack.</param>
        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}