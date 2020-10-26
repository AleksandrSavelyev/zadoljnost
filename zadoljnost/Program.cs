using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace zadoljnost
{
    class Program
    {
        static void Main()
        {
            string path = @"D:\client";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }
            ArrayList list = new ArrayList();
            ArrayList clientList = new ArrayList();
            Client client = new Client();
            string pathFile = @"D:\client\debit.txt";
            int count = 0;



            string text = "001;AZE12345678;22,30\n" +
                         "025;AZE87652134;50,00\n" +
                         "034;AZE87652134;12,35";
            try
            {
                using (StreamWriter sw = new StreamWriter(pathFile, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine($"файл был успешно создан по пути {pathFile}");
            using (StreamReader sr = new StreamReader(pathFile))
            {
                int j = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] param = line.Split(new char[] { ';' });
                    foreach(string l in param)
                    {
                        list.Add(l);
                        
                    }
                }
                for(int i=0;i<list.Count;i++)
                {
                    if (count == 0)
                    {
                        Client cli = new Client();
                        clientList.Add(cli);
                        client = (Client)clientList[j];
                        client.ClientID = Convert.ToString(list[i]);
                        count = +1;
                        
                    }
                    else if (count == 1)
                    {
                        
                        client.ClientDoc = Convert.ToString(list[i]);
                        count =count +1;
                        
                    }
                    else if(count==2)
                    {
                        client.ClientDebit = Convert.ToDouble(list[i]);
                        count = 0;
                        j = j + 1;
                    }
                    
                }
                Console.WriteLine("содержимое файла");
                for (int i = 0; i < clientList.Count; i++)
                {
                    client = (Client)clientList[i];
                    client.GetInfo();
                }
            }
            Console.WriteLine("введите сумму на которую хотите уменьшит сумму долга всех клиентов");
            double changeSum =NumChek();
            for(int i=0;i<clientList.Count;i++)
            {
                client = (Client)clientList[i];
                client.ClientDebit = client.ClientDebit-changeSum;
                client.GetInfo();
            }
            int k = 0;
            for (int i = 0; i < list.Count; i++)
            {
                
                    if (count == 0)
                    {
                        client = (Client)clientList[k];
                        list[i]=client.ClientID;
                        count = count + 1;
                        
                    }
                    else if (count == 1)
                    {
                        list[i]=client.ClientDoc;
                        count = count + 1;
                        
                    }
                    else if (count == 2)
                    {
                        list[i]=Convert.ToString(client.ClientDebit);
                        count = 0;
                        k++;
                    }
                
            }
            using (StreamWriter sw = new StreamWriter(pathFile, false, System.Text.Encoding.Default))
            {

                for(int i=0;i<list.Count;i++)
                {
                    if(count==0)
                    {
                        sw.Write($"{list[i]};");
                        count = count + 1;
                    }
                    else if (count == 1)
                    {
                        sw.Write($"{list[i]};");
                        count = count + 1;
                    }
                    else if (count == 2)
                    {
                        sw.WriteLine($"{list[i]};");
                        count = 0;
                    }
                }
            }
            Console.WriteLine("все данные перезаписанны");
            Console.ReadKey();
        }
        static double NumChek()
        {
            for(; ; )
            {
                try
                {
                    double num = Convert.ToDouble(Console.ReadLine());
                    return num;
                }
                catch
                {
                    Console.WriteLine("не верные данные повторите ввод");
                }
            }
        }
    }
}
/*string ID = $"{Console.ReadLine()}:";
string doc = $"{Console.ReadLine()}:";
string debit = $"{Console.ReadLine()}:";
string path = @"D:\client\debit.txt";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {

                sw.Write(ID);
                sw.Write(doc);
                sw.WriteLine(debit);

            }*/
            
