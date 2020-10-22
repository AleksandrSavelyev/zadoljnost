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
            FileInfo file = new FileInfo(pathFile);
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
            using (StreamReader sr = new StreamReader(pathFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] param = line.Split(new char[] { ';' });
                    foreach(string l in param)
                    {
                        list.Add(l);
                        
                    }
                }
                for(int i=0;i<clientList.Count;i++)
                {
                    client = (Client)clientList[i];
                    if (count == 0)
                    {
                        Client clt = new Client();
                        client = clt;
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
                        clientList.Add(client);
                        count = 0;
                        
                    }
                    
                }
                for (int i = 0; i < clientList.Count; i++)
                {
                    Client cli = (Client)clientList[i];
                    cli.GetInfo();
                }
            }
            double changeSum =Convert.ToDouble(Console.ReadLine());
            for(int i=0;i<clientList.Count;i++)
            {
                client = (Client)clientList[i];
                client.ClientDebit = client.ClientDebit - changeSum;
                clientList.Add(client);
            }
            for (int i = 0; i < clientList.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (count == 0)
                    {
                        client = (Client)clientList[i];
                        list[j] = client.ClientID;
                        count = count + 1;
                    }
                    else if (count == 1)
                    {
                        list[j] = client.ClientDoc;
                        count = count + 1;
                    }
                    else if (count == 2)
                    {
                        list[j] = client.ClientDebit;
                        count = 0;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(pathFile, false, System.Text.Encoding.Default))
            {

                for(int i=0;i<list.Count;i++)
                {
                    sw.WriteLine($"{list[i]};");
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
            
