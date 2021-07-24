using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DoubTech.SpaceGameUtils.Orbit
{
    [CustomEditor(typeof(Orbit))]
    public class OrbitEditor : Editor
    {
        private GameObject planetPrefab;
        private int planetIndex;

        class Content
        {
            #region GUIContent
            #endregion

            #region Styles
            #endregion

            static Content()
            {
            // Style initialization

            }
        }

        public override void OnInspectorGUI()
        {
            var orbit = (Orbit) target;
            base.OnInspectorGUI();



            GUILayout.BeginHorizontal();
            string[] planets = null;
            var solarSystem = orbit.GetComponentInParent<SolarSystem>();
            if (solarSystem)
            {
                planets = solarSystem.planetPrefabs.Select(a => a.name).ToArray();
            }

            if (null != planets && planets.Length > 0)
            {
                planetIndex = EditorGUILayout.Popup(planetIndex, planets);
                planetPrefab = solarSystem.planetPrefabs[planetIndex];
            }
            else
            {
                planetPrefab =
                    (GameObject) EditorGUILayout.ObjectField("Model", planetPrefab,
                        typeof(GameObject));
            }
            if (GUILayout.Button("Apply"))
            {
                var modelTransform = orbit.transform.Find("Planet Model");
                if (modelTransform.childCount > 0)
                {
                    int ct = modelTransform.childCount;
                    for (int i = 0; i < ct; i++)
                    {
                        DestroyImmediate(modelTransform.GetChild(0).gameObject);
                    }
                }

                var model = Instantiate(planetPrefab, modelTransform);
                orbit.OnValidate();

                var rotation = orbit.GetComponent<PlanetaryRotation>();
                if (rotation)
                {
                    rotation.target = model.transform;
                }
                EditorUtility.SetDirty(rotation);
            }
            GUILayout.EndHorizontal();
        }
    }
}
