namespace ProductsCatalog.PresentationGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();

            // Nove komponente
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            labelMinPrice = new Label();
            numericUpDownMinPrice = new NumericUpDown();
            labelMaxPrice = new Label();
            numericUpDownMaxPrice = new NumericUpDown();
            buttonFilter = new Button();
            buttonReset = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxPrice).BeginInit();
            SuspendLayout();

            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 80); 
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(946, 255);
            dataGridView1.TabIndex = 0;

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(716, 386);
            button1.Name = "button1";
            button1.Size = new Size(252, 55);
            button1.TabIndex = 1;
            button1.Text = "Add Product";
            button1.UseVisualStyleBackColor = false;

            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(22, 20); 
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(44, 15);
            labelSearch.TabIndex = 2;
            labelSearch.Text = "Search";

            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(80, 17); 
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(200, 23);
            textBoxSearch.TabIndex = 3;

            // 
            // labelMinPrice
            // 
            labelMinPrice.AutoSize = true;
            labelMinPrice.Location = new Point(300, 20); 
            labelMinPrice.Name = "labelMinPrice";
            labelMinPrice.Size = new Size(61, 15);
            labelMinPrice.TabIndex = 4;
            labelMinPrice.Text = "Min Price";

            // 
            // numericUpDownMinPrice
            // 
            numericUpDownMinPrice.Location = new Point(370, 17); 
            numericUpDownMinPrice.Name = "numericUpDownMinPrice";
            numericUpDownMinPrice.Size = new Size(80, 23);
            numericUpDownMinPrice.TabIndex = 5;
            numericUpDownMinPrice.Minimum = 0;
            numericUpDownMinPrice.Maximum = 100000;

            // 
            // labelMaxPrice
            // 
            labelMaxPrice.AutoSize = true;
            labelMaxPrice.Location = new Point(470, 20); 
            labelMaxPrice.Name = "labelMaxPrice";
            labelMaxPrice.Size = new Size(64, 15);
            labelMaxPrice.TabIndex = 6;
            labelMaxPrice.Text = "Max Price";

            // 
            // numericUpDownMaxPrice
            // 
            numericUpDownMaxPrice.Location = new Point(540, 17); 
            numericUpDownMaxPrice.Name = "numericUpDownMaxPrice";
            numericUpDownMaxPrice.Size = new Size(80, 23);
            numericUpDownMaxPrice.TabIndex = 7;
            numericUpDownMaxPrice.Minimum = 0;
            numericUpDownMaxPrice.Maximum = 100000;

            // 
            // buttonFilter
            // 
            buttonFilter.BackColor = SystemColors.ActiveCaption;
            buttonFilter.Location = new Point(650, 15); 
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(100, 25);
            buttonFilter.TabIndex = 8;
            buttonFilter.Text = "Filter";
            buttonFilter.UseVisualStyleBackColor = false;

            // 
            // buttonReset
            // 
            buttonReset.BackColor = System.Drawing.Color.IndianRed;
            buttonReset.Location = new Point(850, 15);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(100, 25);
            buttonReset.TabIndex = 8;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.ForeColor = System.Drawing.Color.White;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 474);
            Controls.Add(buttonFilter);
            Controls.Add(buttonReset);
            Controls.Add(numericUpDownMaxPrice);
            Controls.Add(labelMaxPrice);
            Controls.Add(numericUpDownMinPrice);
            Controls.Add(labelMinPrice);
            Controls.Add(textBoxSearch);
            Controls.Add(labelSearch);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;

        // Nove promenljive za filter
        private Label labelSearch;
        private TextBox textBoxSearch;
        private Label labelMinPrice;
        private NumericUpDown numericUpDownMinPrice;
        private Label labelMaxPrice;
        private NumericUpDown numericUpDownMaxPrice;
        private Button buttonFilter;
        private Button buttonReset;
    }
}