using CodeChallenge.DbContexts;
using CodeChallenge.Entity;
using CodeChallenge.IServices;
using CodeChallenge.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Services
{
    public class DrawService : IDrawService
    {
        private readonly CodeChallengeDbContext _codeChallengeDbContext;
        public DrawService(CodeChallengeDbContext codeChallengeDbContext)
        {
            _codeChallengeDbContext = codeChallengeDbContext;
        }

        private readonly List<Team> teams = new List<Team>
                                             {
                                                 new Team { Country = "Türkiye", Name = "Adesso İstanbul" },
                                                 new Team { Country = "Türkiye", Name = "Adesso Ankara" },
                                                 new Team { Country = "Türkiye", Name = "Adesso İzmir" },
                                                 new Team { Country = "Türkiye", Name = "Adesso Antalya" },

                                                 new Team { Country = "Almanya", Name = "Adesso Berlin" },
                                                 new Team { Country = "Almanya", Name = "Adesso Frankfurt" },
                                                 new Team { Country = "Almanya", Name = "Adesso Münih" },
                                                 new Team { Country = "Almanya", Name = "Adesso Dortmund" },

                                                 new Team { Country = "Fransa", Name = "Adesso Paris" },
                                                 new Team { Country = "Fransa", Name = "Adesso Marsilya" },
                                                 new Team { Country = "Fransa", Name = "Adesso Nice" },
                                                 new Team { Country = "Fransa", Name = "Adesso Lyon" },

                                                 new Team { Country = "Hollanda", Name = "Adesso Amsterdam" },
                                                 new Team { Country = "Hollanda", Name = "Adesso Rotterdam" },
                                                 new Team { Country = "Hollanda", Name = "Adesso Lahey" },
                                                 new Team { Country = "Hollanda", Name = "Adesso Eindhoven" },

                                                 new Team { Country = "Portekiz", Name = "Adesso Lisbon" },
                                                 new Team { Country = "Portekiz", Name = "Adesso Porto" },
                                                 new Team { Country = "Portekiz", Name = "Adesso Braga" },
                                                 new Team { Country = "Portekiz", Name = "Adesso Coimbra" },

                                                 new Team { Country = "İtalya", Name = "Adesso Roma" },
                                                 new Team { Country = "İtalya", Name = "Adesso Milano" },
                                                 new Team { Country = "İtalya", Name = "Adesso Venedik" },
                                                 new Team { Country = "İtalya", Name = "Adesso Napoli" },

                                                 new Team { Country = "İspanya", Name = "Adesso Sevilla" },
                                                 new Team { Country = "İspanya", Name = "Adesso Madrid" },
                                                 new Team { Country = "İspanya", Name = "Adesso Barselona" },
                                                 new Team { Country = "İspanya", Name = "Adesso Granada" },

                                                 new Team { Country = "Belçika", Name = "Adesso Brüksel" },
                                                 new Team { Country = "Belçika", Name = "Adesso Brugge" },
                                                 new Team { Country = "Belçika", Name = "Adesso Gent" },
                                                 new Team { Country = "Belçika", Name = "Adesso Anvers" },
                                             };



        public async Task<List<Group>> DrawGroups(int groupCount, string drawerName)
        {
            var teamAmount = (groupCount == 4) ? 8 : 4;


            var groups = new List<Group>();
            Group group;
            Team team;

            var count = 0;
            var nextMinLimit = 0;
            var nextMaxLimit = 31;
            var randomGenerator = new Random();
            var number = randomGenerator.Next(nextMinLimit, nextMaxLimit);


            for (char groupChar = 'A'; groupChar < 'A' + groupCount; groupChar++)
            {
                group = new Group()
                {
                    GroupName = groupChar.ToString()
                };
                groups.Add(group);
            }


            for (int i = 0; i < teamAmount; i++)
            {
                while (count < groupCount)
                {
                    team = teams[number];
                    if (!groups[count].Teams.Any(x => x.Country == team.Country))
                    {
                        groups[count].Teams.Add(team);
                        count++;
                        nextMinLimit = 0;
                        number = randomGenerator.Next(nextMinLimit, nextMaxLimit--);
                        teams.RemoveAll(x => x.Name == team.Name);
                    }
                    else
                    {
                        if (number == nextMinLimit)
                        {
                            nextMinLimit++;
                        }
                        number = randomGenerator.Next(nextMinLimit, nextMaxLimit);
                    }
                }
                count = 0;
            }


            var groupList = groups.Adapt<List<Groups>>();

            groupList.ForEach(item =>
            {
                item.RecordUser = drawerName;
                item.RecordDate = DateTime.Now;
            });


            await _codeChallengeDbContext.AddRangeAsync(groupList);
            await _codeChallengeDbContext.SaveChangesAsync();

            return groups;
        }

    }
}





