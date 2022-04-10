namespace DoubleLinkedLists
{
    class Dnode
    {
        public int Value { get; set; }
        public Dnode Next { get; set; }
        public Dnode Previous { get; set; }

        public Dnode(int value)
        {

            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            Dnode newNode = Next;
            string result = "";
            result += Value + "";
            while (newNode != null)
            {
                result += newNode.Value + "";
                newNode = newNode.Next;
            }
            return result;
        }
    }
}
