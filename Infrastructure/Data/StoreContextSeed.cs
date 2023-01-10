using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try 
            {
                if(!context.ProductBrands.Any()) 
                {
                    var brandsData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                
                foreach (var item in brands) {
                    context.ProductBrands.Add(item);
                }

                await context.SaveChangesAsync();
            }
//End Brands block

//begin types block
                if(!context.ProductTypes.Any()) 
                {
                    var typesData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                
                foreach (var item in types) {
                    context.ProductTypes.Add(item);
                }

                await context.SaveChangesAsync();
            }
            
//end types

//begin Product

                            if(!context.Products.Any()) 
                {
                    var productsData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                
                foreach (var item in products) {
                    context.Products.Add(item);
                }

                await context.SaveChangesAsync();
            }
            
            }
            
            catch (Exception ex) {
                    var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex.Message);
            }
            
            }

        }
    }
