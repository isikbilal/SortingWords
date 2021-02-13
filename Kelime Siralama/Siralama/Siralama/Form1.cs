        ﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Siralama
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //HASAN WAS HERE
        private void button1_Click(object sender, EventArgs e)
        {
            string[] kelimeler = textBox1.Text.Split(' ');
            listBox1.Items.AddRange(kelimeler);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            StreamReader oku;
     
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Text Dosyası |*.txt";
            file.Title=("Txt Dosyası Seçme Ekranı");

            if (file.ShowDialog() == DialogResult.OK)
            {

                oku = File.OpenText(file.FileName);
                string yazi;

                while ((yazi = oku.ReadLine()) != null)
                {
                    listBox1.Items.Add(yazi.ToString());
                }
                oku.Close();
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Text Dosyası |*.txt";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
               
                StreamWriter yaz = new StreamWriter(savefile.FileName);

                for(int i=0;i<listBox1.Items.Count;i++)
                {
                    yaz.WriteLine(listBox1.Items[i].ToString());
                }

                yaz.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblsay.Text = listBox1.Items.Count.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int itemsayi = listBox1.Items.Count;
            int sayac = 0;
            string[] kelimeler = { };
            string[] kelimeler2 = new string[1000];
            for (int i = 0; i < itemsayi; i++)
            {
                kelimeler = listBox1.Items[i].ToString().Split(' ');
                foreach (string kelime in kelimeler)
                {

                    kelimeler2[sayac] = kelime;
                    sayac++;
                }

            }
            listBox1.Items.Clear();
            for (int i = 0; i < kelimeler2.Length; i++)
            {
                for (int j = i + 1; j < kelimeler2.Length; j++)
                {

                    int sonuc = String.Compare(kelimeler2[i], kelimeler2[j]);
                    if (sonuc < 0) { }

                    else if (sonuc > 0)
                    {
                        string tut = kelimeler2[i];
                        kelimeler2[i] = kelimeler2[j];
                        kelimeler2[j] = tut;
                    }


                }

            }

            foreach (string kelime in kelimeler2)
            {
                if (kelime == null) { }
                else
                {
                    listBox1.Items.Add(kelime);
                }
            }
        }
    }
}
