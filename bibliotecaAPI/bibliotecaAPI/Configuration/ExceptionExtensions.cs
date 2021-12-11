using System;
using System.Collections.Generic;
using System.Linq;

namespace bibliotecaAPI.Configuration
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
        {
            for (var currentItem = source; canContinue(currentItem); currentItem = nextItem(currentItem))
            {
                yield return currentItem;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        public static string ReturnAllMessages(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException)
                                    .Select(ex => ex.Message);

            return string.Join(Environment.NewLine, messages);
        }
    }
}
