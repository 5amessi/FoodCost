namespace Food_Cost.Forms
{
    partial class Rpt_PurchaseItems
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
            this.rdbMyStore = new System.Windows.Forms.RadioButton();
            this.GrpDateTimeRange = new System.Windows.Forms.GroupBox();
            this.BtnDeliveryDate = new System.Windows.Forms.RadioButton();
            this.BtnCreateDate = new System.Windows.Forms.RadioButton();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.BtnItem = new System.Windows.Forms.Button();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.LItem = new System.Windows.Forms.Label();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.UC_TVKitchens2 = new Food_Cost.Forms.UC_TVKitchens();
            this.CBMyKitchen = new System.Windows.Forms.CheckBox();
            this.RbOrders = new System.Windows.Forms.RadioButton();
            this.RbItems = new System.Windows.Forms.RadioButton();
            this.GbItem = new System.Windows.Forms.GroupBox();
            this.GrpDateTimeRange.SuspendLayout();
            this.GbItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowBtn
            // 
            this.ShowBtn.Location = new System.Drawing.Point(83, 300);
            this.ShowBtn.Name = "ShowBtn";
            this.ShowBtn.Size = new System.Drawing.Size(107, 54);
            this.ShowBtn.TabIndex = 586;
            this.ShowBtn.Text = "Show";
            this.ShowBtn.UseVisualStyleBackColor = true;
            this.ShowBtn.Click += new System.EventHandler(this.ShowBtn_Click);
            // 
            // rdbMyStore
            // 
            this.rdbMyStore.AutoSize = true;
            this.rdbMyStore.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMyStore.Location = new System.Drawing.Point(105, 127);
            this.rdbMyStore.Name = "rdbMyStore";
            this.rdbMyStore.Size = new System.Drawing.Size(107, 20);
            this.rdbMyStore.TabIndex = 594;
            this.rdbMyStore.Text = "For My Store";
            this.rdbMyStore.UseVisualStyleBackColor = true;
            // 
            // GrpDateTimeRange
            // 
            this.GrpDateTimeRange.Controls.Add(this.BtnDeliveryDate);
            this.GrpDateTimeRange.Controls.Add(this.BtnCreateDate);
            this.GrpDateTimeRange.Controls.Add(this.lblDateTo);
            this.GrpDateTimeRange.Controls.Add(this.dtp_to);
            this.GrpDateTimeRange.Controls.Add(this.lblDateFrom);
            this.GrpDateTimeRange.Controls.Add(this.dtp_from);
            this.GrpDateTimeRange.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpDateTimeRange.Location = new System.Drawing.Point(12, 12);
            this.GrpDateTimeRange.Name = "GrpDateTimeRange";
            this.GrpDateTimeRange.Size = new System.Drawing.Size(255, 135);
            this.GrpDateTimeRange.TabIndex = 595;
            this.GrpDateTimeRange.TabStop = false;
            this.GrpDateTimeRange.Tag = "160";
            this.GrpDateTimeRange.Text = "Date Time Range";
            // 
            // BtnDeliveryDate
            // 
            this.BtnDeliveryDate.AutoSize = true;
            this.BtnDeliveryDate.Location = new System.Drawing.Point(132, 23);
            this.BtnDeliveryDate.Name = "BtnDeliveryDate";
            this.BtnDeliveryDate.Size = new System.Drawing.Size(111, 20);
            this.BtnDeliveryDate.TabIndex = 54;
            this.BtnDeliveryDate.TabStop = true;
            this.BtnDeliveryDate.Text = "Delivery Date";
            this.BtnDeliveryDate.UseVisualStyleBackColor = true;
            this.BtnDeliveryDate.CheckedChanged += new System.EventHandler(this.BtnDeliveryDate_CheckedChanged);
            // 
            // BtnCreateDate
            // 
            this.BtnCreateDate.AutoSize = true;
            this.BtnCreateDate.Location = new System.Drawing.Point(19, 23);
            this.BtnCreateDate.Name = "BtnCreateDate";
            this.BtnCreateDate.Size = new System.Drawing.Size(101, 20);
            this.BtnCreateDate.TabIndex = 53;
            this.BtnCreateDate.TabStop = true;
            this.BtnCreateDate.Text = "Create Date";
            this.BtnCreateDate.UseVisualStyleBackColor = true;
            this.BtnCreateDate.CheckedChanged += new System.EventHandler(this.BtnCreateDate_CheckedChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(2, 96);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(65, 22);
            this.lblDateTo.TabIndex = 52;
            this.lblDateTo.Text = "To";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "dd/MM/yyyy";
            this.dtp_to.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(73, 96);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(166, 22);
            this.dtp_to.TabIndex = 51;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(2, 59);
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
            this.dtp_from.Location = new System.Drawing.Point(73, 59);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(166, 22);
            this.dtp_from.TabIndex = 50;
            // 
            // BtnItem
            // 
            this.BtnItem.Location = new System.Drawing.Point(217, 22);
            this.BtnItem.Name = "BtnItem";
            this.BtnItem.Size = new System.Drawing.Size(41, 23);
            this.BtnItem.TabIndex = 615;
            this.BtnItem.UseVisualStyleBackColor = true;
            this.BtnItem.Click += new System.EventHandler(this.BtnItem_Click);
            // 
            // TxtItemCode
            // 
            this.TxtItemCode.Enabled = false;
            this.TxtItemCode.Location = new System.Drawing.Point(44, 23);
            this.TxtItemCode.Name = "TxtItemCode";
            this.TxtItemCode.Size = new System.Drawing.Size(44, 20);
            this.TxtItemCode.TabIndex = 614;
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
            // UC_TVKitchens2
            // 
            this.UC_TVKitchens2.Location = new System.Drawing.Point(299, 12);
            this.UC_TVKitchens2.Name = "UC_TVKitchens2";
            this.UC_TVKitchens2.Size = new System.Drawing.Size(306, 345);
            this.UC_TVKitchens2.TabIndex = 617;
            // 
            // CBMyKitchen
            // 
            this.CBMyKitchen.AutoSize = true;
            this.CBMyKitchen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBMyKitchen.Location = new System.Drawing.Point(83, 265);
            this.CBMyKitchen.Name = "CBMyKitchen";
            this.CBMyKitchen.Size = new System.Drawing.Size(122, 20);
            this.CBMyKitchen.TabIndex = 616;
            this.CBMyKitchen.Text = "For My Kitchen";
            this.CBMyKitchen.UseVisualStyleBackColor = true;
            // 
            // RbOrders
            // 
            this.RbOrders.AutoSize = true;
            this.RbOrders.Checked = true;
            this.RbOrders.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RbOrders.Location = new System.Drawing.Point(55, 162);
            this.RbOrders.Name = "RbOrders";
            this.RbOrders.Size = new System.Drawing.Size(68, 20);
            this.RbOrders.TabIndex = 618;
            this.RbOrders.TabStop = true;
            this.RbOrders.Text = "Orders";
            this.RbOrders.UseVisualStyleBackColor = true;
            this.RbOrders.CheckedChanged += new System.EventHandler(this.RbOrders_CheckedChanged);
            // 
            // RbItems
            // 
            this.RbItems.AutoSize = true;
            this.RbItems.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RbItems.Location = new System.Drawing.Point(181, 162);
            this.RbItems.Name = "RbItems";
            this.RbItems.Size = new System.Drawing.Size(60, 20);
            this.RbItems.TabIndex = 619;
            this.RbItems.Text = "Items";
            this.RbItems.UseVisualStyleBackColor = true;
            this.RbItems.CheckedChanged += new System.EventHandler(this.RbItems_CheckedChanged);
            // 
            // GbItem
            // 
            this.GbItem.Controls.Add(this.LItem);
            this.GbItem.Controls.Add(this.TxtItemName);
            this.GbItem.Controls.Add(this.TxtItemCode);
            this.GbItem.Controls.Add(this.BtnItem);
            this.GbItem.Location = new System.Drawing.Point(10, 188);
            this.GbItem.Name = "GbItem";
            this.GbItem.Size = new System.Drawing.Size(269, 54);
            this.GbItem.TabIndex = 620;
            this.GbItem.TabStop = false;
            this.GbItem.Visible = false;
            // 
            // Rpt_PurchaseItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 415);
            this.Controls.Add(this.GbItem);
            this.Controls.Add(this.RbItems);
            this.Controls.Add(this.RbOrders);
            this.Controls.Add(this.UC_TVKitchens2);
            this.Controls.Add(this.CBMyKitchen);
            this.Controls.Add(this.GrpDateTimeRange);
            this.Controls.Add(this.rdbMyStore);
            this.Controls.Add(this.ShowBtn);
            this.Name = "Rpt_PurchaseItems";
            this.Text = "Rpt_PurchaseItems";
            this.Load += new System.EventHandler(this.Rpt_PurchaseItems_Load);
            this.GrpDateTimeRange.ResumeLayout(false);
            this.GrpDateTimeRange.PerformLayout();
            this.GbItem.ResumeLayout(false);
            this.GbItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ShowBtn;
        private System.Windows.Forms.RadioButton rdbMyStore;
        private System.Windows.Forms.GroupBox GrpDateTimeRange;
        private System.Windows.Forms.RadioButton BtnDeliveryDate;
        private System.Windows.Forms.RadioButton BtnCreateDate;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Button BtnItem;
        private System.Windows.Forms.TextBox TxtItemCode;
        private System.Windows.Forms.Label LItem;
        private System.Windows.Forms.TextBox TxtItemName;
        private UC_TVKitchens UC_TVKitchens2;
        private System.Windows.Forms.CheckBox CBMyKitchen;
        private System.Windows.Forms.RadioButton RbOrders;
        private System.Windows.Forms.RadioButton RbItems;
        private System.Windows.Forms.GroupBox GbItem;
    }
}