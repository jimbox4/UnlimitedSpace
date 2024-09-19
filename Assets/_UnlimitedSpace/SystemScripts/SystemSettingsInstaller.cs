using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SystemSettingsInstaller", menuName = "Installers/SystemSettingsInstaller")]
public class SystemSettingsInstaller : ScriptableObjectInstaller<SystemSettingsInstaller>
{
    public override void InstallBindings()
    {
    }
}