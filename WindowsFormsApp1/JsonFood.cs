using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MissedIngredient
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalName { get; set; }
        public List<string> meta { get; set; }
        public string extendedName { get; set; }
        public string image { get; set; }
    }

    public class UsedIngredient
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalName { get; set; }
        public List<string> meta { get; set; }
        public string image { get; set; }
    }

    public class Recipe// root generally refers to the origin of something.
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public List<MissedIngredient> missedIngredients { get; set; }
        public List<UsedIngredient> usedIngredients { get; set; }
        public List<MissedIngredient> unusedIngredients { get; set; }
        public int likes { get; set; }
    }


}
