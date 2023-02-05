using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using DG.Tweening;
using UnityEngine.UI;
public class LevelController : LevelControlBase
{
    private PlayerController _playerController;
    // public override event Action<int> isLeveltriggered;
    public override event Action isFinishtriggered;
    public LevelController(PlayerController playerController)
    {
        _playerController = playerController.GetComponent<PlayerController>();
    }

    public override void IsLeveltriggered(Collider other)
    {
        if (LevelManager.Instance.LevelTriggers.Any(u => u.name == other.name))
        {
            other.gameObject.SetActive(false);
            foreach (GameObject item in LevelManager.Instance.TreeStairs)
            {
                item.SetActive(true);
            }
        }
        if (LevelManager.Instance.CampTriggers.Any(u => u.name == other.name))
        {
            int index = LevelManager.Instance.CampTriggers.FindIndex(a => a.name == other.name);
            foreach (var item in LevelManager.Instance.CampTriggersWall[index].GetComponentsInChildren<Transform>())
            {
                if (item.gameObject == null)
                    return;
                if(index % 2 == 0)
                    LevelManager.Instance.CampTriggersWall[index].SetActive(true);
                if(index % 2 != 0)
                    LevelManager.Instance.CampTriggersWall[index].SetActive(false);
            }
        }
    }
}
