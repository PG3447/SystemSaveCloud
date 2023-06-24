using UnityEngine;

public class JumpSphere : MonoBehaviour
{
    void FixedUpdate()
    {
        if (this.transform.position.y <= 0.55f) {
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.up * 20000f * Time.deltaTime);
        }
    }
}
