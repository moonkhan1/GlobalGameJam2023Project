using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public List<GameObject> LevelTriggers;
    [SerializeField] public List<GameObject> TreeStairs;
    [SerializeField] public List<GameObject> CampTriggers;
    [SerializeField] public List<GameObject> CampTriggersWall;
    [SerializeField] public List<GameObject> FinishTriggers;

    private void Awake() {
        if(Instance == null)
            Instance = this;
    }
}
