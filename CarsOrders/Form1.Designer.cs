namespace CarsOrders
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            m_CompanyNameTB = new TextBox();
            m_CarNumber = new TextBox();
            m_CompanyHpTB = new TextBox();
            m_CarModel = new TextBox();
            m_CarColor = new TextBox();
            m_AddCarBtn = new Button();
            m_SaveOrderBtn = new Button();
            DisplayFeedbakXml = new Button();
            m_InsertTextLabel = new Label();
            m_SearchCarTB = new TextBox();
            m_SearchBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1301, 165);
            label1.Name = "label1";
            label1.Size = new Size(132, 32);
            label1.TabIndex = 0;
            label1.Text = "שם החברה";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1301, 236);
            label2.Name = "label2";
            label2.Size = new Size(116, 32);
            label2.TabIndex = 1;
            label2.Text = "ח.פ חברה";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1281, 326);
            label3.Name = "label3";
            label3.Size = new Size(155, 32);
            label3.TabIndex = 2;
            label3.Text = "מספרי רכבים:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1241, 420);
            label4.Name = "label4";
            label4.Size = new Size(121, 32);
            label4.TabIndex = 3;
            label4.Text = "מספר רכב";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1241, 500);
            label5.Name = "label5";
            label5.Size = new Size(53, 32);
            label5.TabIndex = 4;
            label5.Text = "דגם";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1241, 573);
            label6.Name = "label6";
            label6.Size = new Size(57, 32);
            label6.TabIndex = 5;
            label6.Text = "צבע";
            // 
            // m_CompanyNameTB
            // 
            m_CompanyNameTB.Location = new Point(1074, 162);
            m_CompanyNameTB.Name = "m_CompanyNameTB";
            m_CompanyNameTB.Size = new Size(200, 39);
            m_CompanyNameTB.TabIndex = 6;
            // 
            // m_CarNumber
            // 
            m_CarNumber.Location = new Point(1021, 413);
            m_CarNumber.Name = "m_CarNumber";
            m_CarNumber.Size = new Size(200, 39);
            m_CarNumber.TabIndex = 7;
            // 
            // m_CompanyHpTB
            // 
            m_CompanyHpTB.Location = new Point(1074, 229);
            m_CompanyHpTB.Name = "m_CompanyHpTB";
            m_CompanyHpTB.Size = new Size(200, 39);
            m_CompanyHpTB.TabIndex = 8;
            // 
            // m_CarModel
            // 
            m_CarModel.Location = new Point(1021, 493);
            m_CarModel.Name = "m_CarModel";
            m_CarModel.Size = new Size(200, 39);
            m_CarModel.TabIndex = 9;
            // 
            // m_CarColor
            // 
            m_CarColor.Location = new Point(1021, 573);
            m_CarColor.Name = "m_CarColor";
            m_CarColor.Size = new Size(200, 39);
            m_CarColor.TabIndex = 10;
            // 
            // m_AddCarBtn
            // 
            m_AddCarBtn.Location = new Point(935, 642);
            m_AddCarBtn.Name = "m_AddCarBtn";
            m_AddCarBtn.Size = new Size(150, 46);
            m_AddCarBtn.TabIndex = 11;
            m_AddCarBtn.Text = "הוסף רכב";
            m_AddCarBtn.UseVisualStyleBackColor = true;
            m_AddCarBtn.Click += m_AddCarBtn_Click;
            // 
            // m_SaveOrderBtn
            // 
            m_SaveOrderBtn.Location = new Point(805, 733);
            m_SaveOrderBtn.Name = "m_SaveOrderBtn";
            m_SaveOrderBtn.Size = new Size(150, 46);
            m_SaveOrderBtn.TabIndex = 12;
            m_SaveOrderBtn.Text = "שמור";
            m_SaveOrderBtn.UseVisualStyleBackColor = true;
            m_SaveOrderBtn.Click += m_SaveOrderBtn_Click;
            // 
            // DisplayFeedbakXml
            // 
            DisplayFeedbakXml.Location = new Point(496, 926);
            DisplayFeedbakXml.Name = "DisplayFeedbakXml";
            DisplayFeedbakXml.Size = new Size(459, 46);
            DisplayFeedbakXml.TabIndex = 13;
            DisplayFeedbakXml.Text = "התקבל משוב להזמנה - לחץ לתצוגה";
            DisplayFeedbakXml.UseVisualStyleBackColor = true;
            DisplayFeedbakXml.Visible = false;
            // 
            // m_InsertTextLabel
            // 
            m_InsertTextLabel.AutoSize = true;
            m_InsertTextLabel.Location = new Point(471, 162);
            m_InsertTextLabel.Name = "m_InsertTextLabel";
            m_InsertTextLabel.Size = new Size(244, 32);
            m_InsertTextLabel.TabIndex = 14;
            m_InsertTextLabel.Text = "הזן מספר רכב לחיפוש:";
            // 
            // m_SearchCarTB
            // 
            m_SearchCarTB.Location = new Point(127, 159);
            m_SearchCarTB.Name = "m_SearchCarTB";
            m_SearchCarTB.Size = new Size(326, 39);
            m_SearchCarTB.TabIndex = 15;
            // 
            // m_SearchBtn
            // 
            m_SearchBtn.Location = new Point(45, 222);
            m_SearchBtn.Name = "m_SearchBtn";
            m_SearchBtn.Size = new Size(150, 46);
            m_SearchBtn.TabIndex = 16;
            m_SearchBtn.Text = "חפש";
            m_SearchBtn.UseVisualStyleBackColor = true;
            m_SearchBtn.Click += m_SearchBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1745, 1003);
            Controls.Add(m_SearchBtn);
            Controls.Add(m_SearchCarTB);
            Controls.Add(m_InsertTextLabel);
            Controls.Add(DisplayFeedbakXml);
            Controls.Add(m_SaveOrderBtn);
            Controls.Add(m_AddCarBtn);
            Controls.Add(m_CarColor);
            Controls.Add(m_CarModel);
            Controls.Add(m_CompanyHpTB);
            Controls.Add(m_CarNumber);
            Controls.Add(m_CompanyNameTB);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "CarsOrders";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox m_CompanyNameTB;
        private TextBox m_CarNumber;
        private TextBox m_CompanyHpTB;
        private TextBox m_CarModel;
        private TextBox m_CarColor;
        private Button m_AddCarBtn;
        private Button m_SaveOrderBtn;
        private Button DisplayFeedbakXml;
        private Label m_InsertTextLabel;
        private TextBox m_SearchCarTB;
        private Button m_SearchBtn;
    }
}
