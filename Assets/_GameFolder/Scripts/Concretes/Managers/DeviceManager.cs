using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DeviceManager : MonoBehaviour
{
    public static DeviceManager Instance;
    [SerializeField] List<GameObject> Keys;
    [SerializeField] List<GameObject> Utils;
    public Dictionary<GameObject, GameObject> itemsDevices;

    [SerializeField] public GameObject particleFire;
    [SerializeField] public GameObject particleSmoke;
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

       
        itemsDevices = new();
        foreach (GameObject keys in Keys)
        {
            foreach (GameObject values in Utils)
            {
                if(!itemsDevices.ContainsKey(keys) && !itemsDevices.ContainsValue(values))
                    itemsDevices.Add(keys, values);

            }

        }
    }
    
}
