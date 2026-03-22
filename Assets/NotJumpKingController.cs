using UnityEngine;

public class NotJumpKingController : MonoBehaviour
{
    public GameObject meshRef;
    public Rigidbody rbRef;
    public bool isJumpingRight = false;
    public Vector3 jumpDir = Vector3.right + Vector3.up;
    public float currJumpForce = 0f;
    public float jumpForcePerSec = 10f;
    public float maxJumpForce = 30f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isJumpingRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isJumpingRight = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            currJumpForce += jumpForcePerSec * Time.deltaTime;
            currJumpForce = Mathf.Clamp(currJumpForce, 0, maxJumpForce);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpDir = jumpDir.normalized;
            Vector3 dirToJump = isJumpingRight ? jumpDir : Vector3.Reflect(jumpDir, Vector3.forward);
            rbRef.AddForce(dirToJump.normalized * currJumpForce, ForceMode.Impulse);
            currJumpForce = 0;
        }
    }
}
