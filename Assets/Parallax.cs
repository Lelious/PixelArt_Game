using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coefficient;

    private float offset = 3f;
    private int layersCount;

    private void Awake()
    {
        layersCount = layers.Length;
    }

    private void Update()
    {
        for (int i = 0; i < layersCount; i++)
        {
            layers[i].position = new Vector3(transform.position.x * coefficient[i], transform.position.y - coefficient[i], 0);

        }
    }
}
