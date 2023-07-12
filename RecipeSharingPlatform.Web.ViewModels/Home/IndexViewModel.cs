using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string AuthorName { get; set; } = null!;

        public string ImageURL { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
