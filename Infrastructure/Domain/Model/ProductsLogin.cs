namespace NeilMacabulos.Midterm_.Infrastructure.Domain.Models
{
    public class ProductsLogin
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Type { get; set; } //Consumable, NonConsumable
        public string? Key { get; set; }
        public string? Value { get; set; }
    }

}