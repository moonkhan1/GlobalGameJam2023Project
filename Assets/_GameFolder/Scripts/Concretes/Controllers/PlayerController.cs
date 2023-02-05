using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UIInventory uiInventory;
    IDevice _device;
    private PlayerCameraBase _playerCamera;
    private LevelControlBase _levelControl;
    public float speed { get; set; } = 6f;
    public float jumpForce = 7f;
    private float crouchSpeed = 3f;
    public float rotationSpeed = 10f;
    private float pushForce = 5f;
    private float pullForce = 5f;

    private bool isCrouching = false;
    private bool isGrounded = false;

    private Animator _anim;

    private bool isStop = false;
    public bool IsPlayerStop => isStop;
    private void Awake()
    {
        _device = new DeviceController(this);
        _playerCamera = new PlayerCameraController(this);
        _levelControl = new LevelController(this);
        

    }
    private void Start() {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, 0);
        direction = direction.normalized;

        if (direction.magnitude > 0.1f)
        {
            if (isCrouching)
            {
                _anim.SetBool("Crouching", true);
                _anim.SetBool("CrouchStay", false);

                transform.position += direction * crouchSpeed * Time.deltaTime;
            }
            else
            {
                _anim.SetBool("Crouching", false);
                //_anim.SetBool("CrouchStay", true);

                transform.position += direction * speed * Time.deltaTime;
            }
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (isCrouching)
            {
                _anim.SetBool("CrouchStay", true);
                _anim.SetBool("Crouching", false);
            }
            else
            {
                _anim.SetBool("CrouchStay", false);
                //_anim.SetBool("Crouching", true);
            }
        }

        _anim.SetFloat("Walk", direction.magnitude);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _anim.SetBool("Jumping", true);
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

    private void OnTriggerEnter(Collider other)
    {
        _playerCamera.TriggerForCamera(other);
        _levelControl.IsLeveltriggered(other);
    }
    private void OnCollisionEnter(Collision other)
    {
        _anim.SetBool("Jumping", false);
        isGrounded = true;
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.LoadScene("Game");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _device.WhenTriggerInteractable(other, true);

    }

    private void OnTriggerExit(Collider other)
    {
        _device.WhenTriggerInteractable(other, false);
    }
}
