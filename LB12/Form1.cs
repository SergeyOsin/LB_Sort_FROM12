using System.Diagnostics.Metrics;
using System.Globalization;

namespace LB12
{
    public partial class Form1 : Form
    {
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
            int[] array = new int[Size_Array];
            Random rd = new Random();
            for (int i = 0; i < Size_Array; i++) array[i] = rd.Next(0, Size_Array);
            int[] arr = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[0].Cells[0].Value)) BubbleSort(Size_Array, arr);
            else clearcells(0);
            int[] arr_1 = (int[])array.Clone();
            int[] arrayCopy = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[1].Cells[0].Value))
                DirectConnection(Size_Array, arr_1);
            else clearcells(1);
            if (Convert.ToBoolean(dataGridView1.Rows[2].Cells[0].Value))
                ChooseSort(Size_Array, arrayCopy);
            else clearcells(2);
            int[] arr2 = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[3].Cells[0].Value))
                Sort_Shell(Size_Array, arr2);
            else clearcells(3);
            int[] arr4 = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[5].Cells[0].Value))
                LineSort(Size_Array, arr4);
            else clearcells(5);
            int[] arr5 = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[6].Cells[0].Value))
                BuildInFunction(Size_Array, arr5);
            else clearcells(6);
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
        }
        private void DirectConnection(int Size_Array, int[] unarray)
        {
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
            dataGridView1.Rows[1].Cells[2].Value = compare;
            dataGridView1.Rows[1].Cells[3].Value = count_per;
            dataGridView1.Rows[1].Cells[4].Value = EndTime;
        }
        private void ChooseSort(int Size_Array, int[] unsortedarray1)
        {
            int count_per = 0, compare = 0;
            int StartTime = Environment.TickCount;
            for(int i = 1; i < Size_Array; i++)
            {
                for (int j = i;  j > 0; j--)
                {
                    compare++;
                    if (unsortedarray1[j] < unsortedarray1[j - 1])
                    {
                        (unsortedarray1[j], unsortedarray1[j - 1]) = (unsortedarray1[j - 1], unsortedarray1[j]);
                         count_per++;
                    }
                    else break;                    
                }
                count_per++;
            }
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[2].Cells[2].Value = compare;
            dataGridView1.Rows[2].Cells[3].Value = count_per;
            dataGridView1.Rows[2].Cells[4].Value = EndTime;
        }
        private void LineSort(int Size_ar, int[] arr2)
        {
            int[] arrayB = new int[Size_ar];
            int compare = 0, count_change = 0;
            int StartTime = Environment.TickCount;
            for (int i = 0; i < Size_ar; i++)
            {
                arrayB[arr2[i]]++;
                count_change++;
            }
            for (int j = 0, ind = 0; j < Size_ar; j++)
            {
                compare++;
                if (arrayB[j] > 0)
                {
                    for (int k = ind; k < arrayB[j]+ind; k++)
                    {
                        arr2[k] = j;
                        count_change++;
                    }
                    ind += arrayB[j];
                }
            }
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[5].Cells[2].Value = compare;
            dataGridView1.Rows[5].Cells[3].Value = count_change;
            dataGridView1.Rows[5].Cells[4].Value = EndTime;
        }
        private void BuildInFunction(int Size_ar, int[] arr1)
        {
            int StartTime = Environment.TickCount;
            Array.Sort(arr1);
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[6].Cells[2].Value = "-";
            dataGridView1.Rows[6].Cells[3].Value = "-";
            dataGridView1.Rows[6].Cells[4].Value = EndTime;
        }
        private void Sort_Shell(int Size_ar, int[] arr1)
        {
            int compare = 0, count_per = 0;
            int StartTime = Environment.TickCount;
            
            int EndTime = Environment.TickCount;
            bool sorted = true;
            for(int i = 0; i < Size_ar - 1; i++)
            {
                if (arr1[i] > arr1[i + 1])
                {
                    sorted = false;
                    break;
                }
            }
            dataGridView1.Rows[3].Cells[4].Value = sorted;
        }
        private void tablewrite()
        {
            dataGridView1.AllowUserToAddRows = false;
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
