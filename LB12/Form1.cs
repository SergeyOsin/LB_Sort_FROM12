using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace LB12
{
    public partial class Form1 : Form
    {
        const int SIZE = 100000;
        int[] array = new int[SIZE];
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Size_Array = Convert.ToInt32(numericUpDown1.Value);
            Random rd = new Random();
            for (int i = 0; i < Size_Array; i++) array[i] = rd.Next(0, SIZE);
            int[] arr_1 = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[0].Cells[0].Value))
                BubbleSort(Size_Array, arr_1);
            int[] arr_2 = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[1].Cells[0].Value))
                DirectConnection(Size_Array, arr_2);
            
        }
        private void BubbleSort(int Size_Array, int[] unsortedarray)
        {
            int count_per = 0, compare = 0;
            bool sorted = true;
            int StartTime = Environment.TickCount;
            {
                for (int i = 0; i < Size_Array - 1; i++)
                {
                    for (int j = 0; j < Size_Array - i - 1; j++)
                    {
                        if (unsortedarray[j] > unsortedarray[j + 1])
                        {
                            sorted = false;
                            count_per++;
                            (unsortedarray[j], unsortedarray[j + 1]) = (unsortedarray[j + 1], unsortedarray[j]);
                        }
                        compare++;
                    }
                    if (sorted)
                        break;
                    sorted = true;
                }
            }
            int EndTime = (Environment.TickCount - StartTime);
            dataGridView1.Rows[0].Cells[2].Value = compare;
            dataGridView1.Rows[0].Cells[3].Value = count_per;
            dataGridView1.Rows[0].Cells[4].Value = EndTime;
        }
        private void DirectConnection(int Size_Array, int[] unarray)
        {

            int count_per = 0, compare = 0;
            int StartTime = Environment.TickCount;
            for (int i = Size_Array - 1; i > 0; i--)
            {
                int max = array[i];
                for (int j = 0; j < i; j++)
                {
                    max = Math.Max(max, unarray[j]);
                    compare++;
                }
                count_per++;
                (unarray[i], max) = (max, unarray[i]);
            }
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[1].Cells[2].Value = compare;
            dataGridView1.Rows[1].Cells[3].Value = count_per;
            dataGridView1.Rows[1].Cells[4].Value = EndTime;
        }
        private void tablewrite()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowCount = 7;
            dataGridView1.ColumnCount = 5;
            string[] sorts = { "Обмен", "Выбор", "Включение", "Шелла", "Быстрая", "Линейная", "Встроенная" };
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[1].Value = sorts[i];
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.CornflowerBlue;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tablewrite();
        }
    }
}
