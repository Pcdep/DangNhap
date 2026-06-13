using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class EnumExtension
    {
        // Từ khóa 'this Enum value' báo cho C# biết đây là hàm đính kèm vào mọi Enum
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            // Tìm xem trên đầu Enum có gắn cái [Description(...)] nào không
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            // Nếu có thì trả về cái nhãn tiếng Việt, nếu không thì trả về tên tiếng Anh gốc
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
