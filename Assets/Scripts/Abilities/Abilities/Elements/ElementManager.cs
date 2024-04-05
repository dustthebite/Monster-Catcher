using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ElementManager : IElementManager
{
    Dictionary<Elements, Elements> elementsRelationships;
    public ElementManager()
    {
        //key - element, value - STR 
        elementsRelationships = new Dictionary<Elements, Elements>()
        {
            {Elements.Ice, Elements.Fire},
            {Elements.Fire, Elements.Wood},
            {Elements.Wood, Elements.Darness},
            {Elements.Darness, Elements.Ice}
        };
    }
    public bool DoesElementCounters(Elements myElement, Elements elementToCompare)
    {
        return elementsRelationships[myElement] == elementToCompare;
    }
}