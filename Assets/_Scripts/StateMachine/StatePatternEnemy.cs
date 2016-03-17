using UnityEngine;
using System.Collections;

public class StatePatternEnemy: MonoBehaviour {

    public float searchingTurnSpeed = 120f;
    public float sightRange = 20f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;
    public float maxAlertBeforeChase = 3f;
    public float maxAlertBeforePatrol = 5f;

    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public bool sawPlayer;

    private void Awake() {
        chaseState = new ChaseState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);

        sawPlayer = false;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        currentState = patrolState;
    }

    void Update() {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other) {
        currentState.OnTriggerEnter(other);
    }
}