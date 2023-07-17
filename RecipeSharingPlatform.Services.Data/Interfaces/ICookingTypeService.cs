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
        public Task<IEnumerable<RecipeCookingTypeSelectFormModel>> GetAllCookingTypesAsync();

        public Task<bool> ExistsById(int id);
    }
}