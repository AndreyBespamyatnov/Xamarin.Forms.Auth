﻿// Copyright (c) 2019 Glenn Watson. All rights reserved.
// Glenn Watson licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Forms.Auth
{
    internal static class EnumerableExtensions
    {
        internal static bool IsNullOrEmpty<T>(this IEnumerable<T> input)
        {
            return input == null || !input.Any();
        }

        internal static string AsSingleString(this IEnumerable<string> input)
        {
            if (input.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return string.Join(" ", input);
        }

        internal static bool ContainsOrdinalIgnoreCase(this IEnumerable<string> set, string toLookFor)
        {
            return set.Any(el => el.Equals(toLookFor, StringComparison.OrdinalIgnoreCase));
        }

        internal static List<T> FilterWithLogging<T>(
            this List<T> list,
            Func<T, bool> predicate,
            ICoreLogger logger,
            string logPrefix)
        {
            int numberBefore = list.Count;
            list = list.Where(predicate).ToList();
            int numberAfter = list.Count;

            logger.Info($"{logPrefix} item count before {numberBefore} after {numberAfter}");

            return list;
        }
    }
}
