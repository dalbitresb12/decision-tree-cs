using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Row: IEnumerable<Feature> {
    readonly List<Feature> features;

    public Row(List<Feature> features = null) {
      if (features == null)
        this.features = new List<Feature>();
      else
        this.features = features;
    }

    public int Count => features.Count;

    public void Add(Feature item) => features.Add(item);

    public Feature this[int index] {
      get => features[index];
      set => features.Insert(index, value);
    }

    public IEnumerator<Feature> GetEnumerator() => features.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
      GetEnumerator();
  }
}
