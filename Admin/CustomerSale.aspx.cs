using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class CustomerSale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         CountWPP();

        }

    public void CountWPP()
        {

            DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2();
            DBLayer.tblOrderDetail order = new DBLayer.tblOrderDetail();
            DBLayer.View_Customer cust = new DBLayer.View_Customer();

            var result = (from p in DB.View_Customer
                          select p);

          
            DataTable telenorTable = new DataTable("Chart");
            DataColumn telenorColumn;
            DataRow telenorRow;

            //telenorColumn = new DataColumn();
            //telenorColumn.ColumnName = "OrderId";
            //telenorTable.Columns.Add(telenorColumn);

            //telenorColumn = new DataColumn();
            //telenorColumn.ColumnName = "ProductId";
            //telenorTable.Columns.Add(telenorColumn);

            telenorColumn = new DataColumn();
            telenorColumn.ColumnName = "Expr1";
            telenorTable.Columns.Add(telenorColumn);

            telenorColumn = new DataColumn();
            telenorColumn.ColumnName = "OrderQty";
            telenorTable.Columns.Add(telenorColumn);

            //telenorColumn = new DataColumn();
            //telenorColumn.ColumnName = "ProductPrice";
            //telenorTable.Columns.Add(telenorColumn);


            foreach (DBLayer.View_Customer temp in result)
            {

                telenorRow = telenorTable.NewRow();
                //telenorRow["OrderId"] = temp.OrderId;
                //telenorRow["ProductId"] = temp.ProductId;
                telenorRow["Expr1"] = temp.Expr1;
                telenorRow["OrderQty"] = temp.OrderQty;
                //telenorRow["ProductPrice"] = temp.ProductPrice;


                telenorTable.Rows.Add(telenorRow);
            }


            //DataTable dt = new DataTable("Chart");
            //dt.Columns.Add("a");
            //dt.Columns.Add("b");


            //telenorTable.Rows.Add("Approved ECNEC" + "  " + result.ToString(), result.ToString());
            //telenorTable.Rows.Add("ECNEC" + "  " + result4.ToString(), result1.ToString());
            //telenorTable.Rows.Add("Approved" + "  " + result3.ToString(), result2.ToString());
            //telenorTable.Rows.Add("Pending CDWP" + "  " + result2.ToString(), result3.ToString());
            //telenorTable.Rows.Add("WP UnderProcess" + "  " + result4.ToString(), result4.ToString());
            //telenorTable.Rows.Add("Return" + "  " + result5.ToString(), result5.ToString());

            //telenorTable.Rows.Add("Pending PIA" + "  " + result6.ToString(), result6.ToString());

            //Chart1.DataSource = telenorTable;
            

            //Chart1.Series[0].XValueMember = "ProductName";

            //Chart1.Series[0].YValueMembers = "OrderQty";

            //Chart1.Series[1].XValueMember = "ProductName";

            //Chart1.Series[1].YValueMembers = "OrderQty";
            ////Chart1.Series[1].Color = Color.Green;

            //Chart1.DataBind();



            Chart2.DataSource = telenorTable;


            Chart2.Series[0].XValueMember = "Expr1";

            Chart2.Series[0].YValueMembers = "OrderQty";

            Chart2.Series[1].XValueMember = "Expr1";

            Chart2.Series[1].YValueMembers = "OrderQty";
            //Chart1.Series[1].Color = Color.Green;

            Chart2.DataBind();




        }



        public string fn_getStock(string Id)
        {

            DBLayer.ICONEntities2 DB = new DBLayer.ICONEntities2();
            DBLayer.tblProduct pro = new DBLayer.tblProduct();


            var result = (from p in DB.tblProducts
                          where p.UPC_code == Id
                          select p).SingleOrDefault();

            return result.ProductStock.ToString();

        }

       
    }
}