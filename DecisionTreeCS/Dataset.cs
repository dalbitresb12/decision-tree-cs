using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace DecisionTreeCS {
  class Dataset: IEnumerable<Row> {
    readonly List<string> headers;
    readonly List<Row> rows;
    bool hasConvertedFirstRow = false;

    public Dataset(List<Row> rows = null, List<string> headers = null) {
      if (rows == null) {
        this.rows = new List<Row>();
      } else {
        this.rows = rows;
      }
      if (headers == null) {
        headers = new List<string>();
        for (int i = 0; i < MaxFeatureCount; ++i) {
          string header = $"Field{i + 1}";
          headers.Add(header);
        }
      } else {
        this.headers = headers;
      }
    }

    public List<string> Headers => headers;

    public int Count => rows.Count;

    public int MaxFeatureCount {
      get {
        int count = 0;
        foreach (Row row in rows) {
          if (row.Count > count)
            count = row.Count;
        }
        return count;
      }
    }

    public HashSet<Feature> GetUniqueValues(int index) {
      HashSet<Feature> values = new HashSet<Feature>();
      foreach (Row row in rows) {
        _ = values.Add(row[index]);
      }
      return values;
    }

    public bool ConvertFirstRowToHeader() {
      // If the first row has already been converted, ignore
      if (hasConvertedFirstRow)
        return false;
      // Capture the first row
      Row row = rows[0];
      // Clear the headers list
      headers.Clear();
      // Convert each feature value into a header
      foreach (Feature feature in row)
        headers.Add(feature.ToString());
      // Remove the first element from the rows list
      rows.RemoveAt(0);
      // Prevent future calls to this function from executing
      hasConvertedFirstRow = true;
      return true;
    }

    public void Add(Row item) => rows.Add(item);

    public void AddRange(IEnumerable<Row> collection) => rows.AddRange(collection);

    public void Clear() => rows.Clear();

    public Row this[int index] {
      get => rows[index];
      set => rows.Insert(index, value);
    }

    public IEnumerator<Row> GetEnumerator() => rows.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
