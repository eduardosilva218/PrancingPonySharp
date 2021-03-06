using System;
using Xunit;

namespace PrancingPonySharp.QueueExtensions.Test
{
    public class QueueTest
    {
        [Fact]
        public void ShouldQueueEnumerable()
        {
            var expected = new Queue<string>(new[]
            {
                "one", "two", "three", "four"
            });
            var actual = new Queue<string>(new[]
            {
                "one"
            });
            actual.EnqueueEnumerable(new[]
            {
                "two", "three", "four"
            });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldRemoveFirstTwoNumbersOfQueue()
        {
            var expected = new Queue<int>(new[]
            {
                3, 4
            });
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            actual.DequeueEnumerable(2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnFirstTwoNumbersOfQueue()
        {
            var expected = new[]
            {
                1, 2
            };
            var queue = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = queue.DequeueEnumerable(2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldThrowIndexOutOfRangeExceptionWithCorrectMessageIfItAsksForMoreElements()
        {
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            const int quantity = 200000;
            var exception = Assert.Throws<IndexOutOfRangeException>(
                () => actual.DequeueEnumerable(quantity));
            Assert.Equal($"Attempted to dequeue an invalid amount of values: The queue's length is {actual.Count} but the amount expected to dequeue is {quantity}.", exception.Message);
        }

        [Fact]
        public void ShouldThrowIndexOutOfRangeExceptionWithCorrectMessageIfPassNegativeNumber()
        {
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            const int quantity = -23;
            var exception = Assert.Throws<IndexOutOfRangeException>(
                () => actual.DequeueEnumerable(quantity));
            Assert.Equal($"Attempted to dequeue an invalid amount of values: The queue's length is {actual.Count} but the amount expected to dequeue is {quantity}.", exception.Message);
        }

        [Fact]
        public void ShouldNotModifyTheQueueIfItPassesZero()
        {
            var expected = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            actual.DequeueEnumerable(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnAnEmptyEnumerableIfYouPassZero()
        {
            var expected = Array.Empty<int>();
            var queue = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = queue.DequeueEnumerable(0);
            Assert.Equal(expected, actual);
        }
    }
}
