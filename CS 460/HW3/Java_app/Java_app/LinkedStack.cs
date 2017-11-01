using System;


namespace Java_app
{
    //***************************************
    /// <summary>
    /// A singly linked stack implementation.
    /// </summary>
    //****************************************
    class LinkedStack : IStackADT
    {

        private Node top;

        public LinkedStack(){
            top = null;//Empty stack condition
        }

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


        object IStackADT.Peek() 
        {
            if (IsEmpty())
            {
                return null;
            }
            return top.data;
        }

        /**
         * Query the stack to see if it is empty or not. Cannot produce an error.
         */
        bool IsEmpty()
        {
            return top == null;
        }

        void IStackADT.Clear()
        {
            top = null;
        }

    }
}