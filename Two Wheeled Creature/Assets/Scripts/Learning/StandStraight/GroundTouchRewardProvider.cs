using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning.StandStraight
{
	[RequireComponent(typeof(ObservedGroundTouch)), DisallowMultipleComponent()]
	public class GroundTouchRewardProvider : RewardProvider
	{
		[SerializeField, Tooltip("Reward amount per step for touching ground"), Min(0)]
		float groundTouchReward = 0.1f;
		[SerializeField, Tooltip("Penalty amount per step for missing ground"), Min(0)]
		float groundMissPenalty = 0.1f;

		ObservedGroundTouch observedGroundTouch;

		private void Awake()
		{
			this.observedGroundTouch = this.GetComponent<ObservedGroundTouch>();
		}

		public override bool RewardAgent(Agent agent)
		{
			agent.AddReward(this.observedGroundTouch.IsGrounded ? this.groundTouchReward : -this.groundMissPenalty);
			return true;
		}
	}
}