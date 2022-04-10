namespace LinkedList
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node(int value)
        {

            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            Node newNode = Next;
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
