using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    public GameObject backdoor;
    NavMeshAgent agent;

    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    void Start()
    {

        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Sequence steal = new Sequence("Steal Something");
        Leaf goToDiamond = new Leaf("Go To Diamond", GoToDiamond);
        Leaf goToBackDoor = new Leaf("Go To Backdoor", GoToBackDoor);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToBackDoor);
        steal.AddChild(goToDiamond);
        steal.AddChild(goToBackDoor);
        steal.AddChild(goToVan);

        tree.AddChild(steal);




        tree.PrintTree();


    }



    public Node.Status GoToBackDoor()
    {
        return GoToLocation(backdoor.transform.position);
    }
 -------------
    void Update()
    {
        if (treeStatus == Node.Status.RUNNING)
            treeStatus = tree.Process();
    }
}