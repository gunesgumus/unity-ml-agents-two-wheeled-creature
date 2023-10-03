using UnityEngine;

namespace GNMS.TwoWheeledCreature.Physics
{
	[RequireComponent(typeof(Rigidbody))]
	public class MaxAngularSpeedSetter : MonoBehaviour
	{
		[SerializeField]
		float maxAngularSpeed = 50.0f;

		private void Awake()
		{
			this.GetComponent<Rigidbody>().maxAngularVelocity = maxAngularSpeed;
		}
	}
}