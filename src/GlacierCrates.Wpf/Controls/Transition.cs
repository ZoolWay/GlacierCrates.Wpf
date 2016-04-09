using System;

namespace GlacierCrates.Wpf.Controls
{
    /// <summary>
    /// Defines flags which determine which transitions will be applied.
    /// </summary>
    [Flags]
    public enum Transition
    {
        None = 0,
        Slide = 1,
        Fade = 2,
        Grow = 4,
    }
}
