using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class SaleReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         CountWPP();

        }

    public void CountWPP()
        {

            DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2();
            DBLayer.tblProduct pro = new DBLayer.tblProduct();

            var result = fn_getStock("7160");
            lblResult0.Text = result.ToString();
            lblCode0.Text = "7160";

            var result1 = fn_getStock("6518");
            lblResult1.Text = result1.ToString();
            lblCode1.Text = "6518";

            var result2 = fn_getStock("93835");
            lblResult2.Text = result2.ToString();
            lblCode2.Text = "93835";

            var result3 = fn_getStock("67502");
            lblResult3.Text = result3.ToString();
            lblCode3.Text = "67502";

            var result4 = fn_getStock("9901");
            lblResult4.Text = result4.ToString();
            lblCode4.Text = "9901";

            var result5 = fn_getStock("1538776");
            lblResult5.Text = result5.ToString();
            lblCode5.Text = "1538776";

            var result6 = fn_getStock("1627");
            lblResult6.Text = result6.ToString();
            lblCode6.Text = "1627";





            DataTable dt = new DataTable("Chart");
            dt.Columns.Add("a");
            dt.Columns.Add("b");


            dt.Rows.Add("Approved ECNEC" + "  " + result.ToString(), result.ToString());
            dt.Rows.Add("ECNEC" + "  " + result4.ToString(), result1.ToString());
            dt.Rows.Add("Approved" + "  " + result3.ToString(), result2.ToString());
            dt.Rows.Add("Pending CDWP" + "  " + result2.ToString(), result3.ToString());
            dt.Rows.Add("WP UnderProcess" + "  " + result4.ToString(), result4.ToString());
            dt.Rows.Add("Return" + "  " + result5.ToString(), result5.ToString());

            dt.Rows.Add("Pending PIA" + "  " + result6.ToString(), result6.ToString());

            Chart1.DataSource = dt;

            Chart1.Series[0].XValueMember = "a";

            Chart1.Series[0].YValueMembers = "b";

            Chart1.Series[1].XValueMember = "a";

            Chart1.Series[1].YValueMembers = "b";
            //Chart1.Series[1].Color = Color.Green;

            Chart1.DataBind();

            

        }



        public string fn_getStock(string Id)
        {

            DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2();
            DBLayer.tblProduct pro = new DBLayer.tblProduct();


            var result = (from p in DB.tblProducts
                          where p.UPC_code == Id
                          select p).SingleOrDefault();
            if (result != null)
            {
                return result.ProductStock.ToString();
            }
            else
            {
                return "";
            }



        }

       
    }
}