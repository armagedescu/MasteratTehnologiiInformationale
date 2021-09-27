using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Tablouri1D
{
    public class Sorter<T>
    {
        public enum SortType
        {
            bubble,
            insertion,
            selection
        };
        public T[] array; //data
        SortedDictionary<T, int> expected; //statistics
        public SortType sort = SortType.bubble;
        public Sorter() { }
        public Sorter(int n) { array = new T[n]; } 
        public Sorter(T[] arr, bool copy = true) { reinit(arr, copy); }
        public void reinit(T[] arr, bool copy = true)
        {
            array = arr;
            if (copy) //creaza o copie in loc de original
            {
                array = new T[arr.Length];
                for (int i = 0; i < arr.Length; i++) array[i] = arr[i];
            }
            Restat();
        }
        public void rebuild(Func<T> f)
        {
            for (int i = 0; i < array.Length; i++) array[i] = f();
            Restat();
        }
        public void resize(int n, Func<T> f)
        {
            T[] tmparr = array;
            array = new T[n];
            int l = n;
            if (n > tmparr.Length) l = tmparr.Length;
            for (int i = 0; i < l; i++) array[i] = tmparr[i];
            for (int i = l; i < n; i++) array[i] = f();
            Restat();
        }
        public void replace(int i, T t) { array [i] = t; Restat(); }
        public delegate void AfterCmpHandler(Sorter<T> s, int a, int b, bool r);
        public event AfterCmpHandler onAfterCmp;
        public void invokeOnAfterCmp(Sorter<T> s, int a, int b, bool r)
        {
            if (onAfterCmp == null) return;
            onAfterCmp.Invoke(this, a, b, r);
        }

        void swap(ref T a, ref T b) { T t = a; a = b; b = t; }
        int a, b;
        bool r;
        bool cmpi(int a, int b, Func<T, T, bool> cmp)
        {
            bool r = cmp(array[a], array[b]);
            //onAfterCmp?.Invoke(this, a, b, r);
            invokeOnAfterCmp(this, a, b, r);
            this.a = a; this.b = b; this.r = r; //hold last compare results, for UI
            return r;
        }
        bool cmpi(T n, int a, int b, Func<T, T, bool> cmp)
        {
            bool r = cmp(n, array[b]);
            //onAfterCmp?.Invoke(this, a, b, r);
            invokeOnAfterCmp(this, a, b, r);
            this.a = a; this.b = b; this.r = r; //hold last compare results, for UI
            return r;
        }
        public bool isSorted(Func<T, T, bool> cmp)
        {
            for (int i = 0; i < array.Length - 1; i++)
                if (cmp(array[i + 1], array[i])) return false;
            return true;
        }
        public void autosort (Func<T, T, bool> cmp)
        {
            switch (sort)
            {
                case SortType.bubble:
                    BubbleSort(cmp);
                    break;
                case SortType.selection:
                    SelectionSort(cmp);
                    break;
                case SortType.insertion:
                    InsertionSort(cmp);
                    break;
            }
        }
        public void BubbleSort(Func<T, T, bool> cmp)
        {
            for (int i = 0, ds = array.Length - 1, unsorted = 1; unsorted != 0; i++)
            {
                unsorted = 0;
                for (int j = 0; j < ds; j++)
                    if (cmpi(j + 1, j, cmp))
                    {
                        swap(ref array[j], ref array[j + 1]);
                        unsorted = j;
                    }
                ds = unsorted;
            }
            //onAfterCmp?.Invoke(this, a, b, r);
            invokeOnAfterCmp(this, a, b, r);
        }
        public void SelectionSort(Func<T, T, bool> cmp)
        {
            for (int i = 0, ds = array.Length - 1, ds1 = array.Length, pos = 0; i < ds; i++, pos = i)
            {
                for (int j = i + 1; j < ds1; j++) if (cmpi(j, pos, cmp)) pos = j;
                if (pos != i) swap(ref array[i], ref array[pos]);
            }
            //onAfterCmp?.Invoke(this, a, b, r);
            invokeOnAfterCmp(this, a, b, r);
        }
        public void InsertionSort(Func<T, T, bool> cmp)
        {
            for (int i = 1, j = 1; j < array.Length; j++, i = j)
            {
                T n = array[j];
                for (; i > 0 && cmpi(n, j, i - 1, cmp); i--) array[i] = array[i - 1];
                array[i] = n;
            }
            //onAfterCmp?.Invoke(this, a, b, r);
            invokeOnAfterCmp(this, a, b, r);
        }
        public T this[int i] { get { return array[i]; } set { array[i] = value; } }

        public T Mex(Func<T, T, bool> cmp)
        {
            T f = array[0];
            for (int i = 1; i < array.Length; i++)
                if (cmp(array[i], f))
                    f = array[i];

            return f;
        }
        public int Length { get { return array.Length; } }
        public override string ToString() { return string.Join(" ", array); } //for debug and output
        public void Restat() { expected = stats(); } //build statistics
        public SortedDictionary<T, int> stats()
        {
            SortedDictionary<T, int> st = new SortedDictionary<T, int>();
            foreach (dynamic a in array)
            {
                if (st.ContainsKey(a)) st[a]++;
                else st[a] = 1;
            }
            return st;
        } 
        public bool Test() //return true if passed
        {
            SortedDictionary<T, int> actual = stats();
            foreach (dynamic s in expected.Keys)
            {
                if (!actual.ContainsKey(s)) return false;
                if (expected[s] != actual[s]) return false;
            }
            return true;
        }
    }
}
