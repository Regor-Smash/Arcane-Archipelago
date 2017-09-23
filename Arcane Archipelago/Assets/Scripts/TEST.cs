using UnityEngine;

public class TEST : MonoBehaviour
{
#if UNITY_EDITOR

    public bool A = true;
    public bool B = true;
    public bool C = false;

    void Awake()
    {
        if (A && B || C)
        {
            Debug.Log("it worked");
        }
    }

    void Start()
    {
        
    }
#endif
}
