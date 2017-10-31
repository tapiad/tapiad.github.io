using System;


namespace Java_app
{
    /** Java Interface defining a Stack. */
    public interface StackADT
    {
        /**
         * Push an item onto the top of the stack. Pushing an object that 
         * doesn’t exist should result in an error and should not succeed.
         * Pushing an object that is not an item should result in an error.
         * This operation returns a reference (pointer or link, but not a copy)
         * to the item pushed so that an anonymous object can be pushed and then used.
         */
        Object push(Object newItem);

        /**
         * Remove and return the top item on the stack. This operation should 
         * result in an error if the stack is empty. Returns a reference to the 
         * item removed.
         */
        Object pop();

        /**
         * Return the top item but do not remove it. Generally should result in 
         * an error if the stack is empty. An acceptable alternative is to return 
         * something which the user can use to check to see if the stack was in fact empty.
         */
        Object peek();

        /**
         * Query the stack to see if it is empty or not. Cannot produce an error.
         */
        bool isEmpty();

        /**
         * Reset the stack by emptying it. The exact technique used to clear 
         * the stack is up to the implementor. The user should pay attention to what 
         * this behavior is.
         */
        void clear();
    }

}