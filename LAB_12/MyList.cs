using Cars;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T> beg = null;
        Point<T> end = null;
        int count = 0;
        public int Count => count;
        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }
        public T MakeRandomItem() // создание информационного поля
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); //глубокое клонирование для того, чтобы разные динамические структуры не ссылались на одну и ту же область памяти
            Point<T> newItem = new Point<T>(newData);
            count++;
            if(beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if(end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public bool RemoveItemAfterBrand(string brand) //удаляем все элементы после найденного по бренду элемента
        {
            bool removed = false;
            Point<T>? current = FindItemByBrand(brand);

            while (current != null)
            {
                Point<T>? toRemove = current;

                // Если удаляем первый элемент
                if (toRemove.Pred == null)
                {
                    beg = null;
                    end = null;
                }
                else
                {
                    // Устанавливаем новый конец списка
                    end = toRemove.Pred;
                    end.Next = null;
                }

                count--;
                removed = true;

                // Переходим к следующему элементу
                current = current.Next;
            }

            return removed;
        }

        private Point<T>? FindItemByBrand(string brand) //ищем элемент по бренду
        {
            Point<T>? current = beg;

            while (current != null)
            {
                if (current.Data is Car car && car.Brand == brand) //ищем элемент по бренду
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }

        public MyList() { }
        public MyList(int size) // создание списка
        {
            if (size <= 0) throw new Exception("size less zero");
            beg = MakeRandomData(); // создаём элемент
            end = beg;
            for(int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem(); // создаём информационное поле
                AddToEnd(newItem); // добавляем его в конец
            }
        }
        public MyList(T[] collection) // создание списка по массиву
        {
            if (collection == null) throw new Exception("empty collection: null"); // если коллекция пустая
            if (collection.Length == 0) throw new Exception("empty collection"); 
            T newData = (T)collection[0].Clone(); // клонирование
            beg = new Point<T> (newData);
            end = beg;
            for (int i = 1;i < collection.Length;i++)
                AddToEnd(collection[i]);
        }
        public void PrintList()
        {
            if (count == 0 || beg == null)
                Console.WriteLine("the list is empty");
            Point<T>? current = beg;
            for (int i = 0; current != null ; i++)
            {
                Console.WriteLine(current.Data); // выводим элемент
                current = current.Next; // передвигаемся по ссылке на следующий, так пока current не равно null (0 и последний элемент)
            }
        }
        public void Delete() // удаление списка
        {
            Point<T>? current = beg;

            while (current != null) // обнуляем все ссылки и данные 
            {
                Point<T>? toRemove = current;
                current = current.Next;

                toRemove.Data = default(T);
                toRemove.Next = null;
                toRemove.Pred = null;
            }
            // обнуляем начальную и конечную ссылки
            beg = null; 
            end = null;
            count = 0;
        }
        public Point<T>? FindItem(T item) // поиск элемента с заданным ключом
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data is null");
                if(current.Data.Equals(item)) // сравниваем содержимое перегруженным методом Equals, а не ссылки
                    return current; // возвращает ссылку(Адрес) на искомый элемент
                current = current.Next; // если не совпадает идём на следующий элемент
            }
            return null;
        }
        public bool RemoveItem(T item) // удаление элемента
        {
            if (beg == null) throw new Exception("the list is empty");
            Point<T>? pos = FindItem(item); // находим необходимый элемент
            if (pos == null) return false; // если элемента нет false
            count--;
            // в списке один элемент
            if(beg == end)
            {
                beg = end = null;
                return true;
            }
            // элемент стоит на первой позиции - рассматривается отдельно так как beg изменяет позицию на вторую и первая ссылка удаляется
            if(pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;
            }
            // последний элемент то же самое, что в предыдущем, только наоборот
            if (pos.Next == null) 
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            // остальные случаи
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;
        }
        public MyList<T> DeepClone()
        {
            MyList<T> clonedList = new MyList<T>(); // создание экз. списка для клонирования

            Point<T>? current = beg; // первый элемент списка

            while (current != null)
            {
                if (current.Data != null)
                {
                    T clonedItem = (T)((ICloneable)current.Data).Clone(); // клонируем текущий элемент с помощью Clone
                    clonedList.AddToEnd(clonedItem);
                }

                current = current.Next;
            }

            return clonedList;
        }
        public void AddInMiddle(T item)
        {
            T newData = (T)item.Clone(); // Создаем копию элемента
            Point<T> newItem = new Point<T>(newData);
            count++;

            // Если список пуст, добавляем элемент в начало
            if (beg == null)
            {
                AddToBegin(item);
                return;
            }

            Point<T>? current = beg;
            int index = 0;

            while (current != null)
            {
                if (index == 0 || index % 2 == 0)
                {
                    // Вставляем элемент на позицию 1,3,5..
                    newItem.Next = current;
                    newItem.Pred = current.Pred;

                    if (current.Pred != null)
                    {
                        current.Pred.Next = newItem;
                    }
                    else
                    {
                        beg = newItem; // Если предыдущего элемента нет, значит это начало списка
                    }

                    current.Pred = newItem;
                    return;
                }

                if (current.Next == null)
                {
                    // Если достигли конца списка, добавляем элемент в конец
                    AddToEnd(item);
                    return;
                }

                current = current.Next;
                index++;
            }
        }
        public int IndexOf(T item)
        {
            int index = 0;
            Point<T>? current = beg;

            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(item))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1; // Возвращаем -1, если элемент не найден
        }
    }
}
