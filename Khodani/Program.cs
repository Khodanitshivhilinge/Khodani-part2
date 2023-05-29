// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace RecipeApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var recipeManager = new RecipeManager();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe to display\\");


                Console.WriteLine("4. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipeManager.AddRecipe();
                        break;
                    case "2":
                        recipeManager.DisplayAllRecipes();
                        break;
                    case "3":
                        recipeManager.DisplayRecipe();

                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }   //List to store all recipes

       
        public List<string> Steps { get; set; } // List  all the steps
        public int TotalCalories { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            TotalCalories = 0;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            TotalCalories += ingredient.Calories;
        }

        public void AddStep(string step)
        {

            Steps.Add(step);
        }
    }
    // Adding variable Calories and foodgroup 

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;         // Name of the ingrediant
            Quantity = quantity;  //Quantity of the ingredient
            Unit = unit;           // Unit of measurement for the ingredient e.g grams
            Calories = calories;   // nummber of calories in the ingrediant
            FoodGroup = foodGroup; // foodgroup that the ingredient belong to

        }
    }

    class RecipeManager
    {
        private List<Recipe> recipes;
        private Recipe currentRecipe;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            Console.Clear();
            Console.WriteLine("Enter recipe details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            currentRecipe = new Recipe(name);

            Console.Write("Number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit: ");
                string unit = Console.ReadLine();


                Console.Write("Calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                var ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);
                currentRecipe.AddIngredient(ingredient);
            }

            Console.Write("Number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)

            {
                Console.Write($"Step {i + 1}: ");
                string step = Console.ReadLine();
                currentRecipe.AddStep(step);
            }

            recipes.Add(currentRecipe);
            Console.WriteLine("Recipe added successfully!");
        }
        //Creating method to display the all recipe

        public void DisplayAllRecipes()
        {
            Console.Clear();
            Console.WriteLine("All Recipes:");
            Console.WriteLine();

            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));

            foreach (var recipe in recipes)

            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine("Select a recipe to display:");
            Console.WriteLine();

            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));

            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            Console.WriteLine();
            Console.Write("Enter the recipe number: ");
            int recipeNumber = int.Parse(Console.ReadLine());

            if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[recipeNumber - 1];
                DisplayRecipeDetails(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Invalid recipe number. Please try again.");
            }
        }
        //Creating the method to display the details of the Recipe
        private void DisplayRecipeDetails(Recipe recipe)
        {
            Console.Clear();
            Console.WriteLine($"Recipe: {recipe.Name}");
            Console.WriteLine();

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            Console.WriteLine();

            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.Steps.Count; 

i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }

            Console.WriteLine();

            Console.WriteLine($"Total Calories: {recipe.TotalCalories}");

            if (recipe.TotalCalories > 300)
            {
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");
            }
        }
    }
}

