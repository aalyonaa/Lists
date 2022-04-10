using System;

namespace ArrayLists
{
    public class ArrayList
    {
        public int Lenght { get; private set; }
        private const int _minArrayLenght = 10;
        private int[] _array;

        /// <summary>
        /// 11. Доступ к элементу массива по индексу
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
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        #region конструкторы

        /// <summary>
        /// 23. Пустой конструктор
        /// </summary>
        public ArrayList()
        {
            Lenght = 0;
            _array = new int[_minArrayLenght];
        }

        /// <summary>
        /// 23. Конструктор на основе одного элемента
        /// </summary>
        /// <param name="element"></param>
        public ArrayList(int element)
        {
            Lenght = 1;
            _array = new int[_minArrayLenght];
            _array[0] = element;
        }

        /// <summary>
        /// 23. Конструктор на основе листа
        /// </summary>
        /// <param name="arrayList"></param>
        public ArrayList(ArrayList arrayList)
        {
            Lenght = arrayList.Lenght;
            if (arrayList.Lenght > _minArrayLenght)
            {
                _array = new int[(int)(arrayList.Lenght * 1.5)];
            }
            else
            {
                _array = new int[_minArrayLenght];
            }

            for (int i = 0; i < arrayList.Lenght; i++)
            {
                _array[i] = arrayList[i];
            }
        }

        /// <summary>
        /// 23. Конструктор на основе массива
        /// </summary>
        /// <param name="arr"></param>
        public ArrayList(int[] arr)
        {
            Lenght = arr.Length;
            if (arr.Length > _minArrayLenght)
            {
                _array = new int[(int)(arr.Length * 1.5)];
            }
            else
            {
                _array = new int[_minArrayLenght];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }
        }

        #endregion

        #region для конкретных элементов

