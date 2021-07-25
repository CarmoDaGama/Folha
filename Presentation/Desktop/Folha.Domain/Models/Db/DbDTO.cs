using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Db
{
   public class DbDTO
    {
        public string Nome { get; set; }
        public string[] Campos { get; set; }
        public object[] Valores { get; set; }
        public string Criterios { get; set; }
        public Guid Id { get; set; }
        public Type Tipo { get; set; }
        public string[] Nomes { get; set; }
        public string[] Criterios2 { get; set; }
        public static DbDTO GetInstance<Entity>(Entity entity, string nome) where Entity:class
        {
            int count = entity.GetType().GetProperties().Count();
            DbDTO dto = new DbDTO() {
                Nome = nome,
                Nomes = new string[count],
                Valores = new object[count]
            };
            var fields = entity.GetType().GetProperties();
            for(int i = 0; i < count; i++)
            {
                var value = fields[i].GetValue(entity);
                if (fieldIsValidete(fields[i], value))
                {
                    dto.Nomes[i] = fields[i].Name;
                    dto.Valores[i] = fields[i].GetValue(entity);
                }
            }
            return dto;
        }

        private static bool fieldIsValidete(PropertyInfo field, object value)
        {
            return !isKey(field) && 
                    !isEntity(field) && 
                    !Equals(value, null) &&
                    !isCollection(field);
        }

        private static bool isCollection(PropertyInfo field)
        {
            
            return field.PropertyType.FullName.Contains("IEnumerable") ||
                   field.PropertyType.FullName.Contains("ICollection") ||
                   field.PropertyType.FullName.Contains("List");
        }

        private static bool isKey(PropertyInfo field)
        {
            return field.Name.ToLower().Contains("cod") ||
                   field.Name.ToLower().Contains("id") ||
                   field.Name.ToLower().Contains("codigo");
        }

        private static bool isEntity(PropertyInfo field)
        {
            return field.PropertyType.FullName.Contains("Folha.Domain.Models");
        }
    }
}
