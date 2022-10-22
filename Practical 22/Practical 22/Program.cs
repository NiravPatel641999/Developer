using System;
using System.Text;
using System.IO;

namespace Practical_22
{
    class ReadWriteDemo
    {
        public void WriteData()
        {
            try
            {
                FileStream fs = new FileStream("C:\\Users\\om\\Desktop\\myTestFile.txt",FileMode.OpenOrCreate);
                Console.WriteLine("File is created or Open Existing file...");
                StreamWriter sw = new StreamWriter(fs);
                Console.WriteLine("Enter the text which you want to write to the file:");
                string str = Console.ReadLine();
                while (sw != null)
                {
                    str = Console.ReadLine();
                    sw.WriteLine(str);
                    if ((str = Console.ReadLine()) == "")
                    {
                        break;
                    }
                }
                //string str = Console.ReadLine();    // Read input from user from Console screen
                //sw.WriteLine(str);  // Write a line in buffer
                sw.Flush();     // To write in output stream
                sw.Close();     // To close the stream
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
        }
        public void ReadData()
        {
            try
            {
                FileStream fs = new FileStream("C:\\Users\\om\\Desktop\\myTestFile.txt", FileMode.OpenOrCreate);
                Console.WriteLine("File is created or Open Existing file...");
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine("Content of the file:");
                string str = sr.ReadLine();     // To read line from input stream
                // To read all content of file line by line
                while(str != null)
                {
                    Console.WriteLine(str);
                    str = sr.ReadLine();
                }
                Console.ReadLine();
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
        }
        static void Main(string[] args)
        {
            ReadWriteDemo obj = new ReadWriteDemo();
            obj.WriteData();
            obj.ReadData();
        }
    }
}
