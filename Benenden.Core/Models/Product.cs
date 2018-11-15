using System.ComponentModel.DataAnnotations;

namespace Benenden.Core.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public float? Cost { get; set; }

        public Member Member { get; set; }
    }
}
