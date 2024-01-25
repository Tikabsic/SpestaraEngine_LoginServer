using GameData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameData.Object_Properties
{
    internal class Transform
    {
        //Vector3
        private float _positionX { get; set; }
        private float _positionY { get; set; }
        private float _positionZ { get; set; }

        //Quaternion
        private float _rotationX { get; set; }
        private float _rotationY { get; set; }
        private float _rotationZ { get; set; }
        private float _rotationW { get; set; }

    }
}
