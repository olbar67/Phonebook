using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        string[,] book;
        string fn, n, sn, ph, m, ad, more, snomer = "";
        internal static int save;

        public Form2(string[,] Book, int index)
        {
            InitializeComponent();
            book = Book;
            if (index >= 0)
                Change(index);
            else Create();
            
        }
        public void Change(int i)
        {
            Text = "Изменить контакт";
            fn = textBox1.Text = book[i, 0];
            n = textBox2.Text = book[i, 1];
            sn = textBox3.Text = book[i, 2];
            ph = textBox4.Text = book[i, 3];
            
            m = textBox5.Text = book[i, 4];
            ad = textBox6.Text = book[i, 5];
            more = textBox7.Text = book[i, 6];
        }
        public void Create()
        {
            Text = "Создать контакт";
            fn = n = sn = ph = m = ad = more = "";
        }

                
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = "";
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = "";
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = "";
        }        
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char E = e.KeyChar;
            label8.Text = "";
            if ((E >= '0' && E <= '9') || E == '+' || E == (char)Keys.Back || E == (char)Keys.Delete || E == (char)Keys.Home || E == (char)Keys.End)
                return;
            else
                e.Handled = true;
            
            
        }        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            snomer = Nomer(textBox4.Text);
            string nomer = Testing();
            textBox4.Text = nomer;
            if (nomer.Length >= 2 && ((nomer[nomer.Length-1]=='('&& nomer[nomer.Length - 2] == ' ')|| (nomer[nomer.Length - 1] == ' ' && nomer[nomer.Length - 2] == ')')))
                textBox4.SelectionStart = textBox4.Text.Length-2;
            else textBox4.SelectionStart = textBox4.Text.Length;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = "";
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = "";
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = "";
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (textBox2.Text != "" || textBox1.Text != "")
                {
                    fn = Form1.fname2 = textBox1.Text;
                    n = Form1.name2 = textBox2.Text;
                    sn = Form1.sname2 = textBox3.Text;
                    ph = Form1.phone2 = textBox4.Text;
                    m = Form1.mail2 = textBox5.Text;
                    ad = Form1.adress2 = textBox6.Text;
                    more = Form1.more2 = textBox7.Text;
                    label8.Text = "Изменения сохранены";


                }
                else MessageBox.Show("Введите фамилию, либо имя!");
            }
            else MessageBox.Show("Введите телефонный номер!");
        }              
        private void button3_Click(object sender, EventArgs e)
        {
            if (fn != textBox1.Text || n != textBox2.Text || sn != textBox3.Text || ph != textBox4.Text || m != textBox5.Text || ad != textBox6.Text || more != textBox7.Text)
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();

            }
            else {
                Form1.fname2 = fn;
                Form1.name2 = n;
                Form1.sname2 = sn;
                Form1.phone2 = ph;
                Form1.mail2 = m;
                Form1.adress2 = ad;
                Form1.more2 = more;
                Close(); }
            if (save == 1)
            {
                fn = Form1.fname2 = textBox1.Text;
                n = Form1.name2 = textBox2.Text;
                sn = Form1.sname2 = textBox3.Text;
                ph = Form1.phone2 = textBox4.Text;
                m = Form1.mail2 = textBox5.Text;
                ad = Form1.adress2 = textBox6.Text;
                more = Form1.more2 = textBox7.Text;
                Close();
            }
            else if (save == 2) {
                Form1.fname2 = fn;
                Form1.name2 = n;
                Form1.sname2 = sn;
                Form1.phone2 = ph;
                Form1.mail2 = m;
                Form1.adress2 = ad;
                Form1.more2 = more;
                Close(); }
            
        }


        public string Nomer(string text)
        {
            string nomer = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '-' && text[i] != ' ' && text[i] != '(' && text[i] != ')') nomer = nomer + text[i];

            }
            return nomer;
        }
        public string Testing()
        {
            string nomer = "";
            int l = snomer.Length;
            if (l > 0)
            {
                if (snomer[0] == '8')
                {
                    if (l == 3) nomer = nomer + snomer[0] + snomer[1] + "-" + snomer[2];
                    else if (l >= 4 && l <= 11)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (i == 1) nomer = nomer + " (";

                            nomer = nomer + snomer[i];
                            if (i == 3) nomer = nomer + ") ";
                        }
                        if (l > 4)
                            for (int i = 4; i < l; i++)
                            {
                                if (i == 7 || i == 9) nomer = nomer + "-";
                                nomer = nomer + snomer[i];
                            }

                    }
                    else nomer = snomer;
                }
                else if (l >= 2 && snomer[0] == '+' && snomer[1] == '7')
                {
                    if (l == 3) nomer = "+7 " + snomer[2];
                    else if (l == 4) nomer = "+7 " + snomer[2] + snomer[3];
                    else if (l >= 5 && l <= 12)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            nomer = nomer + snomer[i];
                            if (i == 1) nomer = nomer + " (";
                            if (i == 4) nomer = nomer + ") ";
                        }
                        if (l > 5)
                        {
                            for (int i = 5; i < l; i++)
                            {
                                if (i == 8 || i == 10) nomer = nomer + "-";
                                nomer = nomer + snomer[i];
                            }
                        }
                    }
                    else nomer = snomer;
                }
                else
                {
                    if (l == 2 || l == 3)
                    {
                        nomer = snomer[0] + "-" + snomer[1];
                        if (l == 3) nomer = nomer + snomer[2];
                    }
                    else if (l >= 4 && l <= 5)
                    {
                        for (int i = 0; i < l; i++)
                        {
                            nomer = nomer + snomer[i];
                            if (i == 0 || i == 2) nomer = nomer + "-";
                        }
                    }
                    else if (l == 6)
                    {
                        for (int i = 0; i < l; i++)
                        {
                            nomer = nomer + snomer[i];
                            if (i == 1 || i == 3) nomer = nomer + "-";
                        }
                    }
                    else if (l == 7)
                    {
                        for (int i = 0; i < l; i++)
                        {
                            nomer = nomer + snomer[i];
                            if (i == 2 || i == 4) nomer = nomer + "-";
                        }
                    }
                    else if (l >= 8 && l <= 10)
                    {
                        for (int i = 0; i < l; i++)
                        {
                            if (i == 6 || i == 8) nomer = nomer + "-";
                            if (i == 0) nomer = " (";
                            nomer = nomer + snomer[i];
                            if (i == 2) nomer = nomer + ") ";

                        }
                    }
                    else nomer = snomer;
                }
            }
            return nomer;

        }
    }
}
