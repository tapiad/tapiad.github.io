using System;


namespace Java_app
{
    /**
     * A singly linked stack implementation.
     */
    class LinkedStack : StackADT
    {

        private Node top;


        Object StackADT.push(Object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }

        Object StackADT.pop()
        {
            if (isEmpty())
            {
                return null;
            }
            Object topItem = top.data;
            top = top.next;
            return topItem;
        }


        Object StackADT.peek()
        {
            if (isEmpty())
            {
                return null;
            }
            return top.data;
        }

        bool StackADT.isEmpty()
        {
            return top = null;
        }

        void StackADT.clear()
        {
            top = null;
        }

    }
}