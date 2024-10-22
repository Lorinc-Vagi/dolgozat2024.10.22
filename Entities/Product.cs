namespace Dolgozat2024._10._22.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public int CategoryId { get; set;} //IdegenKulcs
    }
}
