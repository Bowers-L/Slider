using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut : Box
{
    void Awake()
    {
        SetPaths();

        currentShape = shapes[currentShapeIndex];
        CreateShape();
    }

    private new void OnEnable()
    {
        SGrid.OnSTileEnabled += OnSTileEnabled;
        SGridAnimator.OnSTileMoveEnd += OnSTileMoveEnd;
        SGridAnimator.OnSTileMoveStart += DeactivatePathsOnSTileMove;
    }

    private new void OnDisable()
    {
        SGrid.OnSTileEnabled -= OnSTileEnabled;
        SGridAnimator.OnSTileMoveEnd -= OnSTileMoveEnd;
        SGridAnimator.OnSTileMoveStart -= DeactivatePathsOnSTileMove;
    }

    private void OnSTileEnabled(object sender, SGrid.OnSTileEnabledArgs e)
    {
        CreateShape();
    }
    private void OnSTileMoveEnd(object sender, SGridAnimator.OnTileMoveArgs e)
    {
        foreach (Direction d in paths.Keys)
        {
            paths[d].ChangePair();
        }
        CreateShape();
    }

    public void ChangeShape()
    {
        currentShapeIndex = (currentShapeIndex + 1) % shapes.Count;
        currentShape = shapes[currentShapeIndex];
        CreateShape();
    }

}