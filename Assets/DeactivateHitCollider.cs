using UnityEngine;

public class DeactivateHitCollider : MonoBehaviour
{

    void FixedUpdate()
    {
        Invoke("Deactivate", 0.3f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
