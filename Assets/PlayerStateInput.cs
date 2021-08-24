using UnityEngine;
[RequireComponent(typeof(Shooter))]

public class PlayerStateInput : MonoBehaviour
{
    private PlayerStateAnimations playerStateInput;
    private Shooter shooter;
    void Awake()
    {
        playerStateInput = GetComponent<PlayerStateAnimations>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {

       
    }
}
