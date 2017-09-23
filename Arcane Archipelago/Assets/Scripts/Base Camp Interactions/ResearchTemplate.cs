using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (fileName = "Research Data", menuName = "Research/Add Research", order = 2)]
public class ResearchTemplate : ScriptableObject {

	public string ResearchName;
	public float totalTimeSeconds;	//In seconds
	public List<CraftingRecipe> recipesUnlocked = new List<CraftingRecipe> ();
}

public class CraftingRecipe {
	public string recipeName;
//	public 
}
