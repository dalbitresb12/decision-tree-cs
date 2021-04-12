using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DecisionTreeCS {
  public partial class MainActivity : Form {
    List<ParsedExample> trainingData;
    DecisionTree tree;

    public MainActivity() {
      InitializeComponent();
      resultLabel.Text = "";

      trainingData = new List<ParsedExample> {
        new ParsedExample("lluvioso", "calido", "alto", "bajo", "no"),
        new ParsedExample("lluvioso", "calido", "alto", "alto", "no"),
        new ParsedExample("nublado", "calido", "alto", "bajo", "si"),
        new ParsedExample("soleado", "temp media", "alto", "bajo", "si"),
        new ParsedExample("soleado", "frio", "normal", "bajo", "si"),
        new ParsedExample("soleado", "frio", "normal", "alto", "no"),
        new ParsedExample("nublado", "frio", "normal", "alto", "si"),
        new ParsedExample("lluvioso", "temp media", "alto", "bajo", "no"),
        new ParsedExample("lluvioso", "frio", "normal", "bajo", "si"),
        new ParsedExample("nublado", "temp media", "alto", "alto", "si"),
        new ParsedExample("soleado", "temp media", "alto", "alto", "no"),
      };
      tree = new DecisionTree();
      tree.Fit(trainingData);
    }

    private void startBtn_Click(object sender, EventArgs e) {
      string sky = skyPrediction.SelectedItem as string;
      string ambient = ambientPrediction.SelectedItem as string;
      string humidity = humidityPrediction.SelectedItem as string;
      string windspeed = windspeedPrediction.SelectedItem as string;

      // if (sky.Length == 0 || ambient.Length == 0 || humidity.Length == 0 || windspeed.Length == 0)
      //   return;

      ParsedExample example = new ParsedExample(sky, ambient, humidity, windspeed, "test");

      DecisionNode prediction = tree.Predict(example);
      resultLabel.Text = prediction.ToString();
    }
  }
}
