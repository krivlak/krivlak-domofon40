namespace domofon40
{
    partial class список_сотрудников
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(список_сотрудников));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.фамилияColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ОтчествоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.должностьColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.менеджерColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.уволенColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1058, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(1062, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 28);
            this.button3.TabIndex = 36;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(1062, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 28);
            this.button2.TabIndex = 35;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1062, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 34;
            this.button1.Text = "Новый";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1062, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 25);
            this.button5.TabIndex = 39;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(1060, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 25);
            this.button4.TabIndex = 38;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.фамилияColumn,
            this.имяColumn,
            this.ОтчествоColumn,
            this.должностьColumn,
            this.менеджерColumn,
            this.уволенColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 552);
            this.dataGridView1.TabIndex = 41;
            // 
            // фамилияColumn
            // 
            this.фамилияColumn.DataPropertyName = "фамилия";
            this.фамилияColumn.HeaderText = "фамилия";
            this.фамилияColumn.MaxInputLength = 50;
            this.фамилияColumn.Name = "фамилияColumn";
            this.фамилияColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.фамилияColumn.Width = 200;
            // 
            // имяColumn
            // 
            this.имяColumn.DataPropertyName = "имя";
            this.имяColumn.HeaderText = "Имя";
            this.имяColumn.MaxInputLength = 50;
            this.имяColumn.Name = "имяColumn";
            this.имяColumn.Width = 150;
            // 
            // ОтчествоColumn
            // 
            this.ОтчествоColumn.DataPropertyName = "отчество";
            this.ОтчествоColumn.HeaderText = "Отчество";
            this.ОтчествоColumn.MaxInputLength = 50;
            this.ОтчествоColumn.Name = "ОтчествоColumn";
            this.ОтчествоColumn.Width = 150;
            // 
            // должностьColumn
            // 
            this.должностьColumn.DataPropertyName = "должность";
            this.должностьColumn.HeaderText = "должность";
            this.должностьColumn.MaxInputLength = 50;
            this.должностьColumn.Name = "должностьColumn";
            this.должностьColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.должностьColumn.Width = 200;
            // 
            // менеджерColumn
            // 
            this.менеджерColumn.DataPropertyName = "кассир";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.NullValue = false;
            this.менеджерColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.менеджерColumn.HeaderText = "менеджер";
            this.менеджерColumn.Name = "менеджерColumn";
            // 
            // уволенColumn
            // 
            this.уволенColumn.DataPropertyName = "уволен";
            this.уволенColumn.HeaderText = "уволен";
            this.уволенColumn.Name = "уволенColumn";
            this.уволенColumn.ReadOnly = true;
            // 
            // список_сотрудников
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 552);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "список_сотрудников";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "список сотрудников";
            this.Load += new System.EventHandler(this.список_сотрудников_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ОтчествоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn должностьColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn менеджерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn уволенColumn;
    }
}