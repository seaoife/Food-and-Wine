using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }

    public class Temperature
    {
        public double number { get; set; }
        public string unit { get; set; }
    }

    public class Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
        public Temperature temperature { get; set; }
    }

    public class Length
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class Step
    {
        public int number { get; set; }
        public string step { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<Equipment> equipment { get; set; }
        public Length length { get; set; }
    }

    public class Instruction
    {
        public string name { get; set; }
        public List<Step> steps { get; set; }// steps is a list of class objects.
    }


}
