using Cars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    public class HTable<T> where T : IInit, ICloneable, new()
    {
        LPoint<T>?[] table;
        public int Capacity => table.Length;
        public HTable(int size = 10)
        {
            table = new LPoint<T>[size];
        }
        public void Add(T data) // добавление
        {
            int index = GetIndex(data);
            if (table[index] == null) // если позиция пустая
            {
                table[index] = new LPoint<T>(data);
                //table[index].Data = data;
            }
            else // есть цепочка
            {
                LPoint<T>? current = table[index];
                while (current.Next != null) 
                {
                    if (current.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new LPoint<T>(data);
                current.Next.Pred = current;
            }
        }
        int GetIndex(T data) // индекс
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
        public void Print() //вывод
        {
            if (table == null) { Console.WriteLine("Таблица пустая!"); return; }
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (table[i] != null) // не пустая ссылка
                {
                    Console.WriteLine(table[i].Data); //вывод информации
                    if (table[i].Next != null) // не пустая цепочка
                    {
                        LPoint<T>? current = table[i].Next; // проход по цепочке
                        while (current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
        }
        public bool FindPoint(T data) // поиск элемента
        {
            int index = GetIndex(data);
            if (table == null)
                throw new Exception("Пустая таблица");
            if (table[index] == null) // цепочка пустая
                return false;
            if (table[index].Data.Equals(data)) //нужный элемент найден
                return true;
            else
            {
                LPoint<T>? current = table[index]; //идём по цепочке
                while (current != null)
                {
                    if(current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }
        public bool DelPoint(T data) //удаление элемента
        {
            LPoint<T>? current;
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null) //один элемент в цепочке
                    table[index] = null;
                else
                {
                    table[index] = table[index].Next;
                    table[index].Pred = null;
                }
                return true;
            }
            else
            {
                current = table[index];
                while (current != null)
                {
                    if(current.Data.Equals(data))
                    {
                        LPoint<T>? pred = current.Pred;
                        LPoint<T>? next = current.Next;
                        pred.Next = next;
                        current.Pred = null;
                        if (next != null)
                            next.Pred = null;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }
    }

}
