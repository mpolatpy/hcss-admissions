using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Applications.Any())
            {
                List<SchoolYear> schoolYears = new List<SchoolYear>
                {
                    new SchoolYear
                    {
                        IsActiveYear = true,
                        SchoolYearName = "21-22",
                        DisplayOnForm = true,
                        FormLabel = "21-22 (Current School Year)"
                    },
                    new SchoolYear
                    {
                        IsActiveYear = false,
                        SchoolYearName = "22-23",
                        DisplayOnForm = true,
                        FormLabel = "22-23 (Upcoming School Year)"
                    },
                };

                List<School> schools = new List<School>
                {
                    new School
                    {
                        SchoolName = "HCSS East",

                    },
                    new School
                    {
                        SchoolName = "HCSS West",

                    }
                };

                Lottery lottery = new Lottery 
                {
                    SchoolYear = schoolYears[0],
                    School = schools[0],
                    Grade = 6
                };

                List<Application> applications = new List<Application>
                {
                    new Application
                    {
                        FirstName = "Michael",
                        LastName = "Jordan",
                        Gender = "Male",
                        StreetAddress = "20 Johnson Road",
                        City = "Chicopee",
                        State = "MA",
                        Zipcode = "01022",
                        CurrentSchool = "HCSS",
                        CurrentGrade = "5",
                        HasSibling = false,
                        DOB = DateTime.Parse("2010-11-14").ToUniversalTime(),
                        PrimaryParentName = "Matt Jordan",
                        PrimaryParentEmail = "matt@test.com",
                        PrimaryParentPhoneNumber = "41355226",
                        PrimaryParentRelationship = "Father",
                        AgreeToTerms = true,
                        HowDidYouHear = "Website",
                        Lottery = lottery,
                        School = schools[0],
                        SchoolYear = schoolYears[0]
                    }
                };

                await context.Applications.AddRangeAsync(applications);
                await context.SaveChangesAsync();
            }

        }
    }
}