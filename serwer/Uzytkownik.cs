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
    class Uzytkownik
    {
        //private IPAddress ip{get; set;}
        private int id { get; set;}
        private bool podlaczony
        {
            get;
            set;
        }
        private IPEndPoint adres { get; set; }
        private int R { get; set; }
        private int G { get; set; }
        private int B { get; set; }

        public Uzytkownik(int numer, IPEndPoint koniec) {
            id = numer;
            adres = koniec;
            podlaczony = true;
            R = 0;
            G = 0;
            B = 0;
        
        }
        public void setPodlaczony(bool wartosc){
                podlaczony=wartosc;
            }
        public IPEndPoint getAdres() { return adres; }
        public int getID() { return id; }
        public int getR() { return R; }
        public int getG() { return G; }
        public int getB() { return B; }

        public void ustawKolor(int noweR, int noweG, int noweB) {
            R = noweR;
            G = noweG;
            B = noweB;        
        }

        
    }
}
