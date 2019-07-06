using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;


namespace DCviewer
{
    partial class ViewPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ArrayList allData = new ArrayList();
        //private string[] filters = new string[10];
        private ArrayList filters = new ArrayList();
        private ArrayList highLights = new ArrayList();

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.violinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zipHelperBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.violinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipHelperBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            this.textBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 319);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1013, 267);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 8;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
            // 
            // violinBindingSource
            // 
            this.violinBindingSource.DataSource = typeof(DCviewer.Violin);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("等线", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(495, 267);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox1_KeyDown);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListBox1_KeyPress);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseDown);
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
            this.richTextBox1.Size = new System.Drawing.Size(514, 267);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("等线", 12F);
            this.textBox2.Location = new System.Drawing.Point(79, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(931, 24);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2_KeyPress);
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
            this.zipHelperBindingSource.DataSource = typeof(Lis2013HISWSTest.ZipHelper);
            this.zipHelperBindingSource.CurrentChanged += new System.EventHandler(this.ZipHelperBindingSource_CurrentChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(906, 216);
            this.dataGridView1.TabIndex = 4;
            // 
            // ViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Name = "ViewPanel";
            this.Size = new System.Drawing.Size(1013, 589);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.violinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipHelperBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        public void addData(JArray jsons)
        {
            int maxData = 100;            
            foreach (var ajson in jsons)
            {
                string aJsonString = ajson.ToString();         
                //超上限的处理
                if (allData.Count == maxData)
                {
                    if (doFilter(allData[0].ToString()))
                        listBox1.Items.RemoveAt(0);
                    allData.RemoveAt(0);
                }
                //无论如何都添加新的
                allData.Add(aJsonString);
                if (doFilter(aJsonString))
                {
                    addListBoxItem(aJsonString);
                    setRichText();
                }
            }
            //DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
            //acCode.Name = "_ac_type";
            //acCode.DataPropertyName = "_ac_type";
            //acCode.HeaderText = "_ac_type";
            //dataGridView1.Columns.Add(acCode);
            //int index = dataGridView1.Rows.Add();
            //dataGridView1.Rows[index].Cells[0].Value = "123";
            //dataGridView1.Rows[index].Cells[1].Value = "测试数据";
        }

        private bool doFilter(string aJsonString)
        {
            //MessageBox.Show("in doFilter\n" + filters.Count.ToString());
            if (filters.Count == 0)
                return true;
            foreach(var eachFilter in filters)
            {
                if (aJsonString.Contains(eachFilter.ToString()))
                    return true;
            }
            return false;
        }

        public void addListBoxItem(string aItem)
        {
            listBox1.Items.Add(aItem);
            for (int i = 0; i < 20; i++)
                listBox1.Items.Add(aItem);
            listBox1.TopIndex = listBox1.Items.Count - (int)listBox1.Height / listBox1.ItemHeight;
        }

        public void setTextboxName(string aName)
        {
            this.textBox1.Text = aName;
        }

        public void addToRichbox(string aLine)
        {
            this.richTextBox1.Text.Insert(-1, aLine);
        }


        public void addToTreeView(string aName)
        {
            //this.treeView1.Nodes.Add(aName);
            //this.treeView1.Nodes[0].BackColor = Color.BurlyWood;


        }

        public void setRichText()
        {
            string aJsonString = "";
            richTextBox1.Clear();
            if (listBox1.Items.Count == 0)
                return;
            if (listBox1.SelectedItem == null)
                aJsonString = listBox1.Items[listBox1.Items.Count - 1].ToString();
            else
                aJsonString = listBox1.SelectedItem.ToString();


            aJsonString = "[" + aJsonString + "]";  //JArray.parse只能解析数组
            JArray ajson = JArray.Parse(aJsonString);

            //JObject ajson2 = (JObject)JsonConvert.DeserializeObject(aJsonString);


            //ArrayList aJsonBeforeSort = new ArrayList();
            //foreach (var one in ajson)
            //{
            //    string ss = one.ToString();
            //    if (ss.Contains("extractmap"))
            //    {
            //        ss = ss.Replace("\\", "") + "\n";
            //        aJsonBeforeSort.Insert(0, ss);
            //    }
            //    else
            //    {
            //        aJsonBeforeSort.Add(ss + "\n");
            //    }
            //}
            //foreach (string one in aJsonBeforeSort)
            //{
            //    richTextBox1.AppendText(one.ToString());
            //}

            foreach (var kv in ajson[0])
            {
                string kvs = kv.ToString();
                if (kvs.Contains("extractmap"))
                {
                    kvs = kvs.Replace("\\\"", "\"");
                    string extraJsonString = "[{" + kvs.Substring(16, kvs.Length - 17) + "]";
                    JArray extraJson = JArray.Parse(extraJsonString);

                    richTextBox1.AppendText("\"extractmap\": \"{\n");
                    foreach (var extraItem in extraJson[0])
                    {
                        richTextBox1.AppendText("    ");
                        richTextBoxAddColorText(extraItem.ToString());
                    }
                    richTextBox1.AppendText("}\"\n");
                    continue;
                }
                else
                    richTextBoxAddColorText(kvs);
            }
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
