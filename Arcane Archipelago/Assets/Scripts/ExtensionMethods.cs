using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class ExtensionMethods
{
    #region ToggleGroups
    public static Toggle SelectedToggle(this ToggleGroup toggleGroup)
    {
        return toggleGroup.ActiveToggles().FirstOrDefault();
    }

    /*public static void ListenToToggle(this ToggleGroup toggleGroup, VoidDelegate method)
    {
        toggleGroup.
    }*/
    #endregion ToggleGroups

    #region LookAt
        //ASSUMES SPRITE'S DEFAULT FORWARD IS FACING RIGHT

    public static void LookAt2D (this Transform trans, Transform target)
    {
        trans.right = target.transform.position - trans.position;
    }

    public static void LookAt2DFlip(this Transform trans, Transform target)
    {
        if (target.position.x >= trans.position.x) //Target is to the right of trans
        {
            if (trans.GetComponent<SpriteRenderer>())
            {
                trans.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else //Target is to the left of trans
        {
            if (trans.GetComponent<SpriteRenderer>())
            {
                trans.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
    #endregion LookAt
}
