using RecipeSharingPlatform.Web.ViewModels.CookingType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    public interface ICookingTypeService
    {
         Task<IEnumerable<RecipeCookingTypeSelectFormModel>> GetAllCookingTypesAsync();

         Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCookingTypeNamesAsync();
    }
}