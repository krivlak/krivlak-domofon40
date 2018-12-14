namespace domofon40
{
    partial class список_видов
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(список_видов));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button3 = new System.Windows.Forms.Button();
            this.вид_услугиDataGridView = new System.Windows.Forms.DataGridView();
            this.вид_услугиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.услугColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.вид_услугиDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.вид_услугиBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(595, 397);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 32);
            this.button3.TabIndex = 27;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // вид_услугиDataGridView
            // 
            this.вид_услугиDataGridView.AllowUserToAddRows = false;
            this.вид_услугиDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.вид_услугиDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.вид_услугиDataGridView.AutoGenerateColumns = false;
            this.вид_услугиDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.вид_услугиDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.наименColumn,
            this.услугColumn});
            this.вид_услугиDataGridView.DataSource = this.вид_услугиBindingSource;
            this.вид_услугиDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.вид_услугиDataGridView.Location = new System.Drawing.Point(0, 0);
            this.вид_услугиDataGridView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.вид_услугиDataGridView.Name = "вид_услугиDataGridView";
            this.вид_услугиDataGridView.Size = new System.Drawing.Size(524, 512);
            this.вид_услугиDataGridView.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(594, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(595, 328);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 32);
            this.button2.TabIndex = 26;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(595, 257);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 32);
            this.button1.TabIndex = 25;
            this.button1.Text = "Новый";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(599, 160);
            this.button5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 29);
            this.button5.TabIndex = 29;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(595, 120);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 32);
            this.button4.TabIndex = 28;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен";
            this.наименColumn.HeaderText = "наимен";
            this.наименColumn.MaxInputLength = 50;
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.наименColumn.Width = 300;
            // 
            // услугColumn
            // 
            this.услугColumn.DataPropertyName = "услуг";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.услугColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.услугColumn.HeaderText = "услуг";
            this.услугColumn.Name = "услугColumn";
            this.услугColumn.ReadOnly = true;
            this.услугColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // список_видов
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 512);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.вид_услугиDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "список_видов";
            this.Text = "Виды услуг";
            this.Load += new System.EventHandler(this.список_видов_Load);
            ((System.ComponentModel.ISupportInitialize)(this.вид_услугиDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.вид_услугиBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource вид_услугиBindingSource;
        private System.Windows.Forms.DataGridView вид_услугиDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn услугColumn;
    }
}