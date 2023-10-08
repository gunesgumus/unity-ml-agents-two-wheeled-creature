using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	public class LookDirectionRewardProvider : RewardProvider
	{
		[SerializeField]
		Vector3 localLookDirection = Vector3.forward;
		[SerializeField]
		Vector3 globalLookDirection = Vector3.forward;
		[SerializeField]
		AnimationCurve rewardCurve = AnimationCurve.Linear(-1, -1, 1, 1);
		[SerializeField, Range(0.0001f, 100.0f)]
		float rewardMultiplier = 0.1f;
		[Header("Gizmos")]
		[SerializeField, Min(0.1f)]
		float gizmoLength = 1.0f;
		[SerializeField]
		Color localGizmoColor = Color.red;
		[SerializeField]
		Color globalGizmoColor = Color.yellow;

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = this.localGizmoColor;
			Gizmos.matrix = this.transform.localToWorldMatrix;
			Gizmos.DrawLine(Vector3.zero, this.gizmoLength * this.localLookDirection.normalized);
			Gizmos.color = this.globalGizmoColor;
			Vector3 visualOffset = 0.01f * Vector3.one;
			Gizmos.DrawLine(Vector3.zero + visualOffset, visualOffset + this.gizmoLength * this.transform.InverseTransformDirection(this.globalLookDirection).normalized);
		}

		public override bool RewardAgent(Agent agent)
		{
			float dot = Vector3.Dot(
				this.transform.TransformDirection(this.localLookDirection).normalized,
				this.globalLookDirection.normalized);
			agent.AddReward(this.rewardMultiplier * this.rewardCurve.Evaluate(dot));
			return true;
		}
	}
}