using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13
{
   public class dblnode
    {
        public int vl;
        public dblnode next, prev;
        public dblnode (int x)
        {
            vl = x;
            next = prev = null;
        }
    }

    public class dblList
    {
        public dblnode head, tail;
        public int count;

        public dblList()
        {
            head = tail = null;

            count = -1;
        }

        public void addLast(int x)
        {
            dblnode nd = new dblnode(x);
            if (head == null)
            {
                head = tail = nd;

            }
            else
            {
                tail.next = nd;
                nd.prev = tail;
                tail = nd;
            }
            count++;
        }
        public void addFirst(int x)
        {
            dblnode nd = new dblnode(x);
            if (head == null)
            {
                head = tail = nd;
            }
            else
            {
                head.prev = nd;
                nd.next = head;
                head = nd;
            }
            count++;
        }

        public void addmiddle(int x)
        {
            dblnode nd = new dblnode(x);
            if (head == null)
            {
                head = tail = nd;
            }
            else
            {
                dblnode tmp = head;
                for(int i = 0; i < count / 2; i++)
                {
                    tmp = tmp.next;

                }
                dblnode tmp2 = tmp.next;
                nd.prev = tmp;
                tmp.next.prev = nd;
                tmp.next = nd;
                nd.next = tmp2;

                

            }
            count++;
        }
        public void addatpos(int x, int pos) 
        {
            dblnode nd = new dblnode(x);
            dblnode tmp = FindNode(pos - 1);
            dblnode tmp2 = FindNode(pos);

            nd.prev = tmp;
            tmp.next.prev = nd;
            tmp.next = nd;
            nd.next = tmp2;

            count++;
        }
        public void removeFirst()
        {
            dblnode tmp = head;
            head = head.next;
            head.prev = null;
            tmp = null;

            count--;
        }
        public void removeLast()
        {
            dblnode tmp = tail;
            tail = tail.prev;
            tail.next = null;
            tmp = null;

            count--;
        }
        public void removeMiddle()
        {
            dblnode tmp = FindNode(count / 2 - 1);
            dblnode tmp2 = FindNode(count / 2 + 1);

            tmp.next = tmp2;
            tmp2.prev = tmp;
            count--;
        }
        public void removeAtPos(int pos)
        {
            dblnode tmp = FindNode(pos);
            if (head == null)
            {
                dblnode tmp2 = FindNode(pos + 1);
                head = tmp2;
                head.prev = null;
                tmp = null;

            }
            else if (tail == null)
            {
                dblnode tmp3 = FindNode(pos - 1);
                tail = tmp3;
                tail.next = null;
                tmp = null;
            }
            else
            {
                dblnode tmp4 = FindNode(pos - 1);
                dblnode tmp5 = FindNode(pos + 1);

                tmp4.next = tmp5;
                tmp5.prev = tmp4;
                tmp = null;


            }
            count--;
        }
        public dblList Clone()
        {
            dblList lst = new dblList();
            dblnode tmp = head;
            while (tmp != null)
            {
                lst.addLast(tmp.vl);
                tmp = tmp.next;
            }
            return lst;
        }
        public void addListLast(dblList lst2)
        {
            tail.next = lst2.head;
            lst2.head.prev = tail;
            tail = lst2.tail;
            lst2.head = head;

        }
        public void addlistFirst(dblList lst2)
        {
            lst2.tail.next = head;
            head.prev = lst2.tail;
            lst2.tail = tail;
            head = lst2.head;            
        }
        public void addlistMiddle(dblList lst2)
        {
            dblnode tmp = FindNode(count / 2);
            dblnode tmp2 = FindNode(count / 2 + 1);

            lst2.head.prev = tmp;
            tmp.next = lst2.head;
            tmp2.prev = lst2.tail;
            lst2.tail.next = tmp2;
            lst2.head = head;
            lst2.tail = tail;
        
           
        }

        public void addListAtPos(dblList lst2,int pos)
        {
            dblnode tmp = FindNode(pos - 1);
            dblnode tmp2 = FindNode(pos);
            lst2.head.prev = tmp;
            tmp.next = lst2.head;
            tmp2.prev = lst2.tail;
            lst2.tail.next = tmp2;
            lst2.head = head;
            lst2.tail = tail;
        }

        public void reverse()
        {
            dblnode tmp = null;
            dblnode current = head;
            while (current != null)
            {
                tmp = current.prev;
                current.prev = current.next;
                current.next = tmp;
                current = current.prev;

                if (tmp != null)
                {
                    head = tmp.prev;
                }
            }
        }
        public dblnode FindNode(int pos)
        {
            dblnode tmp = head;
            for(int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
            return tmp;
        }
        public void multipleList(int n)
        {
            dblList lst = Clone();
            for(int i = 0; i < n; i++)
            {
                addListLast(lst.Clone());
               
            }
        }
        public dblList seperatelist()
        {
            dblList lst2 = new dblList();
            for(int i = count / 2 - 1; i < count; i++)
            {
                dblnode tmp2 = FindNode(i);
                lst2.addLast(tmp2.vl);

            }
            lst2.addLast(tail.vl);
            dblnode tmp = head;
            for(int i = 0; i < count / 2; i++)
            {
                tmp = tmp.next;
            }
            tail = tmp;
            tail.next = null;

            count--;
            return lst2;
        }
        public void showElement()
        {
            dblnode tmp = head;
            while (tmp != null)
            {
                Console.Write(tmp.vl + " ");
                tmp = tmp.next;
            }
            Console.WriteLine();
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dblList lst = new dblList();

            lst.addLast(1);
            lst.addLast(2);
            lst.addLast(3);
            lst.addLast(4);
            lst.addLast(5);
            lst.addLast(6);
            lst.showElement();

           // lst.Clone();
            lst.showElement();

            lst.seperatelist();
            lst.showElement();

            //dblList lst2 = new dblList();

            //lst2.addLast(100);
            //lst2.addLast(200);
            //lst2.addLast(300);



            //lst2.showElement();

            //lst2.multipleList(3);
            //lst2.showElement();
            //lst.addlistMiddle(lst2);
            //lst.showElement();
            Console.ReadKey();
        }
    }
}
