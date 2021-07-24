using System;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    [Serializable]
    public class Ellipse
    {
        [SerializeField] public float radiusX;
        [SerializeField] public float radiusY;

        public Vector2 Evaluate(float t)
        {
            var angle = Mathf.Deg2Rad * 360 * t;
            var x = Mathf.Sin(angle) * radiusX;
            var y = Mathf.Cos(angle) * radiusY;
            return new Vector2(x, y);
        }
    }
}
