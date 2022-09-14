using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal price;

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0");
                }
                price = value;
            }
        }
        public int Quantity { get; set; }
        public int CartCount { get; set; }
        public override string ToString() => $"{Id} \t\t {Name} \t\t {Price:C} \t\t {Quantity}";


    }
}
