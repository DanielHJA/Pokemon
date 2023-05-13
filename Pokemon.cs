using Newtonsoft.Json;

namespace API
{
    public class Pokemon: SerializableObject
    {
        [JsonProperty("base_experience")]
        public int BaseExperience {get; set;}
        public List<Form> Forms {get; set;} = new List<Form>();
        public int Height {get; set;}
        
        [JsonProperty("is_default")]
        public bool IsDefault {get; set;}
        
        [JsonProperty("location_area_encounter")]
        public string LocationAreaEncounters {get; set;} = String.Empty;
        public string Name {get; set;} = String.Empty;
        public int Order {get; set;}
        public Species Species {get; set;} = new Species();
        public List<Stat> Stats {get; set;} = new List<Stat>();
        public double Weight {get; set;}
    }

    public class Form
    {
        public string Name {get; set;} = String.Empty;
        public string Url {get; set;} = String.Empty;
    }

    public class Species
    {
        public string Name {get; set;} = String.Empty;
        public string Url {get; set;} = String.Empty;
    }

    public class Stat
    {
        [JsonProperty("base_stat")]
        public int BaseStat {get; set;}
        public int Effort {get; set;}
    }
}

