namespace WPFAutomation.Models
{
    public class Language
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string NameOf { get; set; }
        public string Skill { get; set; }

        internal bool IsNew => (this.Id == default(int));
    }
}