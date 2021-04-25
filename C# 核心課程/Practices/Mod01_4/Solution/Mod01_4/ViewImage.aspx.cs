using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ViewImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            const int BufferSize = 1024;
            if (id != null)
            {
                SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select photo from PhotoTable where id=@id", cn);
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
                {
                    long currentIndex = 0;
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead;
                    while (dr.Read())
                    {
                        currentIndex = 0;
                        bytesRead = (int)dr.GetBytes(0, currentIndex, buffer, 0, BufferSize);
                        while (bytesRead != 0)
                        {
                            imageStream.Write(buffer, 0, bytesRead);
                            currentIndex += bytesRead;
                            bytesRead =
                            (int)dr.GetBytes(0, currentIndex, buffer, 0, BufferSize);
                        }
                    }
                    Response.BinaryWrite(imageStream.ToArray());
                }
            }

        }
    }
}