using System;

namespace Lab6_Interfaces.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с дробями
    /// </summary>
    public interface IFraction
    {
        /// <summary>
        /// Получить вещественное значение дроби
        /// </summary>
        /// <returns>Вещественное представление дроби</returns>
        double GetDoubleValue();

        /// <summary>
        /// Установить числитель дроби
        /// </summary>
        /// <param name="numerator">Новый числитель</param>
        void SetNumerator(int numerator);

        /// <summary>
        /// Установить знаменатель дроби
        /// </summary>
        /// <param name="denominator">Новый знаменатель</param>
        void SetDenominator(int denominator);
    }
}