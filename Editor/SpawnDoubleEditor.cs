using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnDouble))]
public class SpawnDoubleEditor : Editor
{
	SpawnDouble _instance;
	private void OnEnable()
	{
		_instance = (SpawnDouble)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Create Copy At Offset multiplied by time pressed"))
		{
			_instance.SpawnCopy();
		}

		if (GUILayout.Button("Reset compteur"))
		{
			_instance.ResetCpt();
		}
	}
}

