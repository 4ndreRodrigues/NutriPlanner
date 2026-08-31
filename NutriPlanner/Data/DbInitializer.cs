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
                var carnivora = new Diet { Name = "Carnívora", Description = "Dieta rica em proteínas animais." };
                var antiInflamatoria = new Diet { Name = "Anti-inflamatória", Description = "Dieta com alimentos anti-inflamatórios." };
                var mediterranea = new Diet { Name = "Mediterrânea", Description = "Dieta baseada na alimentação tradicional dos países do Mediterrâneo." };
                var cetogenica = new Diet { Name = "Cetogénica", Description = "Dieta com baixo teor de carboidratos e alto teor de gorduras." };
                var vegetariana = new Diet { Name = "Vegetariana", Description = "Dieta baseada em alimentos de origem vegetal." };
                var vegana = new Diet { Name = "Vegana", Description = "Dieta que exclui todos os produtos de origem animal." };
                var paleo = new Diet { Name = "Paleo", Description = "Dieta baseada em alimentos consumidos pelos caçadores-recoletores." };
                var lowCarb = new Diet { Name = "Low Carb", Description = "Dieta com baixo teor de carboidratos." };
                var lowFat = new Diet { Name = "Low Fat", Description = "Dieta com baixo teor de gorduras." };

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
                var pato = new Food { Name = "Pato", SearchTerm = "Duck", Category = "Proteínas" };
                var vaca = new Food { Name = "Vaca", SearchTerm = "Beef steak", Category = "Proteínas" };
                var porco = new Food { Name = "Porco", SearchTerm = "Pork loin", Category = "Proteínas" };
                var borrego = new Food { Name = "Borrego", SearchTerm = "Lamb", Category = "Proteínas" };
                var salmao = new Food { Name = "Salmão", SearchTerm = "Salmon", Category = "Proteínas" };
                var atum = new Food { Name = "Atum", SearchTerm = "Tuna", Category = "Proteínas" };
                var bacalhau = new Food { Name = "Bacalhau", SearchTerm = "Cod", Category = "Proteínas" };
                var sardinha = new Food { Name = "Sardinha", SearchTerm = "Sardine", Category = "Proteínas" };
                var cavala = new Food { Name = "Cavala", SearchTerm = "Mackerel", Category = "Proteínas" };
                var pescada = new Food { Name = "Pescada", SearchTerm = "Hake", Category = "Proteínas" };
                var polvo = new Food { Name = "Polvo", SearchTerm = "Octopus", Category = "Proteínas" };
                var camarao = new Food { Name = "Camarão", SearchTerm = "Shrimp", Category = "Proteínas" };
                var mexilhao = new Food { Name = "Mexilhão", SearchTerm = "Mussel", Category = "Proteínas" };
                var ovos = new Food { Name = "Ovos", SearchTerm = "Egg", Category = "Proteínas" };
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
                var paoBranco = new Food { Name = "Pão Branco", SearchTerm = "White bread", Category = "Hidratos" };
                var paoIntegral = new Food { Name = "Pão Integral", SearchTerm = "Whole wheat bread", Category = "Hidratos" };
                var broa = new Food { Name = "Broa de Milho", SearchTerm = "Corn bread", Category = "Hidratos" };
                var quinoa = new Food { Name = "Quinoa", SearchTerm = "Quinoa", Category = "Hidratos" };
                var cuscuz = new Food { Name = "Cuscuz", SearchTerm = "Couscous", Category = "Hidratos" };
                var milho = new Food { Name = "Milho", SearchTerm = "Corn", Category = "Hidratos" };
                var graoBico = new Food { Name = "Grão-de-bico", SearchTerm = "Chickpeas", Category = "Hidratos" };
                var feijao = new Food { Name = "Feijão", SearchTerm = "Red beans", Category = "Hidratos" };

                // Gorduras
                var azeite = new Food { Name = "Azeite", SearchTerm = "Olive oil", Category = "Gorduras" };
                var manteiga = new Food { Name = "Manteiga", SearchTerm = "Butter", Category = "Gorduras" };
                var abacate = new Food { Name = "Abacate", SearchTerm = "Avocado", Category = "Gorduras" };
                var azeitonas = new Food { Name = "Azeitonas", SearchTerm = "Olives", Category = "Gorduras" };
                var amendoas = new Food { Name = "Amêndoas", SearchTerm = "Almonds", Category = "Gorduras" };
                var nozes = new Food { Name = "Nozes", SearchTerm = "Walnuts", Category = "Gorduras" };
                var queijoCurado = new Food { Name = "Queijo Curado", SearchTerm = "Cheddar cheese", Category = "Gorduras" };

                // Vegetais
                var couveGalega = new Food { Name = "Couve Galega", SearchTerm = "Collard greens", Category = "Vegetais" };
                var brocolos = new Food { Name = "Brócolos", SearchTerm = "Broccoli", Category = "Vegetais" };
                var espinafres = new Food { Name = "Espinafres", SearchTerm = "Spinach", Category = "Vegetais" };
                var tomate = new Food { Name = "Tomate", SearchTerm = "Tomato", Category = "Vegetais" };
                var cenoura = new Food { Name = "Cenoura", SearchTerm = "Carrot", Category = "Vegetais" };
                var cebola = new Food { Name = "Cebola", SearchTerm = "Onion", Category = "Vegetais" };
                var alho = new Food { Name = "Alho", SearchTerm = "Garlic", Category = "Vegetais" };
                var pepino = new Food { Name = "Pepino", SearchTerm = "Cucumber", Category = "Vegetais" };
                var couveFlor = new Food { Name = "Couve-flor", SearchTerm = "Cauliflower", Category = "Vegetais" };

                // Frutas
                var maca = new Food { Name = "Maçã", SearchTerm = "Apple", Category = "Frutas" };
                var pera = new Food { Name = "Pêra", SearchTerm = "Pear", Category = "Frutas" };
                var laranja = new Food { Name = "Laranja", SearchTerm = "Orange", Category = "Frutas" };
                var banana = new Food { Name = "Banana", SearchTerm = "Banana", Category = "Frutas" };
                var manga = new Food { Name = "Manga", SearchTerm = "Mango", Category = "Frutas" };
                var uvas = new Food { Name = "Uvas", SearchTerm = "Grapes", Category = "Frutas" };
                var tamaras = new Food { Name = "Tâmaras", SearchTerm = "Dates", Category = "Frutas" };

                // Outros
                var mel = new Food { Name = "Mel", SearchTerm = "Honey", Category = "Outros" };
                var cafe = new Food { Name = "Café", SearchTerm = "Coffee", Category = "Outros" };

                _context.Foods.AddRange(
                    frango, peru, pato, vaca, porco, borrego,
                    salmao, atum, bacalhau, sardinha, cavala, pescada, polvo, camarao, mexilhao,
                    ovos, tofu, tempeh, seitan,
                    arrozBranco, arrozIntegral, batata, batataDoce, massa, aveia, paoBranco, paoIntegral, broa, quinoa, cuscuz, milho, graoBico, feijao,
                    azeite, manteiga, abacate, azeitonas, amendoas, nozes, queijoCurado,
                    couveGalega, brocolos, espinafres, tomate, cenoura, cebola, alho, pepino, couveFlor,
                    maca, pera, laranja, banana, manga, uvas, tamaras,
                    mel, cafe
                );

                await _context.SaveChangesAsync();

                _context.DietFoods.AddRange(

                    // Carnívora
                    new DietFood { DietId = carnivora.Id, FoodId = frango.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = peru.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = pato.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = vaca.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = porco.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = borrego.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = salmao.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = atum.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = bacalhau.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = cavala.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = pescada.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = polvo.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = camarao.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = mexilhao.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = ovos.Id },
                    new DietFood { DietId = carnivora.Id, FoodId = queijoCurado.Id },

                    // Anti-inflamatória
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = frango.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = peru.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = salmao.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cavala.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = atum.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = ovos.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = azeite.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = abacate.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = nozes.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = aveia.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = graoBico.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = feijao.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = tomate.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = alho.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cebola.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = pepino.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = maca.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = pera.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = laranja.Id },
                    new DietFood { DietId = antiInflamatoria.Id, FoodId = cafe.Id },

                    // Mediterrânica
                    new DietFood { DietId = mediterranea.Id, FoodId = frango.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = peru.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = salmao.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = atum.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = bacalhau.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = cavala.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = pescada.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = polvo.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = camarao.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = mexilhao.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = ovos.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = azeite.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = abacate.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = nozes.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = arrozBranco.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = batata.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = massa.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = aveia.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = paoBranco.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = broa.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = cuscuz.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = milho.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = graoBico.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = feijao.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = tomate.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = cebola.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = alho.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = pepino.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = maca.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = pera.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = laranja.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = uvas.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = queijoCurado.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = mel.Id },
                    new DietFood { DietId = mediterranea.Id, FoodId = cafe.Id },

                    // Cetogénica
                    new DietFood { DietId = cetogenica.Id, FoodId = frango.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = peru.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = pato.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = vaca.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = porco.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = borrego.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = salmao.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = atum.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = cavala.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = camarao.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = mexilhao.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = ovos.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = azeite.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = manteiga.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = abacate.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = nozes.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = queijoCurado.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = tomate.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = pepino.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = cetogenica.Id, FoodId = cafe.Id },

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
                    new DietFood { DietId = vegetariana.Id, FoodId = paoBranco.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = broa.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cuscuz.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = milho.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = graoBico.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = feijao.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = azeite.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = manteiga.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = abacate.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = nozes.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = tomate.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cebola.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = alho.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = pepino.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = maca.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = pera.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = laranja.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = banana.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = manga.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = uvas.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = mel.Id },
                    new DietFood { DietId = vegetariana.Id, FoodId = cafe.Id },

                    // Vegana
                    new DietFood { DietId = vegana.Id, FoodId = tofu.Id },
                    new DietFood { DietId = vegana.Id, FoodId = tempeh.Id },
                    new DietFood { DietId = vegana.Id, FoodId = seitan.Id },
                    new DietFood { DietId = vegana.Id, FoodId = arrozBranco.Id },
                    new DietFood { DietId = vegana.Id, FoodId = arrozIntegral.Id },
                    new DietFood { DietId = vegana.Id, FoodId = batata.Id },
                    new DietFood { DietId = vegana.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = vegana.Id, FoodId = massa.Id },
                    new DietFood { DietId = vegana.Id, FoodId = aveia.Id },
                    new DietFood { DietId = vegana.Id, FoodId = paoBranco.Id },
                    new DietFood { DietId = vegana.Id, FoodId = paoIntegral.Id },
                    new DietFood { DietId = vegana.Id, FoodId = broa.Id },
                    new DietFood { DietId = vegana.Id, FoodId = quinoa.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cuscuz.Id },
                    new DietFood { DietId = vegana.Id, FoodId = milho.Id },
                    new DietFood { DietId = vegana.Id, FoodId = graoBico.Id },
                    new DietFood { DietId = vegana.Id, FoodId = feijao.Id },
                    new DietFood { DietId = vegana.Id, FoodId = azeite.Id },
                    new DietFood { DietId = vegana.Id, FoodId = abacate.Id },
                    new DietFood { DietId = vegana.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = vegana.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = vegana.Id, FoodId = nozes.Id },
                    new DietFood { DietId = vegana.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = vegana.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = vegana.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = vegana.Id, FoodId = tomate.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cebola.Id },
                    new DietFood { DietId = vegana.Id, FoodId = alho.Id },
                    new DietFood { DietId = vegana.Id, FoodId = pepino.Id },
                    new DietFood { DietId = vegana.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = vegana.Id, FoodId = maca.Id },
                    new DietFood { DietId = vegana.Id, FoodId = pera.Id },
                    new DietFood { DietId = vegana.Id, FoodId = laranja.Id },
                    new DietFood { DietId = vegana.Id, FoodId = banana.Id },
                    new DietFood { DietId = vegana.Id, FoodId = manga.Id },
                    new DietFood { DietId = vegana.Id, FoodId = uvas.Id },
                    new DietFood { DietId = vegana.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = vegana.Id, FoodId = cafe.Id },


                    // Paleo
                    new DietFood { DietId = paleo.Id, FoodId = frango.Id },
                    new DietFood { DietId = paleo.Id, FoodId = peru.Id },
                    new DietFood { DietId = paleo.Id, FoodId = pato.Id },
                    new DietFood { DietId = paleo.Id, FoodId = vaca.Id },
                    new DietFood { DietId = paleo.Id, FoodId = porco.Id },
                    new DietFood { DietId = paleo.Id, FoodId = borrego.Id },
                    new DietFood { DietId = paleo.Id, FoodId = salmao.Id },
                    new DietFood { DietId = paleo.Id, FoodId = atum.Id },
                    new DietFood { DietId = paleo.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = paleo.Id, FoodId = cavala.Id },
                    new DietFood { DietId = paleo.Id, FoodId = pescada.Id },
                    new DietFood { DietId = paleo.Id, FoodId = polvo.Id },
                    new DietFood { DietId = paleo.Id, FoodId = camarao.Id },
                    new DietFood { DietId = paleo.Id, FoodId = mexilhao.Id },
                    new DietFood { DietId = paleo.Id, FoodId = ovos.Id },
                    new DietFood { DietId = paleo.Id, FoodId = batataDoce.Id },
                    new DietFood { DietId = paleo.Id, FoodId = azeite.Id },
                    new DietFood { DietId = paleo.Id, FoodId = abacate.Id },
                    new DietFood { DietId = paleo.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = paleo.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = paleo.Id, FoodId = nozes.Id },
                    new DietFood { DietId = paleo.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = paleo.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = paleo.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = paleo.Id, FoodId = tomate.Id },
                    new DietFood { DietId = paleo.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = paleo.Id, FoodId = cebola.Id },
                    new DietFood { DietId = paleo.Id, FoodId = alho.Id },
                    new DietFood { DietId = paleo.Id, FoodId = pepino.Id },
                    new DietFood { DietId = paleo.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = paleo.Id, FoodId = maca.Id },
                    new DietFood { DietId = paleo.Id, FoodId = pera.Id },
                    new DietFood { DietId = paleo.Id, FoodId = laranja.Id },
                    new DietFood { DietId = paleo.Id, FoodId = banana.Id },
                    new DietFood { DietId = paleo.Id, FoodId = manga.Id },
                    new DietFood { DietId = paleo.Id, FoodId = uvas.Id },
                    new DietFood { DietId = paleo.Id, FoodId = tamaras.Id },
                    new DietFood { DietId = paleo.Id, FoodId = mel.Id },
                    new DietFood { DietId = paleo.Id, FoodId = cafe.Id },

                    // Low Carb
                    new DietFood { DietId = lowCarb.Id, FoodId = frango.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = peru.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = pato.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = vaca.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = porco.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = borrego.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = salmao.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = atum.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = bacalhau.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = sardinha.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = cavala.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = pescada.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = polvo.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = camarao.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = mexilhao.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = ovos.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = tofu.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = tempeh.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = azeite.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = manteiga.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = abacate.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = azeitonas.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = amendoas.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = nozes.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = queijoCurado.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = tomate.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = cebola.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = alho.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = pepino.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = lowCarb.Id, FoodId = cafe.Id },

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
                    new DietFood { DietId = lowFat.Id, FoodId = cuscuz.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = milho.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = graoBico.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = feijao.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = couveGalega.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = brocolos.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = espinafres.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = tomate.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = cenoura.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = cebola.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = alho.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = pepino.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = couveFlor.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = maca.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = pera.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = laranja.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = banana.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = manga.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = uvas.Id },
                    new DietFood { DietId = lowFat.Id, FoodId = cafe.Id }
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

                var doencaCeliaca = new HealthCondition
                {
                    Name = "Doença Celíaca",
                    Description = "Reação imunológica ao glúten (proteína encontrada no trigo, cevada, centeio e derivados), que danifica o revestimento do intestino delgado. A dieta deve ser estritamente isenta de glúten."
                };

                _context.HealthConditions.AddRange(
                    diabetes,
                    hipertensao,
                    hiperuricemia,
                    anemia,
                    colesterolAlto,
                    doencaCeliaca
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

                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Arroz Branco"].Id, Severity = FoodSeverity.Moderate, Reason = "Elevado índice glicémico, pode provocar picos rápidos de glicose no sangue." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Batata"].Id, Severity = FoodSeverity.Moderate, Reason = "Rica em hidratos de carbono de rápida absorção; deve ser consumida com moderação." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Massa"].Id, Severity = FoodSeverity.Moderate, Reason = "Fonte significativa de hidratos de carbono refinados que afetam a glicemia." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Pão Branco"].Id, Severity = FoodSeverity.Moderate, Reason = "Farinha refinada que é absorvida rapidamente, aumentando o açúcar no sangue." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Pão Integral"].Id, Severity = FoodSeverity.Moderate, Reason = "Ainda que tenha fibra, contém hidratos de carbono que devem ser contabilizados." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Broa de Milho"].Id, Severity = FoodSeverity.Moderate, Reason = "Contém hidratos de carbono do milho, exigindo controlo das порções." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Cuscuz"].Id, Severity = FoodSeverity.Moderate, Reason = "Derivado de cereal refinado que impacta os níveis de glicemia." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Milho"].Id, Severity = FoodSeverity.Moderate, Reason = "Cereal com teor considerável de amido e hidratos de carbono." },

                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Banana"].Id, Severity = FoodSeverity.Moderate, Reason = "Fruta com maior concentração de açúcares naturais e hidratos de carbono." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Manga"].Id, Severity = FoodSeverity.Moderate, Reason = "Fruta doce rica em açúcares livres, requer moderação na porção." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Uvas"].Id, Severity = FoodSeverity.Moderate, Reason = "Elevado teor de açúcar natural (frutose), podendo elevar a glicemia rapidamente." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Tâmaras"].Id, Severity = FoodSeverity.Moderate, Reason = "Fruto desidratado com altíssima concentração de açúcar por porção." },
                    new() { HealthConditionId = diabetes.Id, FoodId = foods["Mel"].Id, Severity = FoodSeverity.Moderate, Reason = "Açúcar simples de absorção imediata, causa picos acentuados de glicose." },

                    // =========================
                    // Hiperuricemia
                    // =========================

                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Vaca"].Id, Severity = FoodSeverity.Avoid, Reason = "Rica em purinas, cuja degradação aumenta os níveis de ácido úrico." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Porco"].Id, Severity = FoodSeverity.Avoid, Reason = "Carne rica em purinas que agrava o quadro de hiperuricemia." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Borrego"].Id, Severity = FoodSeverity.Avoid, Reason = "Teor elevado de purinas prejudiciais para o ácido úrico." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Pato"].Id, Severity = FoodSeverity.Avoid, Reason = "Carne de aves gorda e rica em purinas." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Sardinha"].Id, Severity = FoodSeverity.Avoid, Reason = "Peixe azul com concentração muito elevada de purinas." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Cavala"].Id, Severity = FoodSeverity.Avoid, Reason = "Peixe gordo rico em purinas que favorece crises de ácido úrico." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Camarão"].Id, Severity = FoodSeverity.Avoid, Reason = "Marisco com alto teor de purinas." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Mexilhão"].Id, Severity = FoodSeverity.Avoid, Reason = "Molusco altamente desaconselhado devido ao excesso de purinas." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Polvo"].Id, Severity = FoodSeverity.Avoid, Reason = "Marisco e cefalópode com forte impacto nos níveis de ácido úrico." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Frango"].Id, Severity = FoodSeverity.Moderate, Reason = "Ave com menor teor de purinas que a carne vermelha, mas deve ser moderada." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Peru"].Id, Severity = FoodSeverity.Moderate, Reason = "Carne branca com teor moderado de purinas." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Atum"].Id, Severity = FoodSeverity.Moderate, Reason = "Peixe com teor moderado de purinas, tolerável em quantidades controladas." },
                    new() { HealthConditionId = hiperuricemia.Id, FoodId = foods["Bacalhau"].Id, Severity = FoodSeverity.Moderate, Reason = "Pode conter teor moderado dependendo do processamento e salinização." },

                    // =========================
                    // HIPERTENSÃO
                    // =========================

                    new() { HealthConditionId = hipertensao.Id, FoodId = foods["Bacalhau"].Id, Severity = FoodSeverity.Moderate, Reason = "Tradicionalmente dessecado com sal; o teor de sódio exige cuidado." },
                    new() { HealthConditionId = hipertensao.Id, FoodId = foods["Azeitonas"].Id, Severity = FoodSeverity.Moderate, Reason = "Normalmente conservadas em salmoura, elevando o teor de sódio." },
                    new() { HealthConditionId = hipertensao.Id, FoodId = hipertensao.Id == doencaCeliaca.Id ? 0 : foods["Queijo Curado"].Id, Severity = FoodSeverity.Moderate, Reason = "Produto lácteo curado com teores elevados de sal e gorduras saturadas." },
                    new() { HealthConditionId = hipertensao.Id, FoodId = foods["Manteiga"].Id, Severity = FoodSeverity.Moderate, Reason = "Gordura saturada que deve ser consumida de forma restrita para proteger o sistema cardiovascular." },


                    // =========================
                    // Colesterol Alto
                    // =========================

                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Vaca"].Id, Severity = FoodSeverity.Moderate, Reason = "Contém gorduras saturadas que podem elevar o colesterol LDL." },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Porco"].Id, Severity = FoodSeverity.Moderate, Reason = "Presença de gordura animal saturada a moderar." },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Borrego"].Id, Severity = FoodSeverity.Moderate, Reason = "Teor significativo de gorduras saturadas." },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Manteiga"].Id, Severity = FoodSeverity.Avoid, Reason = "Riquíssima em gorduras saturadas, impactando diretamente o colesterol LDL." },
                    new() { HealthConditionId = colesterolAlto.Id, FoodId = foods["Queijo Curado"].Id, Severity = FoodSeverity.Moderate, Reason = "Lácteo gordo com elevado teor de gordura saturada." },

                    // =========================
                    // DOENÇA CELÍACA (Restrição de Glúten)
                    // =========================

                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Massa"].Id, Severity = FoodSeverity.Avoid, Reason = "Geralmente fabricada com trigo, contendo glúten tóxico para celíacos." },
                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Pão Branco"].Id, Severity = FoodSeverity.Avoid, Reason = "Feito com farinha de trigo, fonte direta de glúten." },
                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Pão Integral"].Id, Severity = FoodSeverity.Avoid, Reason = "Contém farinhas com glúten (trigo, centeio ou cevada)." },
                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Broa de Milho"].Id, Severity = FoodSeverity.Avoid, Reason = "Frequentemente misturada com farinha de trigo na panificação tradicional." },
                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Cuscuz"].Id, Severity = FoodSeverity.Avoid, Reason = "Derivado direto do trigo." },
                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Seitan"].Id, Severity = FoodSeverity.Avoid, Reason = "Composto inteiramente por glúten de trigo." },
                    new() { HealthConditionId = doencaCeliaca.Id, FoodId = foods["Aveia"].Id, Severity = FoodSeverity.Moderate, Reason = "Embora naturalmente isenta de glúten, sofre frequentemente de contaminação cruzada." }

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
