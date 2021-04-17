
namespace DecisionTreeCS {
  partial class MainActivity {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.fileSelectBtn = new System.Windows.Forms.Button();
      this.csvFileLoader = new System.Windows.Forms.OpenFileDialog();
      this.fileNameLabel = new System.Windows.Forms.Label();
      this.fileContentTextBox = new System.Windows.Forms.TextBox();
      this.dataTypesTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // fileSelectBtn
      // 
      this.fileSelectBtn.Location = new System.Drawing.Point(12, 12);
      this.fileSelectBtn.Name = "fileSelectBtn";
      this.fileSelectBtn.Size = new System.Drawing.Size(119, 23);
      this.fileSelectBtn.TabIndex = 0;
      this.fileSelectBtn.Text = "Seleccionar dataset";
      this.fileSelectBtn.UseVisualStyleBackColor = true;
      this.fileSelectBtn.Click += new System.EventHandler(this.fileSelectBtn_Click);
      // 
      // csvFileLoader
      // 
      this.csvFileLoader.Filter = "Archivo CSV|*.csv";
      this.csvFileLoader.ReadOnlyChecked = true;
      // 
      // fileNameLabel
      // 
      this.fileNameLabel.AutoSize = true;
      this.fileNameLabel.Location = new System.Drawing.Point(137, 17);
      this.fileNameLabel.Name = "fileNameLabel";
      this.fileNameLabel.Size = new System.Drawing.Size(75, 13);
      this.fileNameLabel.TabIndex = 1;
      this.fileNameLabel.Text = "Seleccionado:";
      // 
      // fileContentTextBox
      // 
      this.fileContentTextBox.Location = new System.Drawing.Point(12, 41);
      this.fileContentTextBox.Multiline = true;
      this.fileContentTextBox.Name = "fileContentTextBox";
      this.fileContentTextBox.ReadOnly = true;
      this.fileContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.fileContentTextBox.Size = new System.Drawing.Size(441, 211);
      this.fileContentTextBox.TabIndex = 2;
      // 
      // dataTypesTextBox
      // 
      this.dataTypesTextBox.Location = new System.Drawing.Point(13, 259);
      this.dataTypesTextBox.Name = "dataTypesTextBox";
      this.dataTypesTextBox.ReadOnly = true;
      this.dataTypesTextBox.Size = new System.Drawing.Size(440, 20);
      this.dataTypesTextBox.TabIndex = 3;
      // 
      // MainActivity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(465, 364);
      this.Controls.Add(this.dataTypesTextBox);
      this.Controls.Add(this.fileContentTextBox);
      this.Controls.Add(this.fileNameLabel);
      this.Controls.Add(this.fileSelectBtn);
      this.Name = "MainActivity";
      this.Text = "Decision Tree";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button fileSelectBtn;
    private System.Windows.Forms.OpenFileDialog csvFileLoader;
    private System.Windows.Forms.Label fileNameLabel;
    private System.Windows.Forms.TextBox fileContentTextBox;
    private System.Windows.Forms.TextBox dataTypesTextBox;
  }
}