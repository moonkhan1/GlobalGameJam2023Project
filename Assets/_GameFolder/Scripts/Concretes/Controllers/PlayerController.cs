using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UIInventory uiInventory;

    public float speed = 6f;
    public float jumpForce = 5f;
    public float crouchSpeed = 3f;
    public float pushForce = 5f;
    public float pullForce = 5f;

    private bool isCrouching = false;
    private bool isGrounded = false;



    private bool isStop = false;
    public bool IsPlayerStop => isStop;
    private void Awake()
    {
        // inventory = new Inventory();
        // uiInventory.SetInventory(inventory);

        // ItemAtWorld.SpawnNewItem(new Vector3(-25,-25,32), new Item{itemType = Item.ItemType.Feather, amount = 1});
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, 0);

        if (isCrouching)
        {
            transform.position += direction * crouchSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        isGrounded = true;
    }
}
