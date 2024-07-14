using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Nameless.MoviesNight {
    public static class EnumerableExtension {
        public static bool IsNullOrEmpty([NotNullWhen(returnValue: false)] this IEnumerable? self) {
            if (self is null) {
                return true;
            }

            var enumerator = self.GetEnumerator();
            if (!enumerator.MoveNext()) {
                return true;
            }

            if (enumerator is IDisposable disposable) {
                disposable.Dispose();
            }

            return false;
        }

        public static IEnumerable<(int Index, T Item)> WithIndex<T>(this IEnumerable<T>? self) {
            if (self is null) {
                yield break;
            }

            var counter = 0;
            foreach (var item in self) {
                yield return (counter++, item);
            }
        }
    }
}
