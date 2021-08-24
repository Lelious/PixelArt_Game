using UnityEngine;
public class HorizontalPlatformMovement : MonoBehaviour
{
    [SerializeField] private SliderJoint2D sliderJoint2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            JointMotor2D motor = sliderJoint2D.motor;
            motor.motorSpeed = motor.motorSpeed * -1;
            sliderJoint2D.motor = motor;
        }
    }
}
