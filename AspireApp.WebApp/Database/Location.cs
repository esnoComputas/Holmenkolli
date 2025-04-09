namespace AspireApp.WebApp.Database;

public enum Location
{
    KnutKnudsensPlass = 0,
    LouisesGate = 1,
    WolffsGate = 2,
    WilhelmFærdensVei = 3,
    Forskningsveien = 4,
    Holmenveien = 5,
    SlemdalSkole = 6,
    Besserud = 7,
    Gressbanen = 8,
    Holmendammen = 9,
    Frognerparken = 10,
    NordraaksGate = 11,
    ArnoBergsPlass = 12,
    CamillaCollettsVei = 13,
    Bislettgata = 14
}

public static class LocationExtensions
{
    public static string GetReadableName(this Location location)
    {
        switch (location)
        {
            case Location.KnutKnudsensPlass:
                return "Knut Knudsens plass";
            case Location.LouisesGate:
                return "Louises gate";
            case Location.WolffsGate:
                return "Wolffs gate";
            case Location.WilhelmFærdensVei:
                return "Wilhelm Færdens vei";
            case Location.Forskningsveien:
                return "Forskningsveien";
            case Location.Holmenveien:
                return "Holmenveien";
            case Location.SlemdalSkole:
                return "Slemdal skole";
            case Location.Besserud:
                return "Besserud";
            case Location.Gressbanen:
                return "Gressbanen";
            case Location.Holmendammen:
                return "Holmendammen";
            case Location.Frognerparken:
                return "Frognerparken";
            case Location.NordraaksGate:
                return "Nordraaks gate";
            case Location.ArnoBergsPlass:
                return "Arno Bergs plass";
            case Location.CamillaCollettsVei:
                return "Camilla Colletts vei";
            case Location.Bislettgata:
                return "Bislettgata";
            default:
                return location.ToString(); // Fallback to the enum member name
        }
    }
}