using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace laba1lib
{
    public static class Sorter
    {
        public static List<String> SplitAndSort(String path,String basepath)
        {
            List<String> buffer = new List<string>();
            List<String> filenames = new List<string>();
            int j = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    j++;
                    using (StreamWriter file = new StreamWriter(basepath+"file" + j.ToString() + ".txt", true, Encoding.UTF8, 100))
                    {
                        buffer.Clear();
                        filenames.Add(basepath + "file" + j.ToString() + ".txt");
                        for (int i = 0; i < 1000000; i++)
                            if (!sr.EndOfStream)
                            {
                                buffer.Add(sr.ReadLine());
                            }
                            else break;
                        buffer.Sort();
                        foreach (String s in buffer)
                            file.WriteLine(s);
                    }
                }
            }
            return filenames;
        }
        public static void MergeSortedFiles(List<String> filenames,String path)
        {
            StreamReader[] readers = new StreamReader[filenames.Count];
            List<KeyValuePair<int, String>> buffer = new List<KeyValuePair<int, String>>();
            int i = 0;
            foreach (String name in filenames)
            {
                readers[i] = new StreamReader(name);
                buffer.Add(new KeyValuePair<int, String>(i, readers[i].ReadLine()));
                i++;
            }
            buffer.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            using (StreamWriter file1 = new StreamWriter(path ,true, Encoding.UTF8, 100))
            {
                while (buffer[0].Value.CompareTo("ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ") < 0)
                {
                    file1.WriteLine(buffer[0].Value);
                    int num = buffer[0].Key;
                    buffer.Remove(buffer[0]);
                    if (!readers[num].EndOfStream)
                    {
                        buffer.Add(new KeyValuePair<int, String>(num, readers[num].ReadLine()));
                    }
                    else
                    {
                        buffer.Add(new KeyValuePair<int, String>(num, "ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ"));
                    }
                    buffer.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                }
            }
        }

    }
}
