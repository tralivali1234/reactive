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
        public static ValueTask<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<TSource> Core(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
            {
                var last = await TryGetLast(source, cancellationToken).ConfigureAwait(false);

                return last.HasValue ? last.Value : throw Error.NoElements();
            }
        }

        public static ValueTask<TSource> LastAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<TSource> Core(IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
            {
                var last = await TryGetLast(source, predicate, cancellationToken).ConfigureAwait(false);

                return last.HasValue ? last.Value : throw Error.NoElements();
            }
        }

        internal static ValueTask<TSource> LastAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<TSource> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken cancellationToken)
            {
                var last = await TryGetLast(source, predicate, cancellationToken).ConfigureAwait(false);

                return last.HasValue ? last.Value : throw Error.NoElements();
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<TSource> LastAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (predicate == null)
                throw Error.ArgumentNull(nameof(predicate));

            return Core(source, predicate, cancellationToken);

            static async ValueTask<TSource> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken)
            {
                var last = await TryGetLast(source, predicate, cancellationToken).ConfigureAwait(false);

                return last.HasValue ? last.Value : throw Error.NoElements();
            }
        }
#endif
    }
}
