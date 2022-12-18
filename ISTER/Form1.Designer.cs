namespace ISTER
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
            this.label1 = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ruleBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rulesFromFactsButton = new System.Windows.Forms.Button();
            this.factsFromRuleButton = new System.Windows.Forms.Button();
            this.chosenBox = new System.Windows.Forms.ListBox();
            this.factsBox = new System.Windows.Forms.ListBox();
            this.clearChosenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Изначальные факты";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(231, 241);
            this.outputBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(442, 169);
            this.outputBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вывод";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Инвентарь";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ruleBox
            // 
            this.ruleBox.FormattingEnabled = true;
            this.ruleBox.ItemHeight = 15;
            this.ruleBox.Location = new System.Drawing.Point(231, 45);
            this.ruleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ruleBox.Name = "ruleBox";
            this.ruleBox.Size = new System.Drawing.Size(205, 169);
            this.ruleBox.TabIndex = 6;
            this.ruleBox.SelectedIndexChanged += new System.EventHandler(this.ruleBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Целевые факты";
            // 
            // rulesFromFactsButton
            // 
            this.rulesFromFactsButton.Location = new System.Drawing.Point(442, 45);
            this.rulesFromFactsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rulesFromFactsButton.Name = "rulesFromFactsButton";
            this.rulesFromFactsButton.Size = new System.Drawing.Size(231, 73);
            this.rulesFromFactsButton.TabIndex = 8;
            this.rulesFromFactsButton.Text = "КНОПКА ПРЯМОГО ВЫВОДА";
            this.rulesFromFactsButton.UseVisualStyleBackColor = true;
            this.rulesFromFactsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // factsFromRuleButton
            // 
            this.factsFromRuleButton.Location = new System.Drawing.Point(442, 138);
            this.factsFromRuleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.factsFromRuleButton.Name = "factsFromRuleButton";
            this.factsFromRuleButton.Size = new System.Drawing.Size(231, 76);
            this.factsFromRuleButton.TabIndex = 9;
            this.factsFromRuleButton.Text = "КНОПКА ОБРАТНОГО ВЫВОДА";
            this.factsFromRuleButton.UseVisualStyleBackColor = true;
            this.factsFromRuleButton.Click += new System.EventHandler(this.factsFromRuleButton_Click);
            // 
            // chosenBox
            // 
            this.chosenBox.FormattingEnabled = true;
            this.chosenBox.ItemHeight = 15;
            this.chosenBox.Location = new System.Drawing.Point(12, 241);
            this.chosenBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chosenBox.Name = "chosenBox";
            this.chosenBox.Size = new System.Drawing.Size(200, 169);
            this.chosenBox.TabIndex = 10;
            this.chosenBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.chosenBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // factsBox
            // 
            this.factsBox.FormattingEnabled = true;
            this.factsBox.ItemHeight = 15;
            this.factsBox.Location = new System.Drawing.Point(7, 45);
            this.factsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.factsBox.Name = "factsBox";
            this.factsBox.Size = new System.Drawing.Size(205, 169);
            this.factsBox.TabIndex = 11;
            this.factsBox.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.factsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox3_MouseDoubleClick);
            // 
            // clearChosenButton
            // 
            this.clearChosenButton.Location = new System.Drawing.Point(12, 418);
            this.clearChosenButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearChosenButton.Name = "clearChosenButton";
            this.clearChosenButton.Size = new System.Drawing.Size(200, 22);
            this.clearChosenButton.TabIndex = 12;
            this.clearChosenButton.Text = "Очистить";
            this.clearChosenButton.UseVisualStyleBackColor = true;
            this.clearChosenButton.Click += new System.EventHandler(this.clearChosenButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 461);
            this.Controls.Add(this.clearChosenButton);
            this.Controls.Add(this.factsBox);
            this.Controls.Add(this.chosenBox);
            this.Controls.Add(this.factsFromRuleButton);
            this.Controls.Add(this.rulesFromFactsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ruleBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private TextBox outputBox;
        private Label label2;
        private Label label3;
        private ListBox ruleBox;
        private Label label4;
        private Button rulesFromFactsButton;
        private Button factsFromRuleButton;
        private ListBox chosenBox;
        private ListBox factsBox;
        private Button clearChosenButton;
    }
}