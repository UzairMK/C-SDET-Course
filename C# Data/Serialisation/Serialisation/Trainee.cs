using System;
using Newtonsoft.Json;

namespace Serialisation
{
    [Serializable]
    public class Trainee
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int SpartaNo { get; init; }
        [JsonIgnore]
        public string Fullname => $"{FirstName} {LastName}";
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
