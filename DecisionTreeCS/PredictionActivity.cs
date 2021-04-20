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
  partial class PredictionActivity : Form {
    public PredictionActivity(Dataset dataset, Action<object, FormClosingEventArgs> closingHandler = null) {
      InitializeComponent();
      // Set the Closing event handler
      if (closingHandler != null)
        FormClosing += new FormClosingEventHandler(closingHandler);
      //string[] items = dataset.GetUniqueValues(0).Select(item => item.ToString()).ToArray();
      //comboBox1.Items.AddRange(items);
      CreateFieldsFromDataset(fieldsPanel, dataset);
    }

    static void CreateFieldsFromDataset(FlowLayoutPanel panel, Dataset dataset) {
      // Prevent running if dataset is null
      if (dataset == null)
        return;

      // Clear the panel before removing any previous text box
      panel.Controls.Clear();

      // Initialize the List in which we'll save every control to add
      List<Control> controls = new List<Control>();

      int totalFeatures = dataset.MaxFeatureCount;
      // Create a field for each feature
      for (int i = 0; i < totalFeatures; ++i) {
        // Create the Label for this field
        Label label = new Label();
        label.Text = dataset.Headers[i];
        label.Margin = new Padding(7, 7, 3, 0);
        label.AutoSize = true;
        ComboBox comboBox = new ComboBox();
        comboBox.AutoCompleteMode = AutoCompleteMode.Append;
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox.FormattingEnabled = true;
        comboBox.TabIndex = 0;
        HashSet<Feature> features = dataset.GetUniqueValues(i);
        string[] values = features.Select(item => item.ToString()).ToArray();
        comboBox.Items.AddRange(values);
        panel.SetFlowBreak(comboBox, true);
        controls.Add(label);
        controls.Add(comboBox);
      }

      // Display every new control in the UI
      panel.Controls.AddRange(controls.ToArray());
    }
  }
}
