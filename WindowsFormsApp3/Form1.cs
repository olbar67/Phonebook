using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        internal static string fname2, name2, sname2, phone2, mail2, adress2, more2;
        int count;
        string[,] Book;
        static int sort = 3;
        int b_index=-1;
        public Form1()
        {
            InitializeComponent();
            Vvod_Array();
            Details();
            Info_List(sort);
            
        }

        public void Details()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Имя", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Телефон", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("Доп. информация", 180, HorizontalAlignment.Center);
        }
        public void Info_List(int sort)
        {

            Sort(sort);
            for (int i = 0; i < count; i++)
            {
                string fio = "", phone, dop;
                if ((sort == 1) || (sort == 3))
                {
                    if (Book[i, 0] == "") fio = Book[i, 1];
                    else fio = Book[i, 0] + " " + Book[i, 1];
                }
                if (sort == 2)
                {
                    if (Book[i, 1] == "") fio = Book[i, 0];
                    else fio = Book[i, 1] + " " + Book[i, 0];
                }
                dop = Book[i, 2];
                phone = Book[i, 3];
                ListViewItem zapis = new ListViewItem(fio);
                zapis.SubItems.Add(phone);
                zapis.SubItems.Add(dop);
                listView1.Items.Add(zapis);

            }
        }
        
        
        public void Vvod_Array()
        {
            StreamReader c = new StreamReader("FName.txt");
            count = 0;
            while (true)
            {
                string temp = c.ReadLine();
                if ((temp == null) || (temp == "")) break;
                count++;
            }
            Book = new string[count, 7];
            c.Close();
            label9.Text = Convert.ToString(count);

            StreamReader fn = new StreamReader("FName.txt");
            StreamReader n = new StreamReader("Name.txt");
            StreamReader sn = new StreamReader("SName.txt");
            StreamReader ph = new StreamReader("Phone.txt");
            StreamReader ad = new StreamReader("Adress.txt");
            StreamReader m = new StreamReader("Mail.txt");
            StreamReader more = new StreamReader("More.txt");

            for (int i = 0; i < count; i++)
            {
                string temp = fn.ReadLine();
                if (temp != " ")
                    Book[i, 0] = temp;
                else Book[i, 0] = "";


                temp = n.ReadLine();
                if (temp != " ")
                    Book[i, 1] = temp;
                else Book[i, 1] = "";


                temp = sn.ReadLine();
                if (temp != " ")
                    Book[i, 2] = temp;
                else Book[i, 2] = "";

                temp = ph.ReadLine();
                if (temp != " ")
                    Book[i, 3] = temp;
                else Book[i, 3] = "";

                temp = m.ReadLine();
                if (temp != " ")
                    Book[i, 4] = temp;
                else Book[i, 4] = "";

                temp = ad.ReadLine();
                if (temp != " ")
                    Book[i, 5] = temp;
                else Book[i, 5] = "";

                temp = more.ReadLine();
                if (temp != " ")
                    Book[i, 6] = temp;
                else Book[i, 6] = "";
            }
            fn.Close();
            n.Close();
            sn.Close();
            ph.Close();
            m.Close();
            ad.Close();
            more.Close();
        }
        public void Vivod_Array(int str) {
            StreamWriter fn = new StreamWriter("FName.txt");
            StreamWriter n = new StreamWriter("Name.txt");
            StreamWriter sn = new StreamWriter("SName.txt");
            StreamWriter ph = new StreamWriter("Phone.txt");
            StreamWriter m = new StreamWriter("Mail.txt");
            StreamWriter ad = new StreamWriter("Adress.txt");
            StreamWriter more = new StreamWriter("More.txt");

            for (int i = 0; i < str; i++)
            {
                if (Book[i, 0] != "") fn.WriteLine(Book[i, 0]);
                else fn.WriteLine(" ");

                if (Book[i, 1] != "") n.WriteLine(Book[i, 1]);
                else n.WriteLine(" ");

                if (Book[i, 2] != "") sn.WriteLine(Book[i, 2]);
                else sn.WriteLine(" ");

                if (Book[i, 3] != "") ph.WriteLine(Book[i, 3]);
                else ph.WriteLine(" ");

                if (Book[i, 4] != "") m.WriteLine(Book[i, 4]);
                else m.WriteLine(" ");

                if (Book[i, 5] != "") ad.WriteLine(Book[i, 5]);
                else ad.WriteLine(" ");

                if (Book[i, 6] != "") more.WriteLine(Book[i, 6]);
                else more.WriteLine(" ");
            }
            fn.Close();
            n.Close();
            sn.Close();
            ph.Close();
            m.Close();
            ad.Close();
            more.Close();
        }
        public void Sort(int sort)
        {

            for (int repeat = 0; repeat < count; repeat++)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    sbyte zamena = 0;
                    if (sort == 1)
                    {
                        if ((Book[i, 0] != "") && (Book[i + 1, 0] != ""))
                        {
                            if (String.Compare(Book[i, 0], Book[(i + 1), 0], true) > 0)
                                zamena++;
                        }
                        else if ((Book[i, 0] == "") && (Book[i + 1, 0] != ""))
                        {
                            zamena++;
                        }
                        else if ((Book[i, 0] == "") && (Book[i + 1, 0] == ""))
                        {
                            if (String.Compare(Book[i, 1], Book[(i + 1), 1], true) > 0)
                                zamena++;
                        }
                    }
                    if (sort == 2)
                    {
                        if ((Book[i, 1] != "") && (Book[i + 1, 1] != ""))
                        {
                            if (String.Compare(Book[i, 1], Book[(i + 1), 1], true) > 0)
                                zamena++;
                        }
                        else if ((Book[i, 1] == "") && (Book[i + 1, 1] != ""))
                        {
                            zamena++;
                        }
                        else if ((Book[i, 1] == "") && (Book[i + 1, 1] == ""))
                        {
                            if (String.Compare(Book[i, 0], Book[(i + 1), 0], true) > 0)
                                zamena++;
                        }
                    }
                    else if (sort == 3)
                    {
                        if ((Book[i, 0] != "") && (Book[i + 1, 0] != ""))
                        {
                            if (String.Compare(Book[i, 0], Book[(i + 1), 0], true) > 0)
                                zamena++;
                        }
                        else if ((Book[i, 0] == "") && (Book[i + 1, 0] != ""))
                        {
                            if (String.Compare(Book[i, 1], Book[(i + 1), 0], true) > 0)
                                zamena++;
                        }
                        else if ((Book[i, 0] != "") && (Book[i + 1, 0] == ""))
                        {
                            if (String.Compare(Book[i, 0], Book[(i + 1), 1], true) > 0)
                                zamena++;
                        }
                        else if ((Book[i, 0] == "") && (Book[i + 1, 0] == ""))
                        {
                            if (String.Compare(Book[i, 1], Book[(i + 1), 1], true) > 0)
                                zamena++;
                        }
                    }
                    if (zamena == 1)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            string temp = Book[i, j];
                            Book[i, j] = Book[i + 1, j];
                            Book[i + 1, j] = temp;
                        }
                    }
                }
            }
            Vivod_Array(count);
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
        }


        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b_index = -1;
            Form2 f2 = new Form2(Book, -1);
            f2.ShowDialog();
            if (/*fname2 != "" || name2 != "" || */phone2 != "")
            {
                StreamWriter fn = new StreamWriter("FName.txt", true);
                StreamWriter n = new StreamWriter("Name.txt", true);
                StreamWriter sn = new StreamWriter("SName.txt", true);
                StreamWriter ph = new StreamWriter("Phone.txt", true);
                StreamWriter m = new StreamWriter("Mail.txt", true);
                StreamWriter ad = new StreamWriter("Adress.txt", true);
                StreamWriter more = new StreamWriter("More.txt", true);

                if (fname2 != "") fn.WriteLine(fname2);
                else fn.WriteLine(" ");

                if (name2 != "") n.WriteLine(name2);
                else n.WriteLine(" ");

                if (sname2 != "") sn.WriteLine(sname2);
                else sn.WriteLine(" ");

                if (phone2 != "") ph.WriteLine(phone2);
                else ph.WriteLine(" ");

                if (mail2 != "") m.WriteLine(mail2);
                else m.WriteLine(" ");

                if (adress2 != "") ad.WriteLine(adress2);
                else ad.WriteLine(" ");

                if (more2 != "") more.WriteLine(more2);
                else more.WriteLine(" ");

                fn.Close();
                n.Close();
                sn.Close();
                ph.Close();
                m.Close();
                ad.Close();
                more.Close();

                textBox1.Text = fname2;
                textBox2.Text = name2;
                textBox3.Text = sname2;
                textBox4.Text = phone2;
                textBox5.Text = mail2;
                textBox6.Text = adress2;
                textBox7.Text = more2;
                fname2 = name2 = sname2 = mail2 = adress2 = more2 = "";
                Vvod_Array();
                Details();
                Info_List(sort);

                for (int i = 0; i < count; i++)
                    if (listView1.Items[i].SubItems[1].Text == phone2)
                        b_index = i;
                listView1.FocusedItem = listView1.Items[b_index];
                listView1.Items[b_index].Selected = true;
                listView1.Select();
                listView1.EnsureVisible(b_index);
                phone2 = "";
            }
        }
        private void фамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort = 1;
            listView1.Clear();
            Sort(sort);
            Details();
            Info_List(sort);
        }
        private void имениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort = 2;
            listView1.Clear();
            Sort(sort);
            Details();
            Info_List(sort);
        }
        private void поФамилииИИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sort = 3;
            listView1.Clear();
            Sort(sort);
            Details();
            Info_List(sort);
        }
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Поиск") textBox8.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "Поиск")
            {
                
                if (textBox8.Text.Length > 0)
                {
                    listView1.Clear();
                    Details();
                    bool[] c = new bool[count];
                    for (int i = 0; i < count; i++)
                        c[i] = false;
                    if (Nomer(textBox8.Text))
                    {
                        for (int i = 0; i < count; i++)
                            if (NomerPerevod(Book[i, 3]).Contains(textBox8.Text))
                                c[i] = true;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                            for (int j = 0; j < 7; j++)
                                if ((Book[i, j].Contains(textBox8.Text)) || (Book[i, 0] + " " + Book[i, 1]).Contains(textBox8.Text) || (Book[i, 1] + " " + Book[i, 0]).Contains(textBox8.Text))
                                    c[i] = true;
                    }
                    for (int i = 0; i < count; i++)
                        if (c[i] == true)
                        {
                            string fio = "", phone, dop;
                            if ((sort == 1) || (sort == 3))
                            {
                                if (Book[i, 0] == "") fio = Book[i, 1];
                                else fio = Book[i, 0] + " " + Book[i, 1];
                            }
                            if (sort == 2)
                            {
                                if (Book[i, 1] == "") fio = Book[i, 0];
                                else fio = Book[i, 1] + " " + Book[i, 0];
                            }
                            dop = Book[i, 2];
                            phone = Book[i, 3];
                            ListViewItem zapis = new ListViewItem(fio);
                            zapis.SubItems.Add(phone);
                            zapis.SubItems.Add(dop);
                            listView1.Items.Add(zapis);
                        }
                }
                else
                {

                    listView1.Clear();
                    Details();
                    Info_List(sort);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            textBox8.Text = "Поиск";
            Details();
            Info_List(sort);
        }
        public bool Nomer(string text)
        {
            string nomer = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '-' && text[i] != ' ' && text[i] != '(' && text[i] != ')') nomer = nomer + text[i];

            }
            if (Int64.TryParse(nomer, out Int64 z))
                return true;
            else return false;
        }
        public string NomerPerevod(string text)
        {
            string nomer = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '-' && text[i] != ' ' && text[i] != '(' && text[i] != ')') nomer = nomer + text[i];

            }
            return nomer;
        }
        
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            string phone = listView1.Items[index].SubItems[1].Text;
            for (int i = 0; i < count; i++)
            {
                if (Book[i, 3] == phone)
                {
                    b_index = i;
                    textBox1.Text = Book[i, 0];
                    textBox2.Text = Book[i, 1];
                    textBox3.Text = Book[i, 2];
                    textBox4.Text = Book[i, 3];
                    textBox5.Text = Book[i, 4];
                    textBox6.Text = Book[i, 5];
                    textBox7.Text = Book[i, 6];
                }
            }
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (b_index != -1)
            {
                Form2 f2 = new Form2(Book, b_index);
                f2.ShowDialog();
                Book[b_index, 0] = textBox1.Text = fname2;
                Book[b_index, 1] = textBox2.Text = name2;
                Book[b_index, 2] = textBox3.Text = sname2;
                Book[b_index, 3] = textBox4.Text = phone2;
                Book[b_index, 4] = textBox5.Text = mail2;
                Book[b_index, 5] = textBox6.Text = adress2;
                Book[b_index, 6] = textBox7.Text = more2;
                Vivod_Array(count);
                fname2 = name2 = sname2 = mail2 = adress2 = more2 = "";

                Details();
                Info_List(sort);

                for (int i = 0; i < count; i++)
                    if (listView1.Items[i].SubItems[1].Text == phone2)
                        b_index = i;
                listView1.FocusedItem = listView1.Items[b_index];
                listView1.Items[b_index].Selected = true;
                listView1.Select();
                listView1.EnsureVisible(b_index);
                phone2 = "";
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (b_index != -1) {
                Form f4 = new Form4();
                f4.ShowDialog();
                if (Form4.delete == true)
                {
                    for (int i = b_index; i < count-1; i++)
                        for (int j = 0; j < 7; j++)
                            Book[i, j] = Book[i + 1, j];
                    Vivod_Array(count - 1);
                    Vvod_Array();
                    Details();
                    Info_List(sort);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    b_index = -1;
                }
            }

            
        }
    }
}
