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

		private static float[,] MatrixCreate(int rows, int cols)
		{
			// allocates/creates a matrix initialized to all 0.0. assume rows and cols > 0
			// do error checking here
			float[,] result = new float[rows, cols];
			return result;
		}

		private static float[,] ExtractUpper(float[,] matrix)
		{
			// upper part of a Doolittle decomposition (0.0s in the strictly lower part)
			int rows = matrix.GetLength(0); int cols = matrix.GetLength(1);
			float[,] result = MatrixCreate(rows, cols);
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					if (i <= j)
						result[i, j] = matrix[i, j];
				}
			}
			return result;
		}

        private static float[,] ExtractLower(float[,] matrix)
        {
            // lower part of a Doolittle decomposition (1.0s on diagonal, 0.0s in upper)
            int rows = matrix.GetLength(0); int cols = matrix.GetLength(1);
            float[,] result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i == j)
                        result[i, j] = 1.0f;
                    else if (i > j)
                        result[i, j] = matrix[i, j];
                }
            }
            return result;
        }

		private static float[,] MatrixDuplicate(float[,] matrix)
		{
			// allocates/creates a duplicate of a matrix. assumes matrix is not null.
			float[,] result = MatrixCreate(matrix.GetLength(0), matrix.GetLength(1));
			for (int i = 0; i < matrix.GetLength(0); ++i) // copy the values
				for (int j = 0; j < matrix.GetLength(1); ++j)
					result[i, j] = matrix[i, j];
			return result;
		}

		private static float[,] MatrixDecompose(float[,] matrix, out int[] perm, out int toggle)
		{
			// Doolittle LUP decomposition with partial pivoting.
			// rerturns: result is L (with 1s on diagonal) and U; perm holds row permutations; toggle is +1 or -1 (even or odd)
			int rows = matrix.GetLength(0);
			int cols = matrix.GetLength(1);

			//Check if matrix is square
			if (rows != cols)
				throw new Exception("Attempt to MatrixDecompose a non-square matrix");

			float[,] result = MatrixDuplicate(matrix); // make a copy of the input matrix

			perm = new int[rows]; // set up row permutation result
			for (int i = 0; i < rows; ++i) { perm[i] = i; } // i are rows counter

			toggle = 1; // toggle tracks row swaps. +1 -> even, -1 -> odd. used by MatrixDeterminant

			for (int j = 0; j < rows - 1; ++j) // each column, j is counter for coulmns
			{
				float colMax = Math.Abs(result[j, j]); // find largest value in col j
				int pRow = j;
				for (int i = j + 1; i < rows; ++i)
				{
					if (result[i, j] > colMax)
					{
						colMax = result[i, j];
						pRow = i;
					}
				}

				if (pRow != j) // if largest value not on pivot, swap rows
				{
					float[] rowPtr = new float[result.GetLength(1)];

					//in order to preserve value of j new variable k for counter is declared
					//rowPtr[] is a 1D array that contains all the elements on a single row of the matrix
					//there has to be a loop over the columns to transfer the values
					//from the 2D array to the 1D rowPtr array.
					//----tranfer 2D array to 1D array BEGIN

					for (int k = 0; k < result.GetLength(1); k++)
					{
						rowPtr[k] = result[pRow, k];
					}

					for (int k = 0; k < result.GetLength(1); k++)
					{
						result[pRow, k] = result[j, k];
					}

					for (int k = 0; k < result.GetLength(1); k++)
					{
						result[j, k] = rowPtr[k];
					}

					//----tranfer 2D array to 1D array END

					int tmp = perm[pRow]; // and swap perm info
					perm[pRow] = perm[j];
					perm[j] = tmp;

					toggle = -toggle; // adjust the row-swap toggle
				}

				if (Math.Abs(result[j, j]) < 1.0E-20) // if diagonal after swap is zero . . .
					return null; // consider a throw

				for (int i = j + 1; i < rows; ++i)
				{
					result[i, j] /= result[j, j];
					for (int k = j + 1; k < rows; ++k)
					{
						result[i, k] -= result[i, j] * result[j, k];
					}
				}
			} // main j column loop

			return result;
		} // MatrixDecompose

		private static float MatrixDeterminant(float[,] matrix)
		{
			int[] perm;
			int toggle;
			float[,] lum = MatrixDecompose(matrix, out perm, out toggle);
			if (lum == null)
				throw new Exception("Unable to compute MatrixDeterminant");
			float result = toggle;
			for (int i = 0; i < lum.GetLength(0); ++i)
				result *= lum[i, i];

			return result;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			float R1 = float.Parse(textBox1.Text);
			float R2 = float.Parse(textBox2.Text);
			float R3 = float.Parse(textBox3.Text);
			float R4 = float.Parse(textBox4.Text);
			float R5 = float.Parse(textBox5.Text);
			float R6 = float.Parse(textBox6.Text);
			float R7 = float.Parse(textBox7.Text);
			float R8 = float.Parse(textBox8.Text);
			float R9 = float.Parse(textBox9.Text);
			float R10 = float.Parse(textBox10.Text);

			float J1 = float.Parse(textBox11.Text);
			float J2 = float.Parse(textBox12.Text);

			float E1 = float.Parse(textBox13.Text);
			float E2 = float.Parse(textBox14.Text);
			float E3 = float.Parse(textBox15.Text);

			float[,] m = MatrixCreate(4, 4);
			m[0, 0] = (1 / R1) + (1 / R2) + (1 / R3); m[0, 1] = -(1 / R3); m[0, 2] = 0.0f; m[0, 3] = 0.0f;
			m[1, 0] = -(1 / R3); m[1, 1] = (1 / R3) + (1 / R6); m[1, 2] = -(1 / R6); m[1, 3] = 0.0f;
			m[2, 0] = 0.0f; m[2, 1] = -(1 / R6); m[2, 2] = ((1 / R6) + (1 / R2)); m[2, 3] = -(1 / R7);
			m[3, 0] = 0.0f; m[3, 1] = 0.0f; m[3, 2] = -(1 / R7); m[3, 3] = ((1 / R8) + (1 / R7));

			int[] perm;
			int toggle;

			float[,] luMatrix = MatrixDecompose(m, out perm, out toggle);

			float[,] lower = ExtractLower(luMatrix);
			float[,] upper = ExtractUpper(luMatrix);

			float det = MatrixDeterminant(m);

			Console.WriteLine("Determinant of m computed via decomposition = " + det.ToString("F1"));

			DataTable dt = new DataTable();
			dt.Columns.Add("W");

			dt.Rows.Add(new object[] { det.ToString("F1")});

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
