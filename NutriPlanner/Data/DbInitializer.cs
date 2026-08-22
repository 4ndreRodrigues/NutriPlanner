using Microsoft.EntityFrameworkCore;
using NutriPlanner.Models;

namespace NutriPlanner.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext _context)
        {
            _context.Database.EnsureCreated();
            
            if (!_context.Foods.Any())
            {
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
                var frango = new Food { Name = "Frango", SearchTerm = "Chicken breast", Category = "Proteínas" };
                var peru = new Food { Name = "Peru", SearchTerm = "Turkey breast", Category = "Proteínas" };
                var vaca = new Food { Name = "Vaca", SearchTerm = "Beef steak", Category = "Proteínas" };
                var porco = new Food { Name = "Porco", SearchTerm = "Pork loin", Category = "Proteínas" };
                var borrego = new Food { Name = "Borrego", SearchTerm = "Lamb", Category = "Proteínas" };
                var salmao = new Food { Name = "Salmão", SearchTerm = "Salmon", Category = "Proteínas" };
                var atum = new Food { Name = "Atum", SearchTerm = "Tuna", Category = "Proteínas" };
                var bacalhau = new Food { Name = "Bacalhau", SearchTerm = "Cod", Category = "Proteínas" };
                var sardinha = new Food { Name = "Sardinha", SearchTerm = "Sardine", Category = "Proteínas" };
                var cavala = new Food { Name = "Cavala", SearchTerm = "Mackerel", Category = "Proteínas" };
                var pescada = new Food { Name = "Pescada", SearchTerm = "Hake", Category = "Proteínas" };
                var ovos = new Food { Name = "Ovos", SearchTerm = "Egg", Category = "Proteínas" };
                var camarao = new Food { Name = "Camarão", SearchTerm = "Shrimp", Category = "Proteínas" };
                var mexilhao = new Food { Name = "Mexilhão", SearchTerm = "Mussel", Category = "Proteínas" };
                var polvo = new Food { Name = "Polvo", SearchTerm = "Octopus", Category = "Proteínas" };
                var tofu = new Food { Name = "Tofu", SearchTerm = "Tofu", Category = "Proteínas" };
                var tempeh = new Food { Name = "Tempeh", SearchTerm = "Tempeh", Category = "Proteínas" };
                var seitan = new Food { Name = "Seitan", SearchTerm = "Seitan", Category = "Proteínas" };

                // Hidratos
                var arrozBranco = new Food { Name = "Arroz Branco", SearchTerm = "White rice", Category = "Hidratos" };
                var arrozIntegral = new Food { Name = "Arroz Integral", SearchTerm = "Brown rice", Category = "Hidratos" };
                var batata = new Food { Name = "Batata", SearchTerm = "Potato", Category = "Hidratos" };
                var batataDoce = new Food { Name = "Batata-doce", SearchTerm = "Sweet potato", Category = "Hidratos" };
                var massa = new Food { Name = "Massa", SearchTerm = "Pasta", Category = "Hidratos" };
                var aveia = new Food { Name = "Aveia", SearchTerm = "Oats", Category = "Hidratos" };
                var paoIntegral = new Food { Name = "Pão Integral", SearchTerm = "Whole wheat bread", Category = "Hidratos" };
                var quinoa = new Food { Name = "Quinoa", SearchTerm = "Quinoa", Category = "Hidratos" };
                var cuscuz = new Food { Name = "Cuscuz", SearchTerm = "Couscous", Category = "Hidratos" };
                var milho = new Food { Name = "Milho", SearchTerm = "Corn", Category = "Hidratos" };

                // Gorduras
                var abacate = new Food { Name = "Abacate", SearchTerm = "Avocado", Category = "Gorduras" };
                var azeite = new Food { Name = "Azeite", SearchTerm = "Olive oil", Category = "Gorduras" };
                var azeitonas = new Food { Name = "Azeitonas", SearchTerm = "Olives", Category = "Gorduras" };
                var amendoas = new Food { Name = "Amêndoas", SearchTerm = "Almonds", Category = "Gorduras" };
                var nozes = new Food { Name = "Nozes", SearchTerm = "Walnuts", Category = "Gorduras" };
                var queijoCurado = new Food { Name = "Queijo Curado", SearchTerm = "Cheddar cheese", Category = "Gorduras" };

                // Vegetais
                var brocolos = new Food { Name = "Brócolos", SearchTerm = "Broccoli", Category = "Vegetais" };
                var espinafres = new Food { Name = "Espinafres", SearchTerm = "Spinach", Category = "Vegetais" };
                var tomate = new Food { Name = "Tomate", SearchTerm = "Tomato", Category = "Vegetais" };
                var cenoura = new Food { Name = "Cenoura", SearchTerm = "Carrot", Category = "Vegetais" };
                var cebola = new Food { Name = "Cebola", SearchTerm = "Onion", Category = "Vegetais" };
                var alho = new Food { Name = "Alho", SearchTerm = "Garlic", Category = "Vegetais" };
                var pepino = new Food { Name = "Pepino", SearchTerm = "Cucumber", Category = "Vegetais" };
                var couveFlor = new Food { Name = "Couve-flor", SearchTerm = "Cauliflower", Category = "Vegetais" };

                // Frutas
                var banana = new Food { Name = "Banana", SearchTerm = "Banana", Category = "Frutas" };
                var manga = new Food { Name = "Manga", SearchTerm = "Mango", Category = "Frutas" };
                var uvas = new Food { Name = "Uvas", SearchTerm = "Grapes", Category = "Frutas" };
                var tamaras = new Food { Name = "Tâmaras", SearchTerm = "Dates", Category = "Frutas" };

                // Outros
                var mel = new Food { Name = "Mel", SearchTerm = "Honey", Category = "Outros" };

                _context.Foods.AddRange(
                    frango, peru, vaca, porco, borrego,
                    salmao, atum, bacalhau, sardinha, cavala, pescada,
                    ovos, camarao, mexilhao, polvo, tofu, tempeh, seitan,
                    arrozBranco, arrozIntegral, batata, batataDoce, massa, aveia, paoIntegral, quinoa, cuscuz, milho,
                    abacate, azeite, azeitonas, amendoas, nozes, queijoCurado,
                    brocolos, espinafres, tomate, cenoura, cebola, alho, pepino, couveFlor,
                    banana, manga, uvas, tamaras,
                    mel
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
                    new DietFood { DietId = carnivora.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = cavala.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = ovos.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = camarao.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = queijoCurado.Id },

                    // Anti-inflamatória
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = salmao.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cavala.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = azeite.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = abacate.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = tomate.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = alho.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cebola.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = nozes.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = uvas.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = banana.Id },

                    // Mediterrânica
                    new DietFood { DietId = mediterranea.Id, FoodId = frango.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = peru.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = salmao.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = atum.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = bacalhau.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = ovos.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = camarao.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = azeite.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = abacate.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = nozes.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = massa.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = tomate.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = cebola.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = alho.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = pepino.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = banana.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = manga.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = uvas.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = queijoCurado.Id },

                    // Cetogénica
                    new DietFood { DietId = cetogenica.Id, FoodId = frango.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = peru.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = vaca.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = porco.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = salmao.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = ovos.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = azeite.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = abacate.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = nozes.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = queijoCurado.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = pepino.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = alho.Id },

                    // Vegetariana
                    new DietFood { DietId = vegetariana.Id, FoodId = tofu.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = tempeh.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = seitan.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = ovos.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = queijoCurado.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = arrozBranco.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = batata.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = massa.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = aveia.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cuscuz.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = azeite.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = abacate.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = nozes.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = tomate.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cebola.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = alho.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = pepino.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = banana.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = manga.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = uvas.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = mel.Id },

                    // Vegana
                    new DietFood { DietId = vegana.Id, FoodId = tofu.Id },
                    new DietFood { DietId = vegana.Id, FoodId = tempeh.Id },
                    new DietFood { DietId = vegana.Id, FoodId = seitan.Id },
                    new DietFood { DietId = vegana.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = vegana.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = vegana.Id, FoodId = aveia.Id },
                    new DietFood { DietId = vegana.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = vegana.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cuscuz.Id },
                    new DietFood { DietId = vegana.Id, FoodId = azeite.Id },
                    new DietFood { DietId = vegana.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = vegana.Id, FoodId = abacate.Id },
                    new DietFood { DietId = vegana.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = vegana.Id, FoodId = nozes.Id },
                    new DietFood { DietId = vegana.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = vegana.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = vegana.Id, FoodId = tomate.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cebola.Id },
                    new DietFood { DietId = vegana.Id, FoodId = alho.Id },
                    new DietFood { DietId = vegana.Id, FoodId = pepino.Id },
                    new DietFood { DietId = vegana.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = vegana.Id, FoodId = banana.Id },
                    new DietFood { DietId = vegana.Id, FoodId = manga.Id },
                    new DietFood { DietId = vegana.Id, FoodId = uvas.Id },
                    new DietFood { DietId = vegana.Id, FoodId = tamaras.Id },

                    // Paleo
                    new DietFood { DietId = paleo.Id, FoodId = frango.Id },
                    new DietFood { DietId = paleo.Id, FoodId = peru.Id },
                    new DietFood { DietId = paleo.Id, FoodId = vaca.Id },
                    new DietFood { DietId = paleo.Id, FoodId = porco.Id },
                    new DietFood { DietId = paleo.Id, FoodId = borrego.Id },
                    new DietFood { DietId = paleo.Id, FoodId = salmao.Id },
                    new DietFood { DietId = paleo.Id, FoodId = atum.Id },
                    new DietFood { DietId = paleo.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = paleo.Id, FoodId = ovos.Id },
                    new DietFood { DietId = paleo.Id, FoodId = camarao.Id },
                    new DietFood { DietId = paleo.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = paleo.Id, FoodId = azeite.Id },
                    new DietFood { DietId = paleo.Id, FoodId = abacate.Id },
                    new DietFood { DietId = paleo.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = paleo.Id, FoodId = nozes.Id },
                    new DietFood { DietId = paleo.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = paleo.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = paleo.Id, FoodId = tomate.Id },
                    new DietFood { DietId = paleo.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = paleo.Id, FoodId = banana.Id },
                    new DietFood { DietId = paleo.Id, FoodId = manga.Id },
                    new DietFood { DietId = paleo.Id, FoodId = uvas.Id },
                    new DietFood { DietId = paleo.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = paleo.Id, FoodId = mel.Id },

                    // Low Carb
                    new DietFood { DietId = lowCarb.Id, FoodId = frango.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = peru.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = vaca.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = porco.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = salmao.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = atum.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = bacalhau.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = ovos.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = camarao.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = azeite.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = abacate.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = nozes.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = queijoCurado.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = tomate.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = pepino.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = couveFlor.Id },

                    // Low Fat
                    new DietFood { DietId = lowFat.Id, FoodId = frango.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = peru.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = bacalhau.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = pescada.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = tofu.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = arrozBranco.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = batata.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = massa.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = aveia.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = tomate.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = cebola.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = banana.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = manga.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = uvas.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = mel.Id }
                 );

                await _context.SaveChangesAsync();
            }

            if (!_context.HealthConditions.Any())
            {
                var diabetes = new HealthCondition
                {
                    Name = "Diabetes",
                    Description = "Condição que afeta a forma como o organismo regula a glicose no sangue. A alimentação deve privilegiar alimentos ricos em fibra, controlar a quantidade de hidratos de carbono e limitar açúcares adicionados."
                };

                var hipertensao = new HealthCondition
                {
                    Name = "Hipertensão",
                    Description = "Pressão arterial elevada. A alimentação deve privilegiar frutas, vegetais, cereais integrais e alimentos pouco processados, com especial atenção à redução do consumo de sódio."
                };

                var hiperuricemia = new HealthCondition
                {
                    Name = "Hiperuricemia",
                    Description = "Níveis elevados de ácido úrico no sangue. É importante limitar alimentos muito ricos em purinas e bebidas ou alimentos ricos em frutose, de acordo com orientação profissional."
                };

                var anemia = new HealthCondition
                {
                    Name = "Anemia",
                    Description = "Condição caracterizada por uma quantidade insuficiente de glóbulos vermelhos ou hemoglobina. A alimentação depende da causa da anemia; no caso de deficiência de ferro, alimentos ricos em ferro podem ser importantes."
                };

                var colesterolAlto = new HealthCondition
                {
                    Name = "Colesterol Alto",
                    Description = "Níveis elevados de colesterol no sangue, especialmente LDL. A alimentação deve privilegiar fibras, cereais integrais, leguminosas, frutos secos e gorduras insaturadas, limitando gorduras saturadas."
                };

                _context.HealthConditions.AddRange(
                    diabetes,
                    hipertensao,
                    hiperuricemia,
                    anemia,
                    colesterolAlto
                );

                await _context.SaveChangesAsync();


                // Buscar os alimentos que já existem na BD
                var foods = await _context.Foods
                    .ToDictionaryAsync(f => f.Name!);


                var healthConditionFoods = new List<HealthConditionFood>
                {
                    // =========================
                    // DIABETES
                    // =========================

                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Arroz Branco"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Batata"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Massa"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Pão Integral"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Milho"].Id, Severity = FoodSeverity.Moderate },

                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Banana"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Manga"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Uvas"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Tâmaras"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Mel"].Id, Severity = FoodSeverity.Moderate },

                    // =========================
                    // Hiperuricemia
                    // =========================

                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Vaca"].Id, Severity = FoodSeverity.Avoid },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Porco"].Id, Severity = FoodSeverity.Avoid },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Borrego"].Id, Severity = FoodSeverity.Avoid },

                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Sardinha"].Id, Severity = FoodSeverity.Avoid },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Cavala"].Id, Severity = FoodSeverity.Avoid },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Camarão"].Id, Severity = FoodSeverity.Avoid },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Mexilhão"].Id, Severity = FoodSeverity.Avoid },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Polvo"].Id, Severity = FoodSeverity.Avoid },

                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Frango"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Peru"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Atum"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Bacalhau"].Id, Severity = FoodSeverity.Moderate },

                    // =========================
                    // HIPERTENSÃO
                    // =========================

                    new() { HealthConditionId = hipertensao.Id, FoodId = foods["Bacalhau"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = hipertensao.Id, FoodId = foods["Azeitonas"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = hipertensao.Id, FoodId = foods["Queijo Curado"].Id, Severity = FoodSeverity.Moderate },


                    // =========================
                    // Colesterol Alto
                    // =========================

                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Vaca"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Porco"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Borrego"].Id, Severity = FoodSeverity.Moderate },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Queijo Curado"].Id, Severity = FoodSeverity.Moderate }

                    // =========================
                    // Anemia
                    // =========================

                    // Não há restrições nesta condição.
                    // Os alimentos ricos em ferro serão tratados futuramente
                    // como benefícios/recomendações, caso essa funcionalidade seja adicionada.
                };

                _context.HealthConditionFoods.AddRange(healthConditionFoods);

                await _context.SaveChangesAsync();
            }
        }
    }
}
