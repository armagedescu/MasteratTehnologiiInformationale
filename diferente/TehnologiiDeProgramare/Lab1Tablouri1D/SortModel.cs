using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1Tablouri1D
{
    public class SortModel
    {
        Random random = new Random();
        Data<int> data = new Data<int>
        {
            arr = new int[30],
            from = 30,
            to = 500
        };
        public int   from { get { return data.from; } set { data.from = value; Readjust(); } }
        public int   to   { get { return data.to;   } set { data.to   = value; Readjust(); } }
        public int[] arr  { get { return data.arr;  } set { data.arr  = value; } }
        public void setItem(int i, int n)
        {
            if (arr[i] == n) return;
            if (!ValidateArrValue(n)) return;
            arr[i] = n;
            Readjust();
        }
        public Sorter<int>[] sorter = new Sorter<int>[3];
        Thread[] thread = null;

        public int Build() { return random.Next(from, to); }
        int Build(int n) { if (!ValidateArrValue(n)) n = Build(); return n; }

        string baza;
        XmlSerializer serializer = new XmlSerializer(typeof(Data<int>));
        void writeTo()
        {
            TextWriter writer = new StreamWriter(baza);
            serializer.Serialize(writer, data);
            writer.Close();
        }
        void LoadFromFile()
        {
            StreamReader streamer = new StreamReader(baza);
            Data<int> dt = (Data<int>)serializer.Deserialize(streamer);
            streamer.Close();
            data = dt;
            for (int i = 0; i < sorter.Length; i++) sorter[i] = new Sorter<int>(arr);
        }
        void BuildNew()
        {
            for (int i = 0; i < sorter.Length; i++) sorter[i] = new Sorter<int>(arr);
            Rebuild();
        }

        public SortModel(string baza)
        {
            OnChange += writeTo;
            this.baza = baza;

            if (File.Exists(baza)) LoadFromFile();
            else BuildNew();


            sorter[0].sort = Sorter<int>.SortType.bubble;
            sorter[1].sort = Sorter<int>.SortType.selection;
            sorter[2].sort = Sorter<int>.SortType.insertion;

            //OnChange?.Invoke();
            invokeOnChange();
        }
        public delegate void changedDelegate();
        public event changedDelegate OnChange;
        public void invokeOnChange()
        {
            if (OnChange == null) return;
            OnChange.Invoke();
        }

        public void SetRange(int from, int to) { this.from = from; this.to = to; Readjust(); invokeOnChange();  }
        public void Realloc(int n) 
        {
            int l = n;
            if (l > arr.Length) l = arr.Length;
            if (n != arr.Length)
            {
                int[] a = new int[n];
                int i = 0;
                for (; i < l; i++) a[i] = Build(arr[i]);
                for (; i < n; i++) a[i] = Build();
                arr = a;
            }
            Reinit();
        }
        public void Rebuild () { for (int i = 0; i < arr.Length; i++) arr[i] = Build(); invokeOnChange(); Reinit(); }
        public void Readjust() { for (int i = 0; i < arr.Length; i++) arr[i] = Build(arr[i]); invokeOnChange();  Reinit(); }
        public void Reinit() { Array.ForEach(sorter, (s) => s.reinit(arr)); invokeOnChange(); }
        public void Autosort(Func<int, int, bool> cmp)
        {
            thread = new Thread[sorter.Length];
            for (int i = 0; i < thread.Length; i++)
            {
                Sorter<int> s = sorter[i];
                thread[i] = new Thread(() => { s.autosort(cmp); });
            }
            Array.ForEach(thread, (t) => t.Start());
        }
        public void Stop() { Array.ForEach(thread, (t) => { if (t != null && t.IsAlive) t.Interrupt(); }); }


        public bool ValidateFrom    (string s) { int n; return int.TryParse(s, out n) && ValidateFrom(n); }
        public bool ValidateTo      (string s) { int n; return int.TryParse(s, out n) && ValidateTo(n); }
        public bool ValidateSize    (string s) { int n; return int.TryParse(s, out n) && ValidateSize(n); }
        public bool ValidateArrValue(string s) { int n; return int.TryParse(s, out n) && ValidateArrValue(n); }
        public bool ValidateFrom    (int n)    { return n >= 5 && n < to; }
        public bool ValidateTo      (int n)    { return n > from && n <= 500; }
        public bool ValidateSize    (int n)    { return n >= 5 && n <= 100; }
        public bool ValidateArrValue(int n)    { return n >= from && n <= to; }
    }
}
