using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace lab6v2
{
    class Malarze
    {
        private int poczatekX { get; set; }
        private int poczatekY { get; set; }
        private int koniecX { get; set; }
        private int koniecY { get; set; }
        private int R { get; set; }
        private int G { get; set; }
        private int B { get; set; }
        private Pen pioro;

        public Malarze() { 
            poczatekX =-1;
            poczatekY =-1;
            koniecX =-1;
            koniecY = -1;
            pioro = new Pen(Color.Black, 5);
        
        }
        public int getR() { return R; }
        public int getG() { return G; }
        public int getB() { return B; }
        public int getPoczatekX() { return poczatekX; }
        public int getPoczatekY() { return poczatekY; }
        public int getKoniecX() { return koniecX; }
        public int getKoniecY() { return koniecY; }

        public void ustawPoczatek(int nX, int nY)
        {
            poczatekX = nX;
            poczatekY = nY;
        }
        public void ustawKoniec(int nX, int nY)
        {
            koniecX = nX;
            koniecY = nY;
        }
        public void ustawKolor(int noweR, int noweG, int noweB)
        {
            R = noweR;
            G = noweG;
            B = noweB;
            pioro = new Pen(Color.FromArgb(R, G, B), 5);
        }
        public Pen getPioro() {
            return pioro;
        }
        
        
        }
    
}
