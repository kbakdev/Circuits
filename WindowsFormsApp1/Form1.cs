using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{

			DataTable dt = new DataTable();
			dt.Columns.Add("1");
			dt.Columns.Add("2");
			dt.Columns.Add("3");
			dt.Columns.Add("4");

			dt.Rows.Add(new object[] { "1", "2", "3", "4" });

			dataGridView1.DataSource = dt;
		}
	}
}
