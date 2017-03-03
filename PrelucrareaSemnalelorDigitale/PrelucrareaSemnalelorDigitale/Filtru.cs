using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrelucrareaSemnalelorDigitale
{
    class Filtru
    {
        List<double> input = new List<double>{ 1, 2, 3, 4, 5, 6 };//x
        List<double> a = new List<double> { 1, 2, 3 };
        List<double> b = new List<double> { 0, 2, 2, 3, 5 };
        List<double> output;
        List<double> calculate(List<double> input)
        {
            this.input = input;
            this.output = new List<double>(input.Count) { 0 };
            for (int n = 0; n < input.Count; n++)
            {
                double item = 0;
                for (int i = 0; i < a.Count; i++)
                    if (n - i >= 0) item += a[i] * input[n - i];
                for (int j = 1; j < b.Count; j++)
                    if (n - j >= 0) item += b[j] * input[n - j];
                output.Add(item);
            }
            return output;
            //input.ForEach(x => x+1).ToList();
        }
    }
}
