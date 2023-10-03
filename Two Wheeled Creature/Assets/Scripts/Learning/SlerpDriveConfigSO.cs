using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	[CreateAssetMenu(fileName = "Slerp Drive Config", menuName = "Two Wheeled Creature/Slerp Drive Configuration")]
	public class SlerpDriveConfigSO : ScriptableObject
	{
		[SerializeField]
		float positionSpring = 1000f;
		[SerializeField]
		float positionDamper = 100f;
		[SerializeField]
		float maximumForce = 1000f;

		public JointDrive SlerpDrive => new JointDrive()
		{
			positionSpring = this.positionSpring,
			positionDamper = this.positionDamper,
			maximumForce = this.maximumForce,
		};
	}
}