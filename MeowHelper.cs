using System;
using System.Collections.Generic;
using Lab6_Interfaces.Interfaces;

namespace Lab6_Interfaces.Utils
{
    /// <summary>
    /// Вспомогательный класс для работы с мяукающими объектами
    /// </summary>
    public static class MeowHelper
    {
        /// <summary>
        /// Вызывает мяуканье у всех переданных объектов
        /// </summary>
        /// <param name="meowables">Массив объектов, которые могут мяукать</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если массив null</exception>
        public static void MeowCare(params IMeowable[] meowables)
        {
            if (meowables == null)
            {
                throw new ArgumentNullException(nameof(meowables));
            }

            foreach (var meowable in meowables)
            {
                if (meowable != null)
                {
                    meowable.Meow();
                }
            }
        }

        /// <summary>
        /// Вызывает мяуканье у всех переданных объектов из коллекции
        /// </summary>
        /// <param name="meowables">Коллекция объектов, которые могут мяукать</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если коллекция null</exception>
        public static void MeowCare(IEnumerable<IMeowable> meowables)
        {
            if (meowables == null)
            {
                throw new ArgumentNullException(nameof(meowables));
            }

            foreach (var meowable in meowables)
            {
                if (meowable != null)
                {
                    meowable.Meow();
                }
            }
        }
    }
}