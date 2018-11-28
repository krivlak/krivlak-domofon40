namespace domofon40
{
    partial class по_видам
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
            System.Windows.Forms.Label прим0Label;
            System.Windows.Forms.Label телефонLabel;
            System.Windows.Forms.Label отчествоLabel;
            System.Windows.Forms.Label имяLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.прим0TextBox = new System.Windows.Forms.TextBox();
            this.телефонTextBox = new System.Windows.Forms.TextBox();
            this.отчествоTextBox = new System.Windows.Forms.TextBox();
            this.имяTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.адресColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.долгColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отключитьColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.отключенColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.повторноColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.звонокColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.примColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.должникColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            прим0Label = new System.Windows.Forms.Label();
            телефонLabel = new System.Windows.Forms.Label();
            отчествоLabel = new System.Windows.Forms.Label();
            имяLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // прим0Label
            // 
            прим0Label.AutoSize = true;
            прим0Label.Location = new System.Drawing.Point(644, 43);
            прим0Label.Name = "прим0Label";
            прим0Label.Size = new System.Drawing.Size(42, 13);
            прим0Label.TabIndex = 22;
            прим0Label.Text = "прим0:";
            // 
            // телефонLabel
            // 
            телефонLabel.AutoSize = true;
            телефонLabel.Location = new System.Drawing.Point(339, 41);
            телефонLabel.Name = "телефонLabel";
            телефонLabel.Size = new System.Drawing.Size(53, 13);
            телефонLabel.TabIndex = 20;
            телефонLabel.Text = "телефон:";
            // 
            // отчествоLabel
            // 
            отчествоLabel.AutoSize = true;
            отчествоLabel.Location = new System.Drawing.Point(160, 42);
            отчествоLabel.Name = "отчествоLabel";
            отчествоLabel.Size = new System.Drawing.Size(57, 13);
            отчествоLabel.TabIndex = 18;
            отчествоLabel.Text = "Отчество:";
            // 
            // имяLabel
            // 
            имяLabel.AutoSize = true;
            имяLabel.Location = new System.Drawing.Point(4, 39);
            имяLabel.Name = "имяLabel";
            имяLabel.Size = new System.Drawing.Size(32, 13);
            имяLabel.TabIndex = 16;
            имяLabel.Text = "Имя:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(прим0Label);
            this.panel1.Controls.Add(this.прим0TextBox);
            this.panel1.Controls.Add(телефонLabel);
            this.panel1.Controls.Add(this.телефонTextBox);
            this.panel1.Controls.Add(отчествоLabel);
            this.panel1.Controls.Add(this.отчествоTextBox);
            this.panel1.Controls.Add(имяLabel);
            this.panel1.Controls.Add(this.имяTextBox);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 66);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(474, 5);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 19);
            this.button5.TabIndex = 25;
            this.button5.Text = "Записать звонок или смс";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(320, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 23);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Должники";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // прим0TextBox
            // 
            this.прим0TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.прим0TextBox.Location = new System.Drawing.Point(689, 38);
            this.прим0TextBox.MaxLength = 50;
            this.прим0TextBox.Name = "прим0TextBox";
            this.прим0TextBox.Size = new System.Drawing.Size(297, 20);
            this.прим0TextBox.TabIndex = 23;
            // 
            // телефонTextBox
            // 
            this.телефонTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.телефонTextBox.Location = new System.Drawing.Point(398, 38);
            this.телефонTextBox.MaxLength = 50;
            this.телефонTextBox.Name = "телефонTextBox";
            this.телефонTextBox.Size = new System.Drawing.Size(229, 20);
            this.телефонTextBox.TabIndex = 21;
            // 
            // отчествоTextBox
            // 
            this.отчествоTextBox.Location = new System.Drawing.Point(223, 39);
            this.отчествоTextBox.Name = "отчествоTextBox";
            this.отчествоTextBox.Size = new System.Drawing.Size(100, 20);
            this.отчествоTextBox.TabIndex = 19;
            // 
            // имяTextBox
            // 
            this.имяTextBox.Location = new System.Drawing.Point(43, 39);
            this.имяTextBox.Name = "имяTextBox";
            this.имяTextBox.Size = new System.Drawing.Size(100, 20);
            this.имяTextBox.TabIndex = 17;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Задание на отключение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Подробности";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(724, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.адресColumn,
            this.фиоColumn,
            this.услугаColumn,
            this.годColumn,
            this.месяцColumn,
            this.долгColumn,
            this.отключитьColumn,
            this.отключенColumn,
            this.повторноColumn,
            this.звонокColumn,
            this.примColumn,
            this.должникColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1050, 487);
            this.dataGridView1.TabIndex = 1;
            // 
            // адресColumn
            // 
            this.адресColumn.DataPropertyName = "адрес";
            this.адресColumn.HeaderText = "адрес";
            this.адресColumn.Name = "адресColumn";
            this.адресColumn.ReadOnly = true;
            this.адресColumn.Width = 150;
            // 
            // фиоColumn
            // 
            this.фиоColumn.DataPropertyName = "фио";
            this.фиоColumn.HeaderText = "фио";
            this.фиоColumn.Name = "фиоColumn";
            this.фиоColumn.ReadOnly = true;
            // 
            // услугаColumn
            // 
            this.услугаColumn.DataPropertyName = "наимен_услуги";
            this.услугаColumn.HeaderText = "услуга";
            this.услугаColumn.Name = "услугаColumn";
            this.услугаColumn.ReadOnly = true;
            // 
            // годColumn
            // 
            this.годColumn.DataPropertyName = "год";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0;#;#";
            this.годColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.годColumn.FillWeight = 60F;
            this.годColumn.HeaderText = "год";
            this.годColumn.Name = "годColumn";
            this.годColumn.ReadOnly = true;
            this.годColumn.Width = 50;
            // 
            // месяцColumn
            // 
            this.месяцColumn.DataPropertyName = "месяц";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0;#;#";
            this.месяцColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.месяцColumn.FillWeight = 40F;
            this.месяцColumn.HeaderText = "месяц";
            this.месяцColumn.Name = "месяцColumn";
            this.месяцColumn.ReadOnly = true;
            this.месяцColumn.Width = 40;
            // 
            // долгColumn
            // 
            this.долгColumn.DataPropertyName = "долг_мес";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0;#;#";
            this.долгColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.долгColumn.FillWeight = 40F;
            this.долгColumn.HeaderText = "долг мес.";
            this.долгColumn.Name = "долгColumn";
            this.долгColumn.ReadOnly = true;
            this.долгColumn.Width = 40;
            // 
            // отключитьColumn
            // 
            this.отключитьColumn.DataPropertyName = "отключить";
            this.отключитьColumn.FillWeight = 60F;
            this.отключитьColumn.HeaderText = "отключить";
            this.отключитьColumn.Name = "отключитьColumn";
            this.отключитьColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.отключитьColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.отключитьColumn.Width = 80;
            // 
            // отключенColumn
            // 
            this.отключенColumn.DataPropertyName = "отключен";
            this.отключенColumn.FillWeight = 70F;
            this.отключенColumn.HeaderText = "отключен";
            this.отключенColumn.Name = "отключенColumn";
            this.отключенColumn.ReadOnly = true;
            this.отключенColumn.Width = 80;
            // 
            // повторноColumn
            // 
            this.повторноColumn.DataPropertyName = "повторно";
            this.повторноColumn.FillWeight = 70F;
            this.повторноColumn.HeaderText = "повторно";
            this.повторноColumn.Name = "повторноColumn";
            this.повторноColumn.ReadOnly = true;
            this.повторноColumn.Width = 80;
            // 
            // звонокColumn
            // 
            this.звонокColumn.DataPropertyName = "звонок";
            this.звонокColumn.HeaderText = "посл.звонок";
            this.звонокColumn.Name = "звонокColumn";
            this.звонокColumn.ReadOnly = true;
            this.звонокColumn.Width = 70;
            // 
            // примColumn
            // 
            this.примColumn.DataPropertyName = "прим";
            this.примColumn.HeaderText = "примечание";
            this.примColumn.Name = "примColumn";
            this.примColumn.Width = 150;
            // 
            // должникColumn
            // 
            this.должникColumn.DataPropertyName = "должник";
            this.должникColumn.FillWeight = 60F;
            this.должникColumn.HeaderText = "должник";
            this.должникColumn.Name = "должникColumn";
            this.должникColumn.ReadOnly = true;
            this.должникColumn.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(348, 265);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(472, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 8;
            // 
            // по_видам
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 553);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "по_видам";
            this.Text = "по_видам";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.по_видам_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox прим0TextBox;
        private System.Windows.Forms.TextBox телефонTextBox;
        private System.Windows.Forms.TextBox отчествоTextBox;
        private System.Windows.Forms.TextBox имяTextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn долгColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn отключитьColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отключенColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn повторноColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn звонокColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn примColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn должникColumn;
    }
}