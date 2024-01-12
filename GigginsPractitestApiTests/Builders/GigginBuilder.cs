using GigginsPractitestApi.DTO;
using GigginsPractitestApi.Models;

namespace GigginsPractitestApiTests.Builders
{
    internal class GigginBuilder
    {
        private Giggin _giggin;
        
        public GigginBuilder()
        {
            _giggin = new Giggin();
            _giggin.Title = "Giggin Title";
            _giggin.Description = "Giggin Description";
            _giggin.Price = 10000;
            _giggin.Artist = "Giggin Artist";
            _giggin.Image = "Giggin Image";
            _giggin.SoldOut = false;
        }

        public GigginBuilder WithTitle(string title)
        {
            _giggin.Title = title;
            return this;
        }

        public GigginBuilder WithPrice(Decimal price)
        {
            _giggin.Price = price;
            return this;
        }

        public GigginBuilder WithDescription(string description)
        {
            _giggin.Description = description;
            return this;
        }

        public GigginBuilder WithArtist(string artist)
        {
            _giggin.Artist = artist;
            return this;
        }

        public GigginBuilder WithImage(string image)
        {
            _giggin.Image = image;
            return this;
        }

        public GigginBuilder IsSoldOut(bool soldOut)
        {
            _giggin.SoldOut = soldOut;
            return this;
        }

        public Giggin Build()
        {
            return _giggin;
        }
    }
}
