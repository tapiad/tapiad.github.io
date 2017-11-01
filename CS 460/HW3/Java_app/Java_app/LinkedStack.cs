

namespace Java_app
{
    //****************************************
    /// <summary>
    /// A singly linked stack implementation.
    /// </summary>
    //****************************************
    class LinkedStack : IStackADT
    {
        /// <summary>
        /// The stack
        /// </summary>
        private Node top;


        /// <summary>
        /// Emtpy stack <see cref="T:Java_app.LinkedStack"/> class.
        /// </summary>
        public LinkedStack(){
            top = null;//Empty stack condition
        }


        /// <summary>
        /// Pushes to top of stack
        /// </summary>
        /// <returns>newItem</returns>
        /// <param name="newItem">object onto top of stack.</param>
        object IStackADT.Push(object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }


        /// <summary>
        /// Pops top objects out of stack
        /// </summary>
        /// <returns>topItem</returns>
        object IStackADT.Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            object topItem = top.data;
            top = top.next;
            return topItem;
        }


        /// <summary>
        /// Checks out top object from stack
        /// </summary>
        /// <returns>Data from top.data.</returns>
        object IStackADT.Peek() 
        {
            if (IsEmpty())
            {
                return null;
            }
            return top.data;
        }


        /// <summary>
        /// Checks if stack is empty
        /// </summary>
        /// <returns>
        /// <c>true</c>, if empty, returns null,
        /// <c>false</c> otherwise, return false.
        /// </returns>
        bool IsEmpty()
        {
            return top == null;
        }


        /// <summary>
        /// Clears out the stack
        /// </summary>
        void IStackADT.Clear()
        {
            top = null;
        }

    }
}