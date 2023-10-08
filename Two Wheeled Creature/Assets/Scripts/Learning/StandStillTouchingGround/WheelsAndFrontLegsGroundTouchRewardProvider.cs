using GNMS.TwoWheeledCreature.Learning.StandStraight;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.Scripting;

namespace GNMS.TwoWheeledCreature.Learning.StandStillTouchingGround
{
	public class WheelsAndFrontLegsGroundTouchRewardProvider : RewardProvider
	{
		[SerializeField]
		ObservedGroundTouch[] wheelGroundTouches;
		[SerializeField]
		ObservedGroundTouch[] frontLegGroundTouches;
		[SerializeField, Range(0, 1)]
		float allWheelsTouchingGroundReward = 0.3f;
		[SerializeField, Range(0, 1)]
		float wheelsMissingGroundPenalty = 0.2f;
		[SerializeField, Range(0, 1)]
		float allFrontLegsTouchingGroundReward = 0.3f;
		[SerializeField, Range(0, 1)]
		float frontLegsMissingGroundPenalty = 0.2f;

		public override bool RewardAgent(Agent agent)
		{
			bool allWheelsTouchGround = true;
			foreach (ObservedGroundTouch wheelGroundTouch in wheelGroundTouches)
			{
				allWheelsTouchGround = allWheelsTouchGround && wheelGroundTouch.IsGrounded;
			}

			bool allFrontLegsTouchGround = true;
			foreach (ObservedGroundTouch frontLegGroundTouch in frontLegGroundTouches)
			{
				allFrontLegsTouchGround = allFrontLegsTouchGround && frontLegGroundTouch.IsGrounded;
			}

			agent.AddReward(allWheelsTouchGround ? this.allWheelsTouchingGroundReward : -this.wheelsMissingGroundPenalty);
			agent.AddReward(allFrontLegsTouchGround ? this.allFrontLegsTouchingGroundReward : -this.frontLegsMissingGroundPenalty);

			return true;
		}
	}
}