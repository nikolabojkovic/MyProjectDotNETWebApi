using MyProjectWebApiDotNET.Models;
using System.Collections.Generic;
namespace MyProjectWebApiDotNET.Domain
{
    public class HeroInMemoryData
    {
        public static List<Hero> heroes = new List<Hero>
        {
            new Hero
            {
                Id = 1,
                Name = "Bart Simpson"
            },
            new Hero
            {
                Id = 2,
                Name = "Lisa Simpson"
            },
            new Hero
            {
                Id = 3,
                Name = "March Simpson"
            },
            new Hero
            {
                Id = 4,
                Name = "Homer Simpson"
            },
            new Hero
            {
                Id = 5,
                Name = "Magi Simpson"
            },
            new Hero
            {
                Id = 6,
                Name = "Grendpa Simpson"
            }
        };
    }
}