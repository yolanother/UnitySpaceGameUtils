using System;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    [RequireComponent(typeof(LineRenderer))]
    public class OrbitRenderer : MonoBehaviour
    {
        [SerializeField] private int segments = 32;
        [SerializeField] private Orbit orbit;

        [HideInInspector]
        [SerializeField] private LineRenderer lineRenderer;

        private void OnValidate()
        {
            if (!lineRenderer) lineRenderer = GetComponent<LineRenderer>();
            if (!orbit) orbit = GetComponent<Orbit>();

            if (!orbit) return;

            RefreshOrbit();
        }

        public void RefreshOrbit()
        {
            string pts = "";
            lineRenderer.positionCount = segments + 1;
            var positions = new Vector3[segments + 1];
            for (int i = 0; i <= segments; i++)
            {
                positions[i] =
                    orbit.transform.TransformPoint(orbit.ellipse.Evaluate(i / (float) segments));
                pts += positions[i];
            }

            Debug.Log("Points: " + pts);
            lineRenderer.SetPositions(positions);
        }
    }
}
