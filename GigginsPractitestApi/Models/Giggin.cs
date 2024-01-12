namespace GigginsPractitestApi.Models
{
    public class Giggin
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }

        public String Artist { get; set; }

        public String Image { get; set; }

        public Boolean SoldOut { get; set; }
    }
}
