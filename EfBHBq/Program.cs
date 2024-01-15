using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration;

    List<Entreprise> entreprises = ReadCsvFile("Origin/entreprises.csv");

    // Utilisez la liste 'entreprises' comme nécessaire.
    foreach (var entreprise in entreprises)
    {
        // Faites quelque chose avec chaque entreprise, par exemple, imprimez les propriétés.
        Console.WriteLine($"{entreprise.Id},{entreprise.NomEntreprise}, {entreprise.Siret}, {entreprise.Statut}, {entreprise.Activite}, {entreprise.Siege}, {entreprise.APE}, {entreprise.Description}");
    }

    static List<Entreprise> ReadCsvFile(string absolutePath)
    {
        List<Entreprise> entreprises;
        var csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";"
        };

        using (TextReader fileReader = File.OpenText(absolutePath))
        {
            var csv = new CsvReader(fileReader, csvConfiguration);
            // Vous pouvez décommenter la ligne suivante si votre fichier CSV a un en-tête.

            // CsvHelper va mapper automatiquement les colonnes aux propriétés de la classe Entreprise.
            entreprises = csv.GetRecords<Entreprise>().ToList();
        }

        return entreprises;
    }
