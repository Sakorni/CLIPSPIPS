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
            this.label1.Location = new System.Drawing.Point(-1, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Что есть";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(264, 51);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(504, 233);
            this.outputBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вывод";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выбранные предметы";
            // 
            // ruleBox
            // 
            this.ruleBox.FormattingEnabled = true;
            this.ruleBox.ItemHeight = 20;
            this.ruleBox.Location = new System.Drawing.Point(10, 341);
            this.ruleBox.Name = "ruleBox";
            this.ruleBox.Size = new System.Drawing.Size(232, 204);
            this.ruleBox.TabIndex = 6;
            this.ruleBox.SelectedIndexChanged += new System.EventHandler(this.ruleBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Что хотим получить";
            // 
            // rulesFromFactsButton
            // 
            this.rulesFromFactsButton.Location = new System.Drawing.Point(816, 51);
            this.rulesFromFactsButton.Name = "rulesFromFactsButton";
            this.rulesFromFactsButton.Size = new System.Drawing.Size(283, 224);
            this.rulesFromFactsButton.TabIndex = 8;
            this.rulesFromFactsButton.Text = "Жми на рычаг, Кронк";
            this.rulesFromFactsButton.UseVisualStyleBackColor = true;
            this.rulesFromFactsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // factsFromRuleButton
            // 
            this.factsFromRuleButton.Location = new System.Drawing.Point(829, 341);
            this.factsFromRuleButton.Name = "factsFromRuleButton";
            this.factsFromRuleButton.Size = new System.Drawing.Size(270, 208);
            this.factsFromRuleButton.TabIndex = 9;
            this.factsFromRuleButton.Text = "Не тот рычаг!";
            this.factsFromRuleButton.UseVisualStyleBackColor = true;
            this.factsFromRuleButton.Click += new System.EventHandler(this.factsFromRuleButton_Click);
            // 
            // chosenBox
            // 
            this.chosenBox.FormattingEnabled = true;
            this.chosenBox.ItemHeight = 20;
            this.chosenBox.Location = new System.Drawing.Point(264, 340);
            this.chosenBox.Name = "chosenBox";
            this.chosenBox.Size = new System.Drawing.Size(504, 204);
            this.chosenBox.TabIndex = 10;
            this.chosenBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.chosenBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // factsBox
            // 
            this.factsBox.FormattingEnabled = true;
            this.factsBox.ItemHeight = 20;
            this.factsBox.Location = new System.Drawing.Point(8, 60);
            this.factsBox.Name = "factsBox";
            this.factsBox.Size = new System.Drawing.Size(234, 224);
            this.factsBox.TabIndex = 11;
            this.factsBox.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.factsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox3_MouseDoubleClick);
            // 
            // clearChosenButton
            // 
            this.clearChosenButton.Location = new System.Drawing.Point(264, 550);
            this.clearChosenButton.Name = "clearChosenButton";
            this.clearChosenButton.Size = new System.Drawing.Size(94, 29);
            this.clearChosenButton.TabIndex = 12;
            this.clearChosenButton.Text = "Очистить";
            this.clearChosenButton.UseVisualStyleBackColor = true;
            this.clearChosenButton.Click += new System.EventHandler(this.clearChosenButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 615);
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