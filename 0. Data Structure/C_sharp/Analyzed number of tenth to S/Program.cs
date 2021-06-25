using System;

namespace C_sharp
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int n)
        {
            data = n;
            next = null;
        }
    }
    class Stack
    {
        public Node head;
        public Stack()
        {
            this.head = null;
        }

        public void Push(int value)
        {
            if (this.head is null)
            {
                this.head = new Node(value);
            }
            else
            {
                Node temp = this.head;
                this.head = new Node(value);
                this.head.next = temp;
            }
        }
        public void Pop()
        {
            if (this.head is null)
            {
                Console.WriteLine("Sorrry, this stack is empty");
            }
            else
            {
                this.head = this.head.next;
            }
        }
        public void printStack()
        {
            Console.Write("Stack is : ");
            Node temp = this.head;
            while (temp is not null)
            {
                Console.Write(convertNumber(temp.data) + " ");
                temp = temp.next;
            }
        }

        private string convertNumber(int n)
        {
            string[] output = new string[] { "A", "B", "C", "D", "E", "F" };
            if (n >= 10)
            {
                n = n % 10;
                return output[n];
            }
            else
            {
                return n.ToString();   
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chuyen doi so co so 10 sang co so S");
            Console.Write("Nhap so he 10: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Nhap so he so S muon doi: ");
            int s = int.Parse(Console.ReadLine());

            Stack stack = convertNumber(n, s);
            stack.printStack();
        }

        static Stack convertNumber(int n, int s)
        {
            Stack stack = new Stack();
            int divisionResult = n;
            do
            {
                int remainder = divisionResult % s;
                stack.Push(remainder);
                divisionResult /= s;
                Console.WriteLine(remainder);
            } while (divisionResult != 0);

            return stack;
        }
    }
}
