using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigginsPractitestApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedGiggins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Giggins (Title, Artist, Description, Image, Price, SoldOut) VALUES
                ('Macaron', 'Baher Khairy', 'Sweet meringue-based rhythms with smooth and sweet injections of soul', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/baher-khairy-97645.jpg', 1000, 0),
                ('Stairs', 'Brentr De Ranter', 'Stairs to the highest peaks of music.', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/brent-de-ranter-426248.jpg', 2000, 0),
                ('Infusion', 'Camille Couvez', 'Introduction of new elements of music into the modern world', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/camille-couvez-424606.jpg', 3000, 0),
                ('Books', 'Cesar-Viteri', 'A book of music, exploring different music genres across the last decade', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/cesar-viteri-426877.jpg', 4000, 0),
                ('White', 'Dan Schiumarini', 'Vulnerability and humility exposed with Raps of Dan Schiumarini', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/dan-schiumarini-427769.jpg', 5000, 0),
                ('Hustin''', 'Frank Cordoba', 'Story of Hip Hop hustle by Frank Cordoba', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/frank-cordoba-425264.jpg', 6000, 0),
                ('Pumping', 'Jakob Owens', 'Get energized and ready to rock with this fresh and bright work of Jakob Owens', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/jakob-owens-393298.jpg', 7000, 0),
                ('Lion', 'Jakob Puff', 'An album of wild and brave sounds explored by Jakob Puff', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552695/giggin/jakob-puff-425634.jpg', 8000, 0),
                ('ampersand', 'Kirstyn Paynter', 'Connect music and words with ampersand and enjoy find out what happens next', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552696/giggin/kirstyn-paynter-424217.jpg', 9000, 0),
                ('Taxi', 'Peter Kasprzyk', 'Take a Taxi ride with Peter to explore different beats of the city', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552696/giggin/peter-kasprzyk-111462.jpg', 9000, 0),
                ('Plaza De La Juderia', 'Quino Al', 'Spanish rhythms from Plaza De La Juderia', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552696/giggin/quino-al-427620.jpg', 9000, 0),
                ('Girl', 'Shine Tang', 'Shine Tang offers a grand exploration of classical music', 'https://res.cloudinary.com/schae/image/upload/f_auto,q_auto/v1519552696/giggin/shine-tang-425878.jpg', 9000, 0);
            ");

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Giggins");
        }
    }
}
