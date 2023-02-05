using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance;
    public delegate void AgentInTroubleEvent();

    public event AgentInTroubleEvent isFireExtinguished;
    public event AgentInTroubleEvent isMonkeyEscaped;
    public event AgentInTroubleEvent isBirdEscaped;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void RaiseOnButtonClick()
    {
        if (isFireExtinguished != null)
        {
            isFireExtinguished();
        }
    }
     public void RaiseOnButtonClickMonkey()
    {
        if (isMonkeyEscaped != null)
        {
            isMonkeyEscaped();
        }
    }

     public void RaiseOnButtonClickBird()
    {
        if (isBirdEscaped != null)
        {
            isBirdEscaped();
        }
    }
}