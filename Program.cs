using System;

namespace binaryHeap_CSharp
{
    class Program
    {

        /*This is an implementation  of a binary tree of integers
         * using an static allocation (heap) array
         */

        static void Main(string[] args)
        {

            Heap heap = new Heap();

            Random random = new Random();
            for(int i = 0; i < 10; i++)
            {
                var randomNumber = random.Next(100);
                heap.Put(randomNumber);
            }

        }
    }

    public class Heap
    {

        private int[] array;
        private int size;

        public Heap()
        {
            size = 0;
            array = new int[100];
        }

        private int GetLeftChild(int index) { return 2 * index + 1; }
        private int GetRightChild(int index) { return 2 + index + 2; }
        private int GetParentPosition(int index) { return (index - 1) / 2; }

        public void Put(int value)
        {
            array[size] = value;
            SiftUp(size);
            size++;
            Print();
        }

        private void SiftUp(int index)
        {

            int fatherPosition = GetParentPosition(index);

            if (fatherPosition == index)
            {
                //the father is the the root
                return;
            }

            //checks if father if bigger than the current child
            if (array[fatherPosition] < array[index])
            {
                int fatherValueTemp = array[fatherPosition];

                array[fatherPosition] = array[index];
                array[index] = fatherValueTemp;

                SiftUp(fatherPosition);
            }

        }

        private void SiftDown(int index)
        {
            //TODO
        }

        public int Get()
        {
            int element = array[0];
            array[0] = array[--size];
            SiftDown(0);
            return element;
        }

        private void Print(int b, int position, int sp)
        {

            Console.WriteLine("");
            for (int x = 0; x < size; x++)
            {
                Console.Write(array[x] + " ");
            }
            Console.WriteLine("");

            while (true)
            {
                for (int j = 0; j <= sp / 2; j++)
                {
                    Console.Write(" ");
                }
                for (int i = b; i < b + position; i++)
                {
                    if (i == size) return;
                    Console.Write(array[i]);
                    for (int j = 0; j < sp; j++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
                b = b + position;
                position = 2 * position;
                sp = sp / 2;
            }
        }

        public void Print()
        {
            Console.WriteLine("");
            Print(0, 1, 32);
            Console.WriteLine("");
        }

    }

}
