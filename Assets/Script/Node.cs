using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Sequence : Node
{
    public Sequence(string n)
    {
        name = n;
    }

    public override Status Process()
    {
        Status Childstatus = children[currentChild].Process();
        if (Childstatus == Status.RUNNING) return Status.RUNNING;
        if (Childstatus == Status.FAILURE)
            return Childstatus;

        currentChild++;
        if (currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
}