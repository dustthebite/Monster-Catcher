using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BiomManager : MonoBehaviour, IBiomManager
{
    Biom currentBiom;
    bool areEncountersAllowed;
    public event Action OnCurrentBiomChange;
    public Biom GetCurrentBiom() => currentBiom;
    public void SetCurrentBiom(Biom _currentBiom)
    {
        currentBiom = _currentBiom;
        OnCurrentBiomChange?.Invoke();
    }
    public bool AreEncountersAllowed() => areEncountersAllowed;
    public void SetEncountersAllowance(bool _value) => areEncountersAllowed = _value;
}
