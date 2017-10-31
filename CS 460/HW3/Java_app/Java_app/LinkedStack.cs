using System;


namespace Java_app
{
    /**
     * A singly linked stack implementation.
     */
    class LinkedStack : StackADT
    {

        private Node top;

        LinkedStack(){
            top = null;//Empty stack condition
        }

        Object push(Object newItem)
        {
            if(newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }

        Object pop()
        {
            if (isEmpty()){
                return null;
            }
            Object topItem = top.data;
            top = top.next;
            return topItem;
        }

        Object peek()
        {
            if(isEmpty())
            {
                return null;
            }
            return top.data;
        }

        Boolean isEmpty()
        {
            return top = null;
        }

        void clear()
        {
            top = null;
        }
    }
}