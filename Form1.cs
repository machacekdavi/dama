using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace ProgramDama2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerujPlochu();  
        }

        Policko[,] HraciPole = new Policko[8, 8];

        // na zacatku hry plni matici pole, ktera odpovida hraci plose jako prvek pole je pouzito tlacitko,
        // ktere si nese vsechny atributy o hraci plose k nasledne dalsi manipulaci
        private void GenerujPlochu()
        {
            for (int i = 0; i < 8; i++)
                for (int z = 0; z < 8; z++)
                {
                    var policko = new Policko();
                    policko.Oznacena = false;
                    policko.Radek = i;
                    policko.Sloupec = z;
                    policko.Barva = ((i + z) % 2);  // 0-bily , 1-Cerny
                    if (policko.Barva == 1 & i < 3) policko.JeKamen = true;
                    if (policko.Barva == 1 & i > 4) policko.JeKamen = true;
                    //policko.Obraz = GenerujObraz(i, z, policko.Barva);
                    var picture = new PictureBox();
                    if (policko.Barva == 0) picture.Image = global::ProgramDama2.Properties.Resources.svetly;
                    else picture.Image = global::ProgramDama2.Properties.Resources.tmavy;

                    if (policko.Barva == 1 & i < 3) picture.Image = global::ProgramDama2.Properties.Resources.tmavykamen;
                    if (policko.Barva == 1 & i > 4) picture.Image = global::ProgramDama2.Properties.Resources.bilykamen;
                    picture.Location = new System.Drawing.Point(z * 75, i * 75);
                    picture.Size = new System.Drawing.Size(75, 75);
                    picture.TabStop = false;
                    picture.Click += policko_Click;
                    HraciPlocha.Controls.Add(picture);
                    picture.Tag = policko;
                    policko.Obraz = picture;
                    HraciPole[i, z] = policko;
                }
            this.LabelHrac.Text = "Hraje hrac Bílý" ;
            this.LabelHrac.Tag = 0;
        }

        // procedura pouzita v GenerujPlocho , slouzi jen pro to aby vygenerovala plochu na zacatku hry,
        // zakladni rozestaveni obrazku i s kameny
        private PictureBox GenerujObraz(int i, int z, int barva)
        {
            var picture = new PictureBox();
            if (barva == 0) picture.Image = global::ProgramDama2.Properties.Resources.svetly;
            else picture.Image = global::ProgramDama2.Properties.Resources.tmavy;

            if (barva == 1 & i < 3) picture.Image = global::ProgramDama2.Properties.Resources.tmavykamen;
            if (barva == 1 & i > 4) picture.Image = global::ProgramDama2.Properties.Resources.bilykamen;
            picture.Location = new System.Drawing.Point(z * 75, i * 75);
            picture.Size = new System.Drawing.Size(75, 75);
            picture.TabStop = false;
            picture.Click += policko_Click;
            HraciPlocha.Controls.Add(picture);
            return picture;
        }

        private void policko_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender; 
            Policko pole = (Policko)picture.Tag;

            if (pole.Barva == 1 & pole.JeKamen == true)
            {
                pole.Oznacena = true;
            }

            string s = "Radek je " + Convert.ToString(pole.Radek)+ " Sloupec je " + Convert.ToString(pole.Sloupec);
            MessageBox.Show(this, s, "Oznameni", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void HracSitovy_Click(object sender, EventArgs e)
        {
            EchoClient.Hlavni();
        }

        private void HracLokalni_Click(object sender, EventArgs e)
        {
            var server = new EchoServer();
            // sem zadat IP pokud je hrac lokalni
            System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse("192.168.1.133");
            server.StartUp(ipaddress, 33223);
        }
    }



    public class Policko
    {
        public int Radek;
        public int Sloupec;
        public PictureBox Obraz;
        public bool JeKamen;
        public int Barva; // 0-bily , 1-Cerny
        public bool Oznacena;
    }

    public class Hrac
    {
        int TahneHrac;  // 0-byli , 1-cerny
    }

    class EchoServer
    {
        Socket s;

        public bool StartUp(IPAddress ip, int port)
        {
            try
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                    ProtocolType.Tcp);
                s.Bind(new IPEndPoint(ip, port));
                s.Listen(10);  // maximal 10 clients in queue
            }
            catch (Exception e) { Console.WriteLine("An error occurred: '{0}'", e); }
            for (;;)
            {
                Communicate(s.Accept());  // waits for connecting clients
            }
        }
        // returns all the received data back to the client
        public void Communicate(Socket clSock)
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (clSock.Receive(buffer) > 0)  // receive data
                    clSock.Send(buffer);  // send back the data
                clSock.Shutdown(SocketShutdown.Both);  // close sockets
                clSock.Close();
            }
            catch (Exception e) { Console.WriteLine("An error occurred: '{0}'", e); }
        }
    }


    class EchoClient
    {

        public static void Hlavni()
        {
            try
            {
                // connect to the server
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(new IPEndPoint(IPAddress.Loopback, 5000));
                s.Send(Encoding.ASCII.GetBytes("This is a test"));  // send the message

                byte[] echo = new byte[1024];
                s.Receive(echo);  // receive the echo message
                Console.WriteLine(Encoding.ASCII.GetString(echo));
            }
            catch (Exception e) { Console.WriteLine("An error occurred: '{0}'", e); }
        }
    }
}

