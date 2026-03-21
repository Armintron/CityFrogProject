using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject meshRef;
    public Rigidbody rbRef;

    public bool isClimbing = false;
    public float maxStamina = 100f;
    public float currStamina = 100f;
    public float turnRate = 10f;
    public float speed = 10f;
    public float staminaRatePerSec = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = true;
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
                    meshRef.transform.Rotate(Vector3.right, -turnRate);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    meshRef.transform.Rotate(Vector3.right, turnRate);
                }
            }

        }
        else
        {
            currStamina += staminaRatePerSec * Time.deltaTime;
            rbRef.useGravity = true;
        }

        currStamina = Mathf.Clamp(currStamina, 0, maxStamina);  
    }
}
