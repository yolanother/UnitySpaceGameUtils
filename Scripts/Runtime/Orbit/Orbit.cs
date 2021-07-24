using System;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    public class Orbit : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField] private Transform orbitingObject;
        [SerializeField] public Ellipse ellipse;
        [SerializeField] private float speed;
        [Range(0, 1)]
        [SerializeField] private float startPosition;

        [HideInInspector]
        [SerializeField] private OrbitRenderer orbitRenderer;

        private float position = 0;

        public void OnValidate()
        {
            if (!orbitRenderer) orbitRenderer = GetComponentInChildren<OrbitRenderer>();

            var modelTransform = transform.Find("Planet Model");
            if (modelTransform.childCount > 0)
            {
                orbitingObject = modelTransform.GetChild(0);
            }

            Update();
            if (orbitRenderer) orbitRenderer.RefreshOrbit();
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
    }
}
