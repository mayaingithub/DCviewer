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
        private int preListBox1SelectedIndex = -2;
        public ViewPanel()
        {
            InitializeComponent();
       }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void SplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (listBox1.SelectedIndex < 0)
                return;
            if (listBox1.SelectedIndex == preListBox1SelectedIndex)
            {
                listBox1.ClearSelected();
                preListBox1SelectedIndex = -2;
            }
            else
            {
                preListBox1SelectedIndex = listBox1.SelectedIndex;
                setRichText();
            }
            

        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //获取过滤关键字                 
            if (e.KeyChar == (char)Keys.Enter)
            {
                
                filters.Clear();
                foreach (var one in new ArrayList(textBox1.Text.Trim().Split(' ')))
                    if (one.ToString() != "")
                    {
                        filters.Add(one);
                    }
            
                //重新过滤
                listBox1.Items.Clear();
                if (allData.Count != 0)
                {
                    listBox1.BeginUpdate();
                    foreach (string aData in allData)
                    {
                        if (doFilter(aData))
                        {                             
                            addListBoxItem(aData);
                        }
                    }
                    listBox1.EndUpdate();
                }                
                setRichText();
            }
        }

       
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //获取高亮关键字
            
            if (e.KeyChar == (char)Keys.Enter)
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
            
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            //TextBox1_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void ListBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
       
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

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            
        }

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void ZipHelperBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
