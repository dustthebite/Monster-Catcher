using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IBiomManager 
{
    public event Action OnCurrentBiomChange;
    public Biom GetCurrentBiom();
    public void SetCurrentBiom(Biom _currentBiom);
    public bool AreEncountersAllowed();
    public void SetEncountersAllowance(bool _value);
}