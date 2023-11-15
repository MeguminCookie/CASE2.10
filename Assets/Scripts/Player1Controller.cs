using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float hoverForce = 5f;
    public float dodgeDistance = 5f;
    public float dodgeCooldown = 2f;
    public float staminaRegenDelay = 3f;
    public float staminaRegenRate = 1f;
    public float maxStamina = 100f;

    public float currentStamina;
    private bool isGrounded;
    private bool isDodging;
    private bool canRegenStamina = true;

    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        currentStamina = maxStamina;
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Player movement
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveDirection = Vector3.zero;

        // Restrict movement to eight directions
        if (movement.magnitude > 0)
        {
            float angle = Mathf.Atan2(movement.z, movement.x) * Mathf.Rad2Deg;
            angle = Mathf.Round(angle / 45) * 45;
            moveDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        }

        playerRigidbody.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKeyDown(KeyCode.Q) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Hover
        if (Input.GetKey(KeyCode.Q) && !isGrounded && currentStamina > 0)
        {
            playerRigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Force);
            ConsumeStamina();
        }

        // Dodge
        if (Input.GetKeyDown(KeyCode.E) && !isDodging && currentStamina > 0)
        {
            StartCoroutine(PerformDodge());
        }

        // Stamina regeneration
        if (!isDodging && canRegenStamina && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
    }

    void ConsumeStamina()
    {
        currentStamina = Mathf.Clamp(currentStamina - 1, 0, maxStamina);
        canRegenStamina = false;
        Invoke("EnableStaminaRegen", staminaRegenDelay);
    }

    void EnableStaminaRegen()
    {
        canRegenStamina = true;
    }

    IEnumerator PerformDodge()
    {
        isDodging = true;
        Vector3 dodgeDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        playerRigidbody.MovePosition(transform.position + dodgeDirection * dodgeDistance);
        ConsumeStamina();
        yield return new WaitForSeconds(dodgeCooldown);
        isDodging = false;
    }
}
