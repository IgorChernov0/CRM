namespace CrmUI.Statement
{
    partial class OblicForm<T>
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Update = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Excel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 83;
            this.label1.Text = "Викладач";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Січень",
            "Лютий",
            "Березень",
            "Квітень",
            "Травень",
            "Червень",
            "Липень",
            "Серпень",
            "Вересень",
            "Жоовтень",
            "Грудень"});
            this.comboBox3.Location = new System.Drawing.Point(337, 60);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(139, 24);
            this.comboBox3.TabIndex = 82;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(334, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(47, 17);
            this.label34.TabIndex = 81;
            this.label34.Text = "Групи";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(172, 37);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(33, 17);
            this.label33.TabIndex = 80;
            this.label33.Text = "Тип";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(934, 20);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(182, 74);
            this.Save.TabIndex = 79;
            this.Save.Text = "Зберегти";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Бюджетні",
            "Контрактні"});
            this.comboBox2.Location = new System.Drawing.Point(175, 60);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(139, 24);
            this.comboBox2.TabIndex = 78;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(746, 21);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(182, 74);
            this.Update.TabIndex = 77;
            this.Update.Text = "Оновити";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Show
            // 
            this.Show.Location = new System.Drawing.Point(558, 20);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(182, 75);
            this.Show.TabIndex = 76;
            this.Show.Text = "Фільтр";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ""});
            this.comboBox1.Location = new System.Drawing.Point(13, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 24);
            this.comboBox1.TabIndex = 75;
            // 
            // Excel
            // 
            this.Excel.Location = new System.Drawing.Point(1126, 20);
            this.Excel.Name = "Excel";
            this.Excel.Size = new System.Drawing.Size(182, 74);
            this.Excel.TabIndex = 74;
            this.Excel.Text = "Завантажити Excel";
            this.Excel.UseVisualStyleBackColor = true;
            this.Excel.Click += new System.EventHandler(this.Excel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1298, 638);
            this.dataGridView1.TabIndex = 73;
            // 
            // OblicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 778);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Excel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OblicForm";
            this.Text = "OblicForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Show;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Excel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}