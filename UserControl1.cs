using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntPayCalc
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool mCheck = true;
            if (!checkIfDate(maskedTextBox1.Text) & mCheck) { maskedTextBox1.Text = ""; mCheck = false; }

            if (!checkIfDate(maskedTextBox2.Text) & mCheck) { maskedTextBox2.Text = ""; mCheck = false; }

            float valf;
            float intf;
            int napi;

            if (!float.TryParse(maskedTextBox4.Text, out valf) & mCheck) { maskedTextBox4.Text = ""; mCheck = false; }

            if (!float.TryParse(maskedTextBox3.Text, out intf) & mCheck) { maskedTextBox3.Text = ""; mCheck = false; }

            if (!int.TryParse(maskedTextBox5.Text, out napi) & mCheck) { maskedTextBox5.Text = ""; mCheck = false; }
            float retF;
            string returnstring;

            if (mCheck) {
                label7.Text = "";
                retF = ipCalculate(maskedTextBox1.Text, maskedTextBox2.Text, valf, intf, napi);
                returnstring = Convert.ToString(retF);
                textBox1.Text = returnstring;
            }
            else{
                label7.Text = "Error: Ammend the input values!";
            }
        }


        private bool checkIfDate(string intext)
        {
            bool strChecked;
            
            DateTime dDate;

            if (DateTime.TryParse(intext, out dDate))
            {
                strChecked = true;
            }
            else
            {
                strChecked = false;
            }
            return strChecked;
        }

        private float ipCalculate (string inDate, string calcDate, float val, float cup, int napf)
        {
            float intAm = 0;
            float decr1;
            int sumOfPaidm;
            int numPerLeft;

            DateTime conDate;
            DateTime calDate;
            DateTime.TryParse(inDate, out conDate);
            DateTime.TryParse(calcDate, out calDate);
            sumOfPaidm = ((calDate.Year - conDate.Year) * 12) + calDate.Month - conDate.Month;
            if (calDate.Day - conDate.Day < 0 ) { sumOfPaidm--; }

            numPerLeft = (napf * 12 - sumOfPaidm);
            val = val - val*numPerLeft/(napf*12);
            for (int i = 0; i < numPerLeft; i++)
            {
               
                intAm = intAm + cup*val / 100;
                val = val - val / (napf * 12);
     
            }
            

            return intAm;
        }

    }
}
