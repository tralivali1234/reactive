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
        public static ValueTask<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
            {
                var count = 0L;

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

        public static ValueTask<long> LongCountAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
            {
                var count = 0L;

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

        internal static ValueTask<long> LongCountAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
            {
                var count = 0L;

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
        internal static ValueTask<long> LongCountAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken)
            {
                var count = 0L;

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
