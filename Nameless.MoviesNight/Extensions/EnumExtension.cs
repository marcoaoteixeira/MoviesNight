using System.ComponentModel;
using System.Reflection;

namespace Nameless.MoviesNight {
    public static class EnumExtension {
        public static string GetDescription<TEnum>(this TEnum self)
        where TEnum : Enum {
            var name = self.ToString();

            var field = typeof(TEnum).GetField(name);
            if (field is null) {
                return name;
            }

            var attr = field.GetCustomAttribute<DescriptionAttribute>(inherit: false);
            return attr is not null ? attr.Description : name;
        }
    }
}
