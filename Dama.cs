using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace DamaDavi
{
    public class DamaSprava
    {
        public static HraciPlocha VytvorLokalniHru(Control panel)
        {
            //vytvor 2 lokalni hrace
            // a pak hraci plochu
            //je to na testovani
            throw new NotImplementedException();
        }

        public static HraciPlocha VytvorSitovouHru(Control panel)
        {
            //vytvor 1 lokalni hrace
            //vytvor 1 sitovy hrac + NET remoting server
            // a pak hraci plochu
            throw new NotImplementedException();
        }


        public static HraciPlocha VytvorKlientaSitoveHry(Control panel, string server)
        {
            //vytvor 1 lokalni hrace
            //vytvor 1 sitovy hrac + NET remoting klienta
            // a pak hraci plochu
            throw new NotImplementedException();
        }
    }

    public class HraciPlocha
    {
        
        public HraciPlocha()
        {

        }

        //sloupec, radek
        public HraciPlocha(Control panel, Hrac hrac1, Hrac hrac2)
        {
            Panel = panel;
            Hrac1 = hrac1;
            Hrac2 = hrac2;

            //ve 2 vnorenych cyklech vyrob vsechny figurky
            for (int i = 0; i < 8; i++)
                for (int z = 0; z < 8; z++)
                {
                    var figurka = new Figurka[i,z];
                    // policko.Barva = ((i + z) % 2);  // 0-bily , 1-Cerny
                    // if (policko.Barva == 1 & i < 3) picture.Image = global::ProgramDama2.Properties.Resources.tmavykamen;
                    if (((i + z) % 2)==1 & i<3)
                    {
                        figurka[i, z].Hrac.Jmeno = "Cerny";
                    }

                    
                }
        }

        public Figurka[,] Sachovnice { get; private set; }

        public Hrac Hrac1 { get; private set; }
        public Hrac Hrac2 { get; private set; }

        protected Control Panel;

        public void Vykresli()
        {
            //v cykle zavola vykresli pre kazdu figurku a vykresli prazdne mista kde Figurka == null

        }


        public Figurka NajdiOznacenouFigurku()
        {
            //najdi oznacenou figurku, kdyz neni vrat null
            throw new NotImplementedException();
        }

        public Figurka NajdiFigurkuPodMysi(int x, int y)
        {
            //najdi figurku pod mysi pomoci kalkulace
            throw new NotImplementedException();
        }
    }

    public abstract class Figurka
    {
        protected Figurka(HraciPlocha hraciPlocha, Control panel, int sloupec, int radek, Hrac hrac)
        {
            HraciPlocha = hraciPlocha;
            Panel = panel;
            Sloupec = sloupec;
            Radek = radek;
            Hrac = hrac;
        }

        public int Sloupec { get; private set; }

        public int Radek { get; private set; }

        public Hrac Hrac { get; private set; }

        public bool Oznacena { get; private set; }

        protected HraciPlocha HraciPlocha;
        protected Control Panel;

        public abstract void Vykresli();

        public abstract bool MuzeTahnout(int sloupec, int radek);

        public void Tahni(int sloupec, int radek)
        {
            //presun figurku na pozici pokud to jde, pokud ne vyhod excepsnu
            //odznac figurku
            
            //pokud si vyhodil protihracovu figurku, tak na ni zavolej vyhod a uprav si skore
            //pokud si v cily, premen za damu
            //zkontroluj jestli neni konec hry
            //zavolej Panel.Invalidate na prekresleni
        }

        public void Vyhod()
        {
            //zavolej vyhod figurku na hraci plose
        }

        public void VymenZaDamu()
        {
            //vytvor novou FigurkuDama a vymen ji za tuhle
        }

        public void OznacFigurku() { }
    }

    public class FigurkaKamen : Figurka
    {
        public FigurkaKamen(HraciPlocha hraciPlocha, Control panel, int sloupec, int radek, Hrac hrac) : base(hraciPlocha, panel, sloupec, radek, hrac)
        {
        }

        public override void Vykresli()
        {
            throw new NotImplementedException();
        }

        public override bool MuzeTahnout(int sloupec, int radek)
        {
            throw new NotImplementedException();
        }
    }

    public class FigurkaDama : Figurka
    {

        public FigurkaDama(HraciPlocha hraciPlocha, Control panel, int sloupec, int radek, Hrac hrac) : base(hraciPlocha, panel, sloupec, radek, hrac)
        {
        }

        public override void Vykresli()
        {
            throw new NotImplementedException();
        }

        public override bool MuzeTahnout(int sloupec, int radek)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Hrac
    {
        protected Hrac(Control panel, string jmeno, HraciPlocha hraciPlocha)
        {
            Panel = panel;
            Jmeno = jmeno;
            HraciPlocha = hraciPlocha;
        }

        public string Jmeno { get; set; }

        public bool JeNaTahu { get; set; }

        public int Score { get; set; }

        protected HraciPlocha HraciPlocha;

        protected Control Panel;

        public abstract void Vykresli();

        public virtual void ProtihracTahnul(Figurka figurka, int sloupec, int radek)
        {

        }
    }

    public class HracLokalni : Hrac
    {
        public HracLokalni(Control panel, string jmeno, HraciPlocha hraciPlocha) : base(panel, jmeno, hraciPlocha)
        {
            panel.MouseClick += Panel_MouseClick;
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            //kdyz je na tahu, najdi figurku pod mysi
            //kdyz neni oznacena figurka, oznac
            //kdyz je oznacena a da se tahnout, tahni
            //informuj protihrace ze jsi tahnul
        }

        public override void Vykresli()
        {
            //vykresli hrace a skore
        }
    }

    public class HracSitovy : Hrac
    {
        public HracSitovy(Control panel, string jmeno, HraciPlocha hraciPlocha) : base(panel, jmeno, hraciPlocha)
        {
        }

        public override void Vykresli()
        {
            //vykresli hrace a skore
        }

        public override void ProtihracTahnul(Figurka figurka, int sloupec, int radek)
        {
            //HracLokal tahnul, posli spravu na server/klienta 

        }

        public void VzdalenyHracTahnul(int sloupec1, int radek1, int sloupec2, int radek2)
        {
            //Obdrzel jsi zpravu ze servru/klienta o tahu

            //najdi figurku na pozici sloupec1, radek1
            //tahni ji na pozici sloupec2, radek2

        }
    }
}
