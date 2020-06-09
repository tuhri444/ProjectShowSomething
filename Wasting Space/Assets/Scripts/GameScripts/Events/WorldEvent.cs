using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WorldEvent
{
    void Init(Condition _condition);
    void Timer();
    bool CheckCondition();
    void ActivateEvent();
}