        /// <summary>
        ///  1. добавление в конец
        /// </summary>
        public void Add(int value)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        /// <summary>
        /// 2. добавление в начало
        /// </summary>
        public void AddToBegin(int value)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }
            ShiftRight(Lenght - 1, 0);
            Lenght++;
            _array[0] = value;
        }

        /// <summary>
        /// 3. добавление по индексу
        /// </summary>
        public void Insert(int index, int value)
        {
            if (index > Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }

            ShiftRight(Lenght - 1, index);
            _array[index] = value;
            Lenght++;
        }

        /// <summary>
        /// 4. Удаление одного элемента с конца
        /// </summary>
        public void RemoveLast()
        {
            if (Lenght == 0)
            {
                throw new Exception();
            }
            else
            {
                Lenght -= 1;
            }
        }

        /// <summary>
        /// 5. Удаление одного с начала
        /// </summary>
        public void RemoveFirst()
        {
            ShiftLeft(1, Lenght);
            --Lenght;
        }

        /// <summary>
        /// 6. Удаление одного по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveOneByIndex(int index)
        {
            if (index >= Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            ShiftLeft(++index, Lenght);
            Lenght -= 1;
        }

        /// <summary>
        /// 7. Удаление из конца N элементов
        /// </summary>
        /// <param name="num"></param>
        ///       
        public void RemoveSeveralLast(int num)
        {
            if (num >= Lenght)
            {
                throw new IndexOutOfRangeException();

            }
            Lenght -= num;
        }

        /// <summary>
        /// 8. Удаление из начала N элементов
        /// </summary>
        /// <param name="num"></param>
        public void RemoveSeveralBegin(int num)
        {
            if (num >= Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = num; i > 0; i--)
            {
                ShiftLeft(i, Lenght);
                Lenght--;
            }
        }

        /// <summary>
        /// 9. Удаление по индексу N элементов
        /// </summary>
        /// <param name="index"></param>
        /// <param name="num"></param>
        public void RemoveSeveralByIndex(int index, int num)
        {
            if (index + num - 1 == index || (index + num >= Lenght))
            {
                throw new Exception();
            }
            for (int i = num + index - 1; i >= index; i--)
            {
                ShiftLeft(i, Lenght);
                Lenght--;
            }
        }

        /// <summary>
        /// 12. Первый индекс по значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>     
        public int GetFirstIndexByValue(int value)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region для всех элементов

        /// <summary>
        /// 14. Реверс
        /// </summary>
        public void Reverse()
        {
            for (int i = 0; i < Lenght / 2; i++)
            {
                int tmp = _array[i];
                _array[i] = _array[Lenght - i - 1];
                _array[Lenght - i - 1] = tmp;
            }
        }

        /// <summary>
        /// 15. Поиск максимального элеменета
        /// </summary>
        /// <returns></returns>
        public int GetMaxElement()
        {
            int max = _array[0];

            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        /// <summary>
        /// 16. Поиск минимального элемента
        /// </summary>
        /// <returns></returns>       
        public int GetMinElement()
        {
            int min = _array[0];

            for (int i = 1; i < Lenght - 1; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        /// <summary>
        /// 17. Индекс максимального элемента
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMax()
        {
            int max = _array[0];
            int maxIndex = 0;

            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// 18. Индекс минимального элемента
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMin()
        {
            int min = _array[0];
            int minIndex = 0;

            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        /// <summary>
        /// 19. Сортировка по возрастанию
        /// </summary>
        public void SortAscending()
        {
            for (int i = 0; i < Lenght; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < Lenght; j++)
                {
                    if (_array[j] < _array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[minIndex];
                _array[minIndex] = tmp;
            }
        }

        /// <summary>
        /// 20. Сортировка по убыванию
        /// </summary>
        public void SortDescending()
        {
            for (int i = 0; i < Lenght; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < Lenght; j++)
                {
                    if (_array[j] > _array[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[maxIndex];
                _array[maxIndex] = tmp;
            }
        }

        /// <summary>
        /// 21. Удаление первого элемента по значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveFirstByValue(int value)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    int traffic = i + 1;
                    ShiftLeft(traffic, Lenght);
                    Lenght--;
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 22. Удаление всех элементов по значению, возврат кол-ва
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveAllByValue(int value)
        {
            int num = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    int traffic = i + 1;
                    ShiftLeft(traffic, Lenght);
                    i--;
                    Lenght--;
                    num++;
                }

            }
            return num;
        }

        #endregion

        #region списки

        /// <summary>
        /// 24. Добавление списка в конец
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddArrayListToEnd(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Lenght; i++)
            {
                Add(arrayList[i]);
            }
        }

        /// <summary>
        /// 25. Добавление списка в начало
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddArrayListToBeginning(ArrayList arrayList)
        {
            int i = 0;
            while (arrayList.Lenght > i)
            {
                Insert(i, arrayList[i]);
                i++;
            }

            //for (int i = 0; i < arrayList.Lenght; i++)
            //{
            //    Lenght++;
            //    ShiftRight(i, Lenght);
            //    _array[i] = arrayList[i];
            //}
        }

        /// <summary>
        /// 26. Добавление списка по индексу
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="index"></param>
        public void AddArrayListByIndex(int index, ArrayList arrayList)
        {
            for (int i = index; i < arrayList.Lenght + index; i++)
            {
                ShiftRight(Lenght - 1, i + 1);
                _array[i + 1] = arrayList[i - index];
                Lenght++;
            }
        }

        #endregion

        #region приватные

        /// <summary>
        /// Смещение вправо
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        private void ShiftRight(int end, int start)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }
            for (int i = end; i >= start; i--)
            {
                _array[i + 1] = _array[i];

            }
        }

        /// <summary>
        /// Смещение влево
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        private void ShiftLeft(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                _array[i - 1] = _array[i];
            }
        }

        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        public void WriteToConsole()
        {
            for (int i = 0; i < Lenght; i++)
            {
                Console.Write($"{_array[i]} ");
            }
        }

        /// <summary>
        /// Увеличение массива в 1,5 раза
        /// </summary>
        private void UpArraySize()
        {
            int[] tmpArray = new int[(int)(Lenght * 1.5)];
            for (int i = 0; i < Lenght; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        #endregion

        #region override
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }

            for (int i = 0; i < Lenght; i++)
            {
                if (arrayList._array[i] != _array[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Lenght; i++)
            {
                s += $"{_array[i]} ";
            }
            return s;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
            //return base.GetHashCode();
        }

        #endregion
    }
}

