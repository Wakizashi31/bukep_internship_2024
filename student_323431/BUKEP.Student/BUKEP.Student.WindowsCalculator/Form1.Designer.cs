namespace BUKEP.Student.WindowsCalculator
{
    partial class Form1
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
            this.display = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.butpannel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.butpannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayText
            // 
            this.display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.display.Dock = System.Windows.Forms.DockStyle.Top;
            this.display.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.display.ForeColor = System.Drawing.Color.White;
            this.display.Location = new System.Drawing.Point(0, 0);
            this.display.Name = "DisplayText";
            this.display.ReadOnly = true;
            this.display.Size = new System.Drawing.Size(384, 46);
            this.display.TabIndex = 0;
            this.display.Text = "0";
            this.display.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // butpannel
            // 
            this.butpannel.Controls.Add(this.button1);
            this.butpannel.Controls.Add(this.button17);
            this.butpannel.Controls.Add(this.button16);
            this.butpannel.Controls.Add(this.button15);
            this.butpannel.Controls.Add(this.button14);
            this.butpannel.Controls.Add(this.button13);
            this.butpannel.Controls.Add(this.button12);
            this.butpannel.Controls.Add(this.button11);
            this.butpannel.Controls.Add(this.button10);
            this.butpannel.Controls.Add(this.button9);
            this.butpannel.Controls.Add(this.button8);
            this.butpannel.Controls.Add(this.button7);
            this.butpannel.Controls.Add(this.button6);
            this.butpannel.Controls.Add(this.button5);
            this.butpannel.Controls.Add(this.button3);
            this.butpannel.Controls.Add(this.button2);
            this.butpannel.Controls.Add(this.button4);
            this.butpannel.Location = new System.Drawing.Point(1, 43);
            this.butpannel.Name = "butpannel";
            this.butpannel.Size = new System.Drawing.Size(382, 505);
            this.butpannel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(103, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 70);
            this.button1.TabIndex = 72;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ButtonClear);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button17.Location = new System.Drawing.Point(285, 380);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(85, 73);
            this.button17.TabIndex = 71;
            this.button17.Text = "=";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.ButtonExpressionCalculation);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(103, 380);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(85, 73);
            this.button16.TabIndex = 70;
            this.button16.Text = "0";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.AddNumber);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(285, 301);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(85, 73);
            this.button15.TabIndex = 69;
            this.button15.Text = "+";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.AddOperation);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(285, 222);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(85, 73);
            this.button14.TabIndex = 68;
            this.button14.Text = "-";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.AddOperation);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(285, 143);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(85, 73);
            this.button13.TabIndex = 67;
            this.button13.Text = "*";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.AddOperation);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(194, 301);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(85, 73);
            this.button12.TabIndex = 66;
            this.button12.Text = "3";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.AddNumber);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(194, 222);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(85, 73);
            this.button11.TabIndex = 65;
            this.button11.Text = "6";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.AddNumber);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(194, 143);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(85, 73);
            this.button10.TabIndex = 64;
            this.button10.Text = "9";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.AddNumber);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(103, 301);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(85, 73);
            this.button9.TabIndex = 63;
            this.button9.Text = "2";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.AddNumber);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(12, 301);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 73);
            this.button8.TabIndex = 62;
            this.button8.Text = "1";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.AddNumber);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(12, 222);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 73);
            this.button7.TabIndex = 61;
            this.button7.Text = "4";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.AddNumber);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(103, 222);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 73);
            this.button6.TabIndex = 60;
            this.button6.Text = "5";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.AddNumber);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(12, 143);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 73);
            this.button5.TabIndex = 59;
            this.button5.Text = "7";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.AddNumber);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(285, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 70);
            this.button3.TabIndex = 58;
            this.button3.Text = "/";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.AddOperation);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(194, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 70);
            this.button2.TabIndex = 57;
            this.button2.Text = "⌫";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ButtonDeleteSymbol);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(103, 143);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 73);
            this.button4.TabIndex = 56;
            this.button4.Text = "8";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.AddNumber);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(384, 553);
            this.Controls.Add(this.butpannel);
            this.Controls.Add(this.display);
            this.MaximumSize = new System.Drawing.Size(400, 592);
            this.MinimumSize = new System.Drawing.Size(400, 592);
            this.Name = "Form1";
            this.Text = "Form1";
            this.butpannel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel butpannel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}

