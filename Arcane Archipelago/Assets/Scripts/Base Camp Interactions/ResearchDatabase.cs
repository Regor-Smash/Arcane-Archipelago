using UnityEngine;

[CreateAssetMenu (fileName = "Research Data Tree", menuName = "Research/Add Tree", order = 0)]
public class ResearchDatabase : ScriptableObject
{
	public string characterName;	//Long name
	public string[] researchList;	//Use name of scriptable object
}
