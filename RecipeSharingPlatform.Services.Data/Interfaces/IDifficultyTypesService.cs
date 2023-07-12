namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    using RecipeSharingPlatform.Web.ViewModels.DifficultyType;

    public interface IDifficultyTypesService
    {
        public Task<IEnumerable<RecipeDifficultyTypeSelectFormModel>> GetAllDifficultyTypesAsync();
    }
}
