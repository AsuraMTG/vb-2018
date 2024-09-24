using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VB
{
    public partial class Form1 : Form
    {
        



        public struct listaElemek
        {
            public string varos;
            public string nev1;
            public string nev2;
            public int ferohely;
        }
        public Form1()
        {
            InitializeComponent();
        }

        public listaElemek vb2018Feltoltese = new listaElemek();
        public List<listaElemek> vb2018 = new List<listaElemek>();

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream folyam = new FileStream("vb2018.txt", FileMode.Open);
            StreamReader olvas = new StreamReader(folyam);

            string elso = olvas.ReadLine();
            string[] resz;

            while (!olvas.EndOfStream)
            {
                elso = olvas.ReadLine();

                resz = elso.Split(';');
                vb2018Feltoltese.varos = resz[0];
                vb2018Feltoltese.nev1 = resz[1];
                vb2018Feltoltese.nev2 = resz[2];
                vb2018Feltoltese.ferohely = Convert.ToInt32(resz[3]);
                vb2018.Add(vb2018Feltoltese);
            }

            label1.Text += $"3. feladat: {vb2018.Count}\n";

            int seged1 = vb2018[0].ferohely;
            int seged2 = 0;
            for (int i = 0; i < vb2018.Count; i++)
            {
                if (seged1 < vb2018[i].ferohely)
                {
                    seged2 = i; seged1 = vb2018[i].ferohely;
                }
            }

            label1.Text += $"4. feladat: {vb2018[seged2].varos}, {vb2018[seged2].nev1}, {vb2018[seged2].nev2}, {vb2018[seged2].ferohely}\n";
            
            double seged3 = 0;
            for (int i = 0; i < vb2018.Count; i++)
            {
                seged3 += vb2018[i].ferohely;
            }
            seged3 = seged3 / vb2018.Count;

            label1.Text += $"5. feladat: {seged3.ToString("0.0")}\n";

            seged1 = 0;
            for (int i = 0; i < vb2018.Count; i++)
            {
                if (vb2018[i].nev2 != "n.a.")
                {
                    seged1++;
                }
            }
            label1.Text += $"6. feladat: {seged1}\n";

            
        }

        bool gombNyomva = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 3)
            {
                label2.Text = "TÚL RÖVID A MEGADOTT NÉV!";
            }
            else
            {
                label2.Text = "";
                label1.Text += $"7. feladat: {textBox1.Text}\n";
                gombNyomva = true;

                int seged1 = 0;
                if (gombNyomva == true)
                {
                    for (int i = 0; i < vb2018.Count; i++)
                    {
                        if (vb2018[i].varos.ToLower() == textBox1.Text.ToLower())
                        {
                            label1.Text += $"8. feladat: {textBox1.Text}-ban zajlanak meccsek!\n";
                            seged1 = 1;
                            break;
                        }
                    }
                    if (seged1 == 0)
                    {
                        label1.Text += $"8. feladat: {textBox1.Text}-ban nem zajlanak meccsek!\n";
                    }
                }
            }
        }
    }
}
