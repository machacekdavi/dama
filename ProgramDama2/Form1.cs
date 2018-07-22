using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        // procedura pouzita v GenerujPlocho , slouzi jen pro to aby vygenerovala plochu na zacatku hry,
        // zakladni rozestaveni obrazku i s kameny
        private PictureBox GenerujObraz(int i,int z, int barva)
        {
            var picture = new PictureBox();
            if (barva == 0)  picture.Image = global::ProgramDama2.Properties.Resources.svetly; 
            else picture.Image = global::ProgramDama2.Properties.Resources.tmavy;

            if (barva == 1 & i<3) picture.Image = global::ProgramDama2.Properties.Resources.tmavykamen;
            if (barva == 1 & i > 4) picture.Image = global::ProgramDama2.Properties.Resources.bilykamen;
            picture.Location = new System.Drawing.Point(z*75, i*75);
            picture.Size = new System.Drawing.Size(75, 75);
            picture.TabStop = false;
            picture.Click += policko_Click;
            HraciPlocha.Controls.Add(picture);
            return picture;
        }

        private void policko_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender; //sender je vzdy tlacitko co vygenerovalo udalost, akorat ho musime pretypovat

            //tady manipulace s polem

            //Policko pole = new Policko();
            //pole = picture.Tag;
            // picture.Tag =
            // Policko pole = ;
            MessageBox.Show(this, Convert.ToString(picture.Tag), "Oznameni", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Hraj()
        {

        }

    }



    public class Policko
    {
        public int Radek;
        public int Sloupec;
        public PictureBox Obraz;
        public bool JeKamen;
        public int Barva; // 0-bily , 1-Cerny
    }

    

}
