using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	[RequireComponent(typeof(BehaviorParameters))]
	public class CreatureAgent : Agent
	{
		[SerializeField]
		ObservationProvider[] observationProviders;
		[SerializeField]
		ActionReceiver[] actionReceivers;
		[SerializeField]
		RewardProvider[] rewardProviders;
		[SerializeField]
		EpisodeBeginHandler[] episodeBeginHandlers;

		public override void OnEpisodeBegin()
		{
			foreach (EpisodeBeginHandler episodeBeginHandler in this.episodeBeginHandlers)
			{
				episodeBeginHandler.HandleEpisodeBegin();
			}
		}

		public override void CollectObservations(VectorSensor sensor)
		{
			foreach (ObservationProvider observationProvider in this.observationProviders)
			{
				observationProvider.AddObservations(sensor);
			}
		}

		public override void OnActionReceived(ActionBuffers actions)
		{
			int continuousActionIndex = 0;
			int discreteActionIndex = 0;

			foreach (ActionReceiver actionReceiver in this.actionReceivers)
			{
				actionReceiver.OnActionReceived(actions, ref continuousActionIndex, ref discreteActionIndex);
			}

			foreach (RewardProvider rewardProvider in this.rewardProviders)
			{
				rewardProvider.RewardAgent(this);
			}
		}

		public void RefreshObservationProviders()
		{
			Undo.RecordObject(this, "Refreshed Observation Providers for Creature Agent");
			this.observationProviders = this.GetComponentsInChildren<ObservationProvider>();

			int observationSpaceSize = this.observationProviders
				.Aggregate(0, (totalSpaceSize, nextProvider) =>
					totalSpaceSize += nextProvider.ObservationSpaceSize);
			BehaviorParameters behaviorParameters = this.GetComponent<BehaviorParameters>();
			Undo.RecordObject(behaviorParameters, "Updated Behavior Parameter's Vector Observation Space Size");
			behaviorParameters.BrainParameters.VectorObservationSize = observationSpaceSize;
		}

		public void RefreshActionReceivers()
		{
			Undo.RecordObject(this, "Refreshed Action Receivers for Creature Agent");
			this.actionReceivers = this.GetComponentsInChildren<ActionReceiver>();

			int continuousActionSpaceSize = this.actionReceivers
				.Aggregate(0, (totalContinuousActionSpaceSize, nextReceiver) =>
					totalContinuousActionSpaceSize += nextReceiver.ContinuousActionSpaceSize);
			int[] discreteActionBranchSizes = this.actionReceivers
				.Aggregate(new int[0], (branchSizes, nextReceiver) =>
					nextReceiver.DiscreteActionBranchSizes != null ?
						branchSizes.Concat(nextReceiver.DiscreteActionBranchSizes).ToArray() :
						branchSizes);
			BehaviorParameters behaviorParameters = this.GetComponent<BehaviorParameters>();

			ActionSpec actionSpec = behaviorParameters.BrainParameters.ActionSpec;
			actionSpec.NumContinuousActions = continuousActionSpaceSize;
			actionSpec.BranchSizes = discreteActionBranchSizes;
			Undo.RecordObject(behaviorParameters, "Updated Behavior Parameter's Action Space Size");
			behaviorParameters.BrainParameters.ActionSpec = actionSpec;
		}

		public void RefreshRewardProviders()
		{
			Undo.RecordObject(this, "Refreshed Reward Providers for Creature Agent");
			this.rewardProviders = this.GetComponentsInChildren<RewardProvider>();
		}

		public void RefreshEpisodeBeginHandlers()
		{
			Undo.RecordObject(this, "Refreshed Episode Begin Handlers for Creature Agent");
			this.episodeBeginHandlers = this.GetComponentsInChildren<EpisodeBeginHandler>();
		}
	}
}