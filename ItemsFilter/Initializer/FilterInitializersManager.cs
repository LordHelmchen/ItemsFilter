﻿// ****************************************************************************
// <author>mishkin Ivan</author>
// <email>Mishkin_Ivan@mail.ru</email>
// <date>28.01.2015</date>
// <project>ItemsFilter</project>
// <license> GNU General Public License version 3 (GPLv3) </license>
// ****************************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace BolapanControl.ItemsFilter.Initializer {
    /// <summary>
    /// Define a class that represent set of filter initializers.
    /// </summary>
    public  class FilterInitializersManager : List<FilterInitializer>, IList<FilterInitializer>,IEnumerable<FilterInitializer> {
        private static FilterInitializersManager _default;
        /// <summary>
        /// Represent default instance of FilterInitializersManager that include common used initializers.
        /// </summary>
        public static IEnumerable<FilterInitializer> Default {
            get{
                if (_default == null)
                    _default = new FilterInitializersManager
                    {
                        new EqualFilterInitializer(),
                        new LessOrEqualFilterInitializer(),
                        new GreaterOrEqualFilterInitializer(),
                        new RangeFilterInitializer(),
                        new StringFilterInitializer(),
                        new EnumFilterInitializer(),
                        new NullableRangeFilterInitializer(),
                        new NullableDateTimeFilterInitializer(),
                        new DateTimeFilterInitializer(),
                    };

                return _default;
            }
        }
        /// <summary>
        /// Create empty instance of FilterInitializersManager.
        /// </summary>
        public FilterInitializersManager() {
        }
        /// <summary>
        /// Create instance of FilterInitializersManager and add initializers.
        /// </summary>
        /// <param name="initializers">Enumerable of IFilterInitializer to add.</param>
        public FilterInitializersManager(IEnumerable<FilterInitializer> initializers)
            : base() {
                foreach (var item in initializers) {
                    Add(item);
                }
        }
    }
}
