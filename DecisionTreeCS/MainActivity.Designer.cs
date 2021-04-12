
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
      this.startBtn = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.resultLabel = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.skyPrediction = new System.Windows.Forms.ListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.ambientPrediction = new System.Windows.Forms.ListBox();
      this.label4 = new System.Windows.Forms.Label();
      this.humidityPrediction = new System.Windows.Forms.ListBox();
      this.label5 = new System.Windows.Forms.Label();
      this.windspeedPrediction = new System.Windows.Forms.ListBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // startBtn
      // 
      this.startBtn.Location = new System.Drawing.Point(219, 12);
      this.startBtn.Name = "startBtn";
      this.startBtn.Size = new System.Drawing.Size(109, 23);
      this.startBtn.TabIndex = 0;
      this.startBtn.Text = "Generar predicción";
      this.startBtn.UseVisualStyleBackColor = true;
      this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(216, 51);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Resultado";
      // 
      // resultLabel
      // 
      this.resultLabel.AutoSize = true;
      this.resultLabel.Location = new System.Drawing.Point(216, 81);
      this.resultLabel.Name = "resultLabel";
      this.resultLabel.Size = new System.Drawing.Size(10, 13);
      this.resultLabel.TabIndex = 3;
      this.resultLabel.Text = "r";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.windspeedPrediction);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.humidityPrediction);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.ambientPrediction);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.skyPrediction);
      this.groupBox1.Location = new System.Drawing.Point(15, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(195, 165);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Valores a predecir";
      // 
      // skyPrediction
      // 
      this.skyPrediction.FormattingEnabled = true;
      this.skyPrediction.Items.AddRange(new object[] {
            "lluvioso",
            "nublado",
            "soleado"});
      this.skyPrediction.Location = new System.Drawing.Point(6, 39);
      this.skyPrediction.Name = "skyPrediction";
      this.skyPrediction.Size = new System.Drawing.Size(80, 43);
      this.skyPrediction.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 23);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Cielo";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(98, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Ambiente";
      // 
      // ambientPrediction
      // 
      this.ambientPrediction.FormattingEnabled = true;
      this.ambientPrediction.Items.AddRange(new object[] {
            "calido",
            "temp media",
            "frio"});
      this.ambientPrediction.Location = new System.Drawing.Point(101, 39);
      this.ambientPrediction.Name = "ambientPrediction";
      this.ambientPrediction.Size = new System.Drawing.Size(80, 43);
      this.ambientPrediction.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 94);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Humedad";
      // 
      // humidityPrediction
      // 
      this.humidityPrediction.FormattingEnabled = true;
      this.humidityPrediction.Items.AddRange(new object[] {
            "alto",
            "normal"});
      this.humidityPrediction.Location = new System.Drawing.Point(9, 110);
      this.humidityPrediction.Name = "humidityPrediction";
      this.humidityPrediction.Size = new System.Drawing.Size(80, 43);
      this.humidityPrediction.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(98, 94);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(86, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "Velocidad viento";
      // 
      // windspeedPrediction
      // 
      this.windspeedPrediction.FormattingEnabled = true;
      this.windspeedPrediction.Items.AddRange(new object[] {
            "bajo",
            "alto"});
      this.windspeedPrediction.Location = new System.Drawing.Point(101, 110);
      this.windspeedPrediction.Name = "windspeedPrediction";
      this.windspeedPrediction.Size = new System.Drawing.Size(80, 43);
      this.windspeedPrediction.TabIndex = 7;
      // 
      // MainActivity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(472, 289);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.resultLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.startBtn);
      this.Name = "MainActivity";
      this.Text = "Decision Tree";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button startBtn;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label resultLabel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ListBox skyPrediction;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox windspeedPrediction;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListBox humidityPrediction;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ListBox ambientPrediction;
    private System.Windows.Forms.Label label3;
  }
}