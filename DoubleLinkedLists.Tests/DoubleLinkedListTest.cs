using DoubleLinkedLists;
using NUnit.Framework;
using System;

namespace DoubleLinkedListTests
{
    public class DoubleLinkedListTest
    {
        [Test]
        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(-1, new int[] { -1, -1, -2 }, new int[] { -1, -1, -2, -1 })]
        [TestCase(0, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(1, new int[] { 2 }, new int[] { 2, 1 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.Add(value);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(-1, new int[] { -1, -2, -1 }, new int[] { -1, -1, -2, -1 })]
        [TestCase(0, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(1, new int[] { 2 }, new int[] { 1, 2 })]
        public void AddFirstTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, new int[] { 1, 2, 1 }, new int[] { 1, 1, 2, 1 })]
        [TestCase(0, 1, new int[] { }, new int[] { 1 })]
        [TestCase(2, -1, new int[] { -1, -2, -3 }, new int[] { -1, -2, -1, -3 })]
        [TestCase(0, 0, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(1, 2, new int[] { 1 }, new int[] { 1, 2 })]
        [TestCase(6, 7, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(4, 5, new int[] { 1, 22, 33, 44 }, new int[] { 1, 22, 33, 44, 5 })]
        public void InsertTest(int index, int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.Insert(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-3, -1, new int[] { })]
        [TestCase(-3, -1, new int[] { 1, 3 })]
        public void InsertTest_WhenIndexLessThanZero_ShouldIndexOutOfRangeException(int index, int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }

        [TestCase(3, -1, new int[] { 1, 1 })]
        [TestCase(3, -1, new int[] { })]
        public void InsertTest_WhenIndexLargestLength_ShouldNullReferenceException(int index, int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.Insert(index, value));
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        [TestCase(new int[] { -1, -1, -2, -1 }, new int[] { -1, -1, -2 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 })]
        [TestCase(new int[] { 2 }, new int[] { })]
        [TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 1 })]
        public void RemoveLastTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveLastTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveLast());
        }

