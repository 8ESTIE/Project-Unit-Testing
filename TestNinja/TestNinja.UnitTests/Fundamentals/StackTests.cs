using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class StackTests
    {
        Stack<int?> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<int?>();
        }

        [Test]
        public void Push_ObjIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WhenCalled_PushObj()
        {
            _stack.Push(0);
            Assert.That(_stack.Count, Is.EqualTo(1)); 
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(()=> _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_PopObj()
        {
            _stack.Push(0);
            Assert.That(_stack.Pop()==0 && _stack.Count==0);
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_PeekObj()
        {
            _stack.Push(0);
            Assert.That(_stack.Peek()==0 && _stack.Count == 1);
        }
    }
}