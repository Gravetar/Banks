
namespace Banks
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DebugText = new System.Windows.Forms.RichTextBox();
            this.CMS_Debugger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeTypeStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SeperatorStrip1 = new System.Windows.Forms.ToolStripSeparator();
            this.BankInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.CardsInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AtmInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountsInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TransactionsInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SeperatorStrip2 = new System.Windows.Forms.ToolStripSeparator();
            this.StyleStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugTimer = new System.Windows.Forms.Timer(this.components);
            this.SelectUserCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectCardCB = new System.Windows.Forms.ComboBox();
            this.WIthdraw = new System.Windows.Forms.Button();
            this.CMS_Debugger.SuspendLayout();
            this.SuspendLayout();
            // 
            // DebugText
            // 
            this.DebugText.ContextMenuStrip = this.CMS_Debugger;
            this.DebugText.Cursor = System.Windows.Forms.Cursors.Default;
            this.DebugText.Dock = System.Windows.Forms.DockStyle.Right;
            this.DebugText.Location = new System.Drawing.Point(707, 0);
            this.DebugText.Name = "DebugText";
            this.DebugText.Size = new System.Drawing.Size(263, 618);
            this.DebugText.TabIndex = 0;
            this.DebugText.Text = "DEBUGGER";
            // 
            // CMS_Debugger
            // 
            this.CMS_Debugger.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS_Debugger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeTypeStrip,
            this.SeperatorStrip1,
            this.BankInfoStrip,
            this.CardsInfoStrip,
            this.ClientInfoStrip,
            this.AtmInfoStrip,
            this.AccountsInfoStrip,
            this.TransactionsInfoStrip,
            this.SeperatorStrip2,
            this.StyleStrip,
            this.DebugStrip});
            this.CMS_Debugger.Name = "CMS_Debugger";
            this.CMS_Debugger.Size = new System.Drawing.Size(230, 214);
            // 
            // ChangeTypeStrip
            // 
            this.ChangeTypeStrip.Name = "ChangeTypeStrip";
            this.ChangeTypeStrip.Size = new System.Drawing.Size(229, 22);
            this.ChangeTypeStrip.Text = "Изменить тип";
            this.ChangeTypeStrip.Click += new System.EventHandler(this.CMS_Click);
            // 
            // SeperatorStrip1
            // 
            this.SeperatorStrip1.ForeColor = System.Drawing.Color.Black;
            this.SeperatorStrip1.Name = "SeperatorStrip1";
            this.SeperatorStrip1.Size = new System.Drawing.Size(226, 6);
            // 
            // BankInfoStrip
            // 
            this.BankInfoStrip.CheckOnClick = true;
            this.BankInfoStrip.Name = "BankInfoStrip";
            this.BankInfoStrip.Size = new System.Drawing.Size(229, 22);
            this.BankInfoStrip.Text = "Информация о банке";
            // 
            // CardsInfoStrip
            // 
            this.CardsInfoStrip.CheckOnClick = true;
            this.CardsInfoStrip.Name = "CardsInfoStrip";
            this.CardsInfoStrip.Size = new System.Drawing.Size(229, 22);
            this.CardsInfoStrip.Text = "Информация о картах";
            // 
            // ClientInfoStrip
            // 
            this.ClientInfoStrip.CheckOnClick = true;
            this.ClientInfoStrip.Name = "ClientInfoStrip";
            this.ClientInfoStrip.Size = new System.Drawing.Size(229, 22);
            this.ClientInfoStrip.Text = "Информация о клиентах";
            // 
            // AtmInfoStrip
            // 
            this.AtmInfoStrip.CheckOnClick = true;
            this.AtmInfoStrip.Name = "AtmInfoStrip";
            this.AtmInfoStrip.Size = new System.Drawing.Size(229, 22);
            this.AtmInfoStrip.Text = "Информация о банкоматах";
            // 
            // AccountsInfoStrip
            // 
            this.AccountsInfoStrip.CheckOnClick = true;
            this.AccountsInfoStrip.Name = "AccountsInfoStrip";
            this.AccountsInfoStrip.Size = new System.Drawing.Size(229, 22);
            this.AccountsInfoStrip.Text = "Информация о счетах";
            // 
            // TransactionsInfoStrip
            // 
            this.TransactionsInfoStrip.CheckOnClick = true;
            this.TransactionsInfoStrip.Name = "TransactionsInfoStrip";
            this.TransactionsInfoStrip.Size = new System.Drawing.Size(229, 22);
            this.TransactionsInfoStrip.Text = "Информация о транзакциях";
            // 
            // SeperatorStrip2
            // 
            this.SeperatorStrip2.Name = "SeperatorStrip2";
            this.SeperatorStrip2.Size = new System.Drawing.Size(226, 6);
            // 
            // StyleStrip
            // 
            this.StyleStrip.CheckOnClick = true;
            this.StyleStrip.Name = "StyleStrip";
            this.StyleStrip.Size = new System.Drawing.Size(229, 22);
            this.StyleStrip.Text = "Отоброжать стиль";
            // 
            // DebugStrip
            // 
            this.DebugStrip.Checked = true;
            this.DebugStrip.CheckOnClick = true;
            this.DebugStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DebugStrip.Name = "DebugStrip";
            this.DebugStrip.Size = new System.Drawing.Size(229, 22);
            this.DebugStrip.Text = "Отладка";
            this.DebugStrip.Click += new System.EventHandler(this.CMS_Click);
            // 
            // DebugTimer
            // 
            this.DebugTimer.Interval = 1000;
            this.DebugTimer.Tick += new System.EventHandler(this.DebugTimer_Tick);
            // 
            // SelectUserCB
            // 
            this.SelectUserCB.FormattingEnabled = true;
            this.SelectUserCB.Location = new System.Drawing.Point(160, 12);
            this.SelectUserCB.Name = "SelectUserCB";
            this.SelectUserCB.Size = new System.Drawing.Size(268, 21);
            this.SelectUserCB.TabIndex = 2;
            this.SelectUserCB.Text = "Выбрать...";
            this.SelectUserCB.SelectedIndexChanged += new System.EventHandler(this.SelectUserCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Смотреть от имени...";
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(15, 80);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(686, 526);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать карту...";
            this.label2.Visible = false;
            // 
            // SelectCardCB
            // 
            this.SelectCardCB.FormattingEnabled = true;
            this.SelectCardCB.Location = new System.Drawing.Point(160, 39);
            this.SelectCardCB.Name = "SelectCardCB";
            this.SelectCardCB.Size = new System.Drawing.Size(268, 21);
            this.SelectCardCB.TabIndex = 5;
            this.SelectCardCB.Text = "Выбрать...";
            this.SelectCardCB.Visible = false;
            this.SelectCardCB.SelectedIndexChanged += new System.EventHandler(this.SelectCardCB_SelectedIndexChanged);
            // 
            // WIthdraw
            // 
            this.WIthdraw.Location = new System.Drawing.Point(523, 12);
            this.WIthdraw.Margin = new System.Windows.Forms.Padding(2);
            this.WIthdraw.Name = "WIthdraw";
            this.WIthdraw.Size = new System.Drawing.Size(56, 19);
            this.WIthdraw.TabIndex = 6;
            this.WIthdraw.Text = "button1";
            this.WIthdraw.UseVisualStyleBackColor = true;
            this.WIthdraw.Click += new System.EventHandler(this.WIthdraw_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 618);
            this.Controls.Add(this.WIthdraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectCardCB);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectUserCB);
            this.Controls.Add(this.DebugText);
            this.Name = "MainForm";
            this.Text = "Банковская система";
            this.CMS_Debugger.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer DebugTimer;
        public System.Windows.Forms.RichTextBox DebugText;
        private System.Windows.Forms.ComboBox SelectUserCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SelectCardCB;
        private System.Windows.Forms.ContextMenuStrip CMS_Debugger;
        private System.Windows.Forms.ToolStripMenuItem ChangeTypeStrip;
        private System.Windows.Forms.ToolStripMenuItem BankInfoStrip;
        private System.Windows.Forms.ToolStripMenuItem StyleStrip;
        private System.Windows.Forms.ToolStripMenuItem CardsInfoStrip;
        private System.Windows.Forms.ToolStripMenuItem ClientInfoStrip;
        private System.Windows.Forms.ToolStripSeparator SeperatorStrip1;
        private System.Windows.Forms.ToolStripMenuItem AtmInfoStrip;
        private System.Windows.Forms.ToolStripSeparator SeperatorStrip2;
        private System.Windows.Forms.ToolStripMenuItem DebugStrip;
        private System.Windows.Forms.Button WIthdraw;
        private System.Windows.Forms.ToolStripMenuItem AccountsInfoStrip;
        private System.Windows.Forms.ToolStripMenuItem TransactionsInfoStrip;
    }
}

