using System;


namespace Java_app
{
    /**
     * A simple singly linked node class. This implementation comes from 
     * before Java had Generics.
     */
    class Node
    {
        Object data; //The Payload
        Node next; //Reference to the next Node in the chain

        Node()
        {
            data = null;
            next = null;
        }

        Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}