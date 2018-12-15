using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelQRCodeAddin.Tools
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = new Tools.ComputerInfo().GetComputerInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
              
                File.Copy(openFileDialog1.FileName, AppDomain.CurrentDomain.BaseDirectory  +"register.dat",true);
                button2.Text = "请注册";
                button2.Enabled = true;

            } 
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    var path =  Type.GetType("ExceladdinRegister.Register").Assembly.CodeBase;
        //    Console.WriteLine(path); 
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            ExceladdinRegister.Register register = new ExceladdinRegister.Register();
            if (register.IsRegister())
            {
                MessageBox.Show("恭喜你注册成功", "提示");
                button2.Enabled = false;
                button2.Text = "已注册";
            }
        }
    }
}
