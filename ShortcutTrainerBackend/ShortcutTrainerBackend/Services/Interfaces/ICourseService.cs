using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<DtoCourse>> GetCoursesAsync(string? userId, string language, string? system, string? searchString, int? limit);

        Task<bool> UpdateFavouriteStatusAsync(int courseId, string userId, bool favouriteStatus);
    }
}
