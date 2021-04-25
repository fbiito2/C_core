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
            DataTable dt = new DataTable();
            if (!Page.IsPostBack)
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("select id from PhotTable", cn))
                    {
                        cn.Open();
                        //SqlDataReader dr = cmd.ExecuteReader();
                        //dt.Load(dr);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            //dr.Close();
                            //cn.Close();
                        }

                    }
                }




                lst.DataSource = dt;
                lst.DataTextField = "id";
                lst.DataBind();

            }

        }

        protected void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = lst.SelectedValue.ToString();
            img.ImageUrl = "ViewImage.aspx?id=" + id;

        }
    }
}