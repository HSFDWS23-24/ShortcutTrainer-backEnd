using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockCourseDatabase : IMockDatabase<Course>
    {
        public MockCourseDatabase(IMockDatabase<Question> questionDatabase)
        {
             var questions = questionDatabase.GetDataAsync().Result.ToList();
             DataStore = new List<Course>
             {
                 new Course
                {
                    Id = 1,
                    Title = "Beispielkurs 1",
                    Language = "en",
                    Description = "Beschreibung des Beispielkurses 1",
                    ImageUrl = "url_zum_bild_1",
                    Subscription = SubscriptionType.Free,
                    Tags = new List<CourseTag>
                    {
                        new CourseTag
                        {
                            Tag = "Tag1"
                        },
                        new CourseTag
                        {
                            Tag = "Tag2"
                        }
                    },
                     UserCourses = new List<UserCourse>
                     {
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "1", Name = "UserName1", Email = "user1@example.com"
                             },
                             Favorite = true
                         }
                     }
                },
                new Course
                {
                    Id = 2,
                    Title = "Beispielkurs 2",
                    Language = "de",
                    Description = "Beschreibung des Beispielkurses 2",
                    ImageUrl = "url_zum_bild_2",
                    Subscription = SubscriptionType.Other,
                    Tags = new List<CourseTag>
                    {
                        new CourseTag
                        {
                            Tag = "Tag1"
                        },
                        new CourseTag
                        {
                            Tag = "Tag4"
                        }
                    },
                     UserCourses = new List<UserCourse>
                     {
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "2", Name = "UserName2", Email = "user2@example.com"
                             },
                             Favorite = false
                         },
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "1", Name = "UserName1", Email = "user1@example.com"
                             },
                             Favorite = true
                         }
                     }
                },
                new Course
                {
                    Id = 3,
                    Title = "Beispielkurs 3",
                    Language = "de",
                    Description = "Beschreibung des Beispielkurses 3",
                    ImageUrl = "url_zum_bild_3",
                    Subscription = SubscriptionType.Other,
                    Tags = new List<CourseTag>
                    {
                        new CourseTag
                        {
                            Tag = "Tag3"
                        },
                        new CourseTag
                        {
                            Tag = "Tag5"
                        }
                    },
                     UserCourses = new List<UserCourse>
                     {
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "3", Name = "UserName3", Email = "user3@example.com"
                             },
                             Favorite = true
                         },
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "1", Name = "UserName1", Email = "user1@example.com"
                             },
                             Favorite = true
                         }
                     }
                },
                new Course
                {
                    Id = 4,
                    Title = "Beispielkurs 4",
                    Language = "fr",
                    Description = "Beschreibung des Beispielkurses 4",
                    ImageUrl = "url_zum_bild_4",
                    Subscription = SubscriptionType.Free,
                    Tags = new List<CourseTag>
                    {
                        new CourseTag
                        {
                            Tag = "Tag2"
                        }, 
                        new CourseTag
                        {
                            Tag = "Tag3"
                        }
                    },
                     UserCourses = new List<UserCourse> 
                     {
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "4", Name = "UserName4", Email = "user4@example.com"
                             },
                             Favorite = false
                         },
                         new UserCourse
                         {
                             User = new User
                             {
                                 Id = "3", Name = "UserName3", Email = "user3@example.com"
                             },
                             Favorite = true
                         }
                     }
                }
             };
        }

        public List<Course> DataStore { get; }

        public async Task<IEnumerable<Course>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<Course> data)
        {
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }
    }
}
