using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ProductMatch
    {
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string link { get; set; }
        public string price { get; set; }
        
    }

    public class WineSearch
    {
        public List<string> pairedWines { get; set; }
        public string pairingText { get; set; }
        public List<ProductMatch> productMatches { get; set; }
    }


}
