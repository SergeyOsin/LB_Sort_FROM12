using System.Diagnostics.Metrics;
using System.Globalization;

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
            Random rd = new Random();
            for (int i = 0; i < SIZE; i++) array[i] = rd.Next(0, SIZE);
            if (Convert.ToBoolean(dataGridView1.Rows[0].Cells[0].Value))
                BubbleSort();
            if (Convert.ToBoolean(dataGridView1.Rows[1].Cells[0].Value))
                DirectChoise();
            
        }
        private void DirectChoise()
        {
            int Size_Array = Convert.ToInt32(numericUpDown1.Value);
            int[] unarray = array;
            int count_per = 0, compare = 0;
            int StartTime = Environment.TickCount;
            for (int i = Size_Array - 1; i > 0; i--)
            {
                int max = unarray[i];
                for (int j = 0; j < i; j++)
                {
                    max = Math.Max(max, unarray[j]);
                    compare++;
                }
                count_per++;
                (unarray[i], max) = (max, unarray[i]);
                
            }
            int EndTime = Environment.TickCount - StartTime;
            bool sorted = true;
            for(int j=0;j<Size_Array-1;j++)
                if (unarray[j] > unarray[j + 1])
                {
                    sorted = false;
                    break;
                }
            dataGridView1.Rows[1].Cells[2].Value = compare;
            dataGridView1.Rows[1].Cells[3].Value = count_per;
            dataGridView1.Rows[1].Cells[4].Value = EndTime;
            dataGridView1.Rows[1].Cells[5].Value = (sorted) ? "Да" : "Нет";
        }
        private void BubbleSort()
        {
            int[] unsortedarray = array;
            int Size_Array = Convert.ToInt32(numericUpDown1.Value);
            int count_per = 0, compare = 0;
            bool sorted = false;
            int StartTime = Environment.TickCount;
            {
                for (int i = 0; i < Size_Array - 1; i++)
                {
                    sorted = true;
                    for (int j = 0; j < Size_Array - i - 1; j++)
                    {
                        if (unsortedarray[j] > unsortedarray[j+1])
                        {
                            sorted = false;
                            count_per++;
                            (unsortedarray[j], unsortedarray[j+1]) = (unsortedarray[j+1], unsortedarray[j]);
                        }
                        compare++;
                    }
                    if (sorted)
                        break;
                }
            }
            int EndTime = (Environment.TickCount - StartTime);
            dataGridView1.Rows[0].Cells[2].Value = compare;
            dataGridView1.Rows[0].Cells[3].Value = count_per;
            dataGridView1.Rows[0].Cells[4].Value = EndTime;
            dataGridView1.Rows[0].Cells[5].Value = (sorted) ? "Да" : "Нет";
        }
        private void tablewrite()
        {
            dataGridView1.RowCount = 7;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Rows[0].Cells[1].Value = "Обмен";
            dataGridView1.Rows[1].Cells[1].Value = "Выбор";
            dataGridView1.Rows[2].Cells[1].Value = "Включение";
            dataGridView1.Rows[3].Cells[1].Value = "Шелла";
            dataGridView1.Rows[4].Cells[1].Value = "Быстрая";
            dataGridView1.Rows[5].Cells[1].Value = "Линейная";
            dataGridView1.Rows[6].Cells[1].Value = "Встроенная";
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.CornflowerBlue;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tablewrite();
            
        }
    }
}
