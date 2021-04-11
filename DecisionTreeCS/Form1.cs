using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionTreeCS {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void startBtn_Click(object sender, EventArgs e) {
      List<ParsedExample> trainingData = new List<ParsedExample> {
        new ParsedExample("lluvioso", "calido", "alto", "bajo", "no"),
        new ParsedExample("lluvioso", "calido", "alto", "alto", "no"),
        new ParsedExample("nublado", "calido", "alto", "bajo", "si"),
        new ParsedExample("soleado", "temp media", "alto", "bajo", "si"),
        new ParsedExample("soleado", "frio", "normal", "bajo", "si"),
        new ParsedExample("soleado", "frio", "normal", "alto", "no"),
        new ParsedExample("nublado", "frio", "normal", "alto", "si"),
        new ParsedExample("lluvioso", "temp media", "alto", "bajo", "no"),
        new ParsedExample("lluvioso", "frio", "normal", "bajo", "si"),
      };
      DecisionTree tree = new DecisionTree();
      tree.Fit(trainingData);

      List<ParsedExample> predictionData = new List<ParsedExample> {
        new ParsedExample("nublado", "temp media", "alto", "alto", "si"),
        new ParsedExample("soleado", "temp media", "alto", "alto", "no"),
      };

      foreach (ParsedExample predict in predictionData) {
        DecisionNode prediction = tree.Predict(predict);
        Console.WriteLine(prediction.ToString());
      }
    }
  }
}
