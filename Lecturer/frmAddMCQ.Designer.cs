namespace Lecturer
{
    partial class frmAddMCQ
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoOfQs = new System.Windows.Forms.TextBox();
            this.txtMarksPerQuestion = new System.Windows.Forms.TextBox();
            this.txtMarksAvailable = new System.Windows.Forms.TextBox();
            this.chbNegativeMarking = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of questions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marks per question";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Marks available (%)";
            // 
            // txtNoOfQs
            // 
            this.txtNoOfQs.Location = new System.Drawing.Point(141, 24);
            this.txtNoOfQs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNoOfQs.Name = "txtNoOfQs";
            this.txtNoOfQs.Size = new System.Drawing.Size(67, 20);
            this.txtNoOfQs.TabIndex = 4;
            // 
            // txtMarksPerQuestion
            // 
            this.txtMarksPerQuestion.Location = new System.Drawing.Point(141, 67);
            this.txtMarksPerQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMarksPerQuestion.Name = "txtMarksPerQuestion";
            this.txtMarksPerQuestion.Size = new System.Drawing.Size(67, 20);
            this.txtMarksPerQuestion.TabIndex = 5;
            // 
            // txtMarksAvailable
            // 
            this.txtMarksAvailable.Location = new System.Drawing.Point(141, 108);
            this.txtMarksAvailable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMarksAvailable.Name = "txtMarksAvailable";
            this.txtMarksAvailable.Size = new System.Drawing.Size(67, 20);
            this.txtMarksAvailable.TabIndex = 6;
            // 
            // chbNegativeMarking
            // 
            this.chbNegativeMarking.AutoSize = true;
            this.chbNegativeMarking.Location = new System.Drawing.Point(260, 106);
            this.chbNegativeMarking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbNegativeMarking.Name = "chbNegativeMarking";
            this.chbNegativeMarking.Size = new System.Drawing.Size(115, 17);
            this.chbNegativeMarking.TabIndex = 7;
            this.chbNegativeMarking.Text = "Negative marking?";
            this.chbNegativeMarking.UseVisualStyleBackColor = true;
            this.chbNegativeMarking.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chbNegativeMarking);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMarksAvailable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMarksPerQuestion);
            this.groupBox1.Controls.Add(this.txtNoOfQs);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(397, 140);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MCQ details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 157);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = " Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(336, 157);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 19);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAddMCQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 185);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAddMCQ";
            this.Text = "Add MCQ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddMCQ_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoOfQs;
        private System.Windows.Forms.TextBox txtMarksPerQuestion;
        private System.Windows.Forms.TextBox txtMarksAvailable;
        private System.Windows.Forms.CheckBox chbNegativeMarking;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
    }
}