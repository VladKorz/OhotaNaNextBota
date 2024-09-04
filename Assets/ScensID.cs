using UnityEngine;

public class ScensID : MonoBehaviour
{
    public int id;

    void Start()
    {
        SvapScens.scenId = id;
    }
}
