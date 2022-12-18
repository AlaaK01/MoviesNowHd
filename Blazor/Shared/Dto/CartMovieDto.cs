using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Dto
{
    public class CartMovieDto
    {
        public string Id { get; set; }
        public string MovieId { get; set; }
        public string CartId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public double Rate { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
        public List<string> Actors { get; set; } = new List<string>();
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
