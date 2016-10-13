using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace CarWashManager
{
    public partial class Top10Services : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "  select top 10 B.PNAME+' '+C.CNAME name,COUNT(IDPRICE) cnt "+
                                            "  from CWM..PACKAGE A "+
                                            "  left join CWM..PRICELIST B on A.IDPRICE=B.ID "+
                                            "  left join CWM..CARCLASS C on C.ID = B.IDCLASS "+
                                            "  where DELETED is null "+
                                            "  group by B.PNAME+' '+C.CNAME " +
                                            "  order by cnt desc         ";
            DS = new DataSet();
            DA.Fill(DS, "canc");
            ShowChart1();
            DA.SelectCommand.CommandText = "  select top 10 B.PNAME name,COUNT(IDPRICE) cnt " +
                                "  from CWM..PACKAGE A " +
                                "  left join CWM..PRICELIST B on A.IDPRICE=B.ID " +
                                "  where DELETED is null " +
                                "  group by B.PNAME " +
                                "  order by cnt desc         ";
            DS = new DataSet();
            DA.Fill(DS, "canc2");
            ShowChart2();
        }

        private void ShowChart2()
        {
            double sum_all = 0;
            int cnt_all = 10;

            string[] names = new string[cnt_all];
            double[] current = new double[cnt_all];
            int i = 0;
            foreach (DataRow r in DS.Tables["canc2"].Rows)
            {
                string d = r["cnt"].ToString();
                sum_all += double.Parse(r["cnt"].ToString());
                current[i] = double.Parse(r["cnt"].ToString());
                names[i++] = r["name"].ToString();
            }



            double s1 = current[0] * 100 / sum_all;
            double s2 = current[1] * 100 / sum_all;
            double s3 = current[2] * 100 / sum_all;
            double s4 = current[3] * 100 / sum_all;
            double s5 = current[4] * 100 / sum_all;
            double s6 = current[5] * 100 / sum_all;
            double s7 = current[6] * 100 / sum_all;
            double s8 = current[7] * 100 / sum_all;
            double s9 = current[8] * 100 / sum_all;
            double s10 = current[9] * 100 / sum_all;
            double[] yValues = { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
            string[] xValues = { names[0], names[1], names[2], names[3], names[4], names[5], names[6], names[7], names[8], names[9] };
            Chart2.Series["Default"].Points.DataBindXY(xValues, yValues);

            Chart2.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart2.Series["Default"].Points[1].Color = Color.PaleGreen;
            Chart2.Series["Default"].Points[2].Color = Color.LawnGreen;
            Chart2.Series["Default"].Points[3].Color = Color.Gold;
            Chart2.Series["Default"].Points[4].Color = Color.Aquamarine;
            Chart2.Series["Default"].Points[5].Color = Color.Sienna;
            Chart2.Series["Default"].Points[6].Color = Color.Blue;
            Chart2.Series["Default"].Points[7].Color = Color.Bisque;
            Chart2.Series["Default"].Points[8].Color = Color.Black;
            Chart2.Series["Default"].Points[9].Color = Color.MediumVioletRed;
            /*Chart2.Series["Default"].Points[10].Color = Color.BlueViolet;
            Chart2.Series["Default"].Points[11].Color = Color.Brown;
            Chart2.Series["Default"].Points[12].Color = Color.MidnightBlue;
            Chart2.Series["Default"].Points[13].Color = Color.LightPink;*/


            Chart2.Titles[0].Text = "Десятка самых популярных услуг без учёта класса:";
            Chart2.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart2.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart2.ChartAreas["ChartArea1"].Visible = true;
            Chart2.Legends[0].Enabled = true;
            return;
        }
        private void ShowChart1()
        {
            double sum_all = 0;
            int cnt_all = 10;

            string[] names = new string[cnt_all];
            double[] current = new double[cnt_all];
            int i = 0;
            foreach (DataRow r in DS.Tables["canc"].Rows)
            {
                string d = r["cnt"].ToString();
                sum_all += double.Parse(r["cnt"].ToString());
                current[i] = double.Parse(r["cnt"].ToString());
                names[i++] = r["name"].ToString();
            }

            

            double s1 = current[0] * 100 / sum_all;
            double s2 = current[1] * 100 / sum_all;
            double s3 = current[2] * 100 / sum_all;
            double s4 = current[3] * 100 / sum_all;
            double s5 = current[4] * 100 / sum_all;
            double s6 = current[5] * 100 / sum_all;
            double s7 = current[6] * 100 / sum_all;
            double s8 = current[7] * 100 / sum_all;
            double s9 = current[8] * 100 / sum_all;
            double s10 = current[9] * 100 / sum_all;
            double[] yValues = { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
            string[] xValues = { names[0], names[1], names[2], names[3], names[4], names[5], names[6], names[7], names[8], names[9]};
            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

            Chart1.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart1.Series["Default"].Points[1].Color = Color.PaleGreen;
            Chart1.Series["Default"].Points[2].Color = Color.LawnGreen;
            Chart1.Series["Default"].Points[3].Color = Color.Gold;
            Chart1.Series["Default"].Points[4].Color = Color.Aquamarine;
            Chart1.Series["Default"].Points[5].Color = Color.Sienna;
            Chart1.Series["Default"].Points[6].Color = Color.Blue;
            Chart1.Series["Default"].Points[7].Color = Color.Bisque;
            Chart1.Series["Default"].Points[8].Color = Color.Black;
            Chart1.Series["Default"].Points[9].Color = Color.MediumVioletRed;
            /*Chart1.Series["Default"].Points[10].Color = Color.BlueViolet;
            Chart1.Series["Default"].Points[11].Color = Color.Brown;
            Chart1.Series["Default"].Points[12].Color = Color.MidnightBlue;
            Chart1.Series["Default"].Points[13].Color = Color.LightPink;*/


            Chart1.Titles[0].Text = "Десятка самых популярных услуг по классам:";
            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.ChartAreas["ChartArea1"].Visible = true;
            Chart1.Legends[0].Enabled = true;
            return;
        }
    }
}
