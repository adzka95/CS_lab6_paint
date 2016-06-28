using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Form1 : Form
    {
        private Pen pen;
        private Graphics graphics;
        private Point poczatkowy = new Point(0, 0);
        private Point koncowy = new Point(0, 0);
        private bool podlaczony;
        private bool pisze;
        private string adres;
        private int port;
        private UdpClient klient;
        private int id;
        private int portRysowania = 4321;
        private static Dictionary<int, Malarze> piszacyUzytkownicy = new Dictionary<int,Malarze>();
        

        public Form1()
        {
            InitializeComponent();
            podlaczony = false;
            pisze = false;
            pen = new Pen(System.Drawing.Color.Black, 5);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
        }

        private void klik(object sender, MouseEventArgs e)
        {
            pisze = true;
            poczatkowy.X = e.Location.X+256;
            poczatkowy.Y = e.Location.Y+256;
        }

        private void rusza(object sender, MouseEventArgs e)
        {
            if (pisze) {
                koncowy.X = e.Location.X+256;
                koncowy.Y = e.Location.Y+256;
                string wiadomosc = koncowy.X.ToString()+' '+koncowy.Y.ToString();
                Byte[] sendBytes = Encoding.ASCII.GetBytes(wiadomosc);
                if(podlaczony)
                    klient.Send(sendBytes, sendBytes.Length, adres, portRysowania);
                if(!podlaczony)
                    graphics.DrawLine(pen, poczatkowy.X, poczatkowy.Y, koncowy.X, koncowy.Y);
                pictureBox1.Invalidate();
                poczatkowy.X = koncowy.X;
                poczatkowy.Y = koncowy.Y;
                
            
            }
        }

        private void konczy(object sender, MouseEventArgs e)
        {
            pisze = false;
            string wiadomosc = id.ToString();
            Byte[] sendBytes = Encoding.ASCII.GetBytes(wiadomosc);
            if (podlaczony)
                klient.Send(sendBytes, sendBytes.Length, adres, portRysowania);
        }

       

        private void polaczDoSerwera(object sender, EventArgs e)
        {
            textBox3.Text = "Podlaczono";
            if (podlaczony)
                return;
            adres = adresIP.Text;
            try
            {
                port = int.Parse(numerPortu.Text);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Zly format portu");
                return;
            }
            klient = new UdpClient();
            podlaczony = true;
            string wiadomosc= "polaczono";
            Byte[] sendBytes = Encoding.ASCII.GetBytes(wiadomosc);
            klient.Send(sendBytes, sendBytes.Length, adresIP.Text,port);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Byte[] receiveBytes = klient.Receive(ref RemoteIpEndPoint);
            string receivedData = Encoding.ASCII.GetString(receiveBytes);
            id = int.Parse(receivedData);
            new Task(() => zacznijOczekiwanie()).Start();

        }
        
        private void zacznijOczekiwanie() {
            while (true)
            {
                sprawdzWiadomosc();
            }
        }

        private void sprawdzWiadomosc() {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Byte[] receiveBytes = klient.Receive(ref RemoteIpEndPoint);
            
            string receivedData = Encoding.ASCII.GetString(receiveBytes);
            Console.WriteLine(receivedData);
            Console.WriteLine(receiveBytes.Length);
            string[] words = receivedData.Split(' ');
            Console.WriteLine(receivedData);
            switch (receivedData.Length) { 
                case 17:
                    Malarze nowy2 = new Malarze();
                        nowy2.ustawPoczatek(int.Parse(words[1])-256, int.Parse(words[2])-256);
                        nowy2.ustawKolor(int.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]));
                        piszacyUzytkownicy.Add(int.Parse(words[0]), nowy2);
                    break;
                case 1:
                    piszacyUzytkownicy.Remove(int.Parse(words[0]));
                    break;
                case 9:
                    if (!piszacyUzytkownicy.ContainsKey(int.Parse(words[0])))
                    {
                        Malarze nowy = new Malarze();
                        nowy.ustawPoczatek(int.Parse(words[1]) - 256, int.Parse(words[2]) - 256);
                        piszacyUzytkownicy.Add(int.Parse(words[0]), nowy);
                    }
                    else
                    {
                        Malarze temp;
                        piszacyUzytkownicy.TryGetValue(int.Parse(words[0]), out temp);
                        Pen pioro2 = new Pen(Color.FromArgb(temp.getR(), temp.getG(), temp.getB()), 5);
                        graphics.DrawLine(pioro2, temp.getPoczatekX(), temp.getPoczatekY(), int.Parse(words[1])-256, int.Parse(words[2])-256);
                        temp.ustawPoczatek(int.Parse(words[1])-256, int.Parse(words[2])-256);
                        pictureBox1.Invalidate();
                    
                    }
                    break;
                default:
                    Console.WriteLine("Tuuuuu! {0}", receivedData.Length);
                    Console.WriteLine( receivedData);
                    break;
            
            }


           // zacznijOczekiwanie();
        }

        private void odlaczOdSerwera(object sender, EventArgs e)
        {
            textBox3.Text = "Nie podlaczono";
            podlaczony = false;
            string wiadomosc = id.ToString();
            Byte[] sendBytes = Encoding.ASCII.GetBytes(wiadomosc);
            klient.Send(sendBytes, sendBytes.Length, adresIP.Text, port);
        }

        private void ustawCzarny(object sender, EventArgs e)
        {
            ustawKolor(Color.Black);
        }
        private void ustawKolor(Color kolor) {
            pen = new Pen(kolor, 5);
            if (podlaczony)
            {
                string wiadomosc=kolor.R.ToString() + ' ' + kolor.G.ToString() + ' ' + kolor.B.ToString()+' ';
                Byte[] sendBytes = Encoding.ASCII.GetBytes(wiadomosc);
                klient.Send(sendBytes, sendBytes.Length, adres, portRysowania);
            }        
        }

        private void ustawCzerwony(object sender, EventArgs e)
        {
            ustawKolor(Color.Red);
        }
    }
}
