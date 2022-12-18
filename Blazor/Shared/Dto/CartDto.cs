using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Dto
{
    public class CartDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
