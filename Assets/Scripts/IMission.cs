using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMission
{
    bool Won { get; }
    bool Lost { get; }

    void CheckWinCondition();
    void OnMissionWon();
    void OnMissionLose();
}