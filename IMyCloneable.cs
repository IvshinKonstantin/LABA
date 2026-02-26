using System;

namespace Lab6_Interfaces.Interfaces
{
    /// <summary>
    /// Интерфейс для поддержки клонирования объектов (собственная реализация)
    /// </summary>
    public interface IMyCloneable
    {
        /// <summary>
        /// Создает копию текущего объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        object Clone();
    }
}