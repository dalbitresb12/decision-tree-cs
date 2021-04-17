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
        csvFilePath = csvFileLoader.SafeFileName;
        fileNameLabel.Text = $"Seleccionado: {csvFilePath}";

        // Read the contents of the file into a stream
        Stream fileStream = csvFileLoader.OpenFile();
        using (StreamReader reader = new StreamReader(fileStream))
        using (CsvReader csv = new CsvReader(reader, csvConfig)) {
          // Wrap all this code in a try-catch block to catch parsing errors
          try {
            // Read every line individually
            while (csv.Read()) {
              // Parse the current record
              var record = csv.GetRecord<dynamic>();
              Row featureRow = Row.ParseRowFromCsv(record);
              if (featureRow != null)
                trainingData.Add(featureRow);
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
          if (i.IsNumeric) {
            return ((decimal)i.Value).ToString();
          } else {
            return i.Value as string;
          }
        });
        string str = string.Join(", ", values);
        lines.Add(str);
      }
      fileContentTextBox.Lines = lines.ToArray();
      if (trainingData.Count > 0) {
        dataTypesTextBox.Text = string.Join(", ", trainingData[0].Select(i => {
          if (i.IsNumeric)
            return "numeric";
          else
            return "categorical";
        }));
      }
    }
  }
}