        [TestCase(new int[] { 2, 1, 1 }, new int[] { 1, 1 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        [TestCase(new int[] { -1, -1, -2, -1 }, new int[] { -1, -2, -1 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0 })]
        [TestCase(new int[] { 2 }, new int[] { })]
        [TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
        public void RemoveFirstTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveFirstTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirst());
        }

        [TestCase(3, new int[] { 1, 1, 1, 4 }, new int[] { 1, 1, 1 })]
        [TestCase(1, new int[] { 1, 2, 1 }, new int[] { 1, 1 })]
        [TestCase(2, new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        [TestCase(3, new int[] { -1, -1, -2, -1 }, new int[] { -1, -1, -2 })]
        [TestCase(0, new int[] { 0, 0, 0 }, new int[] { 0, 0 })]
        [TestCase(0, new int[] { 2 }, new int[] { })]
        [TestCase(0, new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
        public void RemoveOneByIndexTest(int index, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveOneByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 3, 4 })]
        public void RemoveOneByIndexTest_WhenIndexLargestLength_ShouldINullReferenceException(int index, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveOneByIndex(index));
        }

        [TestCase(-3, new int[] { 1, 3, 4 })]
        public void RemoveOneByIndexTest_WhenIndexLessThanZero_ShouldIndexOutOfRangeException(int index, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveOneByIndex(index));
        }

        [TestCase(3, new int[] { 1, 1, 1, 4 }, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 2, 1 }, new int[] { 1, 2 })]
        [TestCase(0, new int[] { 1 }, new int[] { 1 })]
        [TestCase(2, new int[] { -1, -2, -3 }, new int[] { -1 })]
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 0 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 1, 22, 33, 44 }, new int[] { 1, 22, 33 })]
        public void RemoveTheLastFewTest(int num, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveTheLastFew(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 1 })]
        public void RemoveTheLastFewTest_WhenNumLargestLength_ShouldNullReferenceException(int num, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveTheLastFew(num));
        }

        [TestCase(-3, new int[] { })]
        public void RemoveTheLastFewTest_WhenNumLessThanZero_ShouldArgumentException(int num, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveTheLastFew(num));
        }

        [TestCase(3, new int[] { 1, 1, 1, 4 }, new int[] { 4 })]
        [TestCase(1, new int[] { 1, 2, 1 }, new int[] { 2, 1 })]
        [TestCase(0, new int[] { 1 }, new int[] { 1 })]
        [TestCase(2, new int[] { -1, -2, -3 }, new int[] { -3 })]
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 0 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 3, 4, 5, 6 })]
        [TestCase(1, new int[] { 1, 22, 33, 44 }, new int[] { 22, 33, 44 })]
        public void RemoveFirstFewTest(int num, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveFirstFew(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { })]
        [TestCase(4, new int[] { 1, 2, 3 })]
        public void RemoveFirstFewTest_WhenNumLargestLength_ShouldNullReferenceException(int num, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirstFew(num));
        }

        [TestCase(-4, new int[] { 1, 2, 3 })]
        public void RemoveFirstFewTest_WhenNumLessThanZero_ShouldArgumentException(int num, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveFirstFew(num));
        }

        [TestCase(3, 1, new int[] { 1, 1, 1, 4 }, new int[] { 1, 1, 1 })]
        [TestCase(1, 2, new int[] { 1, 2, 1 }, new int[] { 1 })]
        [TestCase(0, 1, new int[] { 1 }, new int[] { })]
        [TestCase(0, 2, new int[] { -1, -2, -3 }, new int[] { -3 })]
        [TestCase(3, 2, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(4, 2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, 0, new int[] { 1, 22, 33, 44 }, new int[] { 1, 22, 33, 44 })]
        public void RemoveSeveralByIndexTest(int index, int num, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveSeveralByIndex(index, num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 1, new int[] { })]
        [TestCase(8, 3, new int[] { 1, 22, 33, 44 })]
        [TestCase(0, 66, new int[] { 2, 3, 4, 5, 6 })]
        public void RemoveSeveralByIndexTest_WhenNumPlusIndexLargestLength_ShouldNullReferenceException(int index, int num, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveSeveralByIndex(index, num));
        }

        [TestCase(-5, 1, new int[] { 2, 3, 4, 5, 6 })]
        public void RemoveSeveralByIndexTest_WhenIndexLessThanZero_ShouldIndexOutOfRangeException(int index, int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveSeveralByIndex(index, value));
        }

        [TestCase(5, -1, new int[] { 2, 3, 4, 5, 6 })]
        public void RemoveSeveralByIndexTest_WhenNumLessThanZero_ShouldArgumentException(int index, int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveSeveralByIndex(index, value));
        }

        [TestCase(3, 4, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 4, 0, 0 })]
        [TestCase(5, 6, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(3, 2, new int[] { 1, 22, 33, 44 }, new int[] { 1, 22, 33, 2 })]
        [TestCase(0, 3, new int[] { 1, 22, 33, 44 }, new int[] { 3, 22, 33, 44 })]
        public void ThisTest(int index, int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual[index] = value;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 3, 4, 5 }, 4)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetLengthTest(int[] arr, int expected)
        {
            DoubleLinkedList actualArr = new DoubleLinkedList(arr);
            int actual = actualArr.Lenght;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 1, 1, 3 }, 3)]
        [TestCase(2, new int[] { 1, 2, 1 }, 1)]
        [TestCase(2, new int[] { -1, -2, -3 }, -1)]
        [TestCase(0, new int[] { 0, 0, 0, 0, 0, 0 }, 0)]
        [TestCase(44, new int[] { 1, 22, 33, 44 }, 3)]
        public void GetFirstIndexByValueTest(int value, int[] array, int expected)
        {
            DoubleLinkedList a = new DoubleLinkedList(array);
            int actual = a.GetFirstIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(44, new int[] { })]
        public void GetFirstIndexByValueTest_WhenListEmpty_ShouldNullReferenceException(int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetFirstIndexByValue(value));
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { -1, -1, -2 }, new int[] { -2, -1, -1 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5, -6 }, new int[] { -6, -5, -4, -3, -2, -1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void ReversTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.Reverse());
        }

        [TestCase(new int[] { 1, 2, 5, 4, 3 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 22)]
        public void GetMaxElementTest(int[] array, int expected)
        {
            DoubleLinkedList a = new DoubleLinkedList(array);
            int actual = a.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 1, 4, 3 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 22)]
        public void GetMinElementTest(int[] array, int expected)
        {
            DoubleLinkedList a = new DoubleLinkedList(array);
            int actual = a.GetMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 1, 4, 3 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 0)]
        public void GetIndexOfMaxTest(int[] array, int expected)
        {
            DoubleLinkedList a = new DoubleLinkedList(array);
            int actual = a.GetIndexOfMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 1, 4, 3 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 0)]
        public void GetIndexOfMinTest(int[] array, int expected)
        {
            DoubleLinkedList a = new DoubleLinkedList(array);
            int actual = a.GetIndexOfMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(111, new int[] { 111, 1, 1 }, new int[] { 1, 1 })]
        [TestCase(-1, new int[] { -1, -1, -2 }, new int[] { -1, -2 })]
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 })]
        [TestCase(3, new int[] { 5, 2, 1, 4, 3 }, new int[] { 5, 2, 1, 4 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(22, new int[] { 22, 22, 22, 22, 22, 22 }, new int[] { 22, 22, 22, 22, 22 })]
        [TestCase(1, new int[] { 9, 4, 5, 7, 1 }, new int[] { 9, 4, 5, 7 })]
        public void RemoveFirstByValueTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.RemoveFirstByValue(value);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(222, new int[] { })]
        public void RemoveFirstByValueTest_WhenListEmpty_ShouldNullReferenceException(int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirstByValue(value));
        }

        [TestCase(111, new int[] { 111, 1, 1 }, 1, new int[] { 1, 1 })]
        [TestCase(-1, new int[] { -1, -1, -2 }, 2, new int[] { -2 })]
        [TestCase(2, new int[] { 0, 0, 0 }, 0, new int[] { 0, 0, 0 })]
        [TestCase(3, new int[] { 5, 2, 1, 4, 3 }, 1, new int[] { 5, 2, 1, 4 })]
        [TestCase(1, new int[] { 1 }, 1, new int[] { })]
        [TestCase(22, new int[] { 22, 22, 22, 22, 22, 22 }, 6, new int[] { })]
        [TestCase(1, new int[] { 1, 9, 1, 4, 1, 5, 1, 7, 1 }, 5, new int[] { 9, 4, 5, 7 })]
        public void RemoveAllByValue(int value, int[] array, int expected, int[] exp)
        {
            DoubleLinkedList a = new DoubleLinkedList(array);
            int actual = a.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
            DoubleLinkedList expect = new DoubleLinkedList(exp);
            Assert.AreEqual(expect, a);
        }

        [TestCase(222, new int[] { })]
        public void RemoveAllByValueTest_WhenListEmpty_ShouldNullReferenceException(int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.RemoveAllByValue(value));
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 0, 10, 21, 14 }, new int[] { }, new int[] { 0, 10, 21, 14 })]
        [TestCase(new int[] { }, new int[] { 0, 10, 21, 14 }, new int[] { 0, 10, 21, 14 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddDoubleLinkedListToEndTest(int[] act, int[] add, int[] exp)
        {
            DoubleLinkedList expected = new DoubleLinkedList(exp);
            DoubleLinkedList actual = new DoubleLinkedList(act);
            DoubleLinkedList AddToActual = new DoubleLinkedList(add);
            actual.AddDoubleLinkedListToEnd(AddToActual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 5, 6, 7, 8, 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 10, 21, 14 }, new int[] { }, new int[] { 0, 10, 21, 14 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(new int[] { }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        public void AddDoubleLinkedListToBeginningTest(int[] act, int[] add, int[] exp)
        {
            DoubleLinkedList expected = new DoubleLinkedList(exp);
            DoubleLinkedList actual = new DoubleLinkedList(act);
            DoubleLinkedList AddToActual = new DoubleLinkedList(add);
            actual.AddDoubleLinkedListToBeginning(AddToActual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 1, 2, 3, 4, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 4 })]
        [TestCase(2, new int[] { 0, 10, 21, 14 }, new int[] { }, new int[] { 0, 10, 21, 14 })]
        [TestCase(0, new int[] { }, new int[] { 0, 10, 21, 14 }, new int[] { 0, 10, 21, 14 })]
        [TestCase(3, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddDoubleLinkedListByIndexTest(int index, int[] act, int[] add, int[] exp)
        {
            DoubleLinkedList expected = new DoubleLinkedList(exp);
            DoubleLinkedList actual = new DoubleLinkedList(act);
            DoubleLinkedList AddToActual = new DoubleLinkedList(add);
            actual.AddDoubleLinkedListByIndex(index, AddToActual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 2, 3, 4 }, new int[] { 2, 3, 4 })]
        public void AddDoubleLinkedListByIndexTest_WhenIndexLessThanZero_ShouldIndexOutOfRangeException(int index, int[] act, int[] add)
        {
            DoubleLinkedList actual = new DoubleLinkedList(act);
            DoubleLinkedList addact = new DoubleLinkedList(add);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddDoubleLinkedListByIndex(index, addact));
        }

        [TestCase(5, new int[] { 2, 3, 4 }, new int[] { 2, 3, 4 })]
        public void AddDoubleLinkedListByIndexTest_WhenIndexMoreLength_ShouldIndexOutOfRangeException(int index, int[] act, int[] add)
        {
            DoubleLinkedList actual = new DoubleLinkedList(act);
            DoubleLinkedList addact = new DoubleLinkedList(add);
            Assert.Throws<NullReferenceException>(() => actual.AddDoubleLinkedListByIndex(index, addact));
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 2, 44, 4, 5, 6, 3 }, new int[] { 2, 3, 4, 5, 6, 44 })]
        [TestCase(new int[] { 11, 1, -1 }, new int[] { -1, 1, 11 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { -11, -1, -1 }, new int[] { -11, -1, -1 })]
        public void SortAscendingTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void SortAscendingTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.SortAscending());
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 44 }, new int[] { 44, 6, 5, 4, 3, 2 })]
        [TestCase(new int[] { -9, 1, 22 }, new int[] { 22, 1, -9 })]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { -11, -1, -1 }, new int[] { -1, -1, -11 })]
        public void SortDescendingTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void SortDescendingTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.SortDescending());
        }
    }
}
