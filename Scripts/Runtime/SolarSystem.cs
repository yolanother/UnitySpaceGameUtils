using UnityEngine;

namespace DoubTech.SpaceGameUtils
{
    public class SolarSystem : MonoBehaviour
    {
        [SerializeField] public GameObject[] planetPrefabs;
        [SerializeField] private GameObject sun;

        public Transform Sun => sun.transform;
    }
}
