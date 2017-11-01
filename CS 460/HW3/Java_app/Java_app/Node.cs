using System;


namespace Java_app
{
    /**
     * A simple singly linked node class. This implementation comes from 
     * before Java had Generics.
     */
    class Node
    {
        readonly object data; //The Payload
        readonly Node next; //Reference to the next Node in the chain

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}