using System;


namespace Java_app
{
    /**
     * A singly linked stack implementation.
     */
    class LinkedStack : StackADT
    {

        private Node top;


        public Object StackADT.push(Object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }

        public Object StackADT.pop()
        {
            if (isEmpty())
            {
                return null;
            }
            Object topItem = top.data;
            top = top.next;
            return topItem;
        }

        public Object StackADT.peek()
        {
            if (isEmpty())
            {
                return null;
            }
            return top.data;
        }

        public bool StackADT.isEmpty()
        {
            return top = null;
        }

        public void StackADT.clear()
        {
            top = null;
        }
    }
}