using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExatLoader
{
    public partial class Form1 : Form
    {
        short iPort = 0;
        bool m_bX64 = false;
        bool is_sendingData = false;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            try
            {

                uint nResult = 0;
                try
                {
                    nResult = Lpt.IsInpOutDriverOpen();

                }
                catch (BadImageFormatException)
                {
                    nResult = Lpt.IsInpOutDriverOpen_x64();
                    if (nResult != 0)
                        m_bX64 = true;

                }

                if (nResult == 0)
                {
                    MessageBox.Show("Ошибка операционной системы");
                }
            }
            catch (DllNotFoundException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void UseLpt1_CheckedChanged(object sender, EventArgs e)
        {
            if (is_sendingData)
                return;
            var t = ((CheckBox)sender);
            if (LPT2Chekbox.Enabled)
            {
                LPT2Chekbox.Checked = !t.Checked;
                
            }
            if (t.Checked)
                iPort = 0x378;
        }

        private void UseLpt2_CheckedChanged(object sender, EventArgs e)
        {
            if (is_sendingData)
                return;
            var t = ((CheckBox)sender);
            if (LPT1Chekbox.Enabled)
            {
                LPT1Chekbox.Checked = !t.Checked;
                
            }
            if(t.Checked)
                iPort = 0x278;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ParallelPort");
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                var t = ((CheckBox)this.Controls.Find(String.Format("{0}Chekbox", m["DeviceID"]), false)[0]);
                if (t != null)
                {
                    var s = m["Status"];
                    if (s.ToString() == "OK")
                    {
                        t.Enabled = true;
                        t.Checked = true;
                        iPort = Convert.ToInt16(t.Tag.ToString());
                    }
                }

            }
            if ((LPT1Chekbox.Enabled && LPT2Chekbox.Enabled)) 
            {
                LPT1Chekbox.AutoCheck = true;
                LPT2Chekbox.AutoCheck = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (is_sendingData)
                return;
            var k = e.KeyCode;

            switch (k)
            {
                case Keys.Enter:
                    {
                        Out(Convert.ToInt16('\n'));
                        textBox1.Text = textBox1.Text + "ОТПРАВЛЕНО: ENTER" +Environment.NewLine;
                    }
                    break;
                case Keys.Back:
                    Out(Convert.ToInt16(k));
                    textBox1.Text = textBox1.Text + "ОТПРАВЛЕНО: BACKSPACE" + Environment.NewLine;
                    break;
                case Keys.Escape:
                    Out(Convert.ToInt16(k));
                    textBox1.Text = textBox1.Text + "ОТПРАВЛЕНО: ESCAPE" + Environment.NewLine;
                    break;
                case Keys.F3:
                    openFileDialog.Filter = "Все файлы (*.*)|*.*";
                    openFileDialog.InitialDirectory = Application.StartupPath; 
                    openFileDialog.Title = "Выберите файл EXAT";
                    var dr = openFileDialog.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        if (MessageBox.Show(String.Format("Вы выбрали файл {0}.\nХотите его передать в Exat?", openFileDialog.SafeFileName), "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                            return;
                        if (iPort == 0)
                        {
                            MessageBox.Show("Не найден порт LPT", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        textBox1.Clear();

                        StreamReader reader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(866));
                        string lineFromTxtFile = reader.ReadToEnd();
                        ThreadPool.QueueUserWorkItem(delegate
                            {
                                is_sendingData = true;
                                for (int i = 0; i < lineFromTxtFile.Length; ++i)
                                {

                                    Invoke(new Action(delegate
                                    {
                                        var charc = Convert.ToInt16(lineFromTxtFile[i]);
                                        Out(charc);
                                        textBox1.Text = textBox1.Text + lineFromTxtFile[i];
                                    }));
                                    Thread.Sleep(100);
                                }
                                Invoke(new Action(delegate
                                {
                                    Out(Convert.ToInt16('\n'));
                                    textBox1.Text = textBox1.Text + Environment.NewLine;
                                }));
                                Thread.Sleep(100);
                                Invoke(new Action(delegate
                                {
                                    textBox1.Text = textBox1.Text + "ПЕРЕДАЧА ДАННЫХ ИЗ ФАЙЛА " + openFileDialog.SafeFileName + " ЗАВЕРШЕНА!" + Environment.NewLine;
                                    is_sendingData = false;
                                }));
                                Thread.Sleep(100);
                                
                            });
                    }
                    break;
                case Keys.Y:
                case Keys.D:
                case Keys.N:
                case Keys.L:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.D0:
                case Keys.Tab:
                    Out(Convert.ToInt16(e.KeyCode));
                    textBox1.Text = textBox1.Text + "Отправлено:"+Inp() + Environment.NewLine;
                    break;
                default:
                    {
                        if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
                        {
                            var c = Convert.ToInt16(Keys.ControlKey);
                            Out(Convert.ToInt16(k+c));
                            //Out(Convert.ToInt16(c));
                            textBox1.Text = textBox1.Text + "ОТПРАВЛЕНО: CTRL+C" + Environment.NewLine;
                        }
                        //else
                        //{
                        //    Out(Convert.ToInt16(e.KeyCode));
                        //    textBox1.Text = textBox1.Text + "Отправлено:"+Inp() + Environment.NewLine;
                        //}
                    }
                    break;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Out(short data)
        {
            if (m_bX64)
                Lpt.Out32_x64(iPort, data);
            else
                Lpt.Out32(iPort, data);
        }
        private char Inp()
        {
            if (m_bX64)
                return Lpt.Inp32_x64(iPort);
            else
                return Lpt.Inp32(iPort);
        }

    }
}
