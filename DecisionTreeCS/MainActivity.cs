using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace DecisionTreeCS {
  public partial class MainActivity : Form {
    readonly CsvConfiguration csvConfig;
    readonly List<Row> trainingData;
    string csvFilePath;

    public MainActivity() {
      InitializeComponent();
      csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture) {
        HasHeaderRecord = false
      };
      trainingData = new List<Row>();
      csvFilePath = string.Empty;
    }

    private void fileSelectBtn_Click(object sender, EventArgs e) {
      if (csvFileLoader.ShowDialog() == DialogResult.OK) {
        // Get the path of the specified file
        csvFilePath = csvFileLoader.FileName;
        fileNameLabel.Text = $"Seleccionado: {csvFilePath}";

        // Read the contents of the file into a stream
        Stream fileStream = csvFileLoader.OpenFile();
        using (StreamReader reader = new StreamReader(fileStream))
        using (CsvReader csv = new CsvReader(reader, csvConfig)) {
          // Wrap all this code in a try-catch block to catch parsing errors
          try {
            // Read every line individually
            while (csv.Read()) {
              // Initialize the feature rows
              List<Feature> features = new List<Feature>();

              // Parse the current record
              var record = csv.GetRecord<dynamic>();

              // This will probably be a Dictionary<string, object>, loop over every item
              foreach (var feature in record) {
                // Try casting (this might fail, the try-catch block will prevent the app from dying)
                string featureName = feature.Key as string;
                string featureValue = feature.Value as string;

                Feature parsed = null;
                // Try parsing the value as a number, if successful use that 
                if (decimal.TryParse(featureName, out decimal num))
                  parsed = new Feature(featureName, num);
                else
                  parsed = new Feature(featureName, featureValue);

                // If successful, add it to the feature list
                if (parsed != null)
                  features.Add(parsed);
              }

              trainingData.Add(new Row(features));
            }
          } catch (Exception) {
            // This will catch any type of Exception (for now)
            Console.WriteLine("Invalid CSV file.");
          }
        }
        updateTextBox();
      }
    }

    private void updateTextBox() {
      List<string> lines = new List<string>();
      foreach (Row row in trainingData) {
        IEnumerable<string> values = row.Select(i => {
          if (i.IsNumeric)
            return ((decimal)i.Value).ToString();
          else
            return i.Value as string;
        });
        string str = string.Join(", ", values);
        lines.Add(str);
      }
      fileContentTextBox.Lines = lines.ToArray();
    }
  }
}
