using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WorldEvent
{
    void Init();
    void Timer();
    bool CheckCondition();
    void ActivateEvent();
}
