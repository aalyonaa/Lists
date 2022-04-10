using System;

namespace DoubleLinkedLists
{
    public class DoubleLinkedList
    {
        private Dnode _root;
        private Dnode _tail;
        public int Lenght
        {
            get
            {
                int s = 0;
                if (_root != null)
                {
                    Dnode tmp = _root;
                    s++;
                    while (tmp.Next != null)
                    {
                        tmp = tmp.Next;
                        s++;
                    }
                }
                return s;
            }
            set
            {

            }
        }

        #region конструкторы

        /// <summary>
        /// пустой конструктор
        /// </summary>
        public DoubleLinkedList()
        {
            _root = null;
            _tail = null;
            Lenght = 0;
        }

        /// <summary>
        /// конструктоp на основе одного элемента
        /// </summary>
        /// <param name="value"></param>
        public DoubleLinkedList(int value)
        {
            _root = new Dnode(value);
            _tail = _root;
            Lenght = 1;
        }

        /// <summary>
        /// конструктор на основе массива
        /// </summary>
        /// <param name="array"></param>
        public DoubleLinkedList(int[] array)
        {
            if (array.Length == 0)
            {
                _root = null;
                _tail = null;
                return;
            }
            Dnode tmp = new Dnode(array[0]);
            _root = tmp;
            _tail = tmp;
            for (int i = 1; i < array.Length; i++)
            {
                tmp.Next = new Dnode(array[i]);
                _tail = tmp.Next;
                tmp.Next.Previous = tmp;
                tmp = tmp.Next;
            }

        }

        #endregion

        #region для конкректных элементов

        /// <summary>
        /// 11. Доступ к элементу по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Lenght)
                {
                    throw new IndexOutOfRangeException();
                }
                Dnode tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                Dnode tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        /// <summary>
        /// 1. добавление в конец
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            if (_root != null)
            {
                _tail.Next = new Dnode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }
            else
            {
                _root = new Dnode(value);
                _tail = _root;
            }
        }

        /// <summary>
        /// 2. добавление в начало
        /// </summary>       
        public void AddFirst(int value)
        {
            if (_root != null)
            {
                Dnode tmp = new Dnode(value);
                tmp.Next = _root;
                _root.Previous = tmp;
                _root = tmp;
            }
            else
            {
                _root = new Dnode(value);
                _tail = _root;
            }
        }

        /// <summary>
        /// 3. добавление по индексу
        /// </summary>
        public void Insert(int index, int value)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > Lenght)
            {
                throw new NullReferenceException();
            }
            Dnode tmp = Start(index);
            AddNode(tmp, value, index);
        }

        /// <summary>
        /// 4. Удаление одного элемента с конца
        /// </summary>
        public void RemoveLast()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            if (_root.Next == null)
            {
                _root = null;
                _tail = null;
            }
            else
            {
                _tail.Previous.Next = null;
                _tail = _tail.Previous;
            }
        }

        /// <summary>
        /// 5. Удаление одного с начала
        /// </summary>
        public void RemoveFirst()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            if (_root.Next == null)
            {
                _root = null;
                _tail = null;
            }
            else
            {
                Dnode tmp = _root;
                _root = tmp.Next;
                _root.Previous = null;
                Lenght--;
            }


        }

        /// <summary>
        /// 6. Удаление одного по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveOneByIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index >= Lenght)
            {
                throw new NullReferenceException();
            }


            Dnode tmp = Start(index);

            DeleteNode(tmp);
            Lenght--;

        }

        /// <summary>
        /// 7. Удаление из конца N элементов
        /// </summary>
        /// <param name="num"></param>     
        public void RemoveTheLastFew(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException();
            }
            if (_root == null || (num > Lenght))
            {
                throw new NullReferenceException();
            }
            if (num == Lenght)
            {
                _root = null;
                _tail = null;
            }
            else
            {
                Dnode tmp = _tail;
                for (int i = 1; i <= num; i++)
                {
                    tmp = tmp.Previous;
                    tmp.Next = null;
                    Lenght--;
                }
                _tail = tmp;
            }
            Lenght -= num;
        }

        /// <summary>
        /// 8. Удаление из начала N элементов
        /// </summary>
        /// <param name="num"></param>
        public void RemoveFirstFew(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException();
            }
            if (_root == null || num > Lenght)
            {
                throw new NullReferenceException();
            }
            if (num == 0)
            {
                return;
            }
            if (_root.Next == null && num == 1)
            {
                _root = null;
                return;
            }
            else
            {
                Dnode tmp = _root;
                for (int i = 1; i < num; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next.Previous = null;
                _root = tmp.Next;
            }
            Lenght -= num;
        }

        /// <summary>
        /// 9. Удаление по индексу N элементов
        /// </summary>
        /// <param name="index"></param>
        /// <param name="num"></param>
        public void RemoveSeveralByIndex(int index, int num)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root == null || num + index > Lenght)
            {
                throw new NullReferenceException();
            }
            if (num < 0)
            {
                throw new ArgumentException();
            }
            Dnode tmp = Start(index);
            for (int i = 0; i < num; i++)
            {
                DeleteNode(tmp);
                tmp = tmp.Next;
            }
            Lenght -= num;

        }

        /// <summary>
        /// 12. Первый индекс по значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>     
        public int GetFirstIndexByValue(int value)
        {
            if (_root != null)
            {
                Dnode tmp = _root;
                int s = 0;
                while (tmp != null)
                {
                    if (tmp.Value == value)
                    {
                        return s;
                    }

                    tmp = tmp.Next;
                    s++;
                }
                return -1;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        #endregion

        #region для всех элементов    

        /// <summary>
        /// 14. Реверс
        /// </summary> 
        public void Reverse()
        {
            if (_root != null)
            {
                Dnode tmpNode = _root;
                Dnode prevNode = null;
                Dnode nextNode;

                while (tmpNode != null)
                {
                    nextNode = tmpNode.Next;
                    prevNode = tmpNode.Previous;
                    tmpNode.Next = prevNode;
                    tmpNode.Previous = nextNode;
                    prevNode = tmpNode;
                    tmpNode = nextNode;
                }
                _tail = _root;
                _root = prevNode;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        ///15. Поиск максимального элеменета
        /// </summary>
        /// <returns></returns>
        public int GetMaxElement()
        {
            if (_root == null)
            {
                throw new NullReferenceException();

            }
            Dnode tmpn = _root;
            Dnode tmpp = _tail;
            int maxn = _root.Value;
            int maxp = _tail.Value;
            int max = 0;
            for (int i = 1; i <= Lenght / 2; i++)
            {
                tmpn = tmpn.Next;
                if (maxn < tmpn.Value)
                {
                    maxn = tmpn.Value;
                }
                tmpp = tmpp.Previous;
                if (maxp < tmpp.Value)
                {
                    maxp = tmpp.Value;
                }
            }
            if (maxn > maxp)
            {
                max = maxn;
            }
            else
            {
                max = maxp;
            }
            return max;
        }

        /// <summary>
        /// 16. Поиск минимального элемента
        /// </summary>
        /// <returns></returns>       
        public int GetMinElement()
        {
            if (_root == null)
            {
                throw new NullReferenceException();

            }

            Dnode tmpn = _root;
            Dnode tmpp = _tail;
            int minn = _root.Value;
            int minp = _tail.Value;
            int min = 0;
            for (int i = 1; i <= Lenght / 2; i++)
            {
                tmpn = tmpn.Next;
                if (minn > tmpn.Value)
                {
                    minn = tmpn.Value;
                }
                tmpp = tmpp.Previous;
                if (minp > tmpn.Value)
                {
                    minp = tmpn.Value;
                }
            }
            if (minn < minp)
            {
                min = minn;
            }
            else
            {
                min = minp;
            }
            return min;
        }

        /// <summary>
        /// 17. Индекс максимального элемента
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMax()
        {
            //return GetFirstIndexByValue(GetMaxElement()); не оптимально, но работает
            if (_root == null)
            {
                throw new NullReferenceException();

            }
            Dnode tmpn = _root;
            Dnode tmpp = _tail;
            int maxn = _root.Value;
            int maxp = _tail.Value;
            int maxIndexn = 0;
            int maxIndexp = Lenght - 1;
            int maxIndex = 0;
            int indexn = 0;
            int indexp = 0;
            if (_root.Next != null)
            {
                for (int i = 0; i <= Lenght / 2; i++)
                {
                    tmpn = tmpn.Next;
                    if (maxn < tmpn.Value)
                    {
                        maxn = tmpn.Value;
                        maxIndexn = indexn;
                    }
                    indexn++;
                    tmpp = tmpp.Previous;
                    if (maxp < tmpp.Value)
                    {
                        maxp = tmpp.Value;
                        maxIndexp = indexp;
                    }
                    indexp--;
                }
                if (maxn > maxp || maxn == maxp)
                {
                    maxIndex = maxIndexn;
                }
                else
                {
                    maxIndex = maxIndexp;
                }
            }
            else
            {
                maxIndex = 0;
            }
            return maxIndex;
        }

        /// <summary>
        /// 18. Индекс минимального элемента
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMin()
        {
            //return GetFirstIndexByValue(GetMinElement()); не оптимально, но работает
            if (_root == null)
            {
                throw new NullReferenceException();

            }
            Dnode tmpn = _root;
            Dnode tmpp = _tail;
            int minn = _root.Value;
            int minp = _tail.Value;
            int minIndexn = 0;
            int minIndexp = Lenght - 1;
            int minIndex = 0;
            int indexn = 0;
            int indexp = 0;
            if (_root.Next != null)
            {
                for (int i = 0; i <= Lenght / 2; i++)
                {
                    tmpn = tmpn.Next;
                    indexn++;
                    if (minn > tmpn.Value)
                    {
                        minn = tmpn.Value;
                        minIndexn = indexn;
                    }
                    tmpp = tmpp.Previous;
                    indexp--;
                    if (minp > tmpp.Value)
                    {
                        minp = tmpp.Value;
                        minIndexp = indexp;
                    }
                }
                if (minn > minp || minn == minp)
                {
                    minIndex = minIndexn;
                }
                else
                {
                    minIndex = minIndexp;
                }
            }
            else
            {
                minIndex = 0;
            }
            return minIndex;
        }

        /// <summary>
        /// 19. Сортировка по возрастанию
        /// </summary>
        public void SortAscending()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Dnode tmpRoot = new Dnode(GetMinElement());
            RemoveFirstByValue(tmpRoot.Value);
            while (_root.Next != null)
            {
                tmpRoot.Next = new Dnode(GetMinElement());
                tmpRoot.Next.Previous = tmpRoot;
                RemoveFirstByValue(GetMinElement());
                tmpRoot = tmpRoot.Next;
            }
            tmpRoot.Next = new Dnode(GetMinElement());
            tmpRoot.Next.Previous = tmpRoot;
            RemoveFirstByValue(GetMinElement());

        }

        /// <summary>
        /// 20. Сортировка по убыванию
        /// </summary>
        public void SortDescending()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Dnode tmpRoot = new Dnode(GetMaxElement());
            RemoveFirstByValue(tmpRoot.Value);
            while (_root.Next != null)
            {
                tmpRoot.Next = new Dnode(GetMaxElement());
                tmpRoot.Next.Previous = tmpRoot;
                RemoveFirstByValue(GetMaxElement());
                tmpRoot = tmpRoot.Next;
            }
            tmpRoot.Next = new Dnode(GetMaxElement());
            tmpRoot.Next.Previous = tmpRoot;
            RemoveFirstByValue(GetMaxElement());

        }

        /// <summary>
        /// 21. Удаление первого элемента по значению
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="NullReferenceException"></exception>
        public void RemoveFirstByValue(int value)
        {
            if (_root != null)
            {
                Dnode tmp = _root;

                if (_root.Value != value)
                {
                    while (tmp.Next != null)
                    {
                        if (tmp.Next.Value == value)
                        {
                            DeleteNode(tmp.Next);
                            return;
                        }
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    _root = tmp.Next;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// 22. Удаление всех элементов по значению, возврат кол-ва
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveAllByValue(int value)
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            int num = 0;
            Dnode tmpn = _root;
            Dnode tmpp = _tail;
            int a = Lenght;
            for (int i = 0; i <= a / 2; i++)
            {
                if (tmpp != null)
                {
                    if ((tmpn == tmpp)
                    && (tmpn.Value == value))
                    {
                        DeleteNode(tmpn);
                        return ++num;
                    }
                    if (tmpn.Value == value)
                    {
                        num++;
                        if (tmpn == _root) // можно делать без этого? Иначе он не пониманиет, что это рут
                        {
                            DeleteNode(_root);
                        }
                        else
                        {
                            DeleteNode(tmpn);
                        }
                    }
                }
                tmpn = tmpn.Next;
                if (tmpn != null)
                {
                    if (tmpp.Value == value)
                    {
                        num++;
                        if (tmpp == _tail) // можно делать без этого? Иначе он не пониманиет, что это тейл
                        {
                            DeleteNode(_tail);
                        }
                        else
                        {
                            DeleteNode(tmpp);
                        }
                    }
                    tmpp = tmpp.Previous;
                }
            }

            return num;
        }

        #endregion

        #region листы

        /// <summary>
        /// 24. Добавление списка в конец
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddDoubleLinkedListToEnd(DoubleLinkedList DoubleLinkedList)
        {
            Dnode node = DoubleLinkedList._root;
            while (node != null)
            {
                Add(node.Value);
                node = node.Next;
            }
        }

        /// <summary>
        /// 25. Добавление списка в начало
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddDoubleLinkedListToBeginning(DoubleLinkedList DoubleLinkedList)
        {
            Dnode node = DoubleLinkedList._tail;
            while (node != null)
            {
                AddFirst(node.Value);
                node = node.Previous;
            }
        }

        /// <summary>
        /// 26. Добавление списка по индексу
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="index"></param>
        public void AddDoubleLinkedListByIndex(int index, DoubleLinkedList LinkedList)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > Lenght)
            {
                throw new NullReferenceException();
            }
            if (LinkedList._root != null && _root != null)
            {
                Dnode tmp = Start(index);
                tmp.Previous.Next = LinkedList._root;
                LinkedList._tail.Next = tmp;
            }
            if (_root == null)
            {
                _root = LinkedList._root;
            }
        }

        #endregion

        #region приватные

        private Dnode Start(int index)
        {
            bool IsIndexLeft = index < Lenght / 2;
            Dnode tmp;
            int numOfStep;
            if (IsIndexLeft)
            {
                tmp = _root;
                numOfStep = index;
            }
            else
            {
                tmp = _tail;
                numOfStep = Lenght - index;
            }
            for (int i = 1; i < numOfStep; i++)
            {
                tmp = IsIndexLeft ? tmp.Next : tmp.Previous;
            }
            return tmp;
        }

        private void DeleteNode(Dnode tmp)
        {
            if (tmp != _root && tmp != _tail)
            {
                tmp.Previous.Next = tmp.Next;
                tmp.Next.Previous = tmp.Previous;
            }
            else if (tmp == _root && tmp == _tail)
            {
                _tail = null;
                _root = null;
            }
            else if (tmp == _root)
            {
                tmp.Next.Previous = null;
                _root = tmp.Next;
            }
            else
            {
                tmp.Previous.Next = null;
                _tail = tmp.Previous;
            }
        }

        private void AddNode(Dnode tmp, int value, int index)
        {
            Dnode node = new Dnode(value);
            if (tmp != _root && tmp != _tail)
            {
                tmp.Previous.Next = node;
                node.Next = tmp;
                node.Previous = tmp.Previous;
            }
            else if (tmp == _root && tmp == _tail)
            {
                if (index == 0)
                {
                    _root = node;
                    _root.Next = _tail;
                }
                if (index == 1)
                {
                    _tail = node;
                    _root.Next = node;
                }
            }
            else if (tmp == _root)
            {
                node.Next = _root;
                _root.Previous = node;
                _root = node;
            }
            else
            {
                if (index == Lenght)
                {
                    node.Previous = _tail;
                    _tail.Next = node;
                    _tail = node;
                }
                else //(index == Lenght - 1)
                {
                    node.Next = _tail;
                    _tail.Previous.Next = node;
                    node.Previous = _tail.Previous;
                }
            }
        }

        #endregion

        #region override

        public void WriteToConsole()
        {
            if (_root == null)
            {
                Console.WriteLine();
            }
            Dnode node = _root;
            string result = "";
            while (node != null)
            {
                result += node.Value + " ";
                node = node.Next;
            }
            Console.WriteLine($"{result}");
        }

        public override string ToString()
        {
            string result = "";
            if (_root == null)
            {
                return result;
            }
            Dnode newNode = _root;
            while (newNode != null)
            {
                result += newNode.Value + " ";
                newNode = newNode.Next;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList newDnode = (DoubleLinkedList)obj;
            Dnode tmp1 = _root;
            Dnode tmp2 = newDnode._root;
            if (tmp1 == null && tmp2 == null)
            {
                return true;
            }
            while (tmp1 != null && tmp2 != null)
            {

                if ((tmp1.Next == null && tmp2.Next != null)
                || (tmp1.Next != null && tmp2.Next == null))
                {
                    return false;
                }
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
            //return base.GetHashCode();
        }

        #endregion
    }
}