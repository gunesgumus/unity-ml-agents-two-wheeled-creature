using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning.StandStraight
{
	[RequireComponent(typeof(Rigidbody)), DisallowMultipleComponent()]
	public class BodyStandStraightRewardProvider : RewardProvider
	{
		[SerializeField]
		Vector3 bodyUp = Vector3.up;
		[SerializeField]
		AnimationCurve rewardCurve = AnimationCurve.Linear(-1, -1, 1, 1);
		[SerializeField, Range(0.0001f, 1.0f)]
		float rewardMultiplier = 0.1f;
		[Header("Gizmos")]
		[SerializeField, Min(0.1f)]
		float gizmoLength = 1.0f;
		[SerializeField]
		Color gizmoColor = Color.red;

		Rigidbody body;

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = this.gizmoColor;
			Gizmos.matrix = this.transform.localToWorldMatrix;
			Gizmos.DrawLine(Vector3.zero, this.gizmoLength * this.bodyUp.normalized);
		}

		private void Awake()
		{
			this.body = this.GetComponent<Rigidbody>();
		}

		public override bool RewardAgent(Agent agent)
		{
			float dot = Vector3.Dot(this.transform.TransformDirection(this.bodyUp.normalized), Vector3.up);
			agent.AddReward(this.rewardMultiplier * this.rewardCurve.Evaluate(dot));
			return true;
		}
	}
}