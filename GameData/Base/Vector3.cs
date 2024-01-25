using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameData.Base
{
    internal class Vector3
    {
        private float _x { get; set; }
        private float _y { get; set; }
        private float _z { get; set; }

        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
    }
}
