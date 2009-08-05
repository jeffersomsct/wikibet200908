using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = GV_ACCOUNT.Rows.Count-1;
            double jj,jn, kk,kn,livenum;
            int ii,j, k, f,num2;
            num2=num+1;
            jj = 0; jn = 0; kk = 0; kn = 0;
            double han, odds, amt, betcenter, fee;
            bool freebet,ishave;
            ishave = false;
            freebet = false;
            livenum = 8;
            amt=0;
            betcenter=0;
            fee = 0;

            string typeclass, str1,blstr;
            str1 = "";  
            double[, , ,] arrstr = new double[num, 9, 2, 2];
            double[, ,] arrtemp = new double[9, 2, 2];
            double[] hanarr=new double[num];
            double[,] bets_col_sum_temp= new double[9,2];
            double[,] bets_col_sum = new double[num2,9];
            double[] bet_col=new double[9];
            double[] bet_col_draw=new double[9];
            baseclass basec = new baseclass();
            for ( ii = 0; ii < num; ii++)
            {
                typeclass = GV_ACCOUNT.Rows[ii].Cells["Typeclass"].Value.ToString();
                han = double.Parse(GV_ACCOUNT.Rows[ii].Cells["Han"].Value.ToString());
                hanarr[ii] = han;               
            }         
            
            for (ii = 0; ii < num; ii++)
            {
                blstr = GV_ACCOUNT.Rows[ii].Cells["BackLay"].Value.ToString();
                typeclass = GV_ACCOUNT.Rows[ii].Cells["Typeclass"].Value.ToString();
                odds = double.Parse(GV_ACCOUNT.Rows[ii].Cells["Odds"].Value.ToString());
                han = double.Parse(GV_ACCOUNT.Rows[ii].Cells["Han"].Value.ToString());                
                freebet=GV_ACCOUNT.Rows[ii].Cells["Freebet"].Selected;
                ishave=GV_ACCOUNT.Rows[ii].Cells["ISHave"].Selected;
                amt = double.Parse(GV_ACCOUNT.Rows[ii].Cells["AMT"].Value.ToString());
                fee = double.Parse(GV_ACCOUNT.Rows[ii].Cells["Fee"].Value.ToString());
                basec.getbetcenter(typeclass, hanarr, num);               
                betcenter = basec.BetCenter;
                basec.calculate(blstr, typeclass, odds, han, freebet, ishave, amt, betcenter, fee);             
                arrtemp = basec.Ftype;
                bets_col_sum_temp = basec.Bets_Col_Sum_temp;
                bet_col=basec.Bets_Col;
                bet_col_draw=basec.Bets_Col_Draw;
            }
           //查是否是可以用的列式
            for (j = 0; j < 9; j++)
            {
                kn += bet_col[j];
                kk += bet_col_draw[j];
            }

            for (ii = 0; ii < num; ii++)
            {
                for (j = 0; j < 9; j++)
                {
                    for (k = 0; k < 2; k++)
                    {
                        if (k == 0)
                        {
                            jj = bets_col_sum_temp[j, k];
                            bets_col_sum[ii, j] = jj;
                        }
                        else
                        {
                            jj = bets_col_sum_temp[j, k];
                            bets_col_sum[num2-1, j] = jj;
                        }
                    }
                }
            }
            textBox1.Text = str1;
            str1 = "";
            MessageBox.Show(Math.Abs(kn - kk).ToString());
                           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
