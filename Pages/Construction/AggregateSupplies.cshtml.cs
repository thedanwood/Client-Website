using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RJHWebsite.Models;

namespace RJHWebsite.Pages.Construction
{
    public class AggregateItemModel
    {
        public bool IsMostPopular { get; set; }
        public string AggregateName { get; set; }
        public string Category { get; set; }
        public decimal StartingPrice { get; set; }
        public string QuantityUnit { get; set; }
        public bool? CallForPrices { get; set; }
    }
    public class AggregatesCategory
    {
        public string AggregateCategoryFullName { get; set; }
        public string AggregateCategorySelectorName { get; set; }
    }
    public class AggregatesModel : PageModel
    {
        public string AggregatesSectionSelector { get; set; } //aggregates section
        public List<AggregateItemModel> Aggregates { get; set; }
        public List<AggregatesCategory> AggregateCategories { get; set; }
        public string Type { get; set; }
        public void OnGet(string type)
        {
            string aggregatesJson = System.IO.File.ReadAllText("aggregates-v1.0.json").ToString();
            Aggregates = JsonConvert.DeserializeObject<List<AggregateItemModel>>(aggregatesJson);
            foreach(var aggregate in Aggregates.Where(r => r.AggregateName == "4/10mm Natural Gravel" || r.AggregateName == "10/20mm Natural Gravel" || r.AggregateName == "4/10mm Natural Gravel - Bulk Bag" || r.AggregateName == "10/20mm Natural Gravel - Bulk Bag").ToList())
            {
                aggregate.CallForPrices = true;
            }
            AggregateCategories = Aggregates.GroupBy(r=>r.Category).Select(r => new AggregatesCategory(){AggregateCategoryFullName = r.First().Category, AggregateCategorySelectorName = r.First().Category.Replace(" ","-")}).ToList();
            Type = type;
        }
    }
}
