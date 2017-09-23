using UnityEngine;
using UnityEngine.UI;

public class ReadTactics : MonoBehaviour
{
    public SquadTactics.TacticsList tactic;

    private void Start()
    {
        if (SquadTactics.currentTactic == tactic)
        {
            GetComponent<Toggle>().isOn = true;
        }
    }

    public void UpdateTactic(bool state)
    {
        if (state)
        {
            SquadTactics.currentTactic = tactic;
        }
    }
}
