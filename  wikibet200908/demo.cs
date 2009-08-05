using System.Windows.Forms;
using lpsolve55;
using System;
using System.Threading;
using System.Diagnostics;

namespace demo
{
    public class demo
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public string Demo(int num,int cnum,float[,] arr)
        {
            int lp, ccnum;
            int Ncol;
            string str="";
            int[] colno;
            int j, ret = 0;
            double[] row;
            char xx ='A';
            float[,] array;
            array = arr;
            ccnum = cnum;
            /* We will build the model row by row */
            /* So we start with creating a model with 0 rows and 2 columns */
            Ncol =num; /* there are two variables in the model */
            lp = lpsolve.make_lp(0, Ncol);
            if (lp == 0)
                ret = 1; /* couldn't construct a new model... */

            if (ret == 0)
            {
                /* let us name our variables. Not required, but can be useful for debugging */
                for (int jj = 1; jj <= Ncol;jj++ )
                {
                    int thisnum = ((int)xx) + 1;
                    xx = Convert.ToChar(thisnum);
                    lpsolve.set_col_name(lp, jj, xx.ToString());
                }                
               
            }

            /* create space large enough for one row */
            colno = new int[Ncol];
            row = new double[Ncol];

            if (ret == 0)
            {
                /* construct second row (X <= 100) */
                j = 0;
                for (int tt = 0; tt < Ncol; tt++) 
                {
                    colno[j] = tt + 1;
                    row[j++] = array[ccnum,tt];
                }
                colno[j] = 1; /* first column */
                row[j++] = 1;

                colno[j] = 2; /* second column */
                row[j++] = 0;

                colno[j] = 3; /* second column */
                row[j++] = 0;
                /* add the row to lpsolve */
                if (lpsolve.add_constraintex(lp, j, ref row[0], ref colno[0], lpsolve.lpsolve_constr_types.LE, 100) == false)
                    ret = 3;
            }

            if (ret == 0)
            {
                lpsolve.set_add_rowmode(lp, true); /* makes building the model faster if it is done rows by row */

                /* construct first row (1.09 x-3.8y =0) */
                j = 0;

                colno[j] = 1; /* first column */
                row[j++] = 0;

                colno[j] = 2; /* second column */
                row[j++] =-3.8;

                colno[j] = 3; /* second column */
                row[j++] = 0;
                /* add the row to lpsolve */
                if (lpsolve.add_constraintex(lp, j, ref row[0], ref colno[0], lpsolve.lpsolve_constr_types.EQ, 0) == false)
                    ret = 3;
            }

          

            if (ret == 0)
            {
                /* construct third row (2.09X-2.7Z=0) */
                j = 0;

                colno[j] = 1; /* first column */
                row[j++] = 2.09;

                colno[j] = 2; /* second column */
                row[j++] =0;

                colno[j] = 3; /* second column */
                row[j++] = -2.7;

                /* add the row to lpsolve */
                if (lpsolve.add_constraintex(lp, j, ref row[0], ref colno[0], lpsolve.lpsolve_constr_types.EQ, 0) == false)
                    ret = 3;
            }

            if (ret == 0)
            {
                lpsolve.set_add_rowmode(lp, false); /* rowmode should be turned off again when done building the model */

                /* set the objective function (1.09 x-y-z) */
                j = 0;

                colno[j] = 1; /* first column */
                row[j++] = 1.09;

                colno[j] = 2; /* second column */
                row[j++] = -1;

                colno[j] = 3; /* second column */
                row[j++] = -1;

                /* set the objective in lpsolve */
                if (lpsolve.set_obj_fnex(lp, j, ref row[0], ref colno[0]) == false)
                    ret = 4;
            }

            if (ret == 0)
            {
                lpsolve.lpsolve_return s;

                /* set the object direction to maximize */
                lpsolve.set_maxim(lp);

                /* just out of curioucity, now show the model in lp format on screen */
                /* this only works if this is a console application. If not, use write_lp and a filename */
                lpsolve.write_lp(lp, "model.lp");

                /* I only want to see important messages on screen while solving */
                lpsolve.set_verbose(lp, 3);

                /* Now let lpsolve calculate a solution */
                s = lpsolve.solve(lp);
                if (s == lpsolve.lpsolve_return.OPTIMAL)
                    ret = 0;
                else
                    ret = 5;
            }

            if (ret == 0)
            {
                /* a solution is calculated, now lets get some results */

                /* objective value */
                //System.Diagnostics.Debug.WriteLine("Objective value: " + lpsolve.get_objective(lp));

                str = "MAX:" + Math.Round(lpsolve.get_objective(lp)).ToString() + "\n\n";
                /* variable values */
                lpsolve.get_variables(lp, ref row[0]);
                for (j = 0; j < Ncol; j++)
                    //System.Diagnostics.Debug.WriteLine(lpsolve.get_col_name(lp, j + 1) + ": " + row[j]);
                    str = str + lpsolve.get_col_name(lp, j + 1).ToString() + ": " +Math.Round(row[j]).ToString();
                /* we are done now */
            }

            /* free allocated memory */

            if (lp != 0)
            {
                /* clean up such that all used memory by lpsolve is freed */
                lpsolve.delete_lp(lp);
            }

            return (str.ToString());
        } //Demo
    }
}
