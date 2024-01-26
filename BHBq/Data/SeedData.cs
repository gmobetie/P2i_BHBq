using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    // Initialisate the app database from csv files
    public static void Init()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
        .UseSqlite($"Data Source=BHBq.db")
        .Options;

        using var context = new BHBqContext(options);
        // Look for existing content
        if (context.Entreprises.Any() && context.Lots.Any()) 
        {
            return; // DB already filled
        }
        context.Entreprises.AddRange(ClassConverter<Entreprise>("Origin/entreprises.csv"));
        context.Lots.AddRange(ClassConverter<Lot>("Origin/lots.csv"));

        // Commit changes into DB
        context.SaveChanges();
    }

    static List<T> ClassConverter<T>(string absolutePath) where T : class
    {
        List<T> entities;
        var csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";"
        };

        using (TextReader fileReader = File.OpenText(absolutePath))
        {
            var csv = new CsvReader(fileReader, csvConfiguration);
            entities = csv.GetRecords<T>().ToList();
        }

        return entities;
    }
}