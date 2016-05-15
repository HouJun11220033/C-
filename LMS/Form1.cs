using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS
{
    public partial class Form1 : Form
    {
    //    string coustr = "service=.;database=LMS;usr=sa;pwd=root";
    //    SqlConnection conn = new SqlConnection(coustr);
    //    string sqlstr = "select * from cjb";
    //    SqlCommand cmd = new SqlCommand(sqlstr,conn);
    //    SqlDataAdapter reader = cmd.ExecuteNonQuery();
    //    DataSet ds = new DataSet();
    //    while(reader.Read())
    //    {
    //    string id=reader["学号"].ToString();
    //}
        static public string sn, sub;
       

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        
        }
        
        

        public Form1()
        {
            InitializeComponent();
        }
        Form2 fr2 = new Form2();
        Form3 fr3 = new Form3();
        Form4 fr4 = new Form4();


    

        private void button2_Click(object sender, EventArgs e)
        {
            //string coustr = "service=.;database=LMS;usr=sa;pwd=root";
            string coustr = "Data Source=DESKTOP-3THID4C;Initial Catalog=LMS;User ID=sa;PWD=root";
            SqlConnection conn = new SqlConnection(coustr);
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "") {
                MessageBox.Show("信息不全，请不要遗漏信息!");
            }
            if (admin.Checked) {
                string cstr = "select * from dlb where 类别='管理员' and 用户名='" + textBox1.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(cstr, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    sn = textBox1.Text.Trim();
                    fr4.Show();
                    this.Visible = false;


                }
                else
                {
                    MessageBox.Show("密码或用户名出错，请重新输入！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            if (teacher.Checked)
            {
                string cstr = "select * from dlb where 类别='教师'and 用户名='" + textBox1.Text.Trim() + "'and 密码='" + textBox2.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(cstr, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    sn = textBox1.Text.Trim();
                    sub = dr.GetValue(3).ToString();
                    fr3.Show();
                    this.Visible = false;
                }
                else {
                    MessageBox.Show("密码或用户名出错，请重新输入！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                
                
                }
            }
            if (student.Checked)
            {
                string cstr = "select * from dlb where 类别='学生' and 用户名='" + textBox1.Text.Trim() + "'and 密码='" + textBox2.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(cstr,conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {

                    sn = textBox1.Text.Trim();
                    fr2.Show();
                    this.Visible = false;
                    MessageBox.Show("Successful!");
                }
                else {

                    MessageBox.Show("密码或用户名出错，请重新输入！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }



            }
            conn.Close();
            conn.Dispose();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
