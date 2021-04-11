using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  enum ExampleProperty {
    Sky, Ambient, Humidity, WindSpeed, IsGame
  }

  class ParsedExample {
    public string sky {
      get; set;
    }
    public string ambient {
      get; set;
    }
    public string humidity {
      get; set;
    }
    public string windspeed {
      get; set;
    }
    public string isGame {
      get; set;
    }

    public ParsedExample(string sky, string ambient, string humidity, string windspeed, string isGame) {
      this.sky = sky;
      this.ambient = ambient;
      this.humidity = humidity;
      this.windspeed = windspeed;
      this.isGame = isGame;
    }

    public string GetProperty(ExampleProperty property) {
      switch (property) {
        case ExampleProperty.Sky: return sky;
        case ExampleProperty.Ambient: return ambient;
        case ExampleProperty.Humidity: return humidity;
        case ExampleProperty.WindSpeed: return windspeed;
        case ExampleProperty.IsGame: return isGame;
        default: throw new Exception("Invalid property requested from the example.");
      }
    }
    public int GetFeaturesCount() => 4;
  }
}
