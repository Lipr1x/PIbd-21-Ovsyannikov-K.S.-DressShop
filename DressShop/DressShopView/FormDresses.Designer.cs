namespace AbstractShopView
{
    partial class FormDresses
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			this.Namee = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Namee});
			this.dataGridView.Location = new System.Drawing.Point(3, 3);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(343, 299);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(375, 12);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(117, 26);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point(375, 44);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(117, 26);
			this.buttonEdit.TabIndex = 2;
			this.buttonEdit.Text = "Изменить";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(375, 76);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(117, 26);
			this.buttonDel.TabIndex = 3;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(375, 108);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(117, 26);
			this.buttonRef.TabIndex = 4;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
			// 
			// Namee
			// 
			this.Namee.HeaderText = "Наименование";
			this.Namee.Name = "Namee";
			// 
			// FormDresses
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(512, 306);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.dataGridView);
			this.Name = "FormDresses";
			this.Text = "Dresses";
			this.Load += new System.EventHandler(this.FormDresses_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.DataGridViewTextBoxColumn Namee;
	}
}