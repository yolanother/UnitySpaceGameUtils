using System;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    public class Orbit : MonoBehaviour
    {
        [SerializeField] private Transform orbitingObject;
        [SerializeField] private Ellipse ellipse;
        [SerializeField] private float speed;
        [Range(0, 1)]
        [SerializeField] private float startPosition;

        private float position = 0;

        private void OnValidate()
        {
            Update();
        }

        public void Update()
        {
            position += Application.isPlaying ? Time.smoothDeltaTime * speed / 1000f : 0;
            if (position > 1) position -= 1;
            if (orbitingObject)
            {
                orbitingObject.transform.localPosition =
                    ellipse.Evaluate(position + startPosition);
            }
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; null != ellipse && i < 360; i++)
            {
                Gizmos.DrawLine(ellipse.Evaluate(i / 360f), ellipse.Evaluate((i + 1) / 360f));
            }
        }
    }
}
