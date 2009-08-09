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

            //
            //判斷狀況 j 是否可產生"等式限制式"
            //變數Limit_Equation 值為A 代表可為 等式限制式,值為B 代表 不可為限制式,值為 數字 代表最小值限制式 值為NULL 無限制式
            //
            //Limit_Equation 默認值為 NULL
            //當 (莊家數 num - kk :bet_col_draw) > 絕對值 (kk : bet_col ) 則 Limit_Equation = A
            //特定運動系統設定不可能發生狀況 Limit_Equation = B
            //所有莊家皆投注 則所有狀況J 其Limit_Equation = B
            //使用者填入最小值數字  Limit_Equation = 該數字
            //

            for (j = 0; j < 9; j++)
            {
                kn += bet_col[j];
                kk += bet_col_draw[j];
            }

            string Limit_Equation;
            Limit_Equation = "";

            if (num - kk > kn)  // 當 (莊家數 num - kk :bet_col_draw) > 絕對值 (kk : bet_col ) 則 Limit_Equation = A
            {
                 Limit_Equation = "A";

            } // 當 (莊家數 num - kk :bet_col_draw) > 絕對值 (kk : bet_col ) 則 Limit_Equation = A




            //
            //在特定莊家ii及特定狀況j之下 由Bet_Col_Sum_Temp(狀況別 j,是否為參數k)  產生Bet_Col_Sum(莊家別ii,狀況別j)
            //
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
            
            
   
            
            
            //
            //利用各狀況J 的Bet_Col_Sum(莊家別ii, 狀況別 j) 及 Limit_Equation(狀況別 j) 來產生 Bet_Group(莊家別ii,Group) 及 Group
            //
            //變數 Group = 0 記錄Group數量  

            int Group = 0;
            double[,] Bet_Group = new double[num+3, 9];

            for (j = 0; j < 8; j++) //-A-逐一狀況J 確認 Bet_Col_Sum (ii, j) 轉換為 Bet_Group (ii, Group)
            {

                if (Limit_Equation = "B" || Limit_Equation = "")  // -B-該特定狀況J 是否可為限制式 ,B or Null 不可為限制式
                {
                 //進行下一狀況J 確認   
                }
                else  // -B-該特定狀況J 是否可為限制式 A or 數字 可為限制式
                {

                    if (Bet_Group[num+2,j]="")  // -C-該特定狀況J,可為限制式,第1個Group是否存在(不存在)
                    {

                        //將 Bet_Col_Sum [num+1,j] =0 存放Group 的位置,填入0
                        Bet_Col_Sum[num + 1, j] = 0; 

                        for (ii = 0; ii < num+1; ii++) //-D-逐一將各莊家ii參數 由 Bet_Col_Sum (ii, j) 轉換為 Bet_Group (ii, 0)
                        {
                            Bet_Group [ii,0] = Bet_Col_Sum[ii, j]
                        } //-D-逐一將各莊家ii參數 由 Bet_Col_Sum (ii, j) 轉換為 Bet_Group (ii, 0)

                        Bet_Group [num+2,0] =  Limit_Equation (j);
                        Group =Group +1
                            
                    }

                    else  // -C-該特定狀況J,可為限制式,第1個Group是否存在(存在)
                    {






                    }     // // -C-該特定狀況J,可為限制式,第1個Group是否存在
                }     // -B-該特定狀況J 是否可為限制式 ,B or Null 不可為限制式
            } //-A-逐一狀況J 確認 Bet_Col_Sum (ii, j) 轉換為 Bet_Group (ii, Group)





            //
            //利用Bet_Group(莊家別ii,Group) 產生 Bet_Limit (莊家別ii,Limit) 
            //
            //變數 Limit = 0 記錄限制式Limit 數量 
            //

            int Limit = 0;





            textBox1.Text = str1;
            str1 = "";
            MessageBox.Show(Math.Abs(kn - kk).ToString());
                           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
