using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using TMPro;
using CASP.SoundManager;
// using CASP.SoundManager;
public class DeviceController : IDevice
{
    [SerializeField] Transform _movePosition;
    public PlayerController _playerController;
    private bool isHiding = false;
    private bool isKnifeEquiped = false;
    private bool isKeyEquiped = false;
    private bool isCocoEquiped = false;
    


    public DeviceController(PlayerController playerController)
    {
        _playerController = playerController.GetComponent<PlayerController>();

    }

    public override void WhenTriggerInteractable(Collider other, bool isActive)
    {
        foreach (KeyValuePair<GameObject, GameObject> items in DeviceManager.Instance.itemsDevices)
        {
            if (other.name == items.Key.name && items.Key.name.Contains("Triggers"))
            {
                UIManager.Instance.InteractionKey.gameObject.SetActive(isActive);
            }

            if (other.name == items.Key.name && items.Key.name.Contains("2"))
            {
                if (Input.GetKeyDown(KeyCode.E) && !isHiding)
                {
                    SoundManager.Instance.Play("Interaction");
                    GameObject.FindObjectOfType<PlayerController>().transform.DOMoveZ(-2, 0.3f);
                    isHiding = true;
                    _playerController.speed = 0f;

                }
                else if (Input.GetKeyDown(KeyCode.E) && isHiding)
                {
                    SoundManager.Instance.Play("Interaction");
                    GameObject.FindObjectOfType<PlayerController>().transform.DOMoveZ(-7.7f, 0.3f);
                    isHiding = false;
                    _playerController.speed = 6f;

                }
            }

            if (other.name == items.Key.name && items.Key.name.Contains("1") && isKnifeEquiped)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SoundManager.Instance.Play("Interaction");
                    if(items.Value.GetComponent<SpringJoint>() != null)
                        items.Value.GetComponent<SpringJoint>().connectedBody = null;
                    AnimalManager.Instance?.RaiseOnButtonClick();
                    DeviceManager.Instance.particleFire.gameObject.SetActive(false);
                    DeviceManager.Instance.particleSmoke.gameObject.SetActive(false);
                }
            }
            if (other.name == items.Key.name && items.Key.name.Contains("3") && isKeyEquiped)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SoundManager.Instance.Play("Interaction");
                    items.Value.gameObject.SetActive(false);
                    SoundManager.Instance.Play("Monkey");
                    AnimalManager.Instance?.RaiseOnButtonClickMonkey();
                }
            }
            if (other.name == items.Key.name && items.Key.name.Contains("4") && isCocoEquiped)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SoundManager.Instance.Play("Interaction");
                    items.Value.gameObject.SetActive(false);
                    AnimalManager.Instance?.RaiseOnButtonClickBird();
                }
            }
            if (other.name == items.Key.name && items.Key.tag.Contains("Collectable"))
            {
                items.Value.gameObject.SetActive(true);
                items.Key.gameObject.SetActive(false);
                if(other.name.Contains("Knife"))
                {
                    isKnifeEquiped = true;
                }
                if(other.name.Contains("Key"))
                {
                    isKeyEquiped = true;
                }
                if(other.name.Contains("Coco"))
                {
                    isCocoEquiped = true;
                }
            }
        }
    }


}
