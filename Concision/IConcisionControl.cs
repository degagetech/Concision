namespace Concision
{
    public interface IConcisionControl
    {
        int Depth { get; set; }
        ConcisionManager SkinManager { get; }
        MouseState MouseState { get; set; }

    }

    public enum MouseState
    {
        HOVER,
        DOWN,
        OUT
    }
}
