

namespace Concision.Control
{
    /// <summary>
    ///  圆角类型
    /// </summary>
    public enum RoundStyle
    {
        Node,
        All,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Top = TopLeft | TopRight,
        Bottom = BottomLeft | BottomRight,
        Left= TopLeft|BottomLeft,
        Right= TopRight|BottomRight
    }
}
