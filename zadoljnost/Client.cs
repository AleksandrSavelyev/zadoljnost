using System;
using System.Collections.Generic;
using System.Text;

namespace zadoljnost
{
    class Client
    {
        public Client[] data;
        string clientID;
        string clientDoc;
        double clientDebit;
        public string ClientID
        {
            get
            {
                return clientID;    
            }        
            set
            {
                clientID = value;
            }
        }
        public string ClientDoc
        {
            get
            {
                return clientDoc;
            }
            set
            {
                clientDoc = value;
            }
        }
        public double ClientDebit
        {
            get
            {
                return clientDebit;
            }
            set
            {
                clientDebit = value;
            }
        }
        public void GetInfo()
        {
            Console.WriteLine($"{clientID} {clientDoc} {clientDebit}");
        }

    }
}
