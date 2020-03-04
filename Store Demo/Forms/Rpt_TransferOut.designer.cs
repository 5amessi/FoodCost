namespace Food_Cost.Forms
{
    partial class Rpt_TransferOut
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
            this.GrpDateTimeRange = new System.Windows.Forms.GroupBox();
            this.CbToday = new System.Windows.Forms.CheckBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.RbItems = new System.Windows.Forms.RadioButton();
            this.RbOrders = new System.Windows.Forms.RadioButton();
            this.CBMyKitchen = new System.Windows.Forms.CheckBox();
            this.GbItem = new System.Windows.Forms.GroupBox();
            this.LItem = new System.Windows.Forms.Label();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.BtnItem = new System.Windows.Forms.Button();
            this.CbRejected = new System.Windows.Forms.CheckBox();
            this.CbApproval = new System.Windows.Forms.CheckBox();
            this.CbHold = new System.Windows.Forms.CheckBox();
            this.CbPost = new System.Windows.Forms.CheckBox();
            this.Statues = new System.Windows.Forms.GroupBox();
            this.GrpDateTimeRange.SuspendLayout();
            this.GbItem.SuspendLayout();
            this.Statues.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowBtn
            // 
            this.ShowBtn.Location = new System.Drawing.Point(161, 338);
            this.ShowBtn.Name = "ShowBtn";
            this.ShowBtn.Size = new System.Drawing.Size(122, 54);
            this.ShowBtn.TabIndex = 604;
            this.ShowBtn.Text = "Show";
            this.ShowBtn.UseVisualStyleBackColor = true;
            this.ShowBtn.Click += new System.EventHandler(this.ShowBtn_Click);
            // 
            // UC_TVKitchens2
            // 
            this.UC_TVKitchens2.Location = new System.Drawing.Point(289, 14);
            this.UC_TVKitchens2.Name = "UC_TVKitchens2";
            this.UC_TVKitchens2.Size = new System.Drawing.Size(321, 377);
            this.UC_TVKitchens2.TabIndex = 613;
            this.UC_TVKitchens2.Load += new System.EventHandler(this.UC_TVKitchens2_Load);
            // 
            // GrpDateTimeRange
            // 
            this.GrpDateTimeRange.Controls.Add(this.CbToday);
            this.GrpDateTimeRange.Controls.Add(this.lblDateTo);
            this.GrpDateTimeRange.Controls.Add(this.dtp_to);
            this.GrpDateTimeRange.Controls.Add(this.lblDateFrom);
            this.GrpDateTimeRange.Controls.Add(this.dtp_from);
            this.GrpDateTimeRange.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpDateTimeRange.Location = new System.Drawing.Point(11, 12);
            this.GrpDateTimeRange.Name = "GrpDateTimeRange";
            this.GrpDateTimeRange.Size = new System.Drawing.Size(260, 130);
            this.GrpDateTimeRange.TabIndex = 614;
            this.GrpDateTimeRange.TabStop = false;
            this.GrpDateTimeRange.Tag = "160";
            this.GrpDateTimeRange.Text = "Date Time Range";
            this.GrpDateTimeRange.Enter += new System.EventHandler(this.GrpDateTimeRange_Enter);
            // 
            // CbToday
            // 
            this.CbToday.AutoSize = true;
            this.CbToday.Location = new System.Drawing.Point(23, 21);
            this.CbToday.Name = "CbToday";
            this.CbToday.Size = new System.Drawing.Size(65, 20);
            this.CbToday.TabIndex = 56;
            this.CbToday.Text = "Today";
            this.CbToday.UseVisualStyleBackColor = true;
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(1, 81);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(65, 22);
            this.lblDateTo.TabIndex = 52;
            this.lblDateTo.Text = "To";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_to
            // 
            this.dtp_to.Checked = false;
            this.dtp_to.CustomFormat = "yyyy/MM/dd";
            this.dtp_to.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(77, 81);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(166, 22);
            this.dtp_to.TabIndex = 51;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(6, 44);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(65, 22);
            this.lblDateFrom.TabIndex = 49;
            this.lblDateFrom.Text = "From";
            this.lblDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_from
            // 
            this.dtp_from.AllowDrop = true;
            this.dtp_from.Checked = false;
            this.dtp_from.CustomFormat = "yyyy/MM/dd";
            this.dtp_from.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(77, 44);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(166, 22);
            this.dtp_from.TabIndex = 50;
            // 
            // RbItems
            // 
            this.RbItems.AutoSize = true;
            this.RbItems.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RbItems.Location = new System.Drawing.Point(169, 150);
            this.RbItems.Name = "RbItems";
            this.RbItems.Size = new System.Drawing.Size(69, 20);
            this.RbItems.TabIndex = 621;
            this.RbItems.Text = "Details";
            this.RbItems.UseVisualStyleBackColor = true;
            this.RbItems.CheckedChanged += new System.EventHandler(this.RbItems_CheckedChanged);
            // 
            // RbOrders
            // 
            this.RbOrders.AutoSize = true;
            this.RbOrders.Checked = true;
            this.RbOrders.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RbOrders.Location = new System.Drawing.Point(47, 150);
            this.RbOrders.Name = "RbOrders";
            this.RbOrders.Size = new System.Drawing.Size(87, 20);
            this.RbOrders.TabIndex = 620;
            this.RbOrders.TabStop = true;
            this.RbOrders.Text = "Summary";
            this.RbOrders.UseVisualStyleBackColor = true;
            this.RbOrders.CheckedChanged += new System.EventHandler(this.RbOrders_CheckedChanged);
            // 
            // CBMyKitchen
            // 
            this.CBMyKitchen.AutoSize = true;
            this.CBMyKitchen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBMyKitchen.Location = new System.Drawing.Point(11, 355);
            this.CBMyKitchen.Name = "CBMyKitchen";
            this.CBMyKitchen.Size = new System.Drawing.Size(122, 20);
            this.CBMyKitchen.TabIndex = 612;
            this.CBMyKitchen.Text = "For My Kitchen";
            this.CBMyKitchen.UseVisualStyleBackColor = true;
            // 
            // GbItem
            // 
            this.GbItem.Controls.Add(this.LItem);
            this.GbItem.Controls.Add(this.TxtItemName);
            this.GbItem.Controls.Add(this.TxtItemCode);
            this.GbItem.Controls.Add(this.BtnItem);
            this.GbItem.Location = new System.Drawing.Point(11, 176);
            this.GbItem.Name = "GbItem";
            this.GbItem.Size = new System.Drawing.Size(272, 54);
            this.GbItem.TabIndex = 622;
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
            this.BtnItem.Click += new System.EventHandler(this.BtnItem_Click);
            // 
            // CbRejected
            // 
            this.CbRejected.AutoSize = true;
            this.CbRejected.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CbRejected.Location = new System.Drawing.Point(6, 19);
            this.CbRejected.Name = "CbRejected";
            this.CbRejected.Size = new System.Drawing.Size(83, 20);
            this.CbRejected.TabIndex = 0;
            this.CbRejected.Text = "Rejected";
            this.CbRejected.UseVisualStyleBackColor = true;
            // 
            // CbApproval
            // 
            this.CbApproval.AutoSize = true;
            this.CbApproval.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CbApproval.Location = new System.Drawing.Point(129, 19);
            this.CbApproval.Name = "CbApproval";
            this.CbApproval.Size = new System.Drawing.Size(84, 20);
            this.CbApproval.TabIndex = 1;
            this.CbApproval.Text = "Approval";
            this.CbApproval.UseVisualStyleBackColor = true;
            // 
            // CbHold
            // 
            this.CbHold.AutoSize = true;
            this.CbHold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CbHold.Location = new System.Drawing.Point(130, 51);
            this.CbHold.Name = "CbHold";
            this.CbHold.Size = new System.Drawing.Size(56, 20);
            this.CbHold.TabIndex = 2;
            this.CbHold.Text = "Hold";
            this.CbHold.UseVisualStyleBackColor = true;
            // 
            // CbPost
            // 
            this.CbPost.AutoSize = true;
            this.CbPost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CbPost.Location = new System.Drawing.Point(6, 51);
            this.CbPost.Name = "CbPost";
            this.CbPost.Size = new System.Drawing.Size(54, 20);
            this.CbPost.TabIndex = 3;
            this.CbPost.Text = "Post";
            this.CbPost.UseVisualStyleBackColor = true;
            // 
            // Statues
            // 
            this.Statues.Controls.Add(this.CbPost);
            this.Statues.Controls.Add(this.CbHold);
            this.Statues.Controls.Add(this.CbApproval);
            this.Statues.Controls.Add(this.CbRejected);
            this.Statues.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Statues.Location = new System.Drawing.Point(12, 236);
            this.Statues.Name = "Statues";
            this.Statues.Size = new System.Drawing.Size(271, 77);
            this.Statues.TabIndex = 623;
            this.Statues.TabStop = false;
            this.Statues.Text = "Statues";
            // 
            // Rpt_TransferOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 404);
            this.Controls.Add(this.Statues);
            this.Controls.Add(this.GbItem);
            this.Controls.Add(this.RbItems);
            this.Controls.Add(this.RbOrders);
            this.Controls.Add(this.GrpDateTimeRange);
            this.Controls.Add(this.UC_TVKitchens2);
            this.Controls.Add(this.CBMyKitchen);
            this.Controls.Add(this.ShowBtn);
            this.Name = "Rpt_TransferOut";
            this.Text = "InterKitchenTransfer";
            this.GrpDateTimeRange.ResumeLayout(false);
            this.GrpDateTimeRange.PerformLayout();
            this.GbItem.ResumeLayout(false);
            this.GbItem.PerformLayout();
            this.Statues.ResumeLayout(false);
            this.Statues.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ShowBtn;
        private UC_TVKitchens UC_TVKitchens2;
        private System.Windows.Forms.GroupBox GrpDateTimeRange;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.RadioButton RbItems;
        private System.Windows.Forms.RadioButton RbOrders;
        private System.Windows.Forms.CheckBox CbToday;
        private System.Windows.Forms.CheckBox CBMyKitchen;
        private System.Windows.Forms.GroupBox GbItem;
        private System.Windows.Forms.Label LItem;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.TextBox TxtItemCode;
        private System.Windows.Forms.Button BtnItem;
        private System.Windows.Forms.CheckBox CbRejected;
        private System.Windows.Forms.CheckBox CbApproval;
        private System.Windows.Forms.CheckBox CbHold;
        private System.Windows.Forms.CheckBox CbPost;
        private System.Windows.Forms.GroupBox Statues;
    }
}