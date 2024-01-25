using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIntegration.Entities.Player
{
    public class GameCharacterTransform
    {
        public Guid Id { get; set; }
        public Guid GameCharacterId { get; set; }
        public GameCharacter GameCharacter { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float RotationX { get; set; }
        public float RotationY { get; set; }
        public float RotationZ { get; set; }
        public float RotationW { get; set; }
    }
}
