using FilmsCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog
{
    public static class DummyData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Films.Any())
            {
                context.Films.AddRange(
                    new Film
                    {
                        Title = "Долгое Падение",
                        Description = "Четверо незнакомцев встречаются в одном месте.",
                        Director = "Nick Hornby",
                        Year = 2014
                    },
                    new Film
                    {
                        Title = "Невероятные приключения итальянцев в России",
                        Description = "Описание отсутствует",
                        Director = "Eldar Ryazanov",
                        Year = 1974
                    },
                    new Film
                    {
                        Title = "Need For Speed",
                        Description = "A street racer is framed by a rival who is also a wealthy business associate in a murder case. Upon his release, the street racer devises a plan with revenge in mind.",
                        Director = "Scott Waugh",
                        Year = 2014
                    },
                    new Film
                    {
                        Title = "Иван Васильевич меняет профессию",
                        Description = "A volatile, 16th-century tsar is forced to work while his lookalike, a present-day building supervisor, struggles to rule the country when a faulty time machine makes them change places and fates.",
                        Director = "Leonid Gaidai",
                        Year = 1973
                    },
                    new Film
                    {
                        Title = "Брат",
                        Description = "After finishing his military service, young Danila Bagrov (Sergey Bodrov ml.) seeks help from his older brother (Viktor Sukhorukov), a gangster in St. Petersburg, who puts him to work as a hired gun.",
                        Director = "Aleksei Balabanov",
                        Year = 1997
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
