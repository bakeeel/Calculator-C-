using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public delegate void mydelegate();
        public Form1()
        {
            InitializeComponent();
        }
        string op;
        double x;
        double y;
        String result;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Result_TextBox;
        }

        private void ce_Click(object sender, EventArgs e)
        {
            Result_TextBox.Text = "0";
        }

        private void C_Click(object sender, EventArgs e)
        {
            Result_TextBox.Text = "0";
            label1.Text = "";
        }

        private void del_Click(object sender, EventArgs e)
        {
            int index = Result_TextBox.Text.Length;
            index--;
            Result_TextBox.Text = Result_TextBox.Text.Remove(index);
            if (Result_TextBox.Text == "") Result_TextBox.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Result_TextBox.Text =(double.Parse( Result_TextBox.Text )*-1).ToString();
        }

        private void eq_Click(object sender, EventArgs e)
        {
            if (Result_TextBox.Text != "" && label1.Text=="")
            {
               x= Convert.ToDouble(Result_TextBox.Text);
            }
            else if(Result_TextBox.Text !="") y = Convert.ToDouble(Result_TextBox.Text); ;


            switch (op)
                {
                    case "+":
                        {

                            result = (x + y).ToString();
                            Result_TextBox.Text = result.ToString();
                            label1.Text = "";

                        }
                        break;
                    case "-":
                        {

                           result = (x - y).ToString();
                            Result_TextBox.Text = result.ToString();
                            label1.Text = "";

                        }
                        break;

                    case "*":
                        {

                            result = (x * y).ToString();
                            Result_TextBox.Text = result.ToString();
                            label1.Text = "";


                        }
                        break;

                    case "/":
                        if (y == 0)
                        {
                            Result_TextBox.Text = "0.0";
                            label1.Text = "";
                        }
                        else
                        {

                            result = (x / y).ToString();
                            Result_TextBox.Text = result.ToString();
                            label1.Text = "";

                        }
                        break;                
            }
        }

        private void seven_Click_1(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (Result_TextBox.Text == "0")
                Result_TextBox.Clear();

            //if (Result_TextBox.Text != "0")
                Result_TextBox.Text =Result_TextBox.Text+ b.Text;
            if (Result_TextBox.Text == "." && b.Text == ".") Result_TextBox.Text = "0.";
        }

        private void d_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (Result_TextBox.Text != "" && label1.Text != "")
            {
                mydelegate D =new mydelegate(eq.PerformClick);  //call delegate

                op = b.Text;
               
                label1.Text = Result_TextBox.Text + " " + op;

                x = Convert.ToDouble(Result_TextBox.Text);
                Result_TextBox.Clear();
            }
            else if(Result_TextBox.Text != "")
            {
                op = b.Text;
              
                if (Result_TextBox.Text.Length >= 5)
                {
                    label1.Font = new Font(label1.Font.FontFamily, 10);
                }
                label1.Text = Result_TextBox.Text + " " + op;

                x = Convert.ToDouble(Result_TextBox.Text);
                Result_TextBox.Clear();
            }
           else if(label1.Text != ""&& result!=null )
            {
                op = b.Text;
                label1.Text = result + " " + op;

            }
            else if(label1.Text != "")
            {
                op = b.Text;
                label1.Text = x + " " + op;
                Result_TextBox.Clear();
            }
            
            

        }

        private void five_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Result_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                case '.':
                    e.Handled = false;break;

                case '+':
                    e.Handled = true;
                    add.PerformClick();
                      break;

                case '-':
                    e.Handled = true;
                    s.PerformClick();break;

                case '/': e.Handled = true;
                    d.PerformClick();break;
                case '*': e.Handled = true;
                    m.PerformClick();break;
                case (char)Keys.Enter: eq.PerformClick();break;
                case (char)Keys.Back: del.PerformClick(); break;

                default:
                    e.Handled = true;break;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Result_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

public class products
{
    private int quantity;

    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }
}
