namespace AbstractShopView
{
	partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.ButtonCreateOrder = new System.Windows.Forms.Button();
			this.ButtonTakeOrderInWork = new System.Windows.Forms.Button();
			this.ButtonOrderReady = new System.Windows.Forms.Button();
			this.ButtonPayOrder = new System.Windows.Forms.Button();
			this.ButtonRef = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(12, 47);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(642, 359);
			this.dataGridView.TabIndex = 0;
			// 
			// ButtonCreateOrder
			// 
			this.ButtonCreateOrder.Location = new System.Drawing.Point(773, 47);
			this.ButtonCreateOrder.Name = "ButtonCreateOrder";
			this.ButtonCreateOrder.Size = new System.Drawing.Size(156, 45);
			this.ButtonCreateOrder.TabIndex = 1;
			this.ButtonCreateOrder.Text = "Создать заказ";
			this.ButtonCreateOrder.UseVisualStyleBackColor = true;
			this.ButtonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
			// 
			// ButtonTakeOrderInWork
			// 
			this.ButtonTakeOrderInWork.Location = new System.Drawing.Point(773, 98);
			this.ButtonTakeOrderInWork.Name = "ButtonTakeOrderInWork";
			this.ButtonTakeOrderInWork.Size = new System.Drawing.Size(156, 45);
			this.ButtonTakeOrderInWork.TabIndex = 2;
			this.ButtonTakeOrderInWork.Text = "Отдать на выполнение";
			this.ButtonTakeOrderInWork.UseVisualStyleBackColor = true;
			this.ButtonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
			// 
			// ButtonOrderReady
			// 
			this.ButtonOrderReady.Location = new System.Drawing.Point(773, 149);
			this.ButtonOrderReady.Name = "ButtonOrderReady";
			this.ButtonOrderReady.Size = new System.Drawing.Size(156, 45);
			this.ButtonOrderReady.TabIndex = 3;
			this.ButtonOrderReady.Text = "Заказ Готов";
			this.ButtonOrderReady.UseVisualStyleBackColor = true;
			this.ButtonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
			// 
			// ButtonPayOrder
			// 
			this.ButtonPayOrder.Location = new System.Drawing.Point(773, 200);
			this.ButtonPayOrder.Name = "ButtonPayOrder";
			this.ButtonPayOrder.Size = new System.Drawing.Size(156, 45);
			this.ButtonPayOrder.TabIndex = 4;
			this.ButtonPayOrder.Text = "Заказ оплачен";
			this.ButtonPayOrder.UseVisualStyleBackColor = true;
			this.ButtonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
			// 
			// ButtonRef
			// 
			this.ButtonRef.Location = new System.Drawing.Point(773, 251);
			this.ButtonRef.Name = "ButtonRef";
			this.ButtonRef.Size = new System.Drawing.Size(156, 45);
			this.ButtonRef.TabIndex = 5;
			this.ButtonRef.Text = "Обновить список";
			this.ButtonRef.UseVisualStyleBackColor = true;
			this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(981, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(95, 22);
			this.toolStripDropDownButton1.Text = "Справочники";
			// 
			// компонентыToolStripMenuItem
			// 
			this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
			this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.компонентыToolStripMenuItem.Text = "Компоненты";
			this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
			// 
			// изделияToolStripMenuItem
			// 
			this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
			this.изделияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.изделияToolStripMenuItem.Text = "Изделия";
			this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(981, 404);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.ButtonRef);
			this.Controls.Add(this.ButtonPayOrder);
			this.Controls.Add(this.ButtonOrderReady);
			this.Controls.Add(this.ButtonTakeOrderInWork);
			this.Controls.Add(this.ButtonCreateOrder);
			this.Controls.Add(this.dataGridView);
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button ButtonCreateOrder;
		private System.Windows.Forms.Button ButtonTakeOrderInWork;
		private System.Windows.Forms.Button ButtonOrderReady;
		private System.Windows.Forms.Button ButtonPayOrder;
		private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
    }
}