using DevExpress.Entity.Model.Metadata;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockUserCourseDatabase : IMockDatabase<UserCourse>
    {
        public List<UserCourse> DataStore { get; } = new List<UserCourse>
        {
             //new()
             //{
             //    UserId = default(Guid).ToString(),
             //    CourseId = 1,
             //    //User = new User() { Id = default(Guid).ToString() },
             //    //Course = new Course() { Id = 1 },
             //    Favorite = true
             //},
             //new()
             //{
             //    UserId = default(Guid).ToString(),
             //    CourseId = 2,
             //    //User = new User() { Id = default(Guid).ToString() },
             //    //Course = new Course() { Id = 2 },
             //    Favorite = false
             //}
        };

        public async Task<IEnumerable<UserCourse>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<UserCourse> data)
        {
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }
    }
}