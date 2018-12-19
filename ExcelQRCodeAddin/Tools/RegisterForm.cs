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

            Type registerType = Type.GetTypeFromProgID("ExceladdinRegister.Register");
            dynamic register = Activator.CreateInstance(registerType);
            if (register.IsRegister())
            {
                
                button2.Enabled = false;
                button2.Text = "已注册";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)

                {
                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    if (path.Substring(path.Length - 1, 1) != "\\")
                    {
                     //   MessageBox.Show(path);
                        File.Copy(openFileDialog1.FileName, path + @"\register.dat", true);
                        
                    }
                    else
                    {
                        File.Copy(openFileDialog1.FileName, path + @"register.dat", true);
                    }
                    button2.Text = "请注册";
                    button2.Enabled = true;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
           
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    var path =  Type.GetType("ExceladdinRegister.Register").Assembly.CodeBase;
        //    Console.WriteLine(path); 
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Type registerType = Type.GetTypeFromProgID("ExceladdinRegister.Register");
            dynamic register = Activator.CreateInstance(registerType);
            if (register.IsRegister())
            {
                MessageBox.Show("恭喜你注册成功", "提示");
                button2.Enabled = false;
                button2.Text = "已注册";
            }
        }
    }
}
