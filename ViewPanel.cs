using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DCviewer
{
    public partial class ViewPanel : UserControl
    {
        private int preListBox1SelectedIndex = 0;
        private int preGridRowNum = -1;   //+1是之前的总行数，辅助判断gridselected是手动还是自动切到新行的
        private bool isGridBottom = true;   //是否将表格显示在底部
        private bool isGridSelectedIndexCanBeUpdated = true;
        private ArrayList defaultColumns = new ArrayList{ "all", "_ac_type", "sub_category", "category"};
        private ArrayList customColumns = new ArrayList();
        
        public ViewPanel()
        {
            
            InitializeComponent();
            initDataGridView();
           
        }


        private void initDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();
            customColumns.Clear();

            foreach (var column in defaultColumns)
            {
                addGridColumn(column.ToString());
            }
        }

        private void addGridColumn(string columnName)
        {
            DataGridViewTextBoxColumn columnToInsert = new DataGridViewTextBoxColumn();
            columnToInsert.Name = columnName;
            columnToInsert.HeaderText = columnName;
            columnToInsert.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Insert(0, columnToInsert);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //if (listBox1.SelectedIndex < 0)
            //    return;
            //if (listBox1.SelectedIndex == preListBox1SelectedIndex)
            //{
            //    listBox1.ClearSelected();
            //    preListBox1SelectedIndex = -2;
            //}
            //else
            //{
            //    preListBox1SelectedIndex = listBox1.SelectedIndex;
            //    setRichText("listBox");
            //}            
        }


        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //获取过滤关键字                 
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                reFilter();

                //作废listbox
                //listBox1.Items.Clear();
                //if (allData.Count != 0)
                //{
                //    listBox1.BeginUpdate();
                //    foreach (string aData in allData)
                //    {
                //        if (doFilter(aData))
                //        {                             
                //            addListBoxItem(aData);
                //        }
                //    }
                //    listBox1.EndUpdate();
                //}                
                //setRichText();                

            }         
        }


        private void TextBox1_Leave(object sender, EventArgs e)
        {
            reFilter();
        }


        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //获取高亮关键字            
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                reHighlights();
            }            
        }


        private void TextBox2_Leave(object sender, EventArgs e)
        {
            reHighlights();
        }


        private void reFilter()
        {
            string newFiltersEditText = textBox1.Text.Trim();

            //如果新的过滤字段内容一样，则不作后续处理
            //if (String.Compare(newFiltersEditText, preFiltersEditText) == 0)
            if (newFiltersEditText == preFiltersEditText)
            {
                return;
            }            

            preFiltersEditText = newFiltersEditText;
            filters.Clear();
            customColumns.Clear();
            foreach (var one in new ArrayList(textBox1.Text.Trim().Split(' ')))
                if (one.ToString() != "")
                {
                    filters.Add(one);
                }     

            //重新过滤
            if (allData.Count != 0)
            {
                allFilterData.Clear();
                foreach (string aData in allData)
                {
                    if (doFilter(aData))
                    {
                        allFilterData.Add(aData);
                    }
                }
            }
            dataGridView1.ClearSelection();
            isGridBottom = true;
            preListBox1SelectedIndex = 0;
            preGridRowNum = allFilterData.Count -1;
            setGridView();
            isGridBottom = true;    //过滤显示完成后需要再次初始化isGridBottom
        }


        private void reHighlights()
        {
            highLights.Clear();
            foreach (var one in new ArrayList(textBox2.Text.Trim().Split(' ')))
                if (one.ToString() != "")
                {
                    highLights.Add(one);
                }
            //刷新显示
            setRichText();
        }
        

        private void ListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X)
            {
                allData.Clear();
                listBox1.Items.Clear();
                richTextBox1.Clear();
            }
        }


        private void ZipHelperBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //添加行号，要记得打开RowHeadersVisible为true
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int id = -1;
            if (isGridBottom && dataGridView1.Rows.Count == 1)
            {
                //MessageBox.Show("make sure return\n"+ isGridBottom.ToString()+"\n"+dataGridView1.Rows.Count.ToString());
                return;
            }            

            //int id = dataGridView1.CurrentRow.Index;      表格的选中行的取法，各种难以捉摸
            //int id = e.Row.Index;                         表格的选中行的取法，各种难以捉摸
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = dataGridView1.SelectedRows[0].Index;
            }

            //超出上限被顶掉了，重新置到底部
            //if (dataGridView1.Rows.Count < preGridRowNum + 1)
            //{
            //    MessageBox.Show("dataGridView1.Rows.Count < preGridRowNum + 1"
            //        + "\nisGridBottom: " + isGridBottom.ToString()
            //        + "\npreListBox1SelectedIndex: " + preListBox1SelectedIndex.ToString());
            //}
                
            if (dataGridView1.Rows.Count < preGridRowNum + 1 && isGridBottom && preListBox1SelectedIndex <=0)
            {
                //MessageBox.Show("dataGridView1.Rows.Count: " + dataGridView1.Rows.Count.ToString()
                //    + "\npreGridRowNum +1: " + (preGridRowNum + 1).ToString()
                //    + "\npreListBox1SelectedIndex: " + preListBox1SelectedIndex.ToString());
                dataGridView1.ClearSelection();
                isGridBottom = true;
                preListBox1SelectedIndex = id;
                return;
            }

            //MessageBox.Show("in SelectionChanged\n" +
            //    "id: " + id +
            //    "\npreListBox1SelectedIndex: " + preListBox1SelectedIndex.ToString() +
            //    "\nisGridBottom: " + isGridBottom.ToString() +
            //    "\npreGridRowNum: " + preGridRowNum.ToString());
            if (isGridSelectedIndexCanBeUpdated)
            {
                if (!(id == 99 && id == preGridRowNum)) //非(100条且置底)
                {
                    if (id > preGridRowNum) //如果自动选中的是新加一行，而不是手选的
                    {
                        preGridRowNum = id -1;
                        //MessageBox.Show("if (id > preGridRowNum)");
                    }
                    else
                    {
                        //MessageBox.Show("in else\n" + "preGridRowNum: " + preGridRowNum.ToString());
                        preListBox1SelectedIndex = id;
                        //if (isGridBottom && preGridRowNum > 98)
                        //    MessageBox.Show("id: " + id.ToString()
                        //        + "\npreGridRowNum:" + preGridRowNum.ToString());
                        if (id >= 0)
                            isGridBottom = false;
                    }
                }
              
            }
            if (isGridSelectedIndexCanBeUpdated)
                setRichText();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id == preListBox1SelectedIndex)
            {
                dataGridView1.ClearSelection();
                isGridBottom = true;
                preListBox1SelectedIndex = 0;
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X)
            {
                allData.Clear();
                allFilterData.Clear();
                initDataGridView();
                richTextBox1.Clear();
                preGridRowNum = -1;
                isGridBottom = true;
                preListBox1SelectedIndex = 0;
            }
        }

  
    }
}
