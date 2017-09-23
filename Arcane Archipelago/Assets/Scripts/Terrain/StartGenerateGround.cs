using UnityEngine;

public class StartGenerateGround : GenerateGround
{
    [SerializeField]
    private int maxGroundNumRef;
    [SerializeField]
    private GameObject endGroundRef;

    private void Start ()
    {
        maxGroundNum = maxGroundNumRef;
        endGround = endGroundRef;
	}
}
