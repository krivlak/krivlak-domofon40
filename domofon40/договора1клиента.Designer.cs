namespace domofon40
{
    partial class договора1клиента
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.услуги = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дата_сColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.мастерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.услуги,
            this.датаColumn,
            this.дата_сColumn,
            this.номерColumn,
            this.мастерColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(792, 419);
            this.dataGridView1.TabIndex = 0;
            // 
            // услуги
            // 
            this.услуги.DataPropertyName = "услуги";
            this.услуги.HeaderText = "наимен услуги";
            this.услуги.Name = "услуги";
            this.услуги.ReadOnly = true;
            this.услуги.Width = 200;
            // 
            // датаColumn
            // 
            this.датаColumn.DataPropertyName = "дата_дог";
            dataGridViewCellStyle5.Format = "d";
            this.датаColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.датаColumn.HeaderText = "дата дог.";
            this.датаColumn.Name = "датаColumn";
            this.датаColumn.ReadOnly = true;
            // 
            // дата_сColumn
            // 
            this.дата_сColumn.DataPropertyName = "дата_с";
            dataGridViewCellStyle6.Format = "d";
            this.дата_сColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.дата_сColumn.HeaderText = "дата с";
            this.дата_сColumn.Name = "дата_сColumn";
            this.дата_сColumn.ReadOnly = true;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер_пп";
            this.номерColumn.HeaderText = "номер";
            this.номерColumn.Name = "номерColumn";
            // 
            // мастерColumn
            // 
            this.мастерColumn.DataPropertyName = "сотрудники";
            this.мастерColumn.HeaderText = "мастер";
            this.мастерColumn.Name = "мастерColumn";
            this.мастерColumn.ReadOnly = true;
            this.мастерColumn.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(856, 200);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "новый";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(856, 254);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(856, 307);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 22);
            this.button3.TabIndex = 3;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(837, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 26);
            this.label1.TabIndex = 76;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(812, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(217, 32);
            this.button4.TabIndex = 83;
            this.button4.Text = "Word Печать договора";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(812, 152);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(217, 23);
            this.button7.TabIndex = 89;
            this.button7.Text = "Печать инструкции к домофону";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // договора1клиента
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 419);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "договора1клиента";
            this.Text = "договора1клиента";
            this.Load += new System.EventHandler(this.договора1клиента_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn услуги;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дата_сColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn мастерColumn;
        private System.Windows.Forms.Button button7;
    }
}