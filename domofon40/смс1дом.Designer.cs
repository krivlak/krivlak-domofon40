namespace domofon40
{
    partial class смс1дом
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            this.отклColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.подклColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.договор_сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сведенияColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.звонокColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.тефонColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.действуетColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.отключитьColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.должникColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.долг_рубColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.долг_месColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.квартираColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.вводColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.примColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // отклColumn
            // 
            this.отклColumn.DataPropertyName = "откл";
            this.отклColumn.HeaderText = "отключен";
            this.отклColumn.Name = "отклColumn";
            this.отклColumn.ReadOnly = true;
            // 
            // подклColumn
            // 
            this.подклColumn.DataPropertyName = "подкл";
            this.подклColumn.HeaderText = "подключен";
            this.подклColumn.Name = "подклColumn";
            this.подклColumn.ReadOnly = true;
            // 
            // договор_сColumn
            // 
            this.договор_сColumn.DataPropertyName = "договор_с";
            this.договор_сColumn.HeaderText = "договор с";
            this.договор_сColumn.Name = "договор_сColumn";
            this.договор_сColumn.ReadOnly = true;
            // 
            // сведенияColumn
            // 
            this.сведенияColumn.DataPropertyName = "сведения";
            this.сведенияColumn.HeaderText = "сведения";
            this.сведенияColumn.Name = "сведенияColumn";
            this.сведенияColumn.ReadOnly = true;
            this.сведенияColumn.Width = 200;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "id_сообщения";
            this.idColumn.HeaderText = "id сообщения ";
            this.idColumn.Name = "idColumn";
            this.idColumn.Width = 150;
            // 
            // звонокColumn
            // 
            this.звонокColumn.DataPropertyName = "последний_звонок";
            this.звонокColumn.HeaderText = "последний  звонок";
            this.звонокColumn.Name = "звонокColumn";
            // 
            // тефонColumn
            // 
            this.тефонColumn.DataPropertyName = "телефон";
            this.тефонColumn.HeaderText = "телефон";
            this.тефонColumn.Name = "тефонColumn";
            this.тефонColumn.Width = 200;
            // 
            // действуетColumn
            // 
            this.действуетColumn.DataPropertyName = "действует";
            this.действуетColumn.HeaderText = "наш клиент";
            this.действуетColumn.Name = "действуетColumn";
            this.действуетColumn.ReadOnly = true;
            this.действуетColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.действуетColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.действуетColumn.Width = 40;
            // 
            // отключитьColumn
            // 
            this.отключитьColumn.DataPropertyName = "смс";
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle41.NullValue = false;
            this.отключитьColumn.DefaultCellStyle = dataGridViewCellStyle41;
            this.отключитьColumn.HeaderText = "послать смс";
            this.отключитьColumn.Name = "отключитьColumn";
            this.отключитьColumn.Width = 40;
            // 
            // должникColumn
            // 
            this.должникColumn.DataPropertyName = "должник";
            this.должникColumn.HeaderText = "должник";
            this.должникColumn.Name = "должникColumn";
            this.должникColumn.ReadOnly = true;
            this.должникColumn.Width = 40;
            // 
            // долг_рубColumn
            // 
            this.долг_рубColumn.DataPropertyName = "долг_руб";
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle42.Format = "0;#;#";
            this.долг_рубColumn.DefaultCellStyle = dataGridViewCellStyle42;
            this.долг_рубColumn.HeaderText = "долг руб";
            this.долг_рубColumn.Name = "долг_рубColumn";
            this.долг_рубColumn.Width = 80;
            // 
            // долг_месColumn
            // 
            this.долг_месColumn.DataPropertyName = "долг_мес";
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle43.Format = "0;#;#";
            this.долг_месColumn.DefaultCellStyle = dataGridViewCellStyle43;
            this.долг_месColumn.HeaderText = "долг мес";
            this.долг_месColumn.Name = "долг_месColumn";
            this.долг_месColumn.ReadOnly = true;
            this.долг_месColumn.Width = 40;
            // 
            // месяцColumn
            // 
            this.месяцColumn.DataPropertyName = "месяц";
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle44.Format = "0;#;#";
            this.месяцColumn.DefaultCellStyle = dataGridViewCellStyle44;
            this.месяцColumn.HeaderText = "месяц";
            this.месяцColumn.Name = "месяцColumn";
            this.месяцColumn.ReadOnly = true;
            this.месяцColumn.Width = 30;
            // 
            // годColumn
            // 
            this.годColumn.DataPropertyName = "год";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle45.Format = "0;#;#";
            this.годColumn.DefaultCellStyle = dataGridViewCellStyle45;
            this.годColumn.HeaderText = "год";
            this.годColumn.Name = "годColumn";
            this.годColumn.ReadOnly = true;
            this.годColumn.Width = 40;
            // 
            // услугаColumn
            // 
            this.услугаColumn.DataPropertyName = "наимен_услуги";
            this.услугаColumn.HeaderText = "услуга";
            this.услугаColumn.Name = "услугаColumn";
            this.услугаColumn.ReadOnly = true;
            // 
            // фиоColumn
            // 
            this.фиоColumn.DataPropertyName = "фио";
            this.фиоColumn.HeaderText = "фио";
            this.фиоColumn.Name = "фиоColumn";
            this.фиоColumn.ReadOnly = true;
            this.фиоColumn.Width = 150;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeight = 80;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.квартираColumn,
            this.вводColumn,
            this.фиоColumn,
            this.услугаColumn,
            this.годColumn,
            this.месяцColumn,
            this.долг_месColumn,
            this.долг_рубColumn,
            this.должникColumn,
            this.отключитьColumn,
            this.действуетColumn,
            this.тефонColumn,
            this.звонокColumn,
            this.idColumn,
            this.сведенияColumn,
            this.договор_сColumn,
            this.подклColumn,
            this.отклColumn,
            this.примColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1783, 682);
            this.dataGridView1.TabIndex = 8;
            // 
            // квартираColumn
            // 
            this.квартираColumn.DataPropertyName = "квартира";
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle47.Format = "0;#;#";
            this.квартираColumn.DefaultCellStyle = dataGridViewCellStyle47;
            this.квартираColumn.HeaderText = "квартира";
            this.квартираColumn.Name = "квартираColumn";
            this.квартираColumn.ReadOnly = true;
            this.квартираColumn.Width = 40;
            // 
            // вводColumn
            // 
            this.вводColumn.DataPropertyName = "ввод";
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle48.Format = "0;#;#";
            this.вводColumn.DefaultCellStyle = dataGridViewCellStyle48;
            this.вводColumn.HeaderText = "ввод";
            this.вводColumn.Name = "вводColumn";
            this.вводColumn.ReadOnly = true;
            this.вводColumn.Width = 30;
            // 
            // примColumn
            // 
            this.примColumn.DataPropertyName = "прим";
            this.примColumn.HeaderText = "примечание";
            this.примColumn.Name = "примColumn";
            this.примColumn.ReadOnly = true;
            this.примColumn.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1783, 57);
            this.panel1.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(683, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 27);
            this.checkBox1.TabIndex = 130;
            this.checkBox1.Text = "Все";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(899, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(204, 35);
            this.button5.TabIndex = 129;
            this.button5.Text = "сформировать сообщение";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1301, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 28);
            this.button4.TabIndex = 127;
            this.button4.Text = "записать звонок";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1145, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 126;
            this.button3.Text = "проверка 1 сообщ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 125;
            this.label3.Text = "остаток руб.";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(528, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(88, 22);
            this.textBox3.TabIndex = 124;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 123;
            this.label2.Text = "сообщений за день";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(343, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(68, 22);
            this.textBox2.TabIndex = 122;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 121;
            this.label4.Text = "лимит на день";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 22);
            this.textBox1.TabIndex = 120;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1507, 8);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 34);
            this.button6.TabIndex = 8;
            this.button6.Text = "Подробности";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1664, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // смс1дом
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1783, 739);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "смс1дом";
            this.Text = "смс1дом";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.смс1дом_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn отклColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn подклColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn договор_сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сведенияColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn звонокColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn тефонColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn действуетColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn отключитьColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn должникColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn долг_рубColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn долг_месColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn квартираColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn вводColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn примColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
    }
}