using UnityEngine;

namespace GNMS.TwoWheeledCreature
{
	[RequireComponent(typeof(WheelCollider))]
	public class WakeUpWheelCollider : MonoBehaviour
	{
		private void Start()
		{
			this.GetComponent<WheelCollider>().motorTorque = 0.01f;
		}
	}
}