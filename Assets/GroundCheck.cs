using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public NotJumpKingController notJumpKingControllerRef;

    public void OnTriggerEnter(Collider other)
    {
        notJumpKingControllerRef.grounded = true;
    }

    public void OnTriggerExit(Collider other)
    {
        notJumpKingControllerRef.grounded = false;   
    }
}
