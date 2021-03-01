using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PrakRab_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void load(object sender, EventArgs e)
        {
            Label lab1 = new Label
            {
            Location = new Point(30, 50),
            Size = new System.Drawing.Size(60, 60),
            AutoSize = true,
            Font = new Font("Arial", 14, FontStyle.Bold),
            };
            
            Process p1 = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c date /t & echo %time%",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,

            });

            lab1.Text = "Время и дата: \n\n" + p1.StandardOutput.ReadToEnd();

            Button but1 = new Button
            {
                Text = "Обновить",
                Location = new Point(200, 300),
                Size = new System.Drawing.Size(60, 60),
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Bold),
            };

           but1.Click += (s, a) => 
            {
                p1.Start();
                lab1.Text = "Время и дата: \n\n" + p1.StandardOutput.ReadToEnd();
                
               };

            Controls.Add(lab1);
            Controls.Add(but1);


        }
    }
}
