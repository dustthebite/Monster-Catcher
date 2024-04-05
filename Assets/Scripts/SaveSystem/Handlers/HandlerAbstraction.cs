using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandlerAbstraction : MonoBehaviour
{
    [SerializeField] protected string direcoryName;
    [SerializeField] protected string fileName;
    protected virtual void HandleSave(){}
    protected virtual void HandleLoad(){}
}