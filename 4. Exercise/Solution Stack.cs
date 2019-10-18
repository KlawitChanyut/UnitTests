using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._4.Exercise
{
    [TestFixture]
    class Solution_Stack
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Stack<string>();

            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }     
    }
}
