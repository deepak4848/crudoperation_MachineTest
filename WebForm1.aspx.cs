using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace crudoperation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString); 
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetCountry();
                GetStudent();
            }

        }


        public void GetCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GetCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteReader();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "cname";
                ddlCountry.DataValueField = "cid";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, "Select Country");
            }



        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetState();
        }

        public void GetState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GetState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("cid", ddlCountry.SelectedValue);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteReader();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                ddlstate.DataSource = dt;
                ddlstate.DataTextField = "sname";
                ddlstate.DataValueField = "sid";
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, "Select State");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("StuId", -1);
                cmd.Parameters.AddWithValue("StuName", txtName.Text);
                cmd.Parameters.AddWithValue("RollNo", Convert.ToInt32(txtrollno.Text));
                cmd.Parameters.AddWithValue("contacno", Convert.ToInt32(txtcontact.Text));
                cmd.Parameters.AddWithValue("gender", Convert.ToInt32(rblgender.SelectedValue));
                cmd.Parameters.AddWithValue("countryid", Convert.ToInt32(ddlCountry.SelectedValue));
                cmd.Parameters.AddWithValue("@stateid", Convert.ToInt32(ddlstate.SelectedValue));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (btnSave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("StuId", Convert.ToInt32(ViewState["id"]));
                cmd.Parameters.AddWithValue("StuName", txtName.Text);
                cmd.Parameters.AddWithValue("RollNo", Convert.ToInt32(txtrollno.Text));
                cmd.Parameters.AddWithValue("contacno", Convert.ToInt32(txtcontact.Text));
                cmd.Parameters.AddWithValue("gender", Convert.ToInt32(rblgender.SelectedValue));
                cmd.Parameters.AddWithValue("countryid", Convert.ToInt32(ddlCountry.SelectedValue));
                cmd.Parameters.AddWithValue("@stateid", Convert.ToInt32(ddlstate.SelectedValue));
                cmd.ExecuteNonQuery();
                con.Close();

            }


            GetStudent();
            reset();



        }

        public void reset()
        {
            txtName.Text = "";
            txtrollno.Text = "";
            btnSave.Text = "Submit";
        }


        public void GetStudent()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GetStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteReader();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                grdStudent.DataSource = dt;
                grdStudent.DataBind();
            }
        }

        protected void grdStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRecord")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("GetStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("StuId", e.CommandArgument);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteReader();
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    ViewState["id"] = e.CommandArgument;
                    txtName.Text = dt.Rows[0]["StuName"].ToString();
                    txtrollno.Text = dt.Rows[0]["RollNo"].ToString();
                    txtcontact.Text = dt.Rows[0]["contacno"].ToString();
                    rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                    ddlCountry.SelectedValue = dt.Rows[0]["countryid"].ToString();
                    GetState();
                    ddlstate.Text = dt.Rows[0]["stateid"].ToString();
                    btnSave.Text = "Update";

                }

            }
        }
    }
}