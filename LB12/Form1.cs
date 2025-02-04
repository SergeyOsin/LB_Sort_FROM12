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
        private void clearcells(int id)
        {
            for (int i = 2; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[id].Cells[i].Value = " ";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int Size_Array = Convert.ToInt32(numericUpDown1.Value);
            Random rd = new Random();
            for (int i = 0; i < SIZE; i++) array[i] = rd.Next(0, SIZE);
            int[] arr = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[0].Cells[0].Value)) 
                BubbleSort(Size_Array, arr);
            else clearcells(0);
            int[] arr_1 = (int[])array.Clone();
            int[] arrayCopy = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[1].Cells[0].Value))
                ChooseSort(Size_Array, arrayCopy);
            else clearcells(1);
            if (Convert.ToBoolean(dataGridView1.Rows[2].Cells[0].Value))
                DirectConnection(Size_Array, arr_1);
            else clearcells(2);
        }
         private void BubbleSort(int Size_Array, int[]unarray)
        {
            int count_per = 0, compare = 0;
            bool flag = true;
            int StartTime = Environment.TickCount;
            for (int i = 0; i<Size_Array-1; i++)
            {
                for (int j = 0; j < Size_Array-1-i; j++)
                {
                    if (unarray[j] > unarray[j+1])
                    {
                        flag = false;
                        count_per++;
                        (unarray[j], unarray[j+1]) = (unarray[j+1], unarray[j]);
                    }
                    compare++;
                }
                if (flag)
                    break;
                flag = true;
            }
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[0].Cells[2].Value = compare;
            dataGridView1.Rows[0].Cells[3].Value = count_per;
            dataGridView1.Rows[0].Cells[4].Value = EndTime;
            dataGridView1.Rows[0].Cells[5].Value = (flag) ? "Да" : "Нет";
        }
        private void ChooseSort(int Size_Array, int[] unarray)
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
            bool sorted = true;
            for(int i = 1; i < Size_Array; i++)
            {
                if (unarray[i] < unarray[i - 1])
                {
                    sorted = false;
                    break;
                }
            }
            dataGridView1.Rows[1].Cells[2].Value = compare;
            dataGridView1.Rows[1].Cells[3].Value = count_per;
            dataGridView1.Rows[1].Cells[4].Value = EndTime;
            dataGridView1.Rows[1].Cells[5].Value = (sorted) ? "Да" : "Нет";
        }
        private void DirectConnection(int Size_Array, int[] unsortedarray1)
        {
            int count_per = 0, compare = 0;
            int StartTime = Environment.TickCount;
            int minindex = 0;
            for(int j = 1; j < Size_Array; j++)
            {
                if (unsortedarray1[j] < unsortedarray1[minindex])
                    minindex = j;
            }
            (unsortedarray1[0], unsortedarray1[minindex]) = (unsortedarray1[minindex], unsortedarray1[0]);
            for(int i = 2; i < Size_Array; i++)
            {
                int key = unsortedarray1[i];
                int j;
                for (j=i-1;  unsortedarray1[j]>key;j--,compare++)
                {
                    unsortedarray1[j + 1] = unsortedarray1[j];
                    count_per++;
                }
                unsortedarray1[j + 1] = key;
                compare++;
            }
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[2].Cells[2].Value = compare;
            dataGridView1.Rows[2].Cells[3].Value = count_per;
            dataGridView1.Rows[2].Cells[4].Value = EndTime;
            dataGridView1.Rows[2].Cells[5].Value = (isSorted(unsortedarray1,Size_Array)) ? "Да" : "Нет";
        }
        private bool isSorted(int[] array1,int Size_ar)
        {
            for (int i = 1; i < Size_ar; i++)
            {
                if (array1[i] <array1[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private void tablewrite()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowCount = 7;
            dataGridView1.ColumnCount = 6;
            string[] name_sorts = { "Обмен", "Выбор", "Включение", "Шелла", "Быстрая", "Линейная", "Встроенная"};
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[1].Value = name_sorts[i];
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.CornflowerBlue;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tablewrite();
        }
    }
}
