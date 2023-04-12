using csharp_biblioteca;
using System.Collections.Generic;
using System.Text.RegularExpressions;

Library library = new Library();

//Aggiunta alcuni libri alla lista dei documenti
library.AddDocument(new Book("BK0001", "Harry Potter e la pietra filosofale", 2002, "fantasy", 1300, "J.K. Rowling", 12));
library.AddDocument(new Book("BK0002", "Il nome della rosa", 1980, "Storia", 540, "Umberto Eco", 15));

// Aggiunta di alcuni DVD alla lista dei documenti
library.AddDocument(new Dvd("Dvd0001", "The Mark Wahlberg: 5-Film Collection", 2015, "Action", 150, "Mark Wahlberg", 32));
library.AddDocument(new Dvd("Dvd0002", "The Dark Knight Trilogy", 2012, "Action", 120, "Christopher Nolan", 34));

// Mostra un messaggio di benvenuto e chiede all'utente di scegliere la modalità di ricerca
Console.WriteLine("Benvenuto nella Biblioteca! Cosa vuoi fare:\n[1] Ricerca per codice.\n[2] Ricerca per titolo\n[3] Fai un prestito.");

// Legge l'input dell'utente e lo memorizza nella variabile "scelta"
ConsoleKeyInfo scelta = Console.ReadKey();

// Continua a chiedere all'utente di inserire una scelta valida (1 o 2) finché l'input non è corretto
while (scelta.KeyChar != '1' && scelta.KeyChar != '2' && scelta.KeyChar != '3')
{
    Console.WriteLine("\nScelta non valida. Premi 1 per la ricerca per codice, 2 per la ricerca per titolo, 3 per fare un prestito");
    scelta = Console.ReadKey();
}

// Se l'utente ha scelto la modalità di ricerca per codice
if (scelta.KeyChar == '1')
{
    // Pulisce la console
    Console.Clear();
    // Chiede all'utente di inserire il codice del libro o DVD da cercare
    Console.Write("Inserisci il codice del libro o DVD da cercare: ");
    // Legge l'input dell'utente e lo memorizza nella variabile "codice"
    string codice = Console.ReadLine() ?? string.Empty;

    // Verifica che il codice inserito sia nel formato corretto (LIBxxxx o DVDxxxx)
    Regex regexCodice = new(@"^(BK|Dvd)\d{4}$");
    while (!regexCodice.IsMatch(codice))
    {
        // Se il formato non è corretto, chiede all'utente di inserire nuovamente il codice
        Console.WriteLine("Formato del codice non valido: ");
        codice = Console.ReadLine() ?? string.Empty;
    }

    // Mostra i risultati della ricerca per codice
    Console.WriteLine($"Risultati della ricerca per codice {codice}:");
    foreach (Document documento in library.SearchForCode(codice))
    {
        Console.WriteLine($"{documento.Title} ({documento.Year}) di {documento.Author}");
    }
}
// Se l'utente ha scelto la modalità di ricerca per titolo
else if (scelta.KeyChar == '2')
{
    // Pulisce la console
    Console.Clear();
    // Chiede all'utente di inserire il titolo del libro o DVD da cercare
    Console.Write("Inserisci il titolo del libro o DVD da cercare: ");
    // Legge l'input dell'utente e lo memorizza nella variabile "titolo"
    string titolo = Console.ReadLine() ?? string.Empty;

    // Continua a chiedere all'utente di inserire un titolo valido finché l'input non è corretto
    while (string.IsNullOrWhiteSpace(titolo))
    {
        Console.WriteLine("Titolo non valido. Inserisci un titolo valido: ");
        titolo = Console.ReadLine() ?? string.Empty;
    }

    Console.WriteLine($"Risultati della ricerca per titolo \"{titolo}\":");

    // Mostra i risultati della ricerca per titolo
    List<Document> documentiTrovati = library.SearchForTitle(titolo);
    if (documentiTrovati.Count == 0)
    {
        Console.WriteLine("Nessun risultato trovato.");
    }
    else
    {
        foreach (Document documento in documentiTrovati)
        {
            Console.WriteLine($"{documento.Title} ({documento.Year}) di {documento.Author} {documento.Author}");
        }
    }
}
//Se l'utente ha scelto la modalita del prestito
else if (scelta.KeyChar == '3')
{
    // Pulisce la console
    Console.Clear();

    Console.WriteLine("Registrati per effettuare un prestito:");

    Console.Write("Nome: ");
    string name = Console.ReadLine() ?? string.Empty;

    Console.Write("Cognome: ");
    string surname = Console.ReadLine() ?? string.Empty;

    Console.Write("Email: ");
    string email = Console.ReadLine() ?? string.Empty;

    Console.Write("Password: ");
    string password = Console.ReadLine() ?? string.Empty;

    Console.Write("Numero di telefono: ");
    string phonenumber = Console.ReadLine() ?? string.Empty;

    User user = new User(name, surname, email, password, phonenumber);
    library.Users.Add(user);

    Console.WriteLine("Ti sei registrato correttamente!");

    // Pulisce la console
    Console.Clear();
    // Chiede all'utente di inserire il titolo del libro o DVD da cercare
    Console.Write("Inserisci il titolo del libro o DVD da cercare: ");
    // Legge l'input dell'utente e lo memorizza nella variabile "titolo"
    string titolo = Console.ReadLine() ?? string.Empty;

    // Continua a chiedere all'utente di inserire un titolo valido finché l'input non è corretto
    while (string.IsNullOrWhiteSpace(titolo))
    {
        Console.WriteLine("Titolo non valido. Inserisci un titolo valido: ");
        titolo = Console.ReadLine() ?? string.Empty;
    }

    Console.WriteLine($"Risultati della ricerca per titolo \"{titolo}\":");

    // Mostra i risultati della ricerca per titolo
    List<Document> documentiTrovati = library.SearchForTitle(titolo);
    if (documentiTrovati.Count == 0)
    {
        Console.WriteLine("Nessun risultato trovato.");
    }
    else
    {
        foreach (Document documento in documentiTrovati)
        {
            Console.WriteLine($"{documento.Title} ({documento.Year}) di {documento.Author} {documento.Author}");
        }
    }

    Console.Write("Inserisci periodo di inizio:");
    string periodfrom = Console.ReadLine() ?? string.Empty;

    Console.Write("Inserisci periodo di fine: ");
    string periodto = Console.ReadLine() ?? string.Empty;

    Console.WriteLine("prestito completato");
}

// Chiedi all'utente di premere un tasto per uscire
Console.WriteLine("\nPremi un tasto per uscire.");
Console.ReadKey();