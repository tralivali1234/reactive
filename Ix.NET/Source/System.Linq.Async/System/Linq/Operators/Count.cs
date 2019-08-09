﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static ValueTask<int> CountAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            switch (source)
            {
                case ICollection<TSource> collection:
                    return new ValueTask<int>(collection.Count);
                case IAsyncIListProvider<TSource> listProv:
                    return listProv.GetCountAsync(onlyIfCheap: false, cancellationToken);
                case ICollection collection:
                    return new ValueTask<int>(collection.Count);
            }

            return Core(source, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
            {
                var count = 0;

                await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    checked
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public static ValueTask<int> CountAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
            {
                var count = 0;

                await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    if (predicate(item))
                    {
                        checked
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }

        internal static ValueTask<int> CountAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
            {
                var count = 0;

                await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    if (await predicate(item).ConfigureAwait(false))
                    {
                        checked
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<int> CountAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken)
            {
                var count = 0;

                await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                    {
                        checked
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }
#endif
    }
}
