namespace RecipeSharingPlatform.Common
{
    public class EntityValidationConstants
    {
       
            public static class Category
            {
                public const int CategoryNameMaxLength = 150;

                public const int CategoryNameMinLength = 3;
            }

            public static class Recipe
            {
                public const int RecipeNameMaxLength = 100;

                public const int RecipeNameMinLength = 3;

                public const int DescriptionMaxLength = 5000;

                public const int DescriptionMinLength = 10;

                public const int MaxTimeForCooking = 24;

                public const int MinTimeForCooking = 1;

                public const int MaxTimeForPreparing = 60;

                public const int MinTimeForPreparing = 1;

                public const int MaxCountOfPortions = 10;

                public const int MinCountOfPortions = 1;

                public const int MaxImageUrlLength = 2048;

                public const int MinImageUrlLength = 5;

            }

            public static class Ingredient
            {
                public const int NameMaxLength = 100;

                public const int NameMinLength = 3;

                public const int MaxNeededQuantity = 99999;

                public const int MinNeededQuantity = 1;

                public const int MaxLengthOfTypeMeasurement = 50;

                public const int MinLengthOfTypeMeasurement = 1;
            }


            public static class Comment
            {
                public const int MaxTextLength = 5000;

                public const int MinTextLength = 2;

                public const int MaxUsernameLength = 100;

                public const int MinUsernameLength = 3;
            }

            public static class CookingType
            {
                public const int MaxTextLength = 50;

                public const int MinTextLength = 5;
            }

            public static class DifficultyType
            {
                public const int MaxTextLength = 50;

                public const int MinTextLength = 5;
            }
        }
    }
