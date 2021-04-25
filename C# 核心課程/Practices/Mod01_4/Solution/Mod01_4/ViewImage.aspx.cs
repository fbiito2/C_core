using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            //這裡示範一段一段的由資料庫中取出，但是檔案不大可以不用則一次取出即可
            var id = Request.QueryString["id"];
            const int BufferSize = 1024;  //一段要取出的大小(可以設定)
            DataTable dt = new DataTable();
            if (id != null)
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("select photo from PhotTable where id=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                using (MemoryStream imageStream = new MemoryStream())
                {
                    int bytesRead;
                    bytesRead = (int)(dt.Rows[0].ItemArray[0]);
                    byte[] buffer = new byte[bytesRead];
                    imageStream.Write(buffer, 0, 0);

                    Response.BinaryWrite(imageStream.ToArray());
                }
                // SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
                // SqlCommand cmd = new SqlCommand("select photo from PhotTable where id=@id", cn);
                //cmd.Parameters.AddWithValue("@id", id);

                //cn.Open();
                //using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                //using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
                //{
                //    long currentIndex = 0;
                //    byte[] buffer = new byte[BufferSize];
                //    int bytesRead;
                //    while (dr.Read())
                //    {
                //        currentIndex = 0;
                //        bytesRead = (int)dr.GetBytes(0, currentIndex, buffer, 0, BufferSize);
                //        while (bytesRead != 0)
                //        {
                //            imageStream.Write(buffer, 0, bytesRead);
                //            currentIndex += bytesRead;
                //            bytesRead =
                //            (int)dr.GetBytes(0, currentIndex, buffer, 0, BufferSize);
                //        }
                //    }
                //    Response.BinaryWrite(imageStream.ToArray());
                //}
            }

        }
    }
}