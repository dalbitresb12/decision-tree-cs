﻿using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace DecisionTreeCS {
  public partial class MainActivity : Form {
    DecisionTree decisionTree;
    Dataset trainingData;
    string csvFilePath;

    public MainActivity() {
      InitializeComponent();
      decisionTree = null;
      trainingData = null;
      csvFilePath = string.Empty;
    }

    private void fileSelectBtn_Click(object sender, EventArgs e) {
      if (csvFileLoader.ShowDialog() == DialogResult.OK) {
        // Force disable the CheckBox
        useHeaderCheckbox.Enabled = false;
        useHeaderCheckbox.Checked = false;

        // Clear any previous training data
        trainingData = new Dataset();

        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) {
          HasHeaderRecord = false
        };

        // Wrap all this code in a try-catch block to catch parsing errors
        try {
          // Read the contents of the file into a stream
          using (Stream fileStream = csvFileLoader.OpenFile())
          using (StreamReader reader = new StreamReader(fileStream))
          using (CsvReader csv = new CsvReader(reader, config)) {
            int maxFeatureCount = 0;
            // Read every line individually
            while (csv.Read()) {
              // Parse the current record
              var record = csv.GetRecord<dynamic>();
              Row featureRow = Row.ParseFromCsv(record);
              if (featureRow != null) {
                trainingData.Add(featureRow);
                if (featureRow.Count > maxFeatureCount)
                  maxFeatureCount = featureRow.Count;
              }
            }
            // Add default headers
            for (int i = 0; i < maxFeatureCount; ++i) {
              string header = $"Field{i + 1}";
              trainingData.Headers.Add(header);
            }
          }

          // Get the path of the specified file
          csvFilePath = csvFileLoader.SafeFileName;
          fileNameLabel.Text = $"Seleccionado: {csvFilePath}";

          // Display the fields in the UI
          createFieldsFromDataset(fieldsPanel, trainingData);

          // Reset the CheckBox state to enabled
          useHeaderCheckbox.Enabled = true;
        } catch (Exception) {
          // This will catch any type of Exception (for now)
          // Clear any fields that were added
          fieldsPanel.Controls.Clear();
          // Clear any changes made to trainingData
          trainingData.Clear();
          // Inform the user parsing has failed
          string title = "Failed to parse file";
          string message = "An invalid CSV file was provided.";
          _ = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void startTrainingBtn_Click(object sender, EventArgs e) {
      decisionTree = new DecisionTree();
      decisionTree.Fit(trainingData);
      List<Feature> features = new List<Feature> {
        new Feature("nublado"),
        new Feature("calido"),
        new Feature("normal"),
        new Feature("bajo"),
      };
      DecisionNode node = decisionTree.Predict(new Row(features));
      Console.WriteLine(node.ToString());
    }

    private void useHeaderCheckbox_CheckedChanged(object sender, EventArgs e) {
      CheckBox checkBox = sender as CheckBox;
      if (checkBox.Checked && trainingData != null) {
        // Convert the first row to a header
        if (trainingData.ConvertFirstRowToHeader()) {
          // Update the UI
          createFieldsFromDataset(fieldsPanel, trainingData);        
        }
      }
    }

    private static void createFieldsFromDataset(FlowLayoutPanel panel, Dataset dataset) {
      // Prevent running if dataset is null
      if (dataset == null)
        return;

      // Clear the panel before removing any previous text box
      panel.Controls.Clear();

      // Initialize the List in which we'll save every control to add
      List<Control> controls = new List<Control>();

      // Create every text box for each header
      for (int i = 0; i < dataset.Headers.Count; ++i) {
        // Save a copy of the current index and the label text
        int staticIndex = i;
        string header = dataset.Headers[i];
        // Create the TextBox and assign its value
        TextBox textBox = new TextBox();
        textBox.Text = header;
        // Create the event handler
        textBox.TextChanged += new EventHandler((object sender, EventArgs e) => {
          TextBox senderTextBox = sender as TextBox;
          dataset.Headers[staticIndex] = senderTextBox.Text;
        });
        // Add it to the controls List
        controls.Add(textBox);
      }

      // Set the last item of the Controls to break the flow
      panel.SetFlowBreak(controls[controls.Count - 1], true);

      foreach (Row row in dataset) {
        // Initialize an empty List of Labels
        List<Label> labels = new List<Label>();
        // Iterate over each feature
        foreach (Feature feature in row) {
          // Create the Label and assign its value
          Label label = new Label();
          label.Text = feature.ToString();
          // Add to the local Label list
          labels.Add(label);
        }
        // Set the last item of the Controls to break the flow
        panel.SetFlowBreak(labels[labels.Count - 1], true);
        // Add every label in this iteration to the List
        controls.AddRange(labels);
      }

      // Display every new control in the UI
      panel.Controls.AddRange(controls.ToArray());
    }
  }
}
