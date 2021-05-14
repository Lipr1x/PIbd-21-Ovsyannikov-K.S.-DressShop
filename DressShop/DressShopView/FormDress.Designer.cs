namespace AbstractShopView
{
	partial class FormDress
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
			this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
			this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ButtonRef = new System.Windows.Forms.Button();
			this.ButtonDel = new System.Windows.Forms.Button();
			this.ButtonUpd = new System.Windows.Forms.Button();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.ButtonSave = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.Idd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Componentss = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// maskedTextBox1
			// 
			this.maskedTextBox1.BackColor = System.Drawing.SystemColors.Menu;
			this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.maskedTextBox1.Location = new System.Drawing.Point(12, 12);
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(59, 13);
			this.maskedTextBox1.TabIndex = 0;
			this.maskedTextBox1.Text = "Название:";
			// 
			// maskedTextBox2
			// 
			this.maskedTextBox2.BackColor = System.Drawing.SystemColors.Menu;
			this.maskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.maskedTextBox2.Location = new System.Drawing.Point(12, 48);
			this.maskedTextBox2.Name = "maskedTextBox2";
			this.maskedTextBox2.Size = new System.Drawing.Size(59, 13);
			this.maskedTextBox2.TabIndex = 1;
			this.maskedTextBox2.Text = "Цена:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(77, 9);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(159, 20);
			this.textBoxName.TabIndex = 2;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(77, 45);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(159, 20);
			this.textBoxPrice.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ButtonRef);
			this.groupBox1.Controls.Add(this.ButtonDel);
			this.groupBox1.Controls.Add(this.ButtonUpd);
			this.groupBox1.Controls.Add(this.ButtonAdd);
			this.groupBox1.Controls.Add(this.dataGridView);
			this.groupBox1.Location = new System.Drawing.Point(12, 85);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(423, 310);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Компоненты";
			// 
			// ButtonRef
			// 
			this.ButtonRef.Location = new System.Drawing.Point(329, 152);
			this.ButtonRef.Name = "ButtonRef";
			this.ButtonRef.Size = new System.Drawing.Size(75, 23);
			this.ButtonRef.TabIndex = 8;
			this.ButtonRef.Text = "Обновить";
			this.ButtonRef.UseVisualStyleBackColor = true;
			this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// ButtonDel
			// 
			this.ButtonDel.Location = new System.Drawing.Point(329, 110);
			this.ButtonDel.Name = "ButtonDel";
			this.ButtonDel.Size = new System.Drawing.Size(75, 23);
			this.ButtonDel.TabIndex = 7;
			this.ButtonDel.Text = "Удалить";
			this.ButtonDel.UseVisualStyleBackColor = true;
			this.ButtonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// ButtonUpd
			// 
			this.ButtonUpd.Location = new System.Drawing.Point(329, 69);
			this.ButtonUpd.Name = "ButtonUpd";
			this.ButtonUpd.Size = new System.Drawing.Size(75, 23);
			this.ButtonUpd.TabIndex = 6;
			this.ButtonUpd.Text = "Изменить";
			this.ButtonUpd.UseVisualStyleBackColor = true;
			this.ButtonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.Location = new System.Drawing.Point(329, 30);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.ButtonAdd.TabIndex = 5;
			this.ButtonAdd.Text = "Добавить";
			this.ButtonAdd.UseVisualStyleBackColor = true;
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idd,
            this.Componentss,
            this.Price});
			this.dataGridView.Location = new System.Drawing.Point(6, 19);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(305, 285);
			this.dataGridView.TabIndex = 5;
			// 
			// ButtonSave
			// 
			this.ButtonSave.Location = new System.Drawing.Point(276, 401);
			this.ButtonSave.Name = "ButtonSave";
			this.ButtonSave.Size = new System.Drawing.Size(75, 23);
			this.ButtonSave.TabIndex = 5;
			this.ButtonSave.Text = "Сохранить";
			this.ButtonSave.UseVisualStyleBackColor = true;
			this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Location = new System.Drawing.Point(360, 401);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.ButtonCancel.TabIndex = 6;
			this.ButtonCancel.Text = "Отмена";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// Idd
			// 
			this.Idd.HeaderText = "Id";
			this.Idd.Name = "Idd";
			this.Idd.Visible = false;
			// 
			// Componentss
			// 
			this.Componentss.HeaderText = "Компонент";
			this.Componentss.Name = "Componentss";
			// 
			// Price
			// 
			this.Price.HeaderText = "Количество компонентов";
			this.Price.Name = "Price";
			// 
			// FormDress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 450);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonSave);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.maskedTextBox2);
			this.Controls.Add(this.maskedTextBox1);
			this.Name = "FormDress";
			this.Text = "FormDress";
			this.Load += new System.EventHandler(this.FormDress_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MaskedTextBox maskedTextBox1;
		private System.Windows.Forms.MaskedTextBox maskedTextBox2;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxPrice;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button ButtonRef;
		private System.Windows.Forms.Button ButtonDel;
		private System.Windows.Forms.Button ButtonUpd;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.Button ButtonSave;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn Idd;
		private System.Windows.Forms.DataGridViewTextBoxColumn Componentss;
		private System.Windows.Forms.DataGridViewTextBoxColumn Price;
	}
}