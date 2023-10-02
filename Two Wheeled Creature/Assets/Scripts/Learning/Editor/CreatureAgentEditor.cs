using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace GNMS.TwoWheeledCreature
{
	[CustomEditor(typeof(CreatureAgent))]
	public class CreatureAgentEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			CreatureAgent creatureAgent = target as CreatureAgent;

			int newMaxStep = EditorGUILayout.IntField("Agent max step:", creatureAgent.MaxStep);
			if (newMaxStep != creatureAgent.MaxStep)
			{
				Undo.RecordObject(creatureAgent, "Updated Creature Agent's Max Step");
				creatureAgent.MaxStep = newMaxStep;
			}

			DrawDefaultInspector();

			if (GUILayout.Button("Refresh Observation Providers"))
			{
				creatureAgent.RefreshObservationProviders();
			}

			if (GUILayout.Button("Refresh Action Receivers"))
			{
				creatureAgent.RefreshActionReceivers();
			}

			if (GUILayout.Button("Refresh Reward Providers"))
			{
				creatureAgent.RefreshRewardProviders();
			}

			if (GUILayout.Button("Refresh Episode Begin Handlers"))
			{
				creatureAgent.RefreshEpisodeBeginHandlers();
			}
		}
	}
}