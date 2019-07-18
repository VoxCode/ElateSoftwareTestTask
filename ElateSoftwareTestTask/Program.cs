using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElateSoftwareTestTask
{
    class Program
    {
        static void Main()
        {
            try
            {
                MyStack<string> stack = new MyStack<string>();
                stack.Push("Bob");
                stack.Push("John");
                stack.Push("Tom");
                stack.Push("Jack");              

                var head = stack.Pop();
                Console.WriteLine(head);
                           
                head = stack.Peek();
                Console.WriteLine(head);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadLine();
        }     
    }

    public class MyStack<T>
    {
        private T[] data { get; set; }
        private int SP { get; set; }
        private const int Capacity = 5;
        public MyStack()
        {          
            data = new T[Capacity];
            SP = -1;
            data[0] = default;
        }
        public void Push(T d)
        {
            ++SP;
            if (SP >= Capacity) GrowArray(data.Length + 5);
            data[SP] = d;
        }
        public T Pop()
        {
            if (SP < 0) throw new InvalidOperationException("Stack is empty");
            T value = data[SP];
            data[SP] = default;
            SP--;
            return value;
        }
        public T Peek() 
        {
            if (SP < 0) throw new InvalidOperationException("Stack is empty");
            return data[SP];
        }
        private void GrowArray(int max)
        {
            T[] tempData = new T[max];
            for (int i = 0; i < SP; i++)
                tempData[i] = data[i];
            data = tempData;           
        }
    }
}
