﻿// ****************************************************************************
// <author>mishkin Ivan</author>
// <email>Mishkin_Ivan@mail.ru</email>
// <date>28.01.2015</date>
// <project>ItemsFilter</project>
// <license> GNU General Public License version 3 (GPLv3) </license>
// ****************************************************************************
using BolapanControl.ItemsFilter.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace BolapanControl.ItemsFilter.Initializer
{
    /// <summary>
    /// Base class for PropertyFilter initialiser.
    /// </summary>
    public abstract class PropertyPathFilterInitializer:FilterInitializer
    {
        /// <summary>
        /// Generate new instance of Filter class, if it is possible for filterPresenter and key.
        /// </summary>
        /// <param name="filterPresenter">FilterPresenter, which can be attached Filter</param>
        /// <param name="key">Key for generated Filter. For PropertyFilter, key used as the name for binding property in filterPresenter.Parent collection.</param>
        /// <returns>Instance of Filter class or null.</returns>
        public sealed override Filter NewFilter(FilterPresenter filterPresenter, object key)
        {
            Debug.Assert(filterPresenter != null);
            Debug.Assert(key != null);
            if (key is string && key != null)
            {
                string path = (string)key;
                return NewFilter(filterPresenter, path);
            }
            return null;
        }

        protected abstract PropertyPathFilter NewFilter(FilterPresenter filterPresenter, string key);
    }
}