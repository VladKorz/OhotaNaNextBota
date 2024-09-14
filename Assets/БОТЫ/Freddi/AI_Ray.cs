using UnityEngine;
using System.Collections;

public class AI_Ray : MonoBehaviour {

    [SerializeField] private float _speed;
    private Transform Player;
    private UnityEngine.AI.NavMeshAgent NMA;
    public float speed = 0.5f;


    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NMA = (UnityEngine.AI.NavMeshAgent)this.GetComponent("NavMeshAgent");
	}
	
	
	void Update () 
    {
        NMA.SetDestination(Player.position);
	}

    public void AddSpeed()
    {
        _speed += speed;
        NMA.speed = _speed;
    }
}
