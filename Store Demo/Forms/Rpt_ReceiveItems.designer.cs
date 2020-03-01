namespace Food_Cost.Forms
{
    partial class Rpt_ReceiveItems
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
            this.ShowBtn = new System.Windows.Forms.Button();
            this.UC_TVKitchens2 = new Food_Cost.Forms.UC_TVKitchens();
            this.CBMyKitchen = new System.Windows.Forms.CheckBox();
            this.CBKitchenTransfer = new System.Windows.Forms.CheckBox();
            this.CBPurchase = new System.Windows.Forms.CheckBox();
            this.CBRestaurantTransfer = new System.Windows.Forms.CheckBox();
            this.CBAutoPurchase = new System.Windows.Forms.CheckBox();
            this.RBTransfer = new System.Windows.Forms.RadioButton();
            this.RBPurchase = new System.Windows.Forms.RadioButton();
            this.RbItems = new System.Windows.Forms.RadioButton();
            this.RbOrders = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GbItem = new System.Windows.Forms.GroupBox();
            this.LItem = new System.Windows.Forms.Label();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.BtnItem = new System.Windows.Forms.Button();
            this.GrpDateTimeRange = new System.Windows.Forms.GroupBox();
            this.CbToday = new System.Windows.Forms.CheckBox();
            this.GbDate = new System.Windows.Forms.GroupBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.GbItem.SuspendLayout();
            this.GrpDateTimeRange.SuspendLayout();
            this.GbDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowBtn
            // 
            this.ShowBtn.Location = new System.Drawing.Point(167, 343);
            this.ShowBtn.Name = "ShowBtn";
            this.ShowBtn.Size = new System.Drawing.Size(122, 54);
            this.ShowBtn.TabIndex = 595;
            this.ShowBtn.Text = "Show";
            this.ShowBtn.UseVisualStyleBackColor = true;
            this.ShowBtn.Click += new System.EventHandler(this.ShowBtn_Click);
            // 
            // UC_TVKitchens2
            // 
            this.UC_TVKitchens2.Location = new System.Drawing.Point(316, 15);
            this.UC_TVKitchens2.Name = "UC_TVKitchens2";
            this.UC_TVKitchens2.Size = new System.Drawing.Size(375, 398);
            this.UC_TVKitchens2.TabIndex = 617;
            this.UC_TVKitchens2.Load += new System.EventHandler(this.UC_TVKitchens2_Load);
            // 
            // CBMyKitchen
            // 
            this.CBMyKitchen.AutoSize = true;
            this.CBMyKitchen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBMyKitchen.Location = new System.Drawing.Point(7, 361);
            this.CBMyKitchen.Name = "CBMyKitchen";
            this.CBMyKitchen.Size = new System.Drawing.Size(122, 20);
            this.CBMyKitchen.TabIndex = 616;
            this.CBMyKitchen.Text = "For My Kitchen";
            this.CBMyKitchen.UseVisualStyleBackColor = true;
            // 
            // CBKitchenTransfer
            // 
            this.CBKitchenTransfer.AutoSize = true;
            this.CBKitchenTransfer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBKitchenTransfer.Location = new System.Drawing.Point(164, 200);
            this.CBKitchenTransfer.Name = "CBKitchenTransfer";
            this.CBKitchenTransfer.Size = new System.Drawing.Size(130, 20);
            this.CBKitchenTransfer.TabIndex = 618;
            this.CBKitchenTransfer.Text = "Kitchen Transfer";
            this.CBKitchenTransfer.UseVisualStyleBackColor = true;
            this.CBKitchenTransfer.Visible = false;
            // 
            // CBPurchase
            // 
            this.CBPurchase.AutoSize = true;
            this.CBPurchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBPurchase.Location = new System.Drawing.Point(12, 200);
            this.CBPurchase.Name = "CBPurchase";
            this.CBPurchase.Size = new System.Drawing.Size(86, 20);
            this.CBPurchase.TabIndex = 619;
            this.CBPurchase.Text = "Purchase";
            this.CBPurchase.UseVisualStyleBackColor = true;
            // 
            // CBRestaurantTransfer
            // 
            this.CBRestaurantTransfer.AutoSize = true;
            this.CBRestaurantTransfer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBRestaurantTransfer.Location = new System.Drawing.Point(12, 200);
            this.CBRestaurantTransfer.Name = "CBRestaurantTransfer";
            this.CBRestaurantTransfer.Size = new System.Drawing.Size(150, 20);
            this.CBRestaurantTransfer.TabIndex = 620;
            this.CBRestaurantTransfer.Text = "Restaurant Transfer";
            this.CBRestaurantTransfer.UseVisualStyleBackColor = true;
            this.CBRestaurantTransfer.Visible = false;
            // 
            // CBAutoPurchase
            // 
            this.CBAutoPurchase.AutoSize = true;
            this.CBAutoPurchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBAutoPurchase.Location = new System.Drawing.Point(164, 200);
            this.CBAutoPurchase.Name = "CBAutoPurchase";
            this.CBAutoPurchase.Size = new System.Drawing.Size(119, 20);
            this.CBAutoPurchase.TabIndex = 621;
            this.CBAutoPurchase.Text = "Auto Purchase";
            this.CBAutoPurchase.UseVisualStyleBackColor = true;
            // 
            // RBTransfer
            // 
            this.RBTransfer.AutoSize = true;
            this.RBTransfer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RBTransfer.Location = new System.Drawing.Point(103, 174);
            this.RBTransfer.Name = "RBTransfer";
            this.RBTransfer.Size = new System.Drawing.Size(77, 20);
            this.RBTransfer.TabIndex = 633;
            this.RBTransfer.Text = "Transfer";
            this.RBTransfer.UseVisualStyleBackColor = true;
            // 
            // RBPurchase
            // 
            this.RBPurchase.AutoSize = true;
            this.RBPurchase.Checked = true;
            this.RBPurchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RBPurchase.Location = new System.Drawing.Point(12, 174);
            this.RBPurchase.Name = "RBPurchase";
            this.RBPurchase.Size = new System.Drawing.Size(85, 20);
            this.RBPurchase.TabIndex = 632;
            this.RBPurchase.TabStop = true;
            this.RBPurchase.Text = "Purchase";
            this.RBPurchase.UseVisualStyleBackColor = true;
            this.RBPurchase.CheckedChanged += new System.EventHandler(this.RBPurchase_CheckedChanged);
            // 
            // RbItems
            // 
            this.RbItems.AutoSize = true;
            this.RbItems.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RbItems.Location = new System.Drawing.Point(124, 19);
            this.RbItems.Name = "RbItems";
            this.RbItems.Size = new System.Drawing.Size(69, 20);
            this.RbItems.TabIndex = 635;
            this.RbItems.Text = "Details";
            this.RbItems.UseVisualStyleBackColor = true;
            this.RbItems.CheckedChanged += new System.EventHandler(this.RbItems_CheckedChanged);
            // 
            // RbOrders
            // 
            this.RbOrders.AutoSize = true;
            this.RbOrders.Checked = true;
            this.RbOrders.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RbOrders.Location = new System.Drawing.Point(6, 19);
            this.RbOrders.Name = "RbOrders";
            this.RbOrders.Size = new System.Drawing.Size(87, 20);
            this.RbOrders.TabIndex = 634;
            this.RbOrders.TabStop = true;
            this.RbOrders.Text = "Summary";
            this.RbOrders.UseVisualStyleBackColor = true;
            this.RbOrders.CheckedChanged += new System.EventHandler(this.RbOrders_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbItems);
            this.groupBox1.Controls.Add(this.RbOrders);
            this.groupBox1.Location = new System.Drawing.Point(6, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 53);
            this.groupBox1.TabIndex = 636;
            this.groupBox1.TabStop = false;
            // 
            // GbItem
            // 
            this.GbItem.Controls.Add(this.LItem);
            this.GbItem.Controls.Add(this.TxtItemName);
            this.GbItem.Controls.Add(this.TxtItemCode);
            this.GbItem.Controls.Add(this.BtnItem);
            this.GbItem.Location = new System.Drawing.Point(6, 285);
            this.GbItem.Name = "GbItem";
            this.GbItem.Size = new System.Drawing.Size(272, 54);
            this.GbItem.TabIndex = 637;
            this.GbItem.TabStop = false;
            this.GbItem.Visible = false;
            // 
            // LItem
            // 
            this.LItem.AutoSize = true;
            this.LItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LItem.Location = new System.Drawing.Point(5, 26);
            this.LItem.Name = "LItem";
            this.LItem.Size = new System.Drawing.Size(36, 16);
            this.LItem.TabIndex = 613;
            this.LItem.Text = "Item";
            // 
            // TxtItemName
            // 
            this.TxtItemName.Enabled = false;
            this.TxtItemName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemName.Location = new System.Drawing.Point(94, 22);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(117, 22);
            this.TxtItemName.TabIndex = 612;
            // 
            // TxtItemCode
            // 
            this.TxtItemCode.Enabled = false;
            this.TxtItemCode.Location = new System.Drawing.Point(44, 23);
            this.TxtItemCode.Name = "TxtItemCode";
            this.TxtItemCode.Size = new System.Drawing.Size(44, 20);
            this.TxtItemCode.TabIndex = 614;
            // 
            // BtnItem
            // 
            this.BtnItem.Location = new System.Drawing.Point(217, 22);
            this.BtnItem.Name = "BtnItem";
            this.BtnItem.Size = new System.Drawing.Size(41, 23);
            this.BtnItem.TabIndex = 615;
            this.BtnItem.UseVisualStyleBackColor = true;
            // 
            // GrpDateTimeRange
            // 
            this.GrpDateTimeRange.Controls.Add(this.CbToday);
            this.GrpDateTimeRange.Controls.Add(this.GbDate);
            this.GrpDateTimeRange.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpDateTimeRange.Location = new System.Drawing.Point(11, 12);
            this.GrpDateTimeRange.Name = "GrpDateTimeRange";
            this.GrpDateTimeRange.Size = new System.Drawing.Size(282, 146);
            this.GrpDateTimeRange.TabIndex = 638;
            this.GrpDateTimeRange.TabStop = false;
            this.GrpDateTimeRange.Tag = "160";
            this.GrpDateTimeRange.Text = "Date Time Range";
            // 
            // CbToday
            // 
            this.CbToday.AutoSize = true;
            this.CbToday.Location = new System.Drawing.Point(76, 30);
            this.CbToday.Name = "CbToday";
            this.CbToday.Size = new System.Drawing.Size(65, 20);
            this.CbToday.TabIndex = 55;
            this.CbToday.Text = "Today";
            this.CbToday.UseVisualStyleBackColor = true;
            // 
            // GbDate
            // 
            this.GbDate.Controls.Add(this.lblDateFrom);
            this.GbDate.Controls.Add(this.dtp_from);
            this.GbDate.Controls.Add(this.dtp_to);
            this.GbDate.Controls.Add(this.lblDateTo);
            this.GbDate.Location = new System.Drawing.Point(12, 56);
            this.GbDate.Name = "GbDate";
            this.GbDate.Size = new System.Drawing.Size(255, 80);
            this.GbDate.TabIndex = 56;
            this.GbDate.TabStop = false;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(15, 16);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(65, 22);
            this.lblDateFrom.TabIndex = 49;
            this.lblDateFrom.Text = "From";
            this.lblDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "dd/MM/yyyy";
            this.dtp_from.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(86, 16);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(166, 22);
            this.dtp_from.TabIndex = 50;
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "dd/MM/yyyy";
            this.dtp_to.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(86, 53);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(166, 22);
            this.dtp_to.TabIndex = 51;
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(15, 53);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(65, 22);
            this.lblDateTo.TabIndex = 52;
            this.lblDateTo.Text = "To";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rpt_ReceiveItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 425);
            this.Controls.Add(this.GrpDateTimeRange);
            this.Controls.Add(this.GbItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RBTransfer);
            this.Controls.Add(this.RBPurchase);
            this.Controls.Add(this.CBAutoPurchase);
            this.Controls.Add(this.CBPurchase);
            this.Controls.Add(this.CBKitchenTransfer);
            this.Controls.Add(this.UC_TVKitchens2);
            this.Controls.Add(this.CBMyKitchen);
            this.Controls.Add(this.ShowBtn);
            this.Controls.Add(this.CBRestaurantTransfer);
            this.Name = "Rpt_ReceiveItems";
            this.Text = "Rpt_ReceiveItems";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GbItem.ResumeLayout(false);
            this.GbItem.PerformLayout();
            this.GrpDateTimeRange.ResumeLayout(false);
            this.GrpDateTimeRange.PerformLayout();
            this.GbDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ShowBtn;
        private UC_TVKitchens UC_TVKitchens2;
        private System.Windows.Forms.CheckBox CBMyKitchen;
        private System.Windows.Forms.CheckBox CBKitchenTransfer;
        private System.Windows.Forms.CheckBox CBPurchase;
        private System.Windows.Forms.CheckBox CBRestaurantTransfer;
        private System.Windows.Forms.CheckBox CBAutoPurchase;
        private System.Windows.Forms.RadioButton RBTransfer;
        private System.Windows.Forms.RadioButton RBPurchase;
        private System.Windows.Forms.RadioButton RbItems;
        private System.Windows.Forms.RadioButton RbOrders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GbItem;
        private System.Windows.Forms.Label LItem;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.TextBox TxtItemCode;
        private System.Windows.Forms.Button BtnItem;
        private System.Windows.Forms.GroupBox GrpDateTimeRange;
        private System.Windows.Forms.CheckBox CbToday;
        private System.Windows.Forms.GroupBox GbDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label lblDateTo;
    }
}