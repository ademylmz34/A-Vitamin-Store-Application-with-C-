/***************************************************************************************************************************
**                                                 SAKARYA ÜNİVERSİTESİ
**                                         BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKULTESİ
**                                            BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                                           NESNEYE DAYALI PROGRAMLAMA DERSİ
**                                                 2020-2021 BAHAR DÖNEMİ
**
**
**                                            ÖDEV NUMARASI........: ...........
**                                            ÖĞRENCİ ADI..........: ADEM YILMAZ
**                                            ÖĞRENCİ NUMARASI.....: G191210305
**                                            DERSİN ALINDIĞI GRUP.: 2D
**
**
****************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vitamin_Deposu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class Meyve
        {
            private double _agirlik;
            public double Agirlik { get { return _agirlik; } set { _agirlik = value; } }

            private double _vitaminA;
            public double VitaminA { get { return _vitaminA; } set { _vitaminA = value; } }

            private double _vitaminC;
            public double VitaminC { get { return _vitaminC; } set { _vitaminC = value; } }

            private double _verim;
            public double Verim { get { return _verim; } set { _verim = value; } }
            
            public double SonGramaj_Hesapla()
            {
                return Agirlik * (Verim / 100);
            }
            public abstract double VitaminA_Hesapla();
            public abstract double VitaminC_Hesapla();

        }
        abstract class KatiMeyveler : Meyve
        {

            private double _püregramaj;
            public double Püregramaj { get { return _püregramaj; } set { _püregramaj = value; } }

            public KatiMeyveler(double agirlik, double verim)
            {
                Agirlik = agirlik;
                Verim = verim;
                Püregramaj = SonGramaj_Hesapla();
                VitaminA = VitaminA_Hesapla();
                VitaminC = VitaminC_Hesapla();
            }


        }
        abstract class SiviMeyveler : Meyve
        {

            private double _sivigramaj;
            public double Sivigramaj { get { return _sivigramaj; } set { _sivigramaj = value; } }
            public SiviMeyveler(double agirlik, double verim)
            {
                Agirlik = agirlik;
                Verim = verim;
                Sivigramaj = SonGramaj_Hesapla();
                VitaminA = VitaminA_Hesapla();
                VitaminC = VitaminC_Hesapla();
            }


        }
        class Portakal : SiviMeyveler
        {

            public Portakal(double agirlik, double verim) : base(agirlik, verim)
            {

            }

            public override double VitaminA_Hesapla()
            {
                return SonGramaj_Hesapla() * 225 / 100;

            }
            public override double VitaminC_Hesapla()
            {
                return SonGramaj_Hesapla() * 45 / 100;
            }


        }
        class Mandalina : SiviMeyveler
        {

            public Mandalina(double agirlik, double verim) : base(agirlik, verim)
            {

            }
            public override double VitaminA_Hesapla()
            {
                return SonGramaj_Hesapla() * 681 / 100;

            }
            public override double VitaminC_Hesapla()
            {
                return SonGramaj_Hesapla() * 26 / 100;
            }


        }
        class Greyfurt : SiviMeyveler
        {

            public Greyfurt(double agirlik, double verim) : base(agirlik, verim)
            {

            }
            public override double VitaminA_Hesapla()
            {
                return SonGramaj_Hesapla() * 3 / 100;

            }
            public override double VitaminC_Hesapla()
            {
                return SonGramaj_Hesapla() * 44 / 100;
            }


        }
        class Elma : KatiMeyveler
        {

            public Elma(double agirlik, double verim) : base(agirlik, verim)
            {

            }
            public override double VitaminA_Hesapla()
            {
                return SonGramaj_Hesapla() * 54 / 100;
            }

            public override double VitaminC_Hesapla()
            {
                return SonGramaj_Hesapla() * 5 / 100;
            }


        }
        class Armut : KatiMeyveler
        {


            public Armut(double agirlik, double verim) : base(agirlik, verim)
            {

            }
            public override double VitaminA_Hesapla()
            {
                return SonGramaj_Hesapla() * 25 / 100;

            }
            public override double VitaminC_Hesapla()
            {
                return SonGramaj_Hesapla() * 5 / 100;
            }


        }
        class Çilek : KatiMeyveler
        {
            public Çilek(double agirlik, double verim) : base(agirlik, verim)
            {

            }
            public override double VitaminA_Hesapla()
            {
                return SonGramaj_Hesapla() * 12 / 100;

            }
            public override double VitaminC_Hesapla()
            {
                return SonGramaj_Hesapla() * 60 / 100;
            }
        }

        string msg = "";
        double vitaminAtoplam = 0, vitaminCtoplam = 0;
        public void yazdir(string meyveadi, double agirlik, double verim, double gramaj, double vitaminA, double vitaminC)
        {

            msg = meyveadi + " için değerler\n";
            msg += "Normal Ağırlık :" + agirlik + " gr" + "\n";
            msg += "Verim : %" + verim + "\n";
            msg += "Son Gramaj :" + gramaj + " gr" + "\n";
            msg += "Vitamin A :" + vitaminA + " IU" + "\n";
            msg += "Vitamin C :" + vitaminC + " mg";
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblmeyveadi.Text = "";
            lst_meyveadlari.Items.Add(meyveadi);
            lst_vitaminAdegerleri.Items.Add(vitaminA.ToString());
            lst_vitaminCdegerleri.Items.Add(vitaminC.ToString());
            vitaminAtoplam += vitaminA;
            vitaminCtoplam += vitaminC;
            lbl_vitaminAtoplam.Text = vitaminAtoplam.ToString() + " IU";
            lbl_vitaminCtoplam.Text = vitaminCtoplam.ToString() + " mg";

            if (timerstop == true)
            {
                btn_hesapla.Enabled = false;
                picturebox.Image = null;
            }
            else
            {
                meyveTüret();
            }


        }

        List<KatiMeyveler> katimeyveler;
        List<SiviMeyveler> sivimeyveler;
        int önceki;
        string[] Meyve_isimleri = { "GREYFURT", "ELMA", "ÇİLEK", "PORTAKAL", "ARMUT", "MANDALİNA" };

        public void meyveTüret()
        {
            btn_hesapla.Enabled = false;
            rdn_katimeyvesikacagi.Checked = false;
            rdn_sivimeyvesikacagi.Checked = false;
            rdn_katimeyvesikacagi.Enabled = true;
            rdn_sivimeyvesikacagi.Enabled = true;

            int meyveindis;
            Random rastgele = new Random();
            double agirlik, verim;
            agirlik = rastgele.Next(70, 120);
            meyveindis = rastgele.Next(0, Meyve_isimleri.Length);

            if (önceki == meyveindis) //her seferinde bir öncekinden farklı bir meyve üretecek aynı meyveyi peş peşe üretmeyecek.
            {
                while (önceki == meyveindis)
                {
                    meyveindis = rastgele.Next(0, Meyve_isimleri.Length);
                    if (önceki != meyveindis) { break; }
                }

            }

            önceki = meyveindis;
            lblmeyveadi.Text = Meyve_isimleri[meyveindis].ToString();


            if (lblmeyveadi.Text == "PORTAKAL" || lblmeyveadi.Text == "MANDALİNA" || lblmeyveadi.Text == "GREYFURT")
            {
                sivimeyveler = new List<SiviMeyveler>();
                verim = rastgele.Next(30, 70);

                if (lblmeyveadi.Text == "PORTAKAL")
                {
                    picturebox.ImageLocation = "Resimler\\portakal.jpg";
                    sivimeyveler.Add(new Portakal(agirlik, verim));
                }

                if (lblmeyveadi.Text == "MANDALİNA")
                {
                    picturebox.ImageLocation = "Resimler\\mandalina.jpg";
                    sivimeyveler.Add(new Mandalina(agirlik, verim));
                }

                if (lblmeyveadi.Text == "GREYFURT")
                {
                    picturebox.ImageLocation = "Resimler\\greyfurt.jpg";
                    sivimeyveler.Add(new Greyfurt(agirlik, verim));
                }
            }

            else
            {
                katimeyveler = new List<KatiMeyveler>();
                verim = rastgele.Next(80, 95);

                if (lblmeyveadi.Text == "ELMA")
                {
                    picturebox.ImageLocation = "Resimler\\elma.jpg";
                    katimeyveler.Add(new Elma(agirlik, verim));
                }

                if (lblmeyveadi.Text == "ARMUT")
                {
                    picturebox.ImageLocation = "Resimler\\armut.jpg";
                    katimeyveler.Add(new Armut(agirlik, verim));
                }

                if (lblmeyveadi.Text == "ÇİLEK")
                {
                    picturebox.ImageLocation = "Resimler\\çilek.jpg";
                    katimeyveler.Add(new Çilek(agirlik, verim));
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_yenioyun.Enabled = false;
            btn_hesapla.Enabled = false;
            rdn_katimeyvesikacagi.Enabled = false;
            rdn_sivimeyvesikacagi.Enabled = false;
        }

        private void rdn_katimeyvesikacagi_CheckedChanged(object sender, EventArgs e)
        {
            btn_hesapla.Enabled = true;
        }

        private void rdn_sivimeyvesikacagi_CheckedChanged(object sender, EventArgs e)
        {
            btn_hesapla.Enabled = true;
        }

        int sayac = 60;
        bool timerstop;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            lbl_sayac.Text = sayac.ToString();
            if (sayac == 0)
            {
                btn_yenioyun.Enabled = true;
                timerstop = true;
                timer1.Stop();
                MessageBox.Show("SÜRENİZ DOLMUŞTUR!!!", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdn_katimeyvesikacagi.Enabled = false;
                rdn_sivimeyvesikacagi.Enabled = false;
                btn_hesapla.Enabled = false;
                lblmeyveadi.Text = "";
                picturebox.Image = null;
            }
        }

        double sivigramajtoplam = 0, püregramajtoplam = 0;

        private void btn_basla_Click(object sender, EventArgs e)
        {
            timer1.Start();
            meyveTüret();
            btn_basla.Enabled = false;
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            if (lblmeyveadi.Text == "PORTAKAL" || lblmeyveadi.Text == "MANDALİNA" || lblmeyveadi.Text == "GREYFURT")
            {

                foreach (SiviMeyveler siviMeyve in sivimeyveler)
                {
                    if (siviMeyve.GetType().Name.ToLower() == lblmeyveadi.Text.ToLower() && rdn_sivimeyvesikacagi.Checked)
                    {
                        yazdir(siviMeyve.GetType().Name, siviMeyve.Agirlik, siviMeyve.Verim, siviMeyve.Sivigramaj, siviMeyve.VitaminA, siviMeyve.VitaminC);
                        sivigramajtoplam += siviMeyve.Sivigramaj;
                        lst_sividegeri.Items.Add(siviMeyve.Sivigramaj.ToString());
                        lst_püredegeri.Items.Add("0");
                        lbl_sivigramajtoplam.Text = sivigramajtoplam.ToString() + " gr";

                    }
                }

            }
            else
            {

                foreach (KatiMeyveler katiMeyve in katimeyveler)
                {
                    if (katiMeyve.GetType().Name.ToLower() == lblmeyveadi.Text.ToLower() && rdn_katimeyvesikacagi.Checked)
                    {
                        yazdir(katiMeyve.GetType().Name, katiMeyve.Agirlik, katiMeyve.Verim, katiMeyve.Püregramaj, katiMeyve.VitaminA, katiMeyve.VitaminC);
                        püregramajtoplam += katiMeyve.Püregramaj;
                        lst_püredegeri.Items.Add(katiMeyve.Püregramaj.ToString());
                        lst_sividegeri.Items.Add("0");
                        lbl_püregramajtoplam.Text = püregramajtoplam.ToString() + " gr";

                    }
                }

            }
        }

        private void btn_yenioyun_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
