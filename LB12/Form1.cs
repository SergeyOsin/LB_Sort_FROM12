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
            Random rd = new Random();
            int[] array = new int[Size_Array];
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
            int[] arr3 = (int[])array.Clone();
            if (Convert.ToBoolean(dataGridView1.Rows[4].Cells[0].Value))
            {
                int StartTime = Environment.TickCount;
                QuickSort(arr3, 0, Size_Array - 1, 0, 0);
                int EndTime = Environment.TickCount - StartTime;
                dataGridView1.Rows[4].Cells[4].Value = EndTime;
            }
            else clearcells(4);
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
                for (int j = i;  j >0; j--)
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
        
        private void Sort_Shell(int Size_ar, int[] arr1)
        {
            int compare = 0, count_per = 0;
            int count_steps = (int)Math.Log2(Size_ar) - 1;
            int step = (int)Math.Pow(2, count_steps) - 1;
            int StartTime = Environment.TickCount;
            while (step > 0)
            {
                for(int i = step; i < Size_ar; i++)
                {
                    for (int j = i;j>=step;j-=step, compare++)
                    {
                        if (arr1[j] < arr1[j - step])
                        {
                            count_per++;
                            (arr1[j], arr1[j - step]) = (arr1[j - step], arr1[j]);
                        }
                        else break;
                    }
                    count_per++;
                }
                step /= 2;
            }
            int EndTime = Environment.TickCount - StartTime;
            dataGridView1.Rows[3].Cells[2].Value = compare;
            dataGridView1.Rows[3].Cells[3].Value = count_per;
            dataGridView1.Rows[3].Cells[4].Value = EndTime;
        }
        private void QuickSort(int[] arr3,int left,int right,int compare,int count_per)
        {
            int left1 = left, right1 = right;
            int middle = (left1 + right1) / 2;
            while (left1 <= right1)
            {
                while (arr3[left1] < arr3[middle])
                {
                    left1++;
                    compare++;
                }
                compare++;
                while (arr3[right1] > arr3[middle])
                {
                    right1--; compare++;
                }
                compare++;
                if (left1 <= right1)
                {
                    (arr3[left1], arr3[right1]) = (arr3[right1], arr3[left1]);
                    count_per++; left1++; right1--;
                }
            }
            if (left<right1) QuickSort(arr3,left, right1,compare,count_per);
            if(left1<right) QuickSort(arr3, left1, right,compare,count_per);
            dataGridView1.Rows[4].Cells[2].Value = compare;
            dataGridView1.Rows[4].Cells[3].Value = count_per;
        }
        private void tablewrite()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowCount = 7;
            dataGridView1.ColumnCount = 5;
            string[] name_sorts = { "Обмен", "Выбор", "Включение", "Шелла", "Быстрая", "Линейная", "Встроенная" };
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
