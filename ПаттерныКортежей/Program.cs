string GetWelcome(string lang, string daytime) => (lang, daytime) switch
{
    ("english", "morning") => "Good morning",
    ("english", "evening") => "Good evening",
    ("german", "morning") => "Guten Morgen",
    ("german", "evening") => "Guten Abend",
    _ => "Здрасьть"
};

string message = GetWelcome("english", "evening");
Console.WriteLine(message);  // Good evening

message = GetWelcome("french", "morning");
Console.WriteLine(message);  // Здрасьть