using System;

namespace Lesson_04
{
    public interface I_Inferior
    {
        event EventHandler WorkEnded;

        Boolean IsWorking { get; }

        object Work();
    }
}
