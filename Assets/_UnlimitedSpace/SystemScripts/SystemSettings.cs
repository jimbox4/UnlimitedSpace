using UnityEngine;

[CreateAssetMenu(fileName = "SystemSettings", menuName = "ScriptableObjects/System/SystemSettings", order = -1)]
public class SystemSettings : ScriptableObject
{
    [SerializeField] private int _taskDelayMilisec;

    public int TaskDelayMilisec => _taskDelayMilisec;
}
