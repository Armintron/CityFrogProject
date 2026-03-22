using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject meshRef;
    public Rigidbody rbRef;
    public TextMeshProUGUI staminaText;

    public bool isClimbing = false;
    public float maxStamina = 100;
    public float currStamina = 100;
    public float minStaminaToStartClimbing = 30;
    public float turnRate = 10f;
    public float speed = 10f;
    public float staminaRatePerSec = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currStamina >= minStaminaToStartClimbing)
        {
            isClimbing = !isClimbing;
            if (isClimbing)
            {
                rbRef.linearVelocity = rbRef.angularVelocity = Vector3.zero;
            }
        }

        if (isClimbing)
        {
            currStamina -= staminaRatePerSec * Time.deltaTime;
            rbRef.useGravity = false;
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 dir = meshRef.transform.up.normalized;
                meshRef.transform.position += dir * speed;
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    meshRef.transform.Rotate(meshRef.transform.right, -turnRate);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    meshRef.transform.Rotate(meshRef.transform.right, turnRate);
                }
            }

        }
        else
        {
            currStamina += staminaRatePerSec * Time.deltaTime;
            rbRef.useGravity = true;
        }

        currStamina = Mathf.Clamp(currStamina, 0, maxStamina);
        if (currStamina == 0)
        {
            isClimbing = false;
        }

        staminaText.text = "Stamina: " + (int)currStamina;
    }
}
