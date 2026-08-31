using NutriPlanner.Dtos;
using NutriPlanner.Models;
using System.Text.Json;

namespace NutriPlanner.Services
{
    public class NutritionApiService : INutritionApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NutritionApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKey"]!;
        }

        public async Task<NutritionInfoDto?> GetNutritionInfoAsync(FoodDto foodDto)
        {
            var response = await _httpClient.GetAsync(
                $"foods/search?query={Uri.EscapeDataString(foodDto.SearchTerm)}&api_key={_apiKey}&pageSize=1&dataType=Foundation");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var foodsArray = doc.RootElement.GetProperty("foods");
            if (foodsArray.GetArrayLength() == 0) return null;

            var firstFood = foodsArray[0];
            var fdcId = firstFood.GetProperty("fdcId").GetInt32().ToString();
            var nutrients = firstFood.GetProperty("foodNutrients");

            var nutrition = new NutritionInfo
            {
                FoodId = foodDto.Id,
                ExternalFoodId = fdcId,
                LastUpdated = DateTime.UtcNow
            };

            foreach (var n in nutrients.EnumerateArray())
            {
                var name = n.GetProperty("nutrientName").GetString();
                if (!n.TryGetProperty("value", out var valueProp)) continue;
                var value = n.GetProperty("value").GetDouble();

                switch (name)
                {
                    case "Energy (Atwater General Factors)": nutrition.Calories = (int)value; break;
                    case "Protein": nutrition.Protein = value; break;
                    case "Carbohydrate, by difference": nutrition.Carbs = value; break;
                    case "Total lipid (fat)": nutrition.Fat = value; break;
                }
            }

            return new NutritionInfoDto
            {
                FoodId = nutrition.FoodId,
                ExternalFoodId = fdcId,
                LastUpdated = nutrition.LastUpdated,
                Calories = nutrition.Calories,
                Protein = nutrition.Protein,
                Carbs = nutrition.Carbs,
                Fat = nutrition.Fat
            };
        }
    }
}
