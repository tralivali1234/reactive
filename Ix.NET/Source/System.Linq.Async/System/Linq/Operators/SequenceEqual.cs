﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static ValueTask<bool> SequenceEqualAsync<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, CancellationToken cancellationToken = default) =>
            SequenceEqualAsync(first, second, comparer: null, cancellationToken);

        public static ValueTask<bool> SequenceEqualAsync<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken = default)
        {
            if (first == null)
                throw Error.ArgumentNull(nameof(first));
            if (second == null)
                throw Error.ArgumentNull(nameof(second));

            comparer ??= EqualityComparer<TSource>.Default;

            if (first is ICollection<TSource> firstCol && second is ICollection<TSource> secondCol)
            {
                if (firstCol.Count != secondCol.Count)
                {
                    return new ValueTask<bool>(false);
                }

                if (firstCol is IList<TSource> firstList && secondCol is IList<TSource> secondList)
                {
                    var count = firstCol.Count;

                    for (var i = 0; i < count; i++)
                    {
                        if (!comparer.Equals(firstList[i], secondList[i]))
                        {
                            return new ValueTask<bool>(false);
                        }
                    }

                    return new ValueTask<bool>(true);
                }
            }

            return Core(first, second, comparer, cancellationToken);

            static async ValueTask<bool> Core(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
            {
                await using var e1 = first.GetConfiguredAsyncEnumerator(cancellationToken, false);
                await using var e2 = second.GetConfiguredAsyncEnumerator(cancellationToken, false);

                while (await e1.MoveNextAsync())
                {
                    if (!(await e2.MoveNextAsync() && comparer.Equals(e1.Current, e2.Current)))
                    {
                        return false;
                    }
                }

                return !await e2.MoveNextAsync();
            }
        }
    }
}
