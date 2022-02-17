using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPM
{
    class RPM
    {
        static void Main()
        {
            List<int> array = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\KLOPO\\Desktop\\test\\30000.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out var number))
                        {
                            array.Add(number);
                        }
                    }
                }

                var time = System.Diagnostics.Stopwatch.StartNew(); //1
                int[] arraySorted = new int[array.Count];
                for (int i = 0; i < array.Count; i++)
                {
                    int k = 0;
                    for (int j = 0; j < array.Count; j++)
                    {
                        k += array[i] > array[j] ? 1 : 0;
                    }
                    while (arraySorted[k] == array[i]) k++;
                    arraySorted[k] = array[i];
                }
                time.Stop();
                Console.WriteLine($"1 метод\ntime elapsed: {time.ElapsedTicks}\n");
                //Console.WriteLine(String.Join(", ", arraySorted));

                time = System.Diagnostics.Stopwatch.StartNew(); //3
                
                for (int i = 0; i < array.Count; i++)
                {
                    int minIndex = array.LastIndexOf(array.GetRange(i, array.Count - i).Min());
                    (array[i], array[minIndex]) = (array[minIndex], array[i]);
                }
                time.Stop();

                Console.WriteLine($"3 метод\ntime elapsed: {time.ElapsedTicks}\n");
                //Console.WriteLine(String.Join(", ", arraySorted));

                time = System.Diagnostics.Stopwatch.StartNew();

                arraySorted[0] = array[0]; //2
                for (int i = 1; i < array.Count; i++)
                {
                    int j = 0;
                    while (arraySorted.Length > j && arraySorted[j] < array[i])
                    {
                        j++;
                    }
                    arraySorted[j] = array[i];
                }

                time.Stop();

                Console.WriteLine($"2 метод\ntime elapsed: {time.ElapsedTicks}\n");
                //Console.WriteLine(String.Join(", ", arraySorted));

                time = System.Diagnostics.Stopwatch.StartNew(); //4
                for (int i = 0; i < array.Count; i++)
                {
                    for (int j = i + 1; j < array.Count; j++)
                    {
                        if (array[i] > array[j])
                        {
                            array[i] += array[j];
                            array[j] = array[i] - array[j];
                            array[i] -= array[j];
                        }
                    }
                }
                time.Stop();
                Console.WriteLine($"4 метод\ntime elapsed: {time.ElapsedTicks}\n");
                //Console.WriteLine(String.Join(", ", arraySorted));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}