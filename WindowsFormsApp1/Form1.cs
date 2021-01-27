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
			int R1 = Int32.Parse(textBox1.Text);
			int R2 = Int32.Parse(textBox2.Text);
			int R3 = Int32.Parse(textBox3.Text);
			int R4 = Int32.Parse(textBox4.Text);
			int R5 = Int32.Parse(textBox5.Text);
			int R6 = Int32.Parse(textBox6.Text);
			int R7 = Int32.Parse(textBox7.Text);
			int R8 = Int32.Parse(textBox8.Text);
			int R9 = Int32.Parse(textBox9.Text);
			int R10 = Int32.Parse(textBox10.Text);

			int J1 = Int32.Parse(textBox11.Text);
			int J2 = Int32.Parse(textBox12.Text);

			int E1 = Int32.Parse(textBox13.Text);
			int E2 = Int32.Parse(textBox14.Text);
			int E3 = Int32.Parse(textBox15.Text);


			DataTable dt = new DataTable();
			dt.Columns.Add("Kolumna 1");
			dt.Columns.Add("Kolumna 2");
			dt.Columns.Add("Kolumna 3");
			dt.Columns.Add("Kolumna 4");

			dt.Rows.Add(new object[] { R1, R2, R3, R4 });

			dataGridView1.DataSource = dt;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void label11_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
