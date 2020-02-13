using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Production.Scripts.Utils
{
    public static class NameGenerator
    {
        public static List<string> Adjectives = new List<string>
        {
            "Generous",
            "Kind",
            "Handsome",
            "Awesome",
            "Wonderful",
            "Giant",
            "Little",
            "Big",
            "Short",
            "Smart",
            "Akward",
            "Brilliant",
            "Shy",
            "Mad",
            "Foolish",
            "Brainwashed",
            "Dumb",
            "Magic",
            "Doped",
            "Compulsive",
            "Stupid",
            "Selfish",
            "Cocained",
            "Dangerous",
            "Crazy",
            "Legendary",
            "Skinny",
            "Skinny",
            "Retarded",
            "Genius",
           
        };
        public static List<string> Names = new List<string>()
        {
            "Max",
            "John",
            "Jack",
            "Rob",
            "Ryan",
            "Jake",
            "Valentino",
            "Jena",
            "Matt",
            "Telma",
            "Billy",
            "Ronald",
            "Bob",
            "Sam",
            "Joe",
            "Brad",
            "Luis",
            "Mike",
            "Sally",
            "Peggy",
            "Kim",
            "Haiden",
            "Maxine",
            "Cody",
            "Ana",
            "Tommy",
            "Jacqueline",
            "Bernard",
            "Terry",
        };
        
        public static string GenerateName()
        {
            return Adjectives[Random.Range(0, Adjectives.Count-1)] + " " + Names[Random.Range(0, Names.Count-1)];
        }
    }
}