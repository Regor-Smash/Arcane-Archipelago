using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public enum GroundTypes { Beach, Forest };
    public GroundTypes groundType;

    protected static int groundNum;
    protected static int maxGroundNum;
    protected static GameObject endGround;

    string groundName;
    int index;
    public int minIndex;
    public int maxIndex;

    bool hasGenerated = false;
    public Vector3 offset;
    //GameObject tempGround;

    public void GenerateNewGround()
    {
        if (!hasGenerated)
        {
            hasGenerated = true;
            if (groundNum < maxGroundNum)
            {
                index = Random.Range(minIndex, maxIndex + 1);

                groundName = "Ground/" + groundType + "/" + groundType + "Ground" + index;
                /*tempGround = (GameObject) */
                Instantiate(Resources.Load(groundName), gameObject.transform.position + offset, Quaternion.identity);

                //tempGround.GetComponent<GenerateGround> ().maxGroundNum = maxGroundNum;
                //tempGround.GetComponent<GenerateGround> ().endGround = endGround;

                groundNum++;
            }
            else if (groundNum >= maxGroundNum)
            {
                //groundName = groundType + " Ground/" + groundType + "GroundEnd";
                //tempGround = (GameObject) Instantiate (Resources.Load (groundName), gameObject.transform.position + offset, Quaternion.identity);

                endGround.transform.position = gameObject.transform.position + offset;

                groundNum = 0;
                maxGroundNum = 0;
                endGround = null;
            }
            //Debug.Log ("Name: "+ groundName + ", Index:" + index +", Number: "+ groundNum);
        }
    }
}
