
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager eventManager;
    public delegate void Combo();
    public static event Combo OnCombo;
}
