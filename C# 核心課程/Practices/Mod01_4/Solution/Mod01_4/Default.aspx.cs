using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select id from PhotoTable", cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                lst.DataSource = dt;
                lst.DataTextField = "id";
                lst.DataBind();

                dr.Close();
                cn.Close();
            }

        }

        protected void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = lst.SelectedValue.ToString();
            img.ImageUrl = "ViewImage.aspx?id=" + id;

        }
    }
}