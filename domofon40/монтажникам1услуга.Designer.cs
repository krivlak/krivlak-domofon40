﻿namespace domofon40
{
    partial class монтажникам1услуга
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
            System.Windows.Forms.Label имяLabel;
            System.Windows.Forms.Label отчествоLabel;
            System.Windows.Forms.Label телефонLabel;
            System.Windows.Forms.Label прим0Label;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.адресColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.долгColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отключитьColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.подключенColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отключенColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.повторноColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.звонокColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.примColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.должникColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.имяTextBox = new System.Windows.Forms.TextBox();
            this.отчествоTextBox = new System.Windows.Forms.TextBox();
            this.телефонTextBox = new System.Windows.Forms.TextBox();
            this.прим0TextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            имяLabel = new System.Windows.Forms.Label();
            отчествоLabel = new System.Windows.Forms.Label();
            телефонLabel = new System.Windows.Forms.Label();
            прим0Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // отчествоLabel
            // 
            отчествоLabel.AutoSize = true;
            отчествоLabel.Location = new System.Drawing.Point(160, 42);
            отчествоLabel.Name = "отчествоLabel";
            отчествоLabel.Size = new System.Drawing.Size(57, 13);
            отчествоLabel.TabIndex = 18;
            отчествоLabel.Text = "Отчество:";
            // 
            // телефонLabel
            // 
            телефонLabel.AutoSize = true;
            телефонLabel.Location = new System.Drawing.Point(351, 41);
            телефонLabel.Name = "телефонLabel";
            телефонLabel.Size = new System.Drawing.Size(53, 13);
            телефонLabel.TabIndex = 20;
            телефонLabel.Text = "телефон:";
            // 
            // прим0Label
            // 
            прим0Label.AutoSize = true;
            прим0Label.Location = new System.Drawing.Point(660, 45);
            прим0Label.Name = "прим0Label";
            прим0Label.Size = new System.Drawing.Size(72, 13);
            прим0Label.TabIndex = 22;
            прим0Label.Text = "общее прим:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
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
            this.подключенColumn,
            this.отключенColumn,
            this.повторноColumn,
            this.звонокColumn,
            this.примColumn,
            this.должникColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1330, 384);
            this.dataGridView1.TabIndex = 13;
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
            this.фиоColumn.Width = 120;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0;#;#";
            this.годColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.годColumn.HeaderText = "год";
            this.годColumn.Name = "годColumn";
            this.годColumn.ReadOnly = true;
            this.годColumn.Width = 50;
            // 
            // месяцColumn
            // 
            this.месяцColumn.DataPropertyName = "месяц";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0;#;#";
            this.месяцColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.месяцColumn.HeaderText = "месяц";
            this.месяцColumn.Name = "месяцColumn";
            this.месяцColumn.ReadOnly = true;
            this.месяцColumn.Width = 40;
            // 
            // долгColumn
            // 
            this.долгColumn.DataPropertyName = "долг_мес";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "0;#;#";
            this.долгColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.долгColumn.HeaderText = "долг мес.";
            this.долгColumn.Name = "долгColumn";
            this.долгColumn.ReadOnly = true;
            this.долгColumn.Width = 40;
            // 
            // отключитьColumn
            // 
            this.отключитьColumn.DataPropertyName = "отключить";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle11.NullValue = false;
            this.отключитьColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.отключитьColumn.HeaderText = "отключить";
            this.отключитьColumn.Name = "отключитьColumn";
            this.отключитьColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.отключитьColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.отключитьColumn.Width = 50;
            // 
            // подключенColumn
            // 
            this.подключенColumn.DataPropertyName = "договор_с";
            this.подключенColumn.HeaderText = "договор с";
            this.подключенColumn.Name = "подключенColumn";
            this.подключенColumn.ReadOnly = true;
            this.подключенColumn.Width = 80;
            // 
            // отключенColumn
            // 
            this.отключенColumn.DataPropertyName = "отключен";
            this.отключенColumn.HeaderText = "отключен";
            this.отключенColumn.Name = "отключенColumn";
            this.отключенColumn.ReadOnly = true;
            this.отключенColumn.Width = 80;
            // 
            // повторноColumn
            // 
            this.повторноColumn.DataPropertyName = "повторно";
            this.повторноColumn.HeaderText = "повторно";
            this.повторноColumn.Name = "повторноColumn";
            this.повторноColumn.ReadOnly = true;
            this.повторноColumn.Width = 80;
            // 
            // звонокColumn
            // 
            this.звонокColumn.DataPropertyName = "звонок";
            this.звонокColumn.FillWeight = 80F;
            this.звонокColumn.HeaderText = "звонок";
            this.звонокColumn.Name = "звонокColumn";
            this.звонокColumn.ReadOnly = true;
            // 
            // примColumn
            // 
            this.примColumn.DataPropertyName = "прим";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.примColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.примColumn.HeaderText = "примечание";
            this.примColumn.MaxInputLength = 50;
            this.примColumn.Name = "примColumn";
            this.примColumn.Width = 200;
            // 
            // должникColumn
            // 
            this.должникColumn.DataPropertyName = "должник";
            this.должникColumn.HeaderText = "должник";
            this.должникColumn.Name = "должникColumn";
            this.должникColumn.ReadOnly = true;
            this.должникColumn.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(819, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // имяTextBox
            // 
            this.имяTextBox.Location = new System.Drawing.Point(43, 39);
            this.имяTextBox.Name = "имяTextBox";
            this.имяTextBox.ReadOnly = true;
            this.имяTextBox.Size = new System.Drawing.Size(100, 20);
            this.имяTextBox.TabIndex = 17;
            // 
            // отчествоTextBox
            // 
            this.отчествоTextBox.Location = new System.Drawing.Point(223, 39);
            this.отчествоTextBox.Name = "отчествоTextBox";
            this.отчествоTextBox.ReadOnly = true;
            this.отчествоTextBox.Size = new System.Drawing.Size(100, 20);
            this.отчествоTextBox.TabIndex = 19;
            // 
            // телефонTextBox
            // 
            this.телефонTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.телефонTextBox.Location = new System.Drawing.Point(410, 38);
            this.телефонTextBox.Name = "телефонTextBox";
            this.телефонTextBox.Size = new System.Drawing.Size(222, 20);
            this.телефонTextBox.TabIndex = 21;
            // 
            // прим0TextBox
            // 
            this.прим0TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.прим0TextBox.Location = new System.Drawing.Point(748, 38);
            this.прим0TextBox.Name = "прим0TextBox";
            this.прим0TextBox.Size = new System.Drawing.Size(297, 20);
            this.прим0TextBox.TabIndex = 23;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(307, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 23);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Должники";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(642, 2);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 24);
            this.button5.TabIndex = 25;
            this.button5.Text = "Записать звонок или смс";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.checkBox2);
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
            this.panel1.Size = new System.Drawing.Size(1330, 66);
            this.panel1.TabIndex = 12;
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(444, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 23);
            this.checkBox2.TabIndex = 26;
            this.checkBox2.Text = "отметить всех";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(939, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "sms";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // монтажникам1услуга
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "монтажникам1услуга";
            this.Text = "монтажникам1услуга";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.монтажникам1услуга_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox имяTextBox;
        private System.Windows.Forms.TextBox отчествоTextBox;
        private System.Windows.Forms.TextBox телефонTextBox;
        private System.Windows.Forms.TextBox прим0TextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn долгColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn отключитьColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn подключенColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отключенColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn повторноColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn звонокColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn примColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn должникColumn;
        private System.Windows.Forms.Button button3;
    }
}