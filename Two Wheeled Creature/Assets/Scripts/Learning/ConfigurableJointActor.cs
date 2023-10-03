using GNMS.TwoWheeledCreature;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	public class ConfigurableJointActor : ActionReceiver
	{
		[SerializeField]
		SlerpDriveConfigSO slerpDriveConfig;

		ConfigurableJoint joint;

		float maximumForce;

		// Euler angles for target rotation (3) + maximum force value (1) = 4 floats
		public override int ContinuousActionSpaceSize => 4;

		public override int[] DiscreteActionBranchSizes => new int[0];

		private void Awake()
		{
			this.joint = this.GetComponent<ConfigurableJoint>();

			this.joint.slerpDrive = this.slerpDriveConfig.SlerpDrive;
			this.maximumForce = this.joint.slerpDrive.maximumForce;
		}

		public override void Act(float[] continuousActions, int[] discreteActions)
		{
			this.SetJointTargetRotation(continuousActions[0], continuousActions[1], continuousActions[2]);
			this.SetJointStrength(continuousActions[3]);
		}

		public void SetJointTargetRotation(float x, float y, float z)
		{
			x = (x + 1f) * 0.5f;
			y = (y + 1f) * 0.5f;
			z = (z + 1f) * 0.5f;

			float xRot = Mathf.Lerp(this.joint.lowAngularXLimit.limit, this.joint.highAngularXLimit.limit, x);
			float yRot = Mathf.Lerp(-this.joint.angularYLimit.limit, this.joint.angularYLimit.limit, y);
			float zRot = Mathf.Lerp(-this.joint.angularZLimit.limit, this.joint.angularZLimit.limit, z);

			this.joint.targetRotation = Quaternion.Euler(xRot, yRot, zRot);
		}

		public void SetJointStrength(float strength)
		{
			float force = (strength + 1f) * 0.5f * this.maximumForce;

			JointDrive slerpDrive = new JointDrive
			{
				positionSpring = this.joint.slerpDrive.positionSpring,
				positionDamper = this.joint.slerpDrive.positionDamper,
				maximumForce = force,
			};

			this.joint.slerpDrive = slerpDrive;
		}
	}
}