using NUnit.Framework;
using System;

namespace ArrayLists.Tests
{

    public class Tests
    {

        [Test]
        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(-1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, -1 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(-1, new int[] { 1, 1, 1 }, new int[] { -1, 1, 1, 1 })]
        public void AddToBeginTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddToBegin(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, new int[] { 1, 1, 1 }, new int[] { 1, 2, 1, 1 })]
        [TestCase(0, 1, new int[] { }, new int[] { 1 })]
        [TestCase(3, -1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, -1 })]
        public void InsertTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.Insert(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, -1, new int[] { 1, 1 })]
        public void InsertTest_WhenIndexLargestLength_ShouldIndexOutOfRangeException(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }

        [TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 1 })]
        public void RemoveLastTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 1 }, new int[] { 1, 1 })]
        public void RemoveFirstTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 1, 1, 4 }, new int[] { 1, 1, 1 })]
        public void RemoveOneByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveOneByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 3, 4 })]
        public void RemoveOneByIndexTest_WhenIndexLargestLength_ShouldIndexOutOfRangeException(int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveOneByIndex(index));
        }

        [TestCase(3, new int[] { 1, 1, 1, 4 }, new int[] { 1 })]
        public void RemoveSeveralLastNumTest(int num, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveSeveralLast(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 1 })]
        public void RemoveSeveralLastNumTest_WhenIndexLargestLength_ShouldIndexOutOfRangeException(int num, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveSeveralLast(num));
        }

        [TestCase(2, new int[] { 1, 1, 1 }, new int[] { 1 })]
        [TestCase(1, new int[] { 2, 3, 4, 5, 6 }, new int[] { 3, 4, 5, 6 })]
        [TestCase(0, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        public void RemoveSeveralBeginTest(int num, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveSeveralBegin(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { })]
        public void RemoveSeveralBeginningTest_WhenIndexLargestLength_ShouldIndexOutOfRangeException(int num, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveSeveralBegin(num));
        }

        [TestCase(2, 2, new int[] { 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(1, 0, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        public void RemoveSeveralByIndexTest(int index, int num, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveSeveralByIndex(index, num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 1, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(0, 1, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(2, 1, new int[] { 1, 1, 1 })]
        public void RemoveSeveralByIndexTest_WhenIndexLargestLength_ShouldException(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.RemoveSeveralByIndex(index, value));
        }

        [TestCase(1, new int[] { 1, 1, 1 }, 0)]
        [TestCase(5, new int[] { 2, 3, 4, 5, 6 }, 3)]
        [TestCase(0, new int[] { 1, 1, 1 }, -1)]
        public void GetFirstIndexByValueTest(int value, int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetFirstIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 5, 4, 3 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 22)]
        public void GetMaxElementTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 1, 4, 3 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 22)]
        public void GetMinElementTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 1, 4, 3 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 0)]
        public void GetIndexOfMaxTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetIndexOfMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 2, 1, 4, 3 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 22, 22, 22, 22, 22, 22 }, 0)]
        public void GetIndexOfMinTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetIndexOfMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 2, 44, 4, 5, 6, 3 }, new int[] { 2, 3, 4, 5, 6, 44 })]
        [TestCase(new int[] { 11, 1, -1 }, new int[] { -1, 1, 11 })]
        public void SortAscendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 44 }, new int[] { 44, 6, 5, 4, 3, 2 })]
        [TestCase(new int[] { -9, 1, 22 }, new int[] { 22, 1, -9 })]
        public void SortDescendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        [TestCase(4, new int[] { 2, 3, 4, 5, 6, 5 }, new int[] { 2, 3, 5, 6, 5 })]
        [TestCase(8, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        public void RemoveFirstByValueTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirstByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 1, 1 }, 3)]
        [TestCase(5, new int[] { 2, 3, 4, 5, 6, 5 }, 2)]
        [TestCase(8, new int[] { 1, 1, 1 }, 0)]
        public void RemoveAllByValue(int value, int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 0, 10, 21, 14 }, new int[] { }, new int[] { 0, 10, 21, 14 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddArrayListToEndTest(int[] act, int[] add, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(act);
            ArrayList AddToActual = new ArrayList(add);
            actual.AddArrayListToEnd(AddToActual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 5, 6, 7, 8, 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 10, 21, 14 }, new int[] { }, new int[] { 0, 10, 21, 14 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddArrayListToBeginningTest(int[] act, int[] add, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(act);
            ArrayList AddToActual = new ArrayList(add);
            actual.AddArrayListToBeginning(AddToActual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 1, 2, 3, 4, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 8, })]
        [TestCase(2, new int[] { 0, 10, 21, 14 }, new int[] { }, new int[] { 0, 10, 21, 14 })]
        [TestCase(3, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void AddArrayListByIndexTest(int index, int[] act, int[] add, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(act);
            ArrayList AddToActual = new ArrayList(add);
            actual.AddArrayListByIndex(index, AddToActual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, new int[] { 5, 6, 7, 8, 1, 2, 3, 4 }, new int[] { 5, 6, 7, 3, 1, 2, 3, 4 })]
        [TestCase(3, 3, new int[] { 0, 10, 21, 14 }, new int[] { 0, 10, 21, 3 })]
        [TestCase(0, 0, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 1, 1, 1, 1, 1, 1, 1 })]
        public void ThisTest(int index, int value, int[] act, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(act);
            actual[index] = value;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 6, 7, 8, 1, 2, 3, 4 }, 8)]
        [TestCase(new int[] { 0, 10, 21, 14 }, 4)]
        [TestCase(new int[] { }, 0)]
        public void LenghtTest(int[] act, int expected)
        {
            ArrayList actualList = new ArrayList(act);
            int actual = actualList.Lenght;
            Assert.AreEqual(expected, actual);
        }

    }
}