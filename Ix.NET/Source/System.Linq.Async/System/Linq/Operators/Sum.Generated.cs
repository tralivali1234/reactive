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
        public static ValueTask<int> SumAsync(this IAsyncEnumerable<int> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<int> source, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (int value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }

        public static ValueTask<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }

        internal static ValueTask<int> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int>> selector, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<int> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<int>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<int> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<int>> selector, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }
#endif

        public static ValueTask<long> SumAsync(this IAsyncEnumerable<long> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<long> source, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (long value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }

        public static ValueTask<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }

        internal static ValueTask<long> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long>> selector, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<long> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<long>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<long> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<long>> selector, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    checked
                    {
                        sum += value;
                    }
                }

                return sum;
            }
        }
#endif

        public static ValueTask<float> SumAsync(this IAsyncEnumerable<float> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<float> Core(IAsyncEnumerable<float> source, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (float value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    sum += value;
                }

                return sum;
            }
        }

        public static ValueTask<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<float> Core(IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    sum += value;
                }

                return sum;
            }
        }

        internal static ValueTask<float> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<float> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    sum += value;
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<float> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<float>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<float> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<float>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    sum += value;
                }

                return sum;
            }
        }
#endif

        public static ValueTask<double> SumAsync(this IAsyncEnumerable<double> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<double> Core(IAsyncEnumerable<double> source, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (double value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    sum += value;
                }

                return sum;
            }
        }

        public static ValueTask<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<double> Core(IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    sum += value;
                }

                return sum;
            }
        }

        internal static ValueTask<double> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<double> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    sum += value;
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<double> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<double>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<double> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<double>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    sum += value;
                }

                return sum;
            }
        }
#endif

        public static ValueTask<decimal> SumAsync(this IAsyncEnumerable<decimal> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<decimal> Core(IAsyncEnumerable<decimal> source, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (decimal value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    sum += value;
                }

                return sum;
            }
        }

        public static ValueTask<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<decimal> Core(IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    sum += value;
                }

                return sum;
            }
        }

        internal static ValueTask<decimal> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<decimal> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal>> selector, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    sum += value;
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<decimal> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<decimal>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<decimal> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<decimal>> selector, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    sum += value;
                }

                return sum;
            }
        }
#endif

        public static ValueTask<int?> SumAsync(this IAsyncEnumerable<int?> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<int?> Core(IAsyncEnumerable<int?> source, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (int? value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }

        public static ValueTask<int?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<int?> Core(IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }

        internal static ValueTask<int?> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<int?> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<int?> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<int?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<int?> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<int?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }
#endif

        public static ValueTask<long?> SumAsync(this IAsyncEnumerable<long?> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<long?> Core(IAsyncEnumerable<long?> source, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (long? value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }

        public static ValueTask<long?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<long?> Core(IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }

        internal static ValueTask<long?> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<long?> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<long?> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<long?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<long?> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<long?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0L;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }

                return sum;
            }
        }
#endif

        public static ValueTask<float?> SumAsync(this IAsyncEnumerable<float?> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<float?> Core(IAsyncEnumerable<float?> source, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (float? value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

        public static ValueTask<float?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<float?> Core(IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

        internal static ValueTask<float?> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<float?> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<float?> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<float?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<float?> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<float?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0f;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }
#endif

        public static ValueTask<double?> SumAsync(this IAsyncEnumerable<double?> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<double?> Core(IAsyncEnumerable<double?> source, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (double? value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

        public static ValueTask<double?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<double?> Core(IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

        internal static ValueTask<double?> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<double?> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<double?> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<double?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<double?> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<double?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0.0;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }
#endif

        public static ValueTask<decimal?> SumAsync(this IAsyncEnumerable<decimal?> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return Core(source, cancellationToken);

            static async ValueTask<decimal?> Core(IAsyncEnumerable<decimal?> source, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (decimal? value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

        public static ValueTask<decimal?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<decimal?> Core(IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = selector(item);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

        internal static ValueTask<decimal?> SumAwaitAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<decimal?> Core(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }

#if !NO_DEEP_CANCELLATION
        internal static ValueTask<decimal?> SumAwaitWithCancellationAsyncCore<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<decimal?>> selector, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return Core(source, selector, cancellationToken);

            static async ValueTask<decimal?> Core(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<decimal?>> selector, CancellationToken cancellationToken)
            {
                var sum = 0m;

                await foreach (TSource item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    var value = await selector(item, cancellationToken).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }

                return sum;
            }
        }
#endif

    }
}
