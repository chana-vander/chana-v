namespace clinica.Entities
{
    public class Doctor
    {
        public string name { get; set; }
        public int id { get; set; }
        public string occupation { get; set; }
        public string phone { get; set; }

        public Doctor(string name, int id, string occupation,string phone)
        {
            this.name = name;
            this.id = id;
            this.occupation = occupation;
            this.phone = phone;
        }
    }
}
