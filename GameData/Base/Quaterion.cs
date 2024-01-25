using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameData.Base
{
    internal class Quaterion
    {
        private float _x { get; set; }
        private float _y { get; set; }
        private float _z { get; set; }
        private float _w { get; set; };

        public Quaterion(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }
    }
}
