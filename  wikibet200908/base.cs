using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    class baseclass
    {

        private double[, ,] ftype;
        private int betcenter;
        private double[] bets_col;
        private double[] bets_col_draw;
        private double[,] bet_col_sum_temp;

        public int BetCenter
        {
            set { betcenter = value; }
            get { return betcenter; }
        }
        public double[, ,] Ftype
        {
            set { this.ftype = value; }
            get { return ftype; }
        }
        public double[] Bets_Col
        {
            set { this.bets_col = value; }
            get { return bets_col; }
        }
        public double[] Bets_Col_Draw
        {
            set { this.bets_col_draw = value; }
            get { return bets_col_draw; }
        }
        public double[,] Bets_Col_Sum_temp
        {
            set { this.bet_col_sum_temp = value; }
            get { return bet_col_sum_temp; }
        }
        //取得bet_col_sum 的列式問題
        /*
         * 
         * /
        //取得over 和under 的中心點
        /* typeclas   類型(只要有一個為over /under)       
         * oddstype   類型
         * han        差分數
         * hanarr     為數組
         */
        public void getbetcenter(string typeclass, double[] hanarr, int n_col)
        {
            string strtype;
            double center;
            int col;
            double[] arr;
            arr = hanarr;
            center = 0;
            col = n_col;
            strtype = typeclass;
            switch (strtype)
            {
                case "Over"://Over/Under------------A
                    for (int i = 0; i < col; i++)
                    {
                        center = center + arr[i];

                    }
                    BetCenter = (int)center / col;
                    break;
                case "Under"://Over/Under------------A
                    for (int i = 0; i < col; i++)
                    {
                        center = center + arr[i];

                    }
                    BetCenter = (int)center / col;
                    break;
                default:
                    BetCenter = 0;
                    break;
            }
        }
        //取得全部的參數前面的值的數字
        /*
         * n_col 莊家數
         * blstr back/lay 判斷
         * oddstype   類型
         * odds      倍率
         * freebet   是否freebet
         * have      是否已經下注
         * amt       下注多少money
         * bets_center over/under 中心點
         * fee         費用
         */
        public void calculate( string blstr, string oddstype, double odds, double hans, bool freebet, bool have, double amtt, double bets_center, double fee)
        {
            int num;
            
            string strbl, oddtype;
            strbl = blstr;
            oddtype = oddstype;
            double chknum, chknum1, chknum3, odd, han, amt, fe, bet_center, sit1, sit2;
            odd = odds;
            han = hans;
            amt = amtt;
            bet_center = bets_center;
            fe = fee;
            bool fbet, ishave;
            fbet = freebet;
            ishave = have;
            num = ((Int32)(han / 0.25)) % 4;
            double[, ,] arr = new double[9, 2, 2];
            double[] betscol = new double[9];
            double[] betscoldraw = new double[9];
            double[,] betscolsum = new double[9, 2];
            for (int i = 0; i < 9; i++)
            {
                chknum = han - bet_center - 4 + i;
                chknum1 = han - 0.25 - bet_center - 4 + i;
                chknum3 = han + 0.25 - bet_center - 4 + i;

                switch (oddtype)
                {
                    case "Over"://Over/Under------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;

                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;

                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;

                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5 * amt;

                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                        }
                                        if (chknum3 < 0)
                                        {
                                            sit2 = (1 - fe) * (odd - 1) * 0.5 * amt;
                                        }
                                        else if (chknum3 == 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else
                                        {
                                            sit2 = 0;
                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = (1 - fe) * (odd - 1) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = -0.5 * amt; }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5 * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -0.5;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C     
                        }    //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;
                                        }

                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odd - 1) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = amt * (1 - fe);
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odd - 1) * amt;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0) { sit1 = 0; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = amt * (1 - fe) * 0.5; }
                                        if (chknum3 < 0) { sit2 = 0; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = amt * (1 - fe) * 0.5; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -1 * (odd - 1) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = (1 - fe) * 0.5; }
                                        if (chknum3 < 0) { sit2 = -1 * (odd - 1) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = (1 - fe) * 0.5; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else if (chknum1 == 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else { sit1 = amt * (1 - fe) * 0.5; betscol[i] = 1; betscoldraw[i] = 0; }
                                        if (chknum3 < 0) { sit2 = 0; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = amt * (1 - fe) * 0.5; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -1 * (odd - 1) * 0.5; betscol[i] = -1; betscoldraw[i] = 0; } else if (chknum1 == 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else { sit1 = -0.5 * (1 - fe); betscol[i] = -1; betscoldraw[i] = 0; }
                                        if (chknum3 < 0) { sit2 = -1 * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5 * (1 - fe); }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C     
                        }    //------------B 
                        break;//-------A


                    case "Under"://Over/Under------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (odd - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (odd - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0) { sit1 = 0; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = (1 - fe) * (odd - 1) * 0.5 * amt; }
                                        if (chknum3 < 0) { sit2 = 0; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = (1 - fe) * (odd - 1) * 0.5 * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = (1 - fe) * (odd - 1) * amt; }
                                        if (chknum3 < 0) { sit2 = -0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = (1 - fe) * (odd - 1) * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else if (chknum1 == 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else { sit1 = (1 - fe) * (odd - 1) * 0.5; betscol[i] = 1; betscoldraw[i] = 0; }
                                        if (chknum3 < 0) { sit2 = 0; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = (1 - fe) * (odd - 1) * 0.5; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -0.5; betscol[i] = -1; betscoldraw[i] = 0; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = (1 - fe) * (odd - 1) * 0.5; betscol[i] = 1; betscoldraw[i] = 0; }
                                        if (chknum3 < 0) { sit2 = -0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = (1 - fe) * (odd - 1); }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C     
                        }    //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * (odd - 1) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -1 * (odd - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0) { sit1 = amt * (1 - fe) * 0.5; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = 0; }
                                        if (chknum3 < 0) { sit2 = amt * (1 - fe) * 0.5; ; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = (1 - fe) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = -1 * (odd - 1) * 0.5 * amt; }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -1 * (odd - 1) * 0.5 * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0) { sit1 = (1 - fe) * 0.5; betscol[i] = 1; betscoldraw[i] = 0; } else if (chknum1 == 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -0.5 * (1 - fe); betscol[i] = -1; betscoldraw[i] = 0; } else if (chknum1 == 0) { sit1 = 0; betscol[i] = 0; betscoldraw[i] = 1; } else { sit1 = -1 * (odd - 1) * 0.5; betscol[i] = -1; betscoldraw[i] = 0; }
                                        if (chknum3 < 0) { sit2 = -0.5 * (1 - fe); } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -1 * (odd - 1) * 0.5; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C     
                        }    //------------B 
                        break;//-------A




                    case "Win1"://Win1------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }//------------C

                        }    //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 1 - fe;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 1 - fe;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }//--------------C

                        } //------------B 
                        break;//-------A


                    case "Win2"://Win1------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (odds - 1) * (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (odds - 1) * (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (odds - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = (odds - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }//------------C

                        }    //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 1 - fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = -1 * (odd - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }//--------------C

                        } //------------B 
                        break;//-------A


                    case "X"://X------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1*amt ;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = -1 ;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }//--------------C

                        } //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 =  (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 =  (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] =1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 =  (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }//------------C

                        }    //------------B                        
                        break;//-------A

                    case "S1"://s1------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 )//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] =1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 =0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5 * amt;

                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                        }
                                        if (chknum3 < 0)
                                        {
                                            sit2 = (1 - fe) * (odd - 1) * 0.5 * amt;
                                        }
                                        else if (chknum3 == 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else
                                        {
                                            sit2 = 0;
                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = (1 - fe) * (odd - 1) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = -0.5 * amt; }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5 * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -0.5;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C   
                        } //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 )//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 =0;

                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt * 0.5 ;
                                        }
                                        if (chknum3 < 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else if (chknum3 == 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else
                                        {
                                            sit2 = (1 - fe) * amt * 0.5;
                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -1 * (odd - 1) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = 0.5*(1-fe) * amt; }
                                        if (chknum3 < 0) { sit2 = -1 * (odd - 1) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0.5 * (1 - fe) * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] =1;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0.5*(1-fe);
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = 0; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0.5 * (1 - fe); }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0)
                                        {
                                            sit1 = -1 * (odd - 1) * 0.5;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -0.5*(1-fe);
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = -1 * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5 * (1 - fe); }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C 
                        }    //------------B                        
                        break;//-------A

                    case "S2"://s2------------A

                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = (odd - 1) * (1 - fe) * 0.5 * amt;

                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                        }
                                        if (chknum3 < 0)
                                        {
                                            sit2 = (odd - 1) * (1 - fe) * 0.5 * amt;
                                        }
                                        else if (chknum3 == 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else
                                        {
                                            sit2 = 0;
                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = (odd - 1) * (1 - fe) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = -1 * 0.5 * amt; }
                                        if (chknum3 < 0) { sit2 = (odd - 1) * (1 - fe) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -1 * 0.5 * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0)
                                        {
                                            sit1 = (1 - fe) * (odd - 1) * 0.5;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -0.5;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = (1 - fe) * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5; }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C                              
                        }    //------------B  

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 )//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1-fe)*amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1*(odds - 1) * amt ;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 =(1-fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] =0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 1-fe;
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 =1-fe;
                                            sit2 = 0;
                                            betscol[i] =1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }
                            else //---------C 
                            {
                                if (ishave == true)//------------D ishave
                                {
                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = 0;

                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt * 0.5;
                                        }
                                        if (chknum3 < 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else if (chknum3 == 0)
                                        {
                                            sit2 = 0;
                                        }
                                        else
                                        {
                                            sit2 = (1 - fe) * amt * 0.5;
                                        }
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0) { sit1 = -1 * (odd - 1) * 0.5 * amt; } else if (chknum1 == 0) { sit1 = 0; } else { sit1 = 0.5 * (1 - fe) * amt; }
                                        if (chknum3 < 0) { sit2 = -1 * (odd - 1) * 0.5 * amt; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0.5 * (1 - fe) * amt; }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }//------------E fet
                                }
                                else//------------D ishave
                                {

                                    if (fbet == true)//------------E fbet
                                    {
                                        if (chknum1 < 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0.5 * (1 - fe);
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = 0; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = 0.5 * (1 - fe); }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }
                                    else//------------E fet
                                    {

                                        if (chknum1 < 0)
                                        {
                                            sit1 = -1 * (odd - 1) * 0.5;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum1 == 0)
                                        {
                                            sit1 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = -0.5 * (1 - fe);
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        if (chknum3 < 0) { sit2 = -1 * (odd - 1) * 0.5; } else if (chknum3 == 0) { sit2 = 0; } else { sit2 = -0.5 * (1 - fe); }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E fet
                                }//------------D                              
                            }//------------C 
                        } //------------B                                    
                        break;//-------A





                    case "EH1"://X------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1*amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 =(1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] =0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] =-1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }//--------------C

                        } //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }//------------C
                        }    //------------B                        
                        break;//-------A

                    case "EH2"://X------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }//--------------C

                        } //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * amt ;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * amt ;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] =1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] =1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 =-1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] =-1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }//------------C
                        }    //------------B                        
                        break;//-------A

                    case "EHX"://X------------A
                        if (strbl == "Back")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (odds - 1) * amt * (1 - fe);
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = -1 * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] =0;
                                            betscoldraw[i] =1;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = (1 - fe) * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = -1;
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }//------------E
                                }//------------D
                            }//--------------C

                        } //------------B 

                        if (strbl == "Lay")//Back/Lay------------B
                        {
                            if (num == 0 || num == 2 || num == 1 || num == 3)//------------C
                            {
                                if (ishave == true)//------------D
                                {
                                    if (fbet == true)//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * (odds - 1) * amt;
                                            sit2 = 0;

                                        }
                                        else
                                        {
                                            sit1 = (1 - fe) * amt;
                                            sit2 = 0;
                                        }
                                        arr[i, 0, 1] = sit1;
                                        arr[i, 1, 1] = sit2;
                                        betscol[i] = 0;
                                        betscoldraw[i] = 1;
                                        betscolsum[i, 1] = sit1 + sit2;

                                    }//------------E
                                }
                                else//------------D
                                {
                                    if (fbet == true)//------------E
                                    {

                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = 0;
                                            sit2 = 0;
                                            betscol[i] = 0;
                                            betscoldraw[i] = 1;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;
                                    }
                                    else//------------E
                                    {
                                        if (chknum < 0)
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        else if (chknum == 0)
                                        {
                                            sit1 = -1 * (odds - 1);
                                            sit2 = 0;
                                            betscol[i] = -1;
                                            betscoldraw[i] = 0;
                                        }
                                        else
                                        {
                                            sit1 = (1 - fe);
                                            sit2 = 0;
                                            betscol[i] = 1;
                                            betscoldraw[i] = 0;
                                        }
                                        arr[i, 0, 0] = sit1;
                                        arr[i, 1, 0] = sit2;
                                        betscolsum[i, 0] = sit1 + sit2;

                                    }//------------E
                                }//------------D
                            }//------------C
                        }    //------------B                        
                        break;//-------A
                }
                Ftype = arr;
                Bets_Col = betscol;
                Bets_Col_Draw = betscoldraw;
                Bets_Col_Sum_temp = betscolsum;
            }
        }
    }
}