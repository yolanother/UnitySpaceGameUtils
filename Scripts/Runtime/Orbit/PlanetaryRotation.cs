using System;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    public class PlanetaryRotation : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] private float speed;
        [SerializeField] private Vector3 axis;

        private void Start()
        {
            if (null == target && transform.childCount > 0)
            {
                target = transform.GetChild(0);
            }
        }

        private void Update()
        {
            var angle = Time.smoothDeltaTime * speed;
            target.Rotate(axis, angle, Space.Self);
        }
    }
}
