

namespace Java_app
{
    //*****************************
    /// <summary>
    /// Interface defining a Stack.
    /// </summary>
    //*****************************
    public interface IStackADT
    {
        /// <summary>
        /// Push an item onto the top of the stack.
        /// </summary>
        /// <returns>A reference to the object that was pushed.</returns>
        /// <param name="newItem">The object to push onto the top of the stack.</param>
        object Push(object newItem);


        /// <summary>
        /// Remove and return the top item on the stack.
        /// </summary>
        /// <returns>A reference that was popped.removed from stack.</returns>
        object Pop();


        /// <summary>
        /// Return the top item but do not remove it.
        /// </summary>
        /// <returns>A reference to the item currently on the top of the stack.</returns>
        object Peek();

        /**
         * Reset the stack by emptying it. The exact technique used to clear 
         * the stack is up to the implementor. The user should pay attention to what 
         * this behavior is.
         */

        /// <summary>
        /// Reset the stack by emptying it.
        /// </summary>
        void Clear();
    }

}