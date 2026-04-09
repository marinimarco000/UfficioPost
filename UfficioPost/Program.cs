using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace UfficioPostale
{

    internal class Program

    {
        static void servizio(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni,ref int spedizione,ref int codaspidd,ref int finanziaria)
        {
            Console.WriteLine(" quale lista vuoi servire 1)spedizioni  2) coda finanziaria  3)spid");
            int scelta = Convert.ToInt32(Console.ReadLine());
            if (scelta == 1)
            {
                if (codaspedizioni[0] == "")
                {
                    Console.WriteLine(" in questa lista non è presente nessuno");
                }
                else
                {
                    codaspedizioni.RemoveAt(0);
                    spedizione++;
                }
            }
            else if (scelta == 2)
            {
                if (codafinanziaria[0] == "")
                {
                    Console.WriteLine(" in questa lista non è presente nessuno");
                }
                else
                {
                    codafinanziaria.RemoveAt(0);
                    finanziaria++;
                }
            }
            else if (scelta == 3)
            {
                if (codaspid[0] == "")
                {
                    Console.WriteLine(" in questa lista non è presente nessuno");
                }
                else
                {
                    codaspid.RemoveAt(0);
                    codaspidd++;
                }
            }


        }
        static void accettazione(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni, List<string> nomi)
        {
            Console.WriteLine("dimmi il tuo nome");
            string nome = Console.ReadLine();
            Console.WriteLine("quanti anni hai");
            nomi.Add(nome);
            int eta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" a che lista devi accedere 1)spedizioni  2) coda finanziaria  3)spid");
            int list = Convert.ToInt32(Console.ReadLine());

            if (list == 1)
            {


                if (eta >= 65)
                {
                    codaspedizioni.Insert((codaspedizioni.Count - 1) / 2, nome);
                }
                else
                {
                    codaspedizioni.Add(nome);
                }
            }
            else if (list == 2)
            {

                if (eta >= 65)
                {
                    codafinanziaria.Insert((codaspedizioni.Count - 1) / 2, nome);
                }
                else
                {
                    codafinanziaria.Add(nome);
                }

            }
            else if (list == 3)
            {
                if (eta >= 65)
                {
                    codaspid.Insert((codaspedizioni.Count - 1) / 2, nome);
                }
                else
                {
                    codaspid.Add(nome);
                }
            }
        }
        static void sbaglio(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni) 
        {
            Console.WriteLine("come ti chiami");
            string nome=Console.ReadLine();
            if (codaspid.Contains(nome)) 
            {
                codaspid.Remove(nome);
                Console.WriteLine("dimmi la lista in cui vuoi che ti metto 1) finanziaria 2)spedizioni");
                int coda=Convert.ToInt32(Console.ReadLine());
                if (coda == 1)
                {
                    Console.WriteLine("sei stato messo nella coda finanziaria ");
                    codafinanziaria.Add(nome);
                }
                else if(coda == 2) 
                {
                    Console.WriteLine(" sei stato spostato nella coda spedizioni");
                    codaspedizioni.Add(nome);
                }
                

            }
            else if (codafinanziaria.Contains(nome))
            {
                codafinanziaria.Remove(nome);
                Console.WriteLine("dimmi la lista in cui vuoi che ti metto 1) spid 2)spedizioni");
                int coda = Convert.ToInt32(Console.ReadLine());
                if (coda == 1)
                {
                    Console.WriteLine("sei stato messo nella coda spid ");
                    codaspid.Add(nome);
                }
                else if (coda == 2)
                {
                    Console.WriteLine(" sei stato spostato nella coda spedizioni");
                    codaspedizioni.Add(nome);
                }


            }
            else if (codaspedizioni.Contains(nome))
            {
                codaspedizioni.Remove(nome);
                Console.WriteLine("dimmi la lista in cui vuoi che ti metto 1) finanziaria 2)spid");
                int coda = Convert.ToInt32(Console.ReadLine());
                if (coda == 1)
                {
                    Console.WriteLine("sei stato messo nella coda finanziaria ");
                    codafinanziaria.Add(nome);
                }
                else if (coda == 2)
                {
                    Console.WriteLine(" sei stato spostato nella coda spid");
                    codaspid.Add(nome);
                }


            }

            else
            {
                Console.WriteLine("non sei presente in nessuna fila se secondo te hai sbagliato a scrivere nome riprova");
            }

        }
        static void reportvisivo(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni,int spedizione,int codaspidd,int finaziaria) 
        {
            int totsped = codaspedizioni.Count;
            int totspid = codaspid.Count;
            int totfinanziaria=codafinanziaria.Count;

      

            Console.WriteLine($" nella fila spid ci sono in totale {totspid} persone in coda ");
            Console.WriteLine($" nella fila spedizioni ci sono in totale {totsped} persone in coda ");
            Console.WriteLine($" nella coda fnanziaria ci sono in totale {totfinanziaria} persone in coda ");

            foreach (string nome in codaspid)
            {
                Console.WriteLine($"coda spid {nome}");
            }
            foreach (string nome in codafinanziaria)
            {
                Console.WriteLine($"coda finanziaria{nome}");
            }
            foreach (string nome in codaspedizioni)
            {
                Console.WriteLine($"codaspedizoni {nome}");
            }

            Console.WriteLine($"in tutto nella fila spid son state servite {codaspidd} persone");
            Console.WriteLine($"in tutto nella fila spedizione son state servite {spedizione} persone");
            Console.WriteLine($"in tutto nella fila finanziaria son state servite {finaziaria} persone");
        }
        static void chiusuraspid(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni) 
        { 

            for(int i = 0; i < codaspid.Count ; i++) 
            {
                codafinanziaria.Add( codaspid[i] );
                codaspid.RemoveAt(0);
            }
            
        }
        static void chiusuratotale(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni) 
        {
            Console.WriteLine(" non si accettano piu clineti da adesso in poi e i clienti che ci sono verranno serviti tutti grazie e ci vediamo alla prossima ");
            for (int i = 0; i < codaspid.Count; i++)
            {
                
                codaspid.RemoveAt(0);
            }
            for(int i = 0;i < codafinanziaria.Count; i++) 
            {
                codafinanziaria.RemoveAt(0);
            }
            for(int i=0;i< codaspedizioni.Count; i++) 
            {
                codaspedizioni.RemoveAt(0);
            }
            
        }
        static void pulizia(List<string> codaspid, List<string> codafinanziaria, List<string> codaspedizioni)
        {
            char[] alfabeto = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
           
        }

        static void Main(string[] args)
        {
            int spedizione = 0, codaspidd = 0, finaziaria = 0;
            List<string> codaspedizioni = new List<string>();
            List<string> codafinanziaria = new List<string>();
            List<string> codaspid = new List<string>();
            List<string> nomi = new List<string>();
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("che funzione vuoi usare");
                Console.WriteLine("---1) accettazione clienti");
                Console.WriteLine("---2) servizio clienti");
                Console.WriteLine("---3 sbaglio lista");
                Console.WriteLine("---4 report visivo");
                Console.WriteLine("---5 chiusura spid");
                Console.WriteLine("---6 pulizia sistema");
                Console.WriteLine("---7 chiisura ufficio");
                int scelta = Convert.ToInt32(Console.ReadLine());
                if (scelta == 1)
                {

                    accettazione(codaspid, codafinanziaria, codaspedizioni, nomi);


                }
                else if (scelta == 2)
                {
                    servizio(codaspid, codafinanziaria, codaspedizioni,ref spedizione,ref codaspidd,ref finaziaria);

                }
                else if(scelta==3) 
                {
                    sbaglio(codaspid, codafinanziaria, codaspedizioni);
                }
                else if (scelta == 4) 
                { 
                    reportvisivo(codaspid,codafinanziaria, codaspedizioni, spedizione, codaspidd, finaziaria);
                }
                else if (scelta == 5) 
                {
                    chiusuraspid(codaspid, codafinanziaria, codaspedizioni);
                }
                else if( scelta == 6) 
                { 

                }
                else if (scelta == 7) 
                {
                    chiusuratotale(codaspid, codafinanziaria, codaspedizioni);
                    menu = false;
                }
                else 
                {
                    Console.WriteLine("hai sbagliato a inserire il numero riprova");
                }




            }
        }
    }
}
