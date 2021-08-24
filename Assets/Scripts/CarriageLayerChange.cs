using UnityEngine;

public class CarriageLayerChange : MonoBehaviour
{
    [SerializeField] private GameObject carriage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Carriage")
        {
            Debug.Log("1");
            other.gameObject.layer = 4;
        }
    }
}
