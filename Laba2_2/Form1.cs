using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace Laba1
{
	public partial class Form1 : Form
	{
		private Graphics g;

		public delegate double Fnc(double x);

		Fnc func;
		double a = 0;
		double b = 0;
		int det = 0;
		double h = 0;
		double sootnX = 0;

		public Form1()
		{
			InitializeComponent();
			//this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			g = this.CreateGraphics();
			
		}

		//1
		public double sx(double x)
		{
			return Math.Sin(x);
		}

		//2
		public double xq(double x)
		{
			return x*x;
		}

		//3
		public double third(double x)
		{
			return x * x * x;
		}

		private void Label2_Click(object sender, EventArgs e)
		{

		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Image newImage = Image.FromFile("1.jpg");
			GetRgbChannels(newImage);
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
		
		}

		private void TextBox4_TextChanged(object sender, EventArgs e)
		{
			
		}

		Bitmap[] GetRgbChannels(Image source)
		{
			Bitmap[] result = new Bitmap[3];
			ImageAttributes imageAttributes = new ImageAttributes();
			ColorMatrix[] matrices = new ColorMatrix[3];
			for (int i = 0; i < matrices.Length; i++)
			{
				float[][] elements ={
				new float[]{i == 0 ? 1 : 0, 0, 0, 0, 0},
				new float[]{0, i == 1 ? 1 : 0, 0, 0, 0},
				new float[]{0, 0, i == 2 ? 1 : 0, 0, 0},
				new float[]{0, 0, 0, 1, 0},
				new float[]{0, 0, 0, 0, 0}
			};
				matrices[i] = new ColorMatrix(elements);
			}
			int w = source.Width, h = source.Height;

			result[0] = new Bitmap(source); //red
			imageAttributes.ClearColorMatrix();
			imageAttributes.SetColorMatrix(matrices[0], ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			
			g.DrawImage(result[0], new Rectangle(0, 0, w, h), 0, 0, w, h, GraphicsUnit.Pixel, imageAttributes);
			result[0].Save($"res{0}.jpg");

			result[1] = new Bitmap(source); //green
			imageAttributes.ClearColorMatrix();
			imageAttributes.SetColorMatrix(matrices[1], ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			g.DrawImage(result[1], new Rectangle(0, h, w, h), 0, 0, w, h, GraphicsUnit.Pixel, imageAttributes);
			result[1].Save($"res{1}.jpg");

			result[2] = new Bitmap(source); //blue
			imageAttributes.ClearColorMatrix();
			imageAttributes.SetColorMatrix(matrices[2], ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			g.DrawImage(result[2], new Rectangle(w, h, w, h), 0, 0, w, h, GraphicsUnit.Pixel, imageAttributes);
			result[2].Save($"res{2}.jpg");

			//Отрисовать в отдельные файлы цветные отфильтрованные изображения
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new Bitmap(source);
				imageAttributes.ClearColorMatrix();
				imageAttributes.SetColorMatrix(matrices[i], ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				using (Graphics e = Graphics.FromImage(result[i]))
				{
					e.DrawImage(result[i], new Rectangle(0, 0, w, h), 0, 0, w, h, GraphicsUnit.Pixel, imageAttributes);

					result[i].Save($"res{i}.jpg");
				}
			}

			return result;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form2 newForm = new Form2();
			newForm.Show();
			Form3 newForm2 = new Form3();
			newForm2.Show();
			Form4 newForm3 = new Form4();
			newForm3.Show();
		}
	}
}
