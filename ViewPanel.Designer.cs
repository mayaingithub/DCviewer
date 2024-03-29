﻿using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;
using System.Text.RegularExpressions;


namespace DCviewer
{
    partial class ViewPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public string rawBody = "";
        public string url = "";
        private ArrayList allData = new ArrayList();
        private ArrayList allFilterData = new ArrayList();
        private ArrayList filters = new ArrayList();
        private int maxAllDataNUm = 10000;
        private int maxShowNum = 100;
        private string preFiltersEditText = "";
        private string preHighLightExitText = "";
        private ArrayList highLights = new ArrayList();
        public showErrorForm showErrorForm = new showErrorForm();

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.violinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zipHelperBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.violinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipHelperBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(79, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(931, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.WordWrap = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            this.textBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Location = new System.Drawing.Point(0, 71);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1013, 706);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 8;
            this.splitContainer1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(495, 700);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGridView1_RowStateChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("等线", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(-149, 167);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(319, 242);
            this.listBox1.TabIndex = 3;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox1_KeyDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(514, 706);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBox1_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("等线", 12F);
            this.textBox2.Location = new System.Drawing.Point(79, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(931, 24);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "category _ac_type";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2_KeyPress);
            this.textBox2.Leave += new System.EventHandler(this.TextBox2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "过滤打点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "高亮字段";
            // 
            // zipHelperBindingSource
            // 
            this.zipHelperBindingSource.CurrentChanged += new System.EventHandler(this.ZipHelperBindingSource_CurrentChanged);
            // 
            // ViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Name = "ViewPanel";
            this.Size = new System.Drawing.Size(1013, 780);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.violinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipHelperBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        public void addData(JArray jsons)
        {                 
            foreach (var ajson in jsons)
            {
                string aJsonString = ajson.ToString();
                
                //超上限的处理
                if (allData.Count >= maxAllDataNUm)
                {               
                    allData.RemoveAt(0);
                    //如果超出上限的这条是满足过滤条件且显示在表格里的第1个
                    if (doFilter(allData[0].ToString()))
                    {
                        if (dataGridView1.CurrentRow.Index == 0)
                        {
                            isGridBottom = true;
                            preListBox1SelectedIndex = 0;
                            dataGridView1.ClearSelection();
                        }
                        allFilterData.RemoveAt(0);
                        dataGridView1.Rows.RemoveAt(0);
                        preGridRowNum -= 1;
                    }
                }
                //无论如何都添加新的
                allData.Add(aJsonString);


                if (doFilter(aJsonString))
                {
                    if (allFilterData.Count >= maxShowNum)
                    {
                        //选中的行是超出maxData的第一行，将被删除并重置
                        if (dataGridView1.CurrentRow.Index == 0)
                        {
                            dataGridView1.ClearSelection();
                            isGridBottom = true;
                            preListBox1SelectedIndex = 0;
                        }
                        allFilterData.RemoveAt(0);      
                        dataGridView1.Rows.RemoveAt(0);
                        preGridRowNum -= 1;
                    }
                    allFilterData.Add(aJsonString);
                    addOneToGridView(aJsonString);
                    preGridRowNum += 1;                 
                }
            }
          
            if (isGridBottom)
                setRichText();    
        }

        //显示
        private bool doFilter(string aJsonString)
        {            
            if (filters.Count == 0)
                return true;
            foreach(var eachFilter in filters)
            {
                if (aJsonString.Contains(eachFilter.ToString()))
                    return true;
            }
            return false;
        }

        private bool doHighlight(string aJsonString)
        {
            if (highLights.Count == 0)
                return false;
            foreach (var eachHighLight in highLights)
            {
                if (aJsonString.Contains(eachHighLight.ToString()))
                    return true;
            }
            return false;
        }

        public void addListBoxItem(string aItem)
        {
            listBox1.Items.Add(aItem);
            for (int i = 0; i < 2; i++)
                listBox1.Items.Add(aItem);
            listBox1.TopIndex = listBox1.Items.Count - (int)listBox1.Height / listBox1.ItemHeight;
        }


        public void setGridView()
        {
            initDataGridView();
            if (allFilterData.Count == 0)
                return;
            
            isGridSelectedIndexCanBeUpdated = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.SuspendLayout();            
            foreach (var eachItem in allFilterData)
            {
                addOneToGridView(eachItem.ToString());
            }         
            //固定在表格底部
            dataGridView1.CurrentCell = dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
            //preListBox1SelectedIndex = 0;

            dataGridView1.ResumeLayout();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            isGridSelectedIndexCanBeUpdated = true;
            setRichText();
        }


        public void addOneToGridView(string aItemString)
        {
            int index = dataGridView1.Rows.Add();
            while (aItemString.Contains(@"\\"))
            {
                aItemString = aItemString.Replace(@"\\", @"\");
            }
            aItemString = aItemString.Replace("\\\"", "\"");

            //判断是否要增加列
            if (filters.Count > 0)
            {
                for (int i = filters.Count; i > 0; i--)
                {
                    string aFilterString = filters[i - 1].ToString();
                    //判断过滤关键字是否已是列头
                    if (defaultColumns.Contains(aFilterString) || customColumns.Contains(aFilterString))
                        continue;
                    else
                    {                        
                        string pattern = string.Format("\"{0}\":\\s?\"(.*?)\"", aFilterString);                           
                        Match m = Regex.Match(aItemString, pattern);
                        while (m.Success)
                        {
                            addGridColumn(aFilterString);
                            dataGridView1.Rows[index].Cells[0].Value = m.Groups[1].ToString();
                            customColumns.Add(aFilterString);
                            m = m.NextMatch();
                        }
                    }
                }
            }
            if (highLights.Count > 0)
            {
                for (int i = highLights.Count; i > 0; i--)
                {
                    string aHighLightString = highLights[i - 1].ToString();
                    //判断高亮字段是否已是列头
                    if (defaultColumns.Contains(aHighLightString) || customColumns.Contains(aHighLightString))
                        continue;
                    else
                    {
                        string pattern = string.Format("\"{0}\":\\s?\"(.*?)\"", aHighLightString);
                        Match m = Regex.Match(aItemString, pattern);
                        while (m.Success)
                        {
                            addGridColumn(aHighLightString);
                            dataGridView1.Rows[index].Cells[0].Value = m.Groups[1].ToString();
                            customColumns.Add(aHighLightString);
                            m = m.NextMatch();
                        }
                    }
                }
            }

            //打点数据显示到对应的列
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                string headerText = dataGridView1.Columns[i].HeaderText;
                string pattern = string.Format("\"{0}\":\\s?\"(.*?)\"", headerText);
                if (aItemString.Contains(dataGridView1.Columns[i].Name))
                {
                    Match m = Regex.Match(aItemString, pattern);
                    while (m.Success)
                    {
                        dataGridView1.Rows[index].Cells[i].Value = m.Groups[1].ToString();
                        m = m.NextMatch();
                    }
                }
            }

            //整个打点完整显示在最后一列
            dataGridView1.Rows[index].Cells[dataGridView1.Columns.Count -1].Value = aItemString;

            //固定在表格底部
            if (isGridBottom)
            {
                if (dataGridView1.Rows.Count > 2)
                    dataGridView1.CurrentCell = dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0];
            }
        }

        public void setRichText()
        {
            string aJsonString = "";
            JArray ajson = new JArray();
            ArrayList colorString = new ArrayList();
            ArrayList blackString = new ArrayList();
            string extraString = "";

            if (dataGridView1.SelectedRows.Count == 0)
                return;
            aJsonString = allFilterData[dataGridView1.CurrentRow.Index].ToString();
            
            try
            {
                aJsonString = "[" + aJsonString + "]";  //JArray.parse只能解析数组
                ajson = JArray.Parse(aJsonString);                
            }
            catch
            {
                //showErrorForm.setErrorTextToRich("JArray.Parse 报错：\n" + url + "\n" + aJsonString + "\n原始数据：\n" + rawBody);
                //showErrorForm.Show();
                //showErrorForm.TopMost = true;
                richTextBox1.AppendText(aJsonString);
                string mailContent = "JArray.Parse 报错：\n" + url + "\n" + aJsonString + "\n原始数据：\n" + rawBody;
                SendMail.Send("zefeng.zhuang@happyelements.com", "DCviewer报错了", mailContent, new string[] { });
                return;
            }
           
            richTextBox1.Clear();
            if (filters.Count == 0 && highLights.Count == 0)
            {
                foreach (var kv in ajson[0])
                {
                    string kvs = kv.ToString();
                    if (kvs.Contains("extractmap"))
                    {
                        addExtramapToRichTextBox(kvs);
                    }
                    else
                    {
                        richTextBox1.AppendText(kvs + "\n");
                        //对特殊字段加一行解码显示
                        if (kvs.Contains("gamereplay"))
                        {
                            richTextBox1.AppendText(gamereplay(kvs) + "\n");
                        }
                    }                    
                }
            }
            else
            {   //将各字段分类，用于区分显示不同颜色
                //这种方法僵硬且效率低，但我试过其他方法没有这种逻辑清晰，且各种bug难维护
                foreach (var kv in ajson[0])
                {

                    string kvs = kv.ToString();
                    //对特殊字段加一行解码显示
                    if (kvs.Contains("extractmap"))
                    {
                        extraString = kvs;
                        continue;
                    }
                    if (filters.Count != 0 && doFilter(kvs))
                    {
                        colorString.Add(kv);
                        continue;
                    }
                    if (doHighlight(kvs))
                    {
                        colorString.Add(kv);
                        continue;
                    }
                    blackString.Add(kv);
                }

                //先显示高亮颜色的字段
                foreach (var arr in colorString)
                {
                    richTextBox1.SelectionColor = Color.OrangeRed;
                    string str = arr.ToString();
                    richTextBox1.AppendText(str + "\n");
                    if (str.Contains("gamereplay"))
                    {
                        richTextBox1.SelectionColor = Color.OrangeRed;
                        richTextBox1.AppendText(gamereplay(str) + "\n");
                    }
                }
                richTextBox1.SelectionColor = Color.Black;

                //再显示extramap字段
                addExtramapToRichTextBox(extraString);

                //最后显示普通字段
                foreach (var arr in blackString)
                {
                    string str = arr.ToString();
                    richTextBox1.AppendText(str + "\n");
                    if (str.Contains("gamereplay"))
                    {
                        richTextBox1.AppendText(gamereplay(str) + "\n");
                    }
                }
            }
 


            ////JObject ajson2 = (JObject)JsonConvert.DeserializeObject(aJsonString);


            ////ArrayList aJsonBeforeSort = new ArrayList();
            ////foreach (var one in ajson)
            ////{
            ////    string ss = one.ToString();
            ////    if (ss.Contains("extractmap"))
            ////    {
            ////        ss = ss.Replace("\\", "") + "\n";
            ////        aJsonBeforeSort.Insert(0, ss);
            ////    }
            ////    else
            ////    {
            ////        aJsonBeforeSort.Add(ss + "\n");
            ////    }
            ////}
            ////foreach (string one in aJsonBeforeSort)
            ////{
            ////    richTextBox1.AppendText(one.ToString());
            ////}

            //foreach (var kv in ajson[0])
            //{
            //    string kvs = kv.ToString();
            //    if (kvs.Contains("extractmap"))
            //    {
            //        kvs = kvs.Replace("\\\"", "\"");
            //        string extraJsonString = "[{" + kvs.Substring(16, kvs.Length - 17) + "]";
            //        JArray extraJson = JArray.Parse(extraJsonString);

            //        richTextBox1.AppendText("\"extractmap\": \"{\n");
            //        foreach (var extraItem in extraJson[0])
            //        {
            //            richTextBox1.AppendText("    ");
            //            richTextBoxAddColorText(extraItem.ToString());
            //        }
            //        richTextBox1.AppendText("}\"\n");
            //        continue;
            //    }
            //    else
            //        richTextBoxAddColorText(kvs);
            //}
        }

        public void addExtramapToRichTextBox(string extraString)
        {
            JArray extraJson = new JArray();
            while (extraString.Contains(@"\\"))
            {
                extraString = extraString.Replace(@"\\", @"\");
            }
            extraString = extraString.Replace("\\\"", "\"");
            
            {
                //抓幽灵bug
                if (extraString.Length < 16)
                {
                    showErrorForm.setErrorTextToRich("extraString.Length < 16 报错：\n" + url + "\n" + extraString + "\n原始数据：\n" + rawBody);
                    showErrorForm.Show();
                    showErrorForm.TopMost = true;
                }
            }
            string extraJsonString = extraString.Substring(15, extraString.Length - 16);
            
            //格式化数据,使可以解析出一层json或嵌套json
            extraJsonString = extraJsonString.Replace("{", "[{");
            extraJsonString = extraJsonString.Replace("}", "}]");
            extraJsonString = extraJsonString.Replace("\"[{", "[{");
            extraJsonString = extraJsonString.Replace("}]\"", "}]");
            extraJsonString = extraJsonString.Replace("\"[[", "[");
            extraJsonString = extraJsonString.Replace("]]\"", "]");

            //针对实名认证或闪验extractmap里还嵌套特殊一层无法解析成JArray.
            if (extraJsonString.Contains(@"loginAuth()"))
            {                
                extraJsonString = extraJsonString.Replace("\":\"loginAuth()", ":loginAuth()\":");
            }
            if (extraJsonString.Contains(@"requestPreLogin()"))
            {
                extraJsonString = extraJsonString.Replace("\":\"requestPreLogin()", ":requestPreLogin()\":");
            }


            try
            {
                extraJson = JArray.Parse(extraJsonString);
            }            
            catch
            {
                //showErrorForm.setErrorTextToRich("extraJson.Parse 报错：\n" + url + "\n" + extraJsonString + "\n原始数据：\n" + rawBody);
                //showErrorForm.Show();
                //showErrorForm.TopMost = true;
                richTextBox1.AppendText(extraString);
                string mailContent = "extraJson.Parse 报错：\n" + url + "\n" + extraJsonString + "\n原始数据：\n" + rawBody;
                SendMail.Send("zefeng.zhuang@happyelements.com", "DCviewer报错了", mailContent, new string[] { });
                return;
            }
            richTextBox1.AppendText("\"extractmap\": \"{\n");

            foreach (var extraItem in extraJson[0])
            {
                string extraItemString = extraItem.ToString();
                richTextBox1.AppendText("    ");
                //对嵌套的json，进行格式化输出    
                if (extraItemString.Contains("[") && extraItemString.Contains("{"))
                {
                    extraItemString = extraItemString.Replace("[", "").Replace("]", "");
                    extraItemString = extraItemString.Replace("  ", "    ");
                    extraItemString = extraItemString.Replace("\n", "");
                }
                richTextBoxAddColorText(extraItemString);
            }
            richTextBox1.AppendText("}\"\n");
        }

        public void richTextBoxAddColorText(string string2add)
        { 
            //设置过滤字段颜色
            foreach (var afilter in filters)
            {
                string afs = afilter.ToString();
                if (filters[0].ToString() == "")
                    break;
                if (string2add.Contains(afs))
                {
                    richTextBox1.SelectionColor = Color.OrangeRed;
                    break;
                }                                              
            }
            //设置高亮字段颜色
            foreach (var ahighLight in highLights)
            {
                string ahl = ahighLight.ToString();
                if (highLights[0].ToString() == "")
                    break;
                if (string2add.Contains(ahl))
                {
                richTextBox1.SelectionColor = Color.OrangeRed;    //DeepPink;
                    break;
                }
            }
                
            richTextBox1.AppendText(string2add + "\n");
            richTextBox1.SelectionColor = Color.Black;
        }

        public string gamereplay(string raw)
        {
            string str = raw.Substring(15,raw.Length -16);
            byte[] bb = Convert.FromBase64String(str);
            byte[] unzip = Lis2013HISWSTest.ZipHelper.Decompress(bb);
            return "\"gamereplay解码\": \n" + System.Text.Encoding.Default.GetString(unzip);            
        }


        //  public void BindTreeView(string strJson)
        //{
        //    treeView1.Nodes.Clear();

        //    if (IsJOjbect(strJson))
        //    {
        //        JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);

        //        foreach (var item in jo)
        //        {
        //            TreeNode tree;
        //            if (item.Value.GetType() == typeof(JObject))
        //            {
        //                tree = new TreeNode(item.Key);
        //                AddTreeChildNode(ref tree, item.Value.ToString());
        //                treeView1.Nodes.Add(tree);
        //            }
        //            else if (item.Value.GetType() == typeof(JArray))
        //            {
        //                tree = new TreeNode(item.Key);
        //                AddTreeChildNode(ref tree, item.Value.ToString());
        //                treeView1.Nodes.Add(tree);
        //            }
        //            else
        //            {
        //                tree = new TreeNode(item.Key + " : " + item.Value.ToString());
        //                treeView1.Nodes.Add(tree);
        //            }
        //        }
        //    }
        //    if (IsJArray(strJson))
        //    {
        //        JArray ja = (JArray)JsonConvert.DeserializeObject(strJson);
        //        foreach (JObject item in ja)
        //        {
        //            TreeNode tree = new TreeNode();
        //            foreach (var itemOb in item)
        //            {
        //                TreeNode treeOb;
        //                if (itemOb.Value.GetType() == typeof(JObject))
        //                {
        //                    treeOb = new TreeNode(itemOb.Key);
        //                    AddTreeChildNode(ref treeOb, itemOb.Value.ToString());
        //                    tree.Nodes.Add(treeOb);

        //                }
        //                else if (itemOb.Value.GetType() == typeof(JArray))
        //                {
        //                    treeOb = new TreeNode(itemOb.Key);
        //                    AddTreeChildNode(ref treeOb, itemOb.Value.ToString());
        //                    tree.Nodes.Add(treeOb);
        //                }
        //                else
        //                {
        //                    treeOb = new TreeNode(itemOb.Key + " : " + itemOb.Value.ToString());
        //                    tree.Nodes.Add(treeOb);
        //                }
        //            }
        //            treeView1.Nodes.Add(tree);
        //        }
        //    }
        //    treeView1.ExpandAll();
        //}
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="parantNode"></param>
        /// <param name="value"></param>
        public void AddTreeChildNode(ref TreeNode parantNode, string value)
        {
            if (IsJOjbect(value))
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(value);
                foreach (var item in jo)
                {
                    TreeNode tree;
                    if (item.Value.GetType() == typeof(JObject))
                    {
                        tree = new TreeNode(item.Key);
                        AddTreeChildNode(ref tree, item.Value.ToString());
                        parantNode.Nodes.Add(tree);
                    }
                    else if (item.Value.GetType() == typeof(JArray))
                    {
                        tree = new TreeNode(item.Key);
                        AddTreeChildNode(ref tree, item.Value.ToString());
                        parantNode.Nodes.Add(tree);
                    }
                    else
                    {
                        tree = new TreeNode(item.Key + " : " + item.Value.ToString());
                        parantNode.Nodes.Add(tree);
                    }
                }
            }
            if (IsJArray(value))
            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(value);
                foreach (JObject item in ja)
                {
                    TreeNode tree = new TreeNode();
                    parantNode.Nodes.Add(tree);
                    foreach (var itemOb in item)
                    {
                        TreeNode treeOb;
                        if (itemOb.Value.GetType() == typeof(JObject))
                        {
                            treeOb = new TreeNode(itemOb.Key);
                            AddTreeChildNode(ref treeOb, itemOb.Value.ToString());
                            tree.Nodes.Add(treeOb);

                        }
                        else if (itemOb.Value.GetType() == typeof(JArray))
                        {
                            treeOb = new TreeNode(itemOb.Key);
                            AddTreeChildNode(ref treeOb, itemOb.Value.ToString());
                            tree.Nodes.Add(treeOb);
                        }
                        else
                        {
                            treeOb = new TreeNode(itemOb.Key + " : " + itemOb.Value.ToString());
                            tree.Nodes.Add(treeOb);
                        }
                    }
                }
            }
        }
        /// <summary>
        ///  判断是否JOjbect类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsJOjbect(string value)
        {
            try
            {
                JObject ja = JObject.Parse(value);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 判断是否JArray类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsJArray(string value)
        {
            try
            {
                JArray ja = JArray.Parse(value);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private System.Windows.Forms.TextBox textBox1;
        private SplitContainer splitContainer1;
        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private BindingSource zipHelperBindingSource;
        private BindingSource violinBindingSource;
        private DataGridView dataGridView1;
    }

  
}
