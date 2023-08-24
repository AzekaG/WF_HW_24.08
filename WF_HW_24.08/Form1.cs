using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WF_HW_24._08
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }

        void snd()
        {
          
            SoundPlayer sound = new SoundPlayer(@"D:\Шаг\Системное рпограмирование\Урок 2\WF_HW_24.08\WF_HW_24.08\Sound\kryakanie.wav");
            sound.Play();    
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Thread soundThread = new Thread(snd);
            soundThread.Start();

            listBox.Items.Clear();
            
            if (textBox3.Text == "" || textBox1.Text == "")
            {
                
                listBox.Items.Add("Введите правильно параметры");
            }
            else
            {
                
                Thread secondThread = new Thread(Foo);
               
                secondThread.Start(new List<string> { textBox1.Text, textBox3.Text });
            }

        }
        void Foo(object obj)
        {
                List<string> list = obj as List<string>;

                string pathword = list.First();
                string keyWord = list.Last(); 
                
            StringBuilder sb = new StringBuilder();
                try
                {
                    using (StreamReader sr = new StreamReader(pathword))        //открываем файл по предложенному пути
                    {

                        sb.Append(sr.ReadToEnd());   //копируем в стрингбилдер
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox.Items.Add($"Найдено вхождений :  {Regex.Matches(sb.ToString(), keyWord).Count}");  //смотрим вхождение
            }

           
        }

    }
        

