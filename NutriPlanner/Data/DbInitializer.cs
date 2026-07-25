using Microsoft.EntityFrameworkCore;
using NutriPlanner.Models;

namespace NutriPlanner.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext _context)
        {
            _context.Database.EnsureCreated();
            
            if (_context.Foods.Any())
            {
                return; // DB has been seeded
            }

            // Dietas
            var carnivora = new Diet { Name = "Carnívora", Description = "Dieta rica em proteínas animais" };
            var antiInflamatoria = new Diet { Name = "Anti-inflamatória", Description = "Dieta com alimentos anti-inflamatórios" };
            var mediterranea = new Diet { Name = "Mediterrânea", Description = "Dieta baseada na alimentação tradicional dos países do Mediterrâneo" };
            var cetogenica = new Diet { Name = "Cetogénica", Description = "Dieta com baixo teor de carboidratos e alto teor de gorduras" };
            var vegetariana = new Diet { Name = "Vegetariana", Description = "Dieta baseada em alimentos de origem vegetal" };
            var vegana = new Diet { Name = "Vegana", Description = "Dieta que exclui todos os produtos de origem animal" };
            var paleo = new Diet { Name = "Paleo", Description = "Dieta baseada em alimentos consumidos pelos caçadores-recoletores" };
            var lowCarb = new Diet { Name = "Low Carb", Description = "Dieta com baixo teor de carboidratos" };
            var lowFat = new Diet { Name = "Low Fat", Description = "Dieta com baixo teor de gorduras" };

            _context.Diets.AddRange(
                carnivora,
                antiInflamatoria,
                mediterranea,
                cetogenica,
                vegetariana,
                vegana,
                paleo,
                lowCarb,
                lowFat);

            // Proteínas
            var frango = new Food { Name = "Frango", SearchTerm = "Chicken breast", Category = "Proteína" };
            var peru = new Food { Name = "Peru", SearchTerm = "Turkey breast", Category = "Proteína" };
            var vaca = new Food { Name = "Vaca", SearchTerm = "Beef steak", Category = "Proteína" };
            var porco = new Food { Name = "Porco", SearchTerm = "Pork loin", Category = "Proteína" };
            var borrego = new Food { Name = "Borrego", SearchTerm = "Lamb", Category = "Proteína" };
            var salmao = new Food { Name = "Salmão", SearchTerm = "Salmon", Category = "Proteína" };
            var atum = new Food { Name = "Atum", SearchTerm = "Tuna", Category = "Proteína" };
            var bacalhau = new Food { Name = "Bacalhau", SearchTerm = "Cod", Category = "Proteína" };
            var sardinha = new Food { Name = "Sardinha", SearchTerm = "Sardine", Category = "Proteína" };
            var cavala = new Food { Name = "Cavala", SearchTerm = "Mackerel", Category = "Proteína" };
            var pescada = new Food { Name = "Pescada", SearchTerm = "Hake", Category = "Proteína" };
            var ovos = new Food { Name = "Ovos", SearchTerm = "Egg", Category = "Proteína" };
            var camarao = new Food { Name = "Camarão", SearchTerm = "Shrimp", Category = "Proteína" };
            var mexilhao = new Food { Name = "Mexilhão", SearchTerm = "Mussel", Category = "Proteína" };
            var polvo = new Food { Name = "Polvo", SearchTerm = "Octopus", Category = "Proteína" };
            var tofu = new Food { Name = "Tofu", SearchTerm = "Tofu", Category = "Proteína" };
            var tempeh = new Food { Name = "Tempeh", SearchTerm = "Tempeh", Category = "Proteína" };
            var seitan = new Food { Name = "Seitan", SearchTerm = "Seitan", Category = "Proteína" };

            // Hidratos
            var arrozBranco = new Food { Name = "Arroz Branco", SearchTerm = "White rice", Category = "Hidrato" };
            var arrozIntegral = new Food { Name = "Arroz Integral", SearchTerm = "Brown rice", Category = "Hidrato" };
            var batata = new Food { Name = "Batata", SearchTerm = "Potato", Category = "Hidrato" };
            var batataDoce = new Food { Name = "Batata-doce", SearchTerm = "Sweet potato", Category = "Hidrato" };
            var massa = new Food { Name = "Massa", SearchTerm = "Pasta", Category = "Hidrato" };
            var aveia = new Food { Name = "Aveia", SearchTerm = "Oats", Category = "Hidrato" };
            var paoIntegral = new Food { Name = "Pão Integral", SearchTerm = "Whole wheat bread", Category = "Hidrato" };
            var quinoa = new Food { Name = "Quinoa", SearchTerm = "Quinoa", Category = "Hidrato" };
            var cuscuz = new Food { Name = "Cuscuz", SearchTerm = "Couscous", Category = "Hidrato" };
            var milho = new Food { Name = "Milho", SearchTerm = "Corn", Category = "Hidrato" };

            // Gorduras
            var abacate = new Food { Name = "Abacate", SearchTerm = "Avocado", Category = "Gordura" };
            var azeite = new Food { Name = "Azeite", SearchTerm = "Olive oil", Category = "Gordura" };
            var azeitonas = new Food { Name = "Azeitonas", SearchTerm = "Olives", Category = "Gordura" };
            var amendoas = new Food { Name = "Amêndoas", SearchTerm = "Almonds", Category = "Gordura" };
            var nozes = new Food { Name = "Nozes", SearchTerm = "Walnuts", Category = "Gordura" };
            var queijoCurado = new Food { Name = "Queijo Curado", SearchTerm = "Cheddar cheese", Category = "Gordura" };

            // Vegetais
            var brocolos = new Food { Name = "Brócolos", SearchTerm = "Broccoli", Category = "Vegetal" };
            var espinafres = new Food { Name = "Espinafres", SearchTerm = "Spinach", Category = "Vegetal" };
            var tomate = new Food { Name = "Tomate", SearchTerm = "Tomato", Category = "Vegetal" };
            var cenoura = new Food { Name = "Cenoura", SearchTerm = "Carrot", Category = "Vegetal" };
            var cebola = new Food { Name = "Cebola", SearchTerm = "Onion", Category = "Vegetal" };
            var alho = new Food { Name = "Alho", SearchTerm = "Garlic", Category = "Vegetal" };
            var pepino = new Food { Name = "Pepino", SearchTerm = "Cucumber", Category = "Vegetal" };
            var couveFlor = new Food { Name = "Couve-flor", SearchTerm = "Cauliflower", Category = "Vegetal" };

            _context.Foods.AddRange(
                frango, peru, vaca, porco, borrego,
                salmao, atum, bacalhau, sardinha, cavala, pescada,
                ovos, camarao, mexilhao, polvo, tofu, tempeh, seitan,
                arrozBranco, arrozIntegral, batata, batataDoce, massa, aveia, paoIntegral, quinoa, cuscuz, milho,
                abacate, azeite, azeitonas, amendoas, nozes, queijoCurado,
                brocolos, espinafres, tomate, cenoura, cebola, alho, pepino, couveFlor
            );

            await _context.SaveChangesAsync();

            _context.DietFoods.AddRange(

                // Carnívora
                new DietFood { DietId = carnivora.Id, FoodId = frango.Id },
                new DietFood { DietId = carnivora.Id, FoodId = peru.Id },
                new DietFood { DietId = carnivora.Id, FoodId = vaca.Id },
                new DietFood { DietId = carnivora.Id, FoodId = porco.Id },
                new DietFood { DietId = carnivora.Id, FoodId = borrego.Id },
                new DietFood { DietId = carnivora.Id, FoodId = salmao.Id },
                new DietFood { DietId = carnivora.Id, FoodId = atum.Id },
                new DietFood { DietId = carnivora.Id, FoodId = bacalhau.Id },
                new DietFood { DietId = carnivora.Id, FoodId = ovos.Id },

                // Anti-inflamatória
                new DietFood { DietId = antiInflamatoria.Id, FoodId = salmao.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = azeite.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = abacate.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = brocolos.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = espinafres.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = tomate.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = alho.Id },
                new DietFood { DietId = antiInflamatoria.Id, FoodId = nozes.Id },

                // Mediterrânica
                new DietFood { DietId = mediterranea.Id, FoodId = salmao.Id },
                new DietFood { DietId = mediterranea.Id, FoodId = azeite.Id },
                new DietFood { DietId = mediterranea.Id, FoodId = arrozIntegral.Id },
                new DietFood { DietId = mediterranea.Id, FoodId = tomate.Id },
                new DietFood { DietId = mediterranea.Id, FoodId = cebola.Id },
                new DietFood { DietId = mediterranea.Id, FoodId = brocolos.Id },

                // Cetogénica
                new DietFood { DietId = cetogenica.Id, FoodId = frango.Id },
                new DietFood { DietId = cetogenica.Id, FoodId = vaca.Id },
                new DietFood { DietId = cetogenica.Id, FoodId = ovos.Id },
                new DietFood { DietId = cetogenica.Id, FoodId = azeite.Id },
                new DietFood { DietId = cetogenica.Id, FoodId = abacate.Id },
                new DietFood { DietId = cetogenica.Id, FoodId = queijoCurado.Id },

                // Vegetariana
                new DietFood { DietId = vegetariana.Id, FoodId = tofu.Id },
                new DietFood { DietId = vegetariana.Id, FoodId = ovos.Id },
                new DietFood { DietId = vegetariana.Id, FoodId = arrozIntegral.Id },
                new DietFood { DietId = vegetariana.Id, FoodId = quinoa.Id },
                new DietFood { DietId = vegetariana.Id, FoodId = brocolos.Id },

                // Vegana
                new DietFood { DietId = vegana.Id, FoodId = tofu.Id },
                new DietFood { DietId = vegana.Id, FoodId = quinoa.Id },
                new DietFood { DietId = vegana.Id, FoodId = brocolos.Id },
                new DietFood { DietId = vegana.Id, FoodId = espinafres.Id },
                new DietFood { DietId = vegana.Id, FoodId = amendoas.Id },

                // Paleo
                new DietFood { DietId = paleo.Id, FoodId = frango.Id },
                new DietFood { DietId = paleo.Id, FoodId = salmao.Id },
                new DietFood { DietId = paleo.Id, FoodId = ovos.Id },
                new DietFood { DietId = paleo.Id, FoodId = batataDoce.Id },
                new DietFood { DietId = paleo.Id, FoodId = brocolos.Id },

                // Low Carb
                new DietFood { DietId = lowCarb.Id, FoodId = frango.Id },
                new DietFood { DietId = lowCarb.Id, FoodId = salmao.Id },
                new DietFood { DietId = lowCarb.Id, FoodId = ovos.Id },
                new DietFood { DietId = lowCarb.Id, FoodId = abacate.Id },
                new DietFood { DietId = lowCarb.Id, FoodId = espinafres.Id },

                // Low Fat
                new DietFood { DietId = lowFat.Id, FoodId = frango.Id },
                new DietFood { DietId = lowFat.Id, FoodId = peru.Id },
                new DietFood { DietId = lowFat.Id, FoodId = arrozBranco.Id },
                new DietFood { DietId = lowFat.Id, FoodId = brocolos.Id },
                new DietFood { DietId = lowFat.Id, FoodId = tomate.Id }
             );

            await _context.SaveChangesAsync();
        }
    }
}
