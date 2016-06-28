using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Concurrent;

namespace serwer
{
    class Program
    {
        private static UdpClient udpLaczenie;
        private static UdpClient udpRysowanie;
        private static int portLaczenie = 1234;
        private static int portRysowanie = 4321;
        private static int maxUzytkownikow=256;
        private static int bierzaceID;
        private static Dictionary<int, Uzytkownik> polaczenia = new Dictionary<int, Uzytkownik>();
        private static BlockingCollection<string> kolejkaWiadomosci = new BlockingCollection<string>();
        private static Dictionary<int, int> piszacyUzytkownicy = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            //uzytkownicy = new Uzytkownik[maxUzytkownikow];
            

            Console.WriteLine("Uruchomiono serwer");
            udpLaczenie = new UdpClient(portLaczenie);
            udpRysowanie = new UdpClient(portRysowanie);
            new Task(() => rysuj()).Start();
            new Task(() => wysylaj()).Start();
            bierzaceID = 0;
            while (true)
            {
                IPEndPoint addr = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpLaczenie.Receive(ref addr);
                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                switch (receiveBytes.Length)
                {
                    case 9:
                        if (bierzaceID >= maxUzytkownikow)
                            return;
                        Console.WriteLine("Podlaczono uzytkownika {0}", bierzaceID);
                        string wiadomosc = bierzaceID.ToString();
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(wiadomosc);
                        udpLaczenie.Send(sendBytes, sendBytes.Length, addr);
                        Uzytkownik nowy = new Uzytkownik(bierzaceID, addr);
                        polaczenia.Add(bierzaceID, nowy);                        
                        bierzaceID++;
                        break;
                    case 1:
                        int usuwaneId = int.Parse(receivedData);
                        Console.WriteLine("Rozlaczono uzytkownika {0}", usuwaneId);
                        polaczenia.Remove(usuwaneId);
                        break;
                }
            }


        }

        public static void rysuj() {
            while (true) {
                IPEndPoint addr = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpRysowanie.Receive(ref addr);
                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                
                int id = -1; ;
                foreach (Uzytkownik uzytk in polaczenia.Values) {
                    if (uzytk.getAdres().Equals(addr))
                        id = uzytk.getID();
                }
                if (id == -1)
                    return;
                
                        kolejkaWiadomosci.Add(id.ToString() +' '+ receivedData);
                        
            
            } 
        }
        public static void wysylaj() {
            while (true) {
                while (kolejkaWiadomosci.Count == 0) { }
                string nowaWiadomosc;
                string wiadomosc = kolejkaWiadomosci.ElementAt(0);
                kolejkaWiadomosci.Take();
                string[] words = wiadomosc.Split(' ');
                switch (wiadomosc.Length)
                {
                    case 10: //kolor
                        
                        Uzytkownik temp;
                        polaczenia.TryGetValue(int.Parse(words[0]), out temp);
                        temp.ustawKolor(int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
                        Console.WriteLine("{0} {1} {2}", int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
                        break;
                    
                    case 3:// zakonczenie
                        nowaWiadomosc = words[0].ToString();
                        Byte[] sendBytes2 = Encoding.ASCII.GetBytes(nowaWiadomosc);
                        foreach (Uzytkownik osoba in polaczenia.Values)
                        {
                            udpRysowanie.Send(sendBytes2, sendBytes2.Length, osoba.getAdres());
                        }
                        while(piszacyUzytkownicy.ContainsKey(int.Parse(words[0]))){
                            piszacyUzytkownicy.Remove(int.Parse(words[0]));
                        }
                        break;
                    
                    default:
                        if (!piszacyUzytkownicy.ContainsKey(int.Parse(words[0])))
                        {
                            Uzytkownik chwilowy;
                            String info;
                            polaczenia.TryGetValue(int.Parse(words[0]), out chwilowy);
                            piszacyUzytkownicy.Add(int.Parse(words[0]), int.Parse(words[0]));
                            info = chwilowy.getR().ToString();

                            nowaWiadomosc = words[0].ToString() + ' ' + words[1].ToString() + ' ' + words[2].ToString() + ' ' + chwilowy.getR().ToString() + ' ' + chwilowy.getG().ToString() + ' ' + chwilowy.getB().ToString();
                            


                            Byte[] sendBytes = Encoding.ASCII.GetBytes(nowaWiadomosc);
                            foreach (Uzytkownik osoba in polaczenia.Values)
                            {
                                Console.WriteLine("Info {0}", info);
                                udpRysowanie.Send(sendBytes, sendBytes.Length, osoba.getAdres());
                            }
                        }
                        else
                        {
                            nowaWiadomosc = words[0] + " " + words[1] + ' ' + words[2];


                            Byte[] sendBytes = Encoding.ASCII.GetBytes(nowaWiadomosc);
                            foreach (Uzytkownik osoba in polaczenia.Values)
                            {
                                udpRysowanie.Send(sendBytes, sendBytes.Length, osoba.getAdres());
                            }
                        }
                        break;
                }
            
            
            }
        
        
        }
    }
}
