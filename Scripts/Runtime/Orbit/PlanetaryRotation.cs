using System;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    public class PlanetaryRotation : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 axis;

        private void Update()
        {
            var angle = Time.smoothDeltaTime * speed;
            transform.Rotate(axis, angle);
        }
    }
}
