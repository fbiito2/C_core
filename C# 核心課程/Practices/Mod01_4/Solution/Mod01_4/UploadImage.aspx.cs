using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace WebApplication1
{
    public partial class UploadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            byte[] fileData = null;
            if (FileUpload1 != null)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {

                    string fn = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {

                        Stream str = FileUpload1.PostedFile.InputStream;
                        int len = (int)str.Length;
                        fileData = new byte[len];
                        str.Read(fileData, 0, len);
                        str.Close();

                        SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
                        SqlCommand cmd = new SqlCommand("INSERT INTO PhotoTable (photo) VALUES (@photo)", cn);
                        SqlParameter param1 = new SqlParameter("@photo", SqlDbType.Image);
                        param1.Value = fileData;
                        cmd.Parameters.Add(param1);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        Response.Redirect("default.aspx");
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "發生錯誤 : " + ex.Message;

                    }

                }
            }

        }
    }
}