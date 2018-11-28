namespace domofon40
{
    partial class реквизиты_филиала
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
            System.Windows.Forms.Label адресLabel;
            System.Windows.Forms.Label наименLabel;
            System.Windows.Forms.Label телефонLabel;
            this.адресTextBox = new System.Windows.Forms.TextBox();
            this.наименTextBox = new System.Windows.Forms.TextBox();
            this.телефонTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.филиалыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            адресLabel = new System.Windows.Forms.Label();
            наименLabel = new System.Windows.Forms.Label();
            телефонLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.филиалыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // адресLabel
            // 
            адресLabel.AutoSize = true;
            адресLabel.Location = new System.Drawing.Point(120, 103);
            адресLabel.Name = "адресLabel";
            адресLabel.Size = new System.Drawing.Size(51, 17);
            адресLabel.TabIndex = 1;
            адресLabel.Text = "адрес:";
            // 
            // наименLabel
            // 
            наименLabel.AutoSize = true;
            наименLabel.Location = new System.Drawing.Point(110, 63);
            наименLabel.Name = "наименLabel";
            наименLabel.Size = new System.Drawing.Size(61, 17);
            наименLabel.TabIndex = 3;
            наименLabel.Text = "наимен:";
            // 
            // телефонLabel
            // 
            телефонLabel.AutoSize = true;
            телефонLabel.Location = new System.Drawing.Point(101, 149);
            телефонLabel.Name = "телефонLabel";
            телефонLabel.Size = new System.Drawing.Size(70, 17);
            телефонLabel.TabIndex = 7;
            телефонLabel.Text = "телефон:";
            // 
            // адресTextBox
            // 
            //this.адресTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.филиалыBindingSource, "адрес", true));
            this.адресTextBox.Location = new System.Drawing.Point(196, 100);
            this.адресTextBox.Name = "адресTextBox";
            this.адресTextBox.Size = new System.Drawing.Size(438, 22);
            this.адресTextBox.TabIndex = 2;
            // 
            // наименTextBox
            // 
            //this.наименTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.филиалыBindingSource, "наимен", true));
            this.наименTextBox.Location = new System.Drawing.Point(196, 60);
            this.наименTextBox.Name = "наименTextBox";
            this.наименTextBox.Size = new System.Drawing.Size(438, 22);
            this.наименTextBox.TabIndex = 4;
            // 
            // телефонTextBox
            // 
            //this.телефонTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.филиалыBindingSource, "телефон", true));
            this.телефонTextBox.Location = new System.Drawing.Point(196, 146);
            this.телефонTextBox.Name = "телефонTextBox";
            this.телефонTextBox.Size = new System.Drawing.Size(438, 22);
            this.телефонTextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "*";
            this.label1.Visible = false;
            // 
            // филиалыBindingSource
            // 
//            this.филиалыBindingSource.DataSource = typeof(domofon40.филиалы);
            // 
            // реквизиты_филиала
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(адресLabel);
            this.Controls.Add(this.адресTextBox);
            this.Controls.Add(наименLabel);
            this.Controls.Add(this.наименTextBox);
            this.Controls.Add(телефонLabel);
            this.Controls.Add(this.телефонTextBox);
            this.Name = "реквизиты_филиала";
            this.Text = "реквизиты_филиала";
            this.Load += new System.EventHandler(this.реквизиты_филиала_Load);
            ((System.ComponentModel.ISupportInitialize)(this.филиалыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource филиалыBindingSource;
        private System.Windows.Forms.TextBox адресTextBox;
        private System.Windows.Forms.TextBox наименTextBox;
        private System.Windows.Forms.TextBox телефонTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}