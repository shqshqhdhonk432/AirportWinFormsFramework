namespace AirportWinFormsFramework.Forms
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
            this.gridTariffs = new System.Windows.Forms.DataGridView();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStrategy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridTariffs)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTariffs
            // 
            this.gridTariffs.AllowUserToAddRows = false;
            this.gridTariffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTariffs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDestination,
            this.colBasePrice,
            this.colStrategy,
            this.colDiscount,
            this.colFinal});
            this.gridTariffs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridTariffs.Location = new System.Drawing.Point(0, 0);
            this.gridTariffs.Name = "gridTariffs";
            this.gridTariffs.ReadOnly = true;
            this.gridTariffs.RowHeadersWidth = 51;
            this.gridTariffs.RowTemplate.Height = 24;
            this.gridTariffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTariffs.Size = new System.Drawing.Size(800, 150);
            this.gridTariffs.TabIndex = 0;
            this.gridTariffs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTariffs_ColumnHeaderMouseClick);
            // 
            // colDestination
            // 
            this.colDestination.DataPropertyName = "Destination";
            this.colDestination.HeaderText = "Направление";
            this.colDestination.MinimumWidth = 6;
            this.colDestination.Name = "colDestination";
            this.colDestination.ReadOnly = true;
            this.colDestination.Width = 125;
            // 
            // colBasePrice
            // 
            this.colBasePrice.DataPropertyName = "BasePrice";
            this.colBasePrice.HeaderText = "Базовая цена";
            this.colBasePrice.MinimumWidth = 6;
            this.colBasePrice.Name = "colBasePrice";
            this.colBasePrice.ReadOnly = true;
            this.colBasePrice.Width = 125;
            // 
            // colStrategy
            // 
            this.colStrategy.DataPropertyName = "StrategyType";
            this.colStrategy.HeaderText = "Стратегия";
            this.colStrategy.MinimumWidth = 6;
            this.colStrategy.Name = "colStrategy";
            this.colStrategy.ReadOnly = true;
            this.colStrategy.Width = 125;
            // 
            // colDiscount
            // 
            this.colDiscount.DataPropertyName = "DiscountPercent";
            this.colDiscount.HeaderText = "Скидка, %";
            this.colDiscount.MinimumWidth = 6;
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.ReadOnly = true;
            this.colDiscount.Width = 125;
            // 
            // colFinal
            // 
            this.colFinal.DataPropertyName = "FinalPrice";
            this.colFinal.HeaderText = "Итоговая цена";
            this.colFinal.MinimumWidth = 6;
            this.colFinal.Name = "colFinal";
            this.colFinal.ReadOnly = true;
            this.colFinal.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(38, 169);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(271, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(38, 211);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(271, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(38, 256);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(271, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(38, 301);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(271, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Открыть файл";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(271, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить файл";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMax
            // 
            this.btnMax.Location = new System.Drawing.Point(38, 397);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(750, 23);
            this.btnMax.TabIndex = 6;
            this.btnMax.Text = "Макс. цена: направление";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(727, 423);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 18);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Готово";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridTariffs);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridTariffs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTariffs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinal;
    }
}

