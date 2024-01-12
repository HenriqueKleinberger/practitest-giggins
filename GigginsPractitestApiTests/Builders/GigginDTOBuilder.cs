using GigginsPractitestApi.DTO;

namespace GigginsPractitestApiTests.Builders
{
    internal class GigginDTOBuilder
    {
        private GigginDTO _gigginDTO;
        
        public GigginDTOBuilder()
        {
            _gigginDTO = new GigginDTO();
            _gigginDTO.Title = "Giggin Title";
            _gigginDTO.Description = "Giggin Description";
            _gigginDTO.Price = 10000;
            _gigginDTO.Artist = "Giggin Artist";
            _gigginDTO.Image = "Giggin Image";
            _gigginDTO.SoldOut = false;
        }

        public GigginDTOBuilder WithTitle(string title)
        {
            _gigginDTO.Title = title;
            return this;
        }
        public GigginDTOBuilder WithDescription(string description)
        {
            _gigginDTO.Description = description;
            return this;
        }

        public GigginDTOBuilder WithArtist(string artist)
        {
            _gigginDTO.Artist = artist;
            return this;
        }

        public GigginDTOBuilder WithImage(string image)
        {
            _gigginDTO.Image = image;
            return this;
        }

        public GigginDTOBuilder WithPrice(Decimal price)
        {
            _gigginDTO.Price = price;
            return this;
        }

        public GigginDTOBuilder IsSoldOut(bool soldOut)
        {
            _gigginDTO.SoldOut = soldOut;
            return this;
        }


        public GigginDTO Build()
        {
            return _gigginDTO;
        }
    }
}
