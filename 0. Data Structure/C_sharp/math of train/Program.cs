using System;

namespace math_of_train
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
        public string name;
        public Node head;
        public int topStack;
        public Stack(string name)
        {
            this.head = null;
            this.name = name;
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
                topStack = this.head.data;
            }
        }
        public Node Pop()
        {
            Node tempHead = null;
            if (this.head is null)
            {
                Console.WriteLine("Sorrry, this stack is empty");
            }
            else
            {
                tempHead = this.head;
                this.head = this.head.next;
                this.topStack = this.head == null ? 0 : this.head.data;
            }
            return tempHead;
        }
        public void printStack()
        {
            Console.Write("Stack is : ");
            Node temp = this.head;
            while (temp is not null)
            {
                Console.Write(temp.data.ToString() + " ");
                temp = temp.next;
            }
        }

    }

    class QueueNode
    {
        public int data;
        public QueueNode nextNode;
        public QueueNode previousNode;

        public QueueNode(int data)
        {
            this.data = data;
            this.nextNode = null;
            this.previousNode = null;
        }
    }
    class Queue
    {
        public QueueNode firstNode;
        public QueueNode lastNode;
        // public int maxQueue;
        public Queue()
        {
            this.firstNode = null;
            this.lastNode = null;
        }

        public void Enqueded(int value)
        {
            if (this.firstNode == null)
            {
                QueueNode queueNode = new QueueNode(value);
                this.firstNode = queueNode;
                this.lastNode = queueNode;
            }
            else
            {
                QueueNode queueNode = new QueueNode(value);
                QueueNode temp = this.lastNode;
                temp.previousNode = queueNode;
                queueNode.nextNode = temp;
                this.lastNode = queueNode;
                // this.maxQueue = value;                
            }
        }

        public QueueNode Dequeded()
        {
            if (this.firstNode == null)
            {
                return null;
            }
            else
            {
                QueueNode temp = this.firstNode;
                this.firstNode = this.firstNode.previousNode;
                // this.maxQueue = this.firstNode.nextNode.data;
                return temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number of train");
            int n = 5;
            Stack trainStach = new Stack("Source Train");
            for (int i = n; i > 0; i--)
            {
                trainStach.Push(i);
            }

            Stack middleStack = new Stack("Temp stack Train");

            int[] userinput_result = new int[] { 2, 3, 1, 5, 4 };

            Queue queue_result = new Queue();
            for (int i = 1; i <= n; i++)
            {
                queue_result.Enqueded(userinput_result[i - 1]);
            }


            QueueNode tempResult = queue_result.Dequeded();
            while (tempResult is not null)
            {
                int minStackTrain = trainStach.topStack;
                int maxMiddileStackTrain = middleStack.topStack;
                int current_train_result = tempResult.data;

                if (current_train_result > maxMiddileStackTrain)
                {
                    moveTrain(current_train_result, trainStach, middleStack);
                    moveTrain(current_train_result, middleStack, null);
                }
                else
                {
                    if (current_train_result != middleStack.topStack)
                    {
                        Console.WriteLine("Can move");
                        break;
                    }
                    else
                    {
                        moveTrain(current_train_result, middleStack, null);
                    }
                }
                tempResult = queue_result.Dequeded();
            }

        }

        static void moveTrain(int value, Stack sourceTrain, Stack destination)
        {
            Node tempTrain = sourceTrain.head;
            while (tempTrain is not null)
            {
                if (destination is not null)
                {
                    destination.Push(tempTrain.data);
                    Console.WriteLine("Move train " + tempTrain.data.ToString()
                                                + " from " + sourceTrain.name + " to " + destination?.name);
                    sourceTrain.Pop();
                    if (tempTrain.data == value)
                    {
                        break;
                    }
                }
                else
                // if the first value matching with the top of middle stack then we move this train to destination station
                {
                    if (tempTrain.data == value)
                    {
                        sourceTrain.Pop();
                        Console.WriteLine("Move train " + tempTrain.data.ToString()
                                                + " from " + sourceTrain.name + " to final stack train");
                        break;
                    }
                }
                tempTrain = tempTrain.next;
            }
        }
    }
}
