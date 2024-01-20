using DatabaseIntegration.Entities.Items;

namespace DatabaseIntegration.Entities.Player
{
    public class GameCharacter
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        public int SlotNumber { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public PlayerStats PlayerStats { get; set; }
        public PlayerSkills PlayerSkills { get; set; }
        public List<ObtainableItem> Inventory { get; set; }
    }
}
