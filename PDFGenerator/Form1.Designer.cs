namespace PDFGenerator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.label2 = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.Button();
            this.findFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.frontText = new System.Windows.Forms.TextBox();
            this.rearText = new System.Windows.Forms.TextBox();
            this.frontLabel = new System.Windows.Forms.Label();
            this.rearLabel = new System.Windows.Forms.Label();
            this.frontImageList = new System.Windows.Forms.ImageList(this.components);
            this.rearImageList = new System.Windows.Forms.ImageList(this.components);
            this.frontListView = new System.Windows.Forms.ListView();
            this.rearListView = new System.Windows.Forms.ListView();
            this.changeFront = new System.Windows.Forms.CheckBox();
            this.quantityText = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.bleedText = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.frontListBox = new System.Windows.Forms.ListBox();
            this.rearListBox = new System.Windows.Forms.ListBox();
            this.quantityListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.updateQuantityButton = new System.Windows.Forms.Button();
            this.updateQuantityText = new System.Windows.Forms.TextBox();
            this.DPI300RB = new System.Windows.Forms.RadioButton();
            this.DPI600RB = new System.Windows.Forms.RadioButton();
            this.LetterRB = new System.Windows.Forms.RadioButton();
            this.A4RB = new System.Windows.Forms.RadioButton();
            this.DPIGB = new System.Windows.Forms.GroupBox();
            this.PaperSizeGB = new System.Windows.Forms.GroupBox();
            this.DPIGB.SuspendLayout();
            this.PaperSizeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 733);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Generate PDF";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(250, 789);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(163, 23);
            this.preview.TabIndex = 1;
            this.preview.Text = "Preview with default program";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.generate_Click);
            // 
            // findFolder
            // 
            this.findFolder.Location = new System.Drawing.Point(863, 73);
            this.findFolder.Name = "findFolder";
            this.findFolder.Size = new System.Drawing.Size(101, 23);
            this.findFolder.TabIndex = 2;
            this.findFolder.Text = "Find Folder";
            this.findFolder.UseVisualStyleBackColor = true;
            this.findFolder.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Find Image Folder";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // folderText
            // 
            this.folderText.Location = new System.Drawing.Point(178, 18);
            this.folderText.Name = "folderText";
            this.folderText.ReadOnly = true;
            this.folderText.Size = new System.Drawing.Size(300, 20);
            this.folderText.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 795);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bleed (in mm)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(602, 756);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(226, 20);
            this.outputText.TabIndex = 12;
            // 
            // frontText
            // 
            this.frontText.Location = new System.Drawing.Point(225, 72);
            this.frontText.Name = "frontText";
            this.frontText.Size = new System.Drawing.Size(140, 20);
            this.frontText.TabIndex = 15;
            // 
            // rearText
            // 
            this.rearText.Location = new System.Drawing.Point(688, 75);
            this.rearText.Name = "rearText";
            this.rearText.Size = new System.Drawing.Size(140, 20);
            this.rearText.TabIndex = 16;
            // 
            // frontLabel
            // 
            this.frontLabel.AutoSize = true;
            this.frontLabel.Location = new System.Drawing.Point(40, 75);
            this.frontLabel.Name = "frontLabel";
            this.frontLabel.Size = new System.Drawing.Size(154, 13);
            this.frontLabel.TabIndex = 17;
            this.frontLabel.Text = " Front search (default is \"front\")";
            // 
            // rearLabel
            // 
            this.rearLabel.AutoSize = true;
            this.rearLabel.Location = new System.Drawing.Point(511, 78);
            this.rearLabel.Name = "rearLabel";
            this.rearLabel.Size = new System.Drawing.Size(153, 13);
            this.rearLabel.TabIndex = 18;
            this.rearLabel.Text = "Rear search (default is \"back\")";
            // 
            // frontImageList
            // 
            this.frontImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.frontImageList.ImageSize = new System.Drawing.Size(170, 230);
            this.frontImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // rearImageList
            // 
            this.rearImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.rearImageList.ImageSize = new System.Drawing.Size(170, 230);
            this.rearImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frontListView
            // 
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.frontListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.frontListView.LargeImageList = this.frontImageList;
            this.frontListView.Location = new System.Drawing.Point(40, 111);
            this.frontListView.MultiSelect = false;
            this.frontListView.Name = "frontListView";
            this.frontListView.Size = new System.Drawing.Size(450, 576);
            this.frontListView.SmallImageList = this.frontImageList;
            this.frontListView.TabIndex = 20;
            this.frontListView.UseCompatibleStateImageBehavior = false;
            this.frontListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // rearListView
            // 
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup2";
            this.rearListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.rearListView.LargeImageList = this.rearImageList;
            this.rearListView.Location = new System.Drawing.Point(514, 111);
            this.rearListView.MultiSelect = false;
            this.rearListView.Name = "rearListView";
            this.rearListView.Size = new System.Drawing.Size(450, 576);
            this.rearListView.SmallImageList = this.rearImageList;
            this.rearListView.TabIndex = 21;
            this.rearListView.UseCompatibleStateImageBehavior = false;
            // 
            // changeFront
            // 
            this.changeFront.AutoSize = true;
            this.changeFront.Location = new System.Drawing.Point(990, 111);
            this.changeFront.Name = "changeFront";
            this.changeFront.Size = new System.Drawing.Size(114, 17);
            this.changeFront.TabIndex = 23;
            this.changeFront.Text = "Front in new group";
            this.changeFront.UseVisualStyleBackColor = true;
            // 
            // quantityText
            // 
            this.quantityText.Location = new System.Drawing.Point(990, 146);
            this.quantityText.Name = "quantityText";
            this.quantityText.Size = new System.Drawing.Size(60, 20);
            this.quantityText.TabIndex = 24;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(1056, 149);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(96, 13);
            this.quantityLabel.TabIndex = 25;
            this.quantityLabel.Text = "Quantity (default 1)";
            this.quantityLabel.Click += new System.EventHandler(this.quantityLabel_Click);
            // 
            // bleedText
            // 
            this.bleedText.Location = new System.Drawing.Point(124, 792);
            this.bleedText.Name = "bleedText";
            this.bleedText.Size = new System.Drawing.Size(100, 20);
            this.bleedText.TabIndex = 26;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1167, 107);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 55);
            this.addButton.TabIndex = 27;
            this.addButton.Text = "Add to list";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // frontListBox
            // 
            this.frontListBox.FormattingEnabled = true;
            this.frontListBox.Location = new System.Drawing.Point(980, 180);
            this.frontListBox.Name = "frontListBox";
            this.frontListBox.Size = new System.Drawing.Size(163, 511);
            this.frontListBox.TabIndex = 28;
            this.frontListBox.SelectedIndexChanged += new System.EventHandler(this.frontListBox_SelectedIndexChanged);
            // 
            // rearListBox
            // 
            this.rearListBox.FormattingEnabled = true;
            this.rearListBox.Location = new System.Drawing.Point(1149, 180);
            this.rearListBox.Name = "rearListBox";
            this.rearListBox.Size = new System.Drawing.Size(169, 511);
            this.rearListBox.TabIndex = 29;
            this.rearListBox.SelectedIndexChanged += new System.EventHandler(this.rearListBox_SelectedIndexChanged);
            // 
            // quantityListBox
            // 
            this.quantityListBox.FormattingEnabled = true;
            this.quantityListBox.Location = new System.Drawing.Point(1324, 180);
            this.quantityListBox.Name = "quantityListBox";
            this.quantityListBox.Size = new System.Drawing.Size(43, 511);
            this.quantityListBox.TabIndex = 30;
            this.quantityListBox.SelectedIndexChanged += new System.EventHandler(this.quantityListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Will detect .png .jpeg .jpg .gif files";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(1204, 756);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(120, 44);
            this.clearButton.TabIndex = 32;
            this.clearButton.Text = "Clear Deck";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(1000, 698);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(129, 44);
            this.removeButton.TabIndex = 33;
            this.removeButton.Text = "Remove Selected";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // updateQuantityButton
            // 
            this.updateQuantityButton.Location = new System.Drawing.Point(1167, 697);
            this.updateQuantityButton.Name = "updateQuantityButton";
            this.updateQuantityButton.Size = new System.Drawing.Size(130, 45);
            this.updateQuantityButton.TabIndex = 34;
            this.updateQuantityButton.Text = "Update Quantity";
            this.updateQuantityButton.UseVisualStyleBackColor = true;
            this.updateQuantityButton.Click += new System.EventHandler(this.updateQuantityButton_Click);
            // 
            // updateQuantityText
            // 
            this.updateQuantityText.Location = new System.Drawing.Point(1308, 710);
            this.updateQuantityText.Name = "updateQuantityText";
            this.updateQuantityText.Size = new System.Drawing.Size(59, 20);
            this.updateQuantityText.TabIndex = 35;
            // 
            // DPI300RB
            // 
            this.DPI300RB.AutoSize = true;
            this.DPI300RB.Location = new System.Drawing.Point(24, 32);
            this.DPI300RB.Name = "DPI300RB";
            this.DPI300RB.Size = new System.Drawing.Size(43, 17);
            this.DPI300RB.TabIndex = 37;
            this.DPI300RB.Text = "300";
            this.DPI300RB.UseVisualStyleBackColor = true;
            // 
            // DPI600RB
            // 
            this.DPI600RB.AutoSize = true;
            this.DPI600RB.Checked = true;
            this.DPI600RB.Location = new System.Drawing.Point(81, 32);
            this.DPI600RB.Name = "DPI600RB";
            this.DPI600RB.Size = new System.Drawing.Size(43, 17);
            this.DPI600RB.TabIndex = 38;
            this.DPI600RB.TabStop = true;
            this.DPI600RB.Text = "600";
            this.DPI600RB.UseVisualStyleBackColor = true;
            this.DPI600RB.CheckedChanged += new System.EventHandler(this.DPI600RB_CheckedChanged);
            // 
            // LetterRB
            // 
            this.LetterRB.AutoSize = true;
            this.LetterRB.Location = new System.Drawing.Point(25, 34);
            this.LetterRB.Name = "LetterRB";
            this.LetterRB.Size = new System.Drawing.Size(52, 17);
            this.LetterRB.TabIndex = 40;
            this.LetterRB.Text = "Letter";
            this.LetterRB.UseVisualStyleBackColor = true;
            // 
            // A4RB
            // 
            this.A4RB.AutoSize = true;
            this.A4RB.Checked = true;
            this.A4RB.Location = new System.Drawing.Point(93, 32);
            this.A4RB.Name = "A4RB";
            this.A4RB.Size = new System.Drawing.Size(38, 17);
            this.A4RB.TabIndex = 41;
            this.A4RB.TabStop = true;
            this.A4RB.Text = "A4";
            this.A4RB.UseVisualStyleBackColor = true;
            // 
            // DPIGB
            // 
            this.DPIGB.Controls.Add(this.DPI300RB);
            this.DPIGB.Controls.Add(this.DPI600RB);
            this.DPIGB.Location = new System.Drawing.Point(43, 699);
            this.DPIGB.Name = "DPIGB";
            this.DPIGB.Size = new System.Drawing.Size(159, 77);
            this.DPIGB.TabIndex = 42;
            this.DPIGB.TabStop = false;
            this.DPIGB.Text = "DPI";
            // 
            // PaperSizeGB
            // 
            this.PaperSizeGB.Controls.Add(this.A4RB);
            this.PaperSizeGB.Controls.Add(this.LetterRB);
            this.PaperSizeGB.Location = new System.Drawing.Point(254, 699);
            this.PaperSizeGB.Name = "PaperSizeGB";
            this.PaperSizeGB.Size = new System.Drawing.Size(159, 77);
            this.PaperSizeGB.TabIndex = 43;
            this.PaperSizeGB.TabStop = false;
            this.PaperSizeGB.Text = "Paper Size";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1379, 831);
            this.Controls.Add(this.PaperSizeGB);
            this.Controls.Add(this.DPIGB);
            this.Controls.Add(this.updateQuantityText);
            this.Controls.Add(this.updateQuantityButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quantityListBox);
            this.Controls.Add(this.rearListBox);
            this.Controls.Add(this.frontListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.bleedText);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantityText);
            this.Controls.Add(this.changeFront);
            this.Controls.Add(this.rearListView);
            this.Controls.Add(this.frontListView);
            this.Controls.Add(this.rearLabel);
            this.Controls.Add(this.frontLabel);
            this.Controls.Add(this.rearText);
            this.Controls.Add(this.frontText);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.folderText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.findFolder);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.DPIGB.ResumeLayout(false);
            this.DPIGB.PerformLayout();
            this.PaperSizeGB.ResumeLayout(false);
            this.PaperSizeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.Button findFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox folderText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.TextBox frontText;
        private System.Windows.Forms.TextBox rearText;
        private System.Windows.Forms.Label frontLabel;
        private System.Windows.Forms.Label rearLabel;
        private System.Windows.Forms.ImageList frontImageList;
        private System.Windows.Forms.ImageList rearImageList;
        private System.Windows.Forms.ListView frontListView;
        private System.Windows.Forms.ListView rearListView;
        private System.Windows.Forms.CheckBox changeFront;
        private System.Windows.Forms.TextBox quantityText;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox bleedText;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox frontListBox;
        private System.Windows.Forms.ListBox rearListBox;
        private System.Windows.Forms.ListBox quantityListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button updateQuantityButton;
        private System.Windows.Forms.TextBox updateQuantityText;
        private System.Windows.Forms.RadioButton DPI300RB;
        private System.Windows.Forms.RadioButton DPI600RB;
        private System.Windows.Forms.RadioButton LetterRB;
        private System.Windows.Forms.RadioButton A4RB;
        private System.Windows.Forms.GroupBox DPIGB;
        private System.Windows.Forms.GroupBox PaperSizeGB;
    }
}