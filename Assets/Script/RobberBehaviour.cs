using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Apple;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject dimond;
    public GameObject van;
    NavMeshAgent agent;

    public enum ActionState { ILDE, WORKING };
    ActionState state = ActionState.IDLE;

    // Start is called before the first frame update
    void Start()
    {

        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Node steal = new Node("Steal Something");
        Leaf goToDiamond = new Leaf("Go To Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);



        tree.PrintTree();

        tree.Process();

    }

    public Node.Status GoToDiamond()
    {
        agent.SetDestination(dimond.transform.position);
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToVan()
    {
        agent.SetDestination(van.transform.position);
        return Node.Status.SUCCESS;
    }

    Node.Status GoToLocation(Vector3 destination);
    {
        float distanceToTarget = Vector3.Distance( destination, this.transform.position);
    If(state== ActionState.IDLE)
    {
        agent.SetDestination(destination);
        state = ActionState.WORKING;
    }
    else if ( Vector3.Distance(agente.pathEndPosition, destination) >= 2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }

        else if (distanceToTarget > 2)
        {
             State = ActionState.IDLE;
             return Node.Status.SUCCESS;
        }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}