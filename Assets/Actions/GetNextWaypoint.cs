using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Random = UnityEngine.Random;

[System.Serializable]
public class GetNextWaypoint : ActionNode
{
    public NodeProperty<bool> useRandom;
    public NodeProperty<Transform[]> path;
    public NodeProperty<Vector3> destination;

    protected override void OnStart()
    {
        useRandom.Value = true;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        var length = path.Value.Length;
        if (path.Value == null || length == 0)
            return State.Failure;

        destination.Value = useRandom.Value ? path.Value[Random.Range(0, length)].position : GetNextPosition();
        
        return State.Success;
    }

    private Vector3 GetNextPosition()
    {
        return Vector3.zero;
    }
}
