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
                        Name = "21-22",
                        DisplayOnForm = true,
                    },
                    new SchoolYear
                    {
                        IsActiveYear = false,
                        Name = "22-23",
                        DisplayOnForm = true,
                    },
                };

                List<Parent> parents = new List<Parent>
                {
                    new Parent
                    {
                        FirstName = "Tugba",
                        LastName = "Polat",
                        Email = "mpolat@test.com",
                        PhoneNumber = "413555555",
                        Relationship = "Father",
                    },
                    new Parent
                    {
                        FirstName = "Murat",
                        LastName = "Polat",
                        Email = "mpolat@test.com",
                        PhoneNumber = "413555555",
                        Relationship = "Father",
                    },
                    new Parent
                    {
                        FirstName = "Ahmet",
                        LastName = "Polat",
                        Email = "mpolat@test.com",
                        PhoneNumber = "413555555",
                        Relationship = "Father",
                    },
                };

                List<Student> students = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Zeynep",
                        LastName = "Polat",
                        Gender = "Female",
                        StreetAddress = "20 Johnson Road",
                        City = "Chicopee",
                        State = "MA",
                        ZipCode = "01022",
                        CurrentSchool = "HCSS",
                        CurrentGrade = 5,
                        HasSibling = false,
                        DOB = DateTime.Parse("2010-11-14").ToUniversalTime(),
                        Parents = new List<ApplicantParent>
                        {
                            new ApplicantParent
                            {
                                Parent = parents[0],
                                IsPrimaryParent = true,
                            },
                            new ApplicantParent
                            {
                                Parent = parents[1]
                            }
                        }
                    },
                    new Student
                    {
                        FirstName = "Selim",
                        LastName = "Polat",
                        Gender = "Male",
                        StreetAddress = "20 Johnson Road",
                        City = "Chicopee",
                        State = "MA",
                        ZipCode = "01022",
                        CurrentSchool = "HCSS",
                        CurrentGrade = 5,
                        HasSibling = false,
                        DOB = DateTime.Parse("2010-11-14").ToUniversalTime(),
                        Parents = new List<ApplicantParent>
                        {
                            new ApplicantParent
                            {
                                Parent = parents[0],
                                IsPrimaryParent = true,
                            },
                            new ApplicantParent
                            {
                                Parent = parents[1]
                            }
                        }
                    },
                    new Student
                    {
                        FirstName = "Huseyin",
                        LastName = "Polat",
                        Gender = "Male",
                        StreetAddress = "20 Johnson Road",
                        City = "Chicopee",
                        State = "MA",
                        ZipCode = "01022",
                        CurrentSchool = "HCSS",
                        CurrentGrade = 5,
                        HasSibling = false,
                        DOB = DateTime.Parse("2010-11-14").ToUniversalTime(),
                        Parents = new List<ApplicantParent>
                        {
                            new ApplicantParent
                            {
                                Parent = parents[2],
                                IsPrimaryParent = true,
                            },
                        }
                    }
                };

                List<Application> applications = new List<Application>
                {
                    new Application {
                        SchoolYear = schoolYears[0],
                        School = "HCSS East",
                        Grade = 6,
                        AgreeToTerms = true,
                        Notes = "Seeded Data 1",
                        HowDidYouHear = "Facebook",
                        Student = students[0]
                    },
                    new Application {
                        SchoolYear = schoolYears[0],
                        School = "HCSS West",
                        Grade = 7,
                        AgreeToTerms = true,
                        Notes = "Seeded Data 2",
                        HowDidYouHear = "Twitter",
                        Student = students[1]
                    },
                    new Application {
                        SchoolYear = schoolYears[1],
                        School = "Both Schools",
                        Grade = 8,
                        AgreeToTerms = true,
                        Notes = "Seeded Data 3",
                        HowDidYouHear = "Newspaper",
                        Student = students[2]
                    }
                };

                await context.Applications.AddRangeAsync(applications);
                await context.SaveChangesAsync();
            }

        }
    }
}