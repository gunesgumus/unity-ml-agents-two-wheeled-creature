using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning.StandStraightRestrictedMovement
{
	[RequireComponent(typeof(Rigidbody))]
	public class RestrictedRigidbodyMovementRewardProvider : RewardProvider
	{
		[SerializeField, Range(0, 1)]
		float movementStillnessRewardMultiplier = 0.05f;
		[SerializeField, Range(0, 1)]
		float angularStillnessRewardMultiplier = 0.05f;
		[SerializeField, Min(0.001f)]
		float movementStillnessSeverity = 1;
		[SerializeField, Min(0.001f)]
		float angularStillnessSeverity = 1;

		Rigidbody body;

		private void Awake()
		{
			this.body = this.GetComponent<Rigidbody>();
		}

		public override bool RewardAgent(Agent agent)
		{
			agent.AddReward(this.movementStillnessRewardMultiplier *
				this.CalculatePunishment(
					Vector3.Scale(new Vector3(1,0,1), this.body.velocity).magnitude,
					this.movementStillnessSeverity));
			agent.AddReward(this.angularStillnessRewardMultiplier *
				this.CalculatePunishment(
					this.body.angularVelocity.magnitude,
					this.angularStillnessSeverity));

			return true;
		}

		float CalculatePunishment(float magnitude, float severity)
		{
			return Mathf.Exp(-(severity) * magnitude * magnitude);
		}
	}
}