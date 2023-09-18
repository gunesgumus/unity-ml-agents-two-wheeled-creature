using UnityEngine;

public class WheelColliderVisual : MonoBehaviour
{
	WheelCollider wheelCollider;

	private void Awake()
	{
		this.wheelCollider = this.GetComponentInParent<WheelCollider>();
	}

	private void Update()
	{
		this.wheelCollider.GetWorldPose(out Vector3 wheelPosition, out Quaternion wheelRotation);
		this.transform.position = wheelPosition;
		this.transform.rotation = wheelRotation;
	}
}
