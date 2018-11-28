namespace domofon40
{
    partial class отметитьVуслуги
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.помеченыеDataGridView = new System.Windows.Forms.DataGridView();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.обозначениеColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.выбратьColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.помеченыеDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(583, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Выбор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // помеченыеDataGridView
            // 
            this.помеченыеDataGridView.AllowUserToAddRows = false;
            this.помеченыеDataGridView.AllowUserToDeleteRows = false;
            this.помеченыеDataGridView.AutoGenerateColumns = false;
            this.помеченыеDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.помеченыеDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.наименColumn,
            this.обозначениеColumn,
            this.выбратьColumn});
            this.помеченыеDataGridView.DataSource = this.bindingSource1;
            this.помеченыеDataGridView.Location = new System.Drawing.Point(26, 1);
            this.помеченыеDataGridView.Name = "помеченыеDataGridView";
            this.помеченыеDataGridView.Size = new System.Drawing.Size(505, 379);
            this.помеченыеDataGridView.TabIndex = 4;
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен";
            this.наименColumn.HeaderText = "наименование";
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.ReadOnly = true;
            this.наименColumn.Width = 200;
            // 
            // обозначениеColumn
            // 
            this.обозначениеColumn.DataPropertyName = "обозначение";
            this.обозначениеColumn.HeaderText = "обозначение";
            this.обозначениеColumn.Name = "обозначениеColumn";
            this.обозначениеColumn.ReadOnly = true;
            // 
            // выбратьColumn
            // 
            this.выбратьColumn.DataPropertyName = "выбран";
            this.выбратьColumn.HeaderText = "выбрать";
            this.выбратьColumn.Name = "выбратьColumn";
            this.выбратьColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.выбратьColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // отметитьVуслуги
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 494);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.помеченыеDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "отметитьVуслуги";
            this.Text = "отметитьVуслуги";
            this.Load += new System.EventHandler(this.отметитьVуслуги_Load);
            ((System.ComponentModel.ISupportInitialize)(this.помеченыеDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView помеченыеDataGridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn обозначениеColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn выбратьColumn;
    }
}