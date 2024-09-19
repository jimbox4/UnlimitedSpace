using Zenject;

public class InputSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
#if UNITY_STANDALONE
        Container.Bind<IInputSystem>().FromInstance(new KeyboardMouseInput()).AsSingle();
#endif
    }
}