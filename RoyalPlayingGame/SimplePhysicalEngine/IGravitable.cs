﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* НЕ ИСПОЛЬЗУЕТСЯ
 * Автор: Никитенко А.В.
 */
namespace SimplePhysicalEngine
{
    /// <summary>
    /// интерфейс, добавляющий свойства гравитации к телу
    /// </summary>
    public interface IGravitable
    {
        /// <summary>
        /// вес объекта
        /// </summary>
        double Weight { get; set; }
    }
}
