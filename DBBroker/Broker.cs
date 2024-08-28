using Common.Domain;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class Broker
    {

        private ConnectionBroker connection;
        public Broker()
        {
            connection = new ConnectionBroker();
        }
        public void OpenConnection()
        {
            connection.OpenConnection();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }
        public void Commit()
        {
            connection.Commit();
        }
        public void Rollback()
        {
            connection.Rollback();
        }
        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public T Select<T>(LoginValue<T> loginValue) where T: IEntity, new()
        {
            //određivanje imena klase iz loginValue
            string className = typeof(T).Name;
            string searchQuery = $"SELECT * FROM {className} WHERE ";

            //prikupljanje imena propertyja
            List<string> propertyNames = typeof(T).GetProperties()
                                                 .Select(prop => prop.Name)
                                                 .Where(prop => prop != "TableName" && prop != "Values")
                                                 .ToList();

            //provera da li su parametri definisani i imaju vrednost
            if (loginValue.Parameter != null && loginValue.Parameter.Length > 0)
            {
                //dodavanje uslova za svaki parametar
                for (int i = 0; i < loginValue.Parameter.Length; i++)
                {
                    string paramName = loginValue.Parameter[i];
                    var prop = typeof(T).GetProperty(paramName);
                    if (prop != null)
                    {
                        object paramValue = null;

                        
                        if (loginValue.Value != null)
                        {
                            //ako je parametar vrednost objekta, uzmi vrednost iz loginValue
                            prop = loginValue.Value.GetType().GetProperty(paramName);
                            if (prop != null)
                            {
                                paramValue = prop.GetValue(loginValue.Value);
                            }
                        }

                        if (paramValue != null)
                        {
                            searchQuery += $"{paramName} = @{paramName}";
                            if (i < loginValue.Parameter.Length - 1)
                                searchQuery += " AND ";
                        }
                    }
                }

                //priprema SQL komande
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    for (int i = 0; i < loginValue.Parameter.Length; i++)
                    {
                        string paramName = loginValue.Parameter[i];
                        var prop = typeof(T).GetProperty(paramName);
                        if (prop != null)
                        {
                            object paramValue = null;

                            
                            if (loginValue.Value != null)
                            {
                                //ako je parametar vrednost objekta, uzmi vrednost iz loginValue
                                prop = loginValue.Value.GetType().GetProperty(paramName);
                                if (prop != null)
                                {
                                    paramValue = prop.GetValue(loginValue.Value);
                                }
                            }

                            if (paramValue != null)
                            {
                                cmd.Parameters.AddWithValue($"@{paramName}", paramValue);
                            }
                            else
                            {
                                return default;
                            }
                        }
                    }
                    cmd.CommandText = searchQuery;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //kreiranje instance objekta na osnovu tipa
                            T obj = new T();

                            //postavljanje vrednosti svojstava objekta iz rezultata upita
                            foreach (var property in typeof(T).GetProperties())
                            {
                                if (propertyNames.Contains(property.Name))
                                {
                                    var value = reader[property.Name];
                                    if (value != DBNull.Value)
                                    {
                                        property.SetValue(obj, value);
                                    }
                                }
                            }

                            return obj;
                        }
                        return default;
                    }
                }
            }

            return default;
        }
        public object Add<T>(T obj) where T : class, IEntity, new()
        {
            using (SqlCommand cmd = connection.CreateCommand())
            {
                //izimamo sve propertyje objekta osim TableName i Values i Id
                List<string> propertyNames = obj.GetType().GetProperties()
                    .Where(prop => prop.Name != "TableName" && prop.Name != "Values" && prop.Name != "Id")
                    .Select(prop => prop.Name)
                    .ToList();

                //posle koristimo da ceo sql query spojimo
                string sourcePart = string.Join(",", propertyNames);
                string valuesPart = string.Join(",", propertyNames.Select(p => $"@{p}"));

                //kreiramo ON deo SQL upita (svi intovi i stringovi, sem tablename values i id)
                string onPart = string.Join(" AND ", typeof(T).GetProperties()
                    .Where(p => (p.PropertyType == typeof(int) || p.PropertyType == typeof(string)) && p.Name != "TableName" && p.Name != "Values" && p.Name!="Id")
                    .Select(p => $"target.{p.Name} = source.{p.Name}"));
                //SQL upit
                cmd.CommandText = $@"
                    MERGE INTO {typeof(T).Name} AS target
                    USING (VALUES ({valuesPart})) AS source ({sourcePart})
                    ON {onPart}
                    WHEN NOT MATCHED THEN
                    INSERT ({sourcePart}) VALUES ({valuesPart});
                    ";

                //dodajemo parametre u SQL komandu
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.Name != "TableName" && property.Name != "Values")
                    {
                        var paramName = $"@{property.Name}";
                        object paramValue = property.GetValue(obj);

                        //ako je property tipa IEntity, koristimo samo Id iz tog propertyja
                        if (typeof(IEntity).IsAssignableFrom(property.PropertyType))
                        {
                            var entity = paramValue as IEntity;
                            if (entity != null)
                            {
                                var idProperty = entity.GetType().GetProperty("Id");
                                if (idProperty != null)
                                {
                                    paramValue = idProperty.GetValue(entity);
                                }
                            }
                        }

                        //dodajemo SQL parametar
                        cmd.Parameters.AddWithValue(paramName, paramValue ?? DBNull.Value);
                    }
                }
                //izvršavanje SQL komande
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected == 1 ? obj : null;
            }
        }
        private List<string> GetAllPrimaryKeys(string tableName = "")
        {
            string tableQuery = string.IsNullOrEmpty(tableName) ? "" : $"and table_name = '{tableName}'";
            List<string> primaryKeys = new List<string>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 {tableQuery};";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                primaryKeys.Add(reader[0].ToString());
            }
            return primaryKeys;
        }
        public string GetUpdateQuery<T>(EditValue editValue) where T: class,IEntity,new()
        {
            string setQuery = "set ";
            Type type = typeof(T);
            List<PropertyInfo> properties = type.GetProperties().Where(prop => prop.Name != "TableName" && prop.Name != "Values").ToList();
            List<string> primaryKeys = GetAllPrimaryKeys(type.Name);
            foreach (var property in properties)
            {
                if (primaryKeys.Contains(property.Name)) 
                    continue;
                object setValue = property.GetValue(editValue.EditedValue);
                if (setValue == null)
                {
                    setQuery += $"{property.Name} = NULL,";
                    continue;
                }
                //ako je property slozen, odnosno predstavlja domensku klasu
                if (setValue!=null && property.PropertyType.GetInterfaces().ToList().Contains(typeof(IEntity)))
                {
                    string innerPrimaryKey = GetAllPrimaryKeys(property.PropertyType.Name)[0];
                    PropertyInfo innerProperty = property.PropertyType.GetProperty(innerPrimaryKey);
                    setValue = innerProperty.GetValue(setValue);
                }
                //ako je datum pretvori ga u string odg formata koji sql prepoznaje
                if (setValue.GetType() == typeof(DateTime))
                    setValue = ((DateTime)setValue).ToString("yyyy-MM-dd HH:mm:ss");
                
                //ako je setValue string samo mu dodaj navodnike da bi ga sql prepoznao kao string
                if (setValue.GetType().IsEnum)
                    setValue = setValue.ToString();
                //ako je string dodaj mu ''
                setValue = setValue.GetType() == typeof(string) ?$" '{setValue}' " : setValue;
                setQuery += $"{property.Name} = {setValue},";
            }
            //brisemo , sa kraja
            setQuery = setQuery.TrimEnd(',');
            string whereQuery = "  where ";
            Console.WriteLine(setQuery);
            foreach (var primaryKey in primaryKeys)
            {
                PropertyInfo idProperty = type.GetProperty(primaryKey);
                var primaryKeyValue = idProperty.GetValue(editValue.OriginalValue);
                // ako je string dodaj mu ''
                primaryKeyValue = primaryKeyValue.GetType() == typeof(string) ? $" '{primaryKeyValue}' " : primaryKeyValue;
                whereQuery += $"{primaryKey} = {primaryKeyValue} and";
            }
            //brisi and sa kraja
            whereQuery = whereQuery.Remove(whereQuery.LastIndexOf("and"), 3);
            Console.WriteLine($"update {type.Name} {setQuery} {whereQuery}");
            return $"update {type.Name} {setQuery} {whereQuery}";
        }
        private bool IsListOfIEntity(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type[] genericArguments = type.GetGenericArguments();
                if (genericArguments.Length == 1 && typeof(IEntity).IsAssignableFrom(genericArguments[0]))
                {
                    return true;
                }
            }
            return false;
        }
        public object Edit<T>(EditValue editValue) where T : class,IEntity,new()
        {
            Type editedValueType = editValue.EditedValue.GetType();
            Type originalValueType = editValue.OriginalValue.GetType();
            int affected = 0;
            //for petlja ako je tip lista neka
            if (IsListOfIEntity(editedValueType) && IsListOfIEntity(originalValueType))
            {   
                IList editedEntities = (IList)editValue.EditedValue;
                IList originalEntities = (IList)editValue.OriginalValue;
                for(int i =0; i < editedEntities.Count; i++)
                {
                    EditValue newEV = new EditValue
                    {
                        EditedValue = editedEntities[i],
                        OriginalValue = originalEntities[i],
                        Type = typeof(T).AssemblyQualifiedName
                    };

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = GetUpdateQuery<T>(newEV);
                    affected+= cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }          
            }
            else
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = GetUpdateQuery<T>(editValue);
                affected+= cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            return affected > 0 ? editValue.EditedValue : null;           
        }
        public BindingList<T> Search<T>(SearchValue searchValue) where T : class, IEntity, new()
        {
            string searchQuery;
            //Pravimo instancu objekta preko refleksije
            Type type = typeof(T);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            IEntity obj = (IEntity)constructor.Invoke(null);

            //Uzimamo kolone tabele
            List<string> propertyNames = obj.GetType().GetProperties()
                .Select(prop => prop.Name)
                .Where(prop => prop != "TableName" && prop != "Values")
                .ToList();

            //Pravimo listu objekata gde ce da se cuvaju objekti za kasnije slanje
            BindingList<T> objects = new BindingList<T>();
            SqlCommand cmd = connection.CreateCommand();

            //if (string.IsNullOrEmpty(searchValue.Parameter))
            //{
            //    searchQuery = BuildSearchQuery(type, searchValue.Value);
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(searchValue.Value.ToString()))
            //        searchQuery = string.Empty;
            //    else
            //        searchQuery = int.TryParse(searchValue.Value.ToString(), out _)
            //            ? $"WHERE {searchValue.Parameter} LIKE '{searchValue.Value}'"
            //            : $"WHERE {searchValue.Parameter} LIKE '%{searchValue.Value}%'";
            //}

            if (string.IsNullOrEmpty(searchValue.Value.ToString()))
                searchQuery = string.Empty;
            else
                searchQuery = int.TryParse(searchValue.Value.ToString(), out _)
                    ? $"WHERE {searchValue.Parameter} LIKE '{searchValue.Value}'"
                    : $"WHERE {searchValue.Parameter} LIKE '%{searchValue.Value}%'";

            // Pravimo query za search


            cmd.CommandText = $"SELECT * FROM {obj.TableName} {searchQuery}";
            SqlDataReader reader = cmd.ExecuteReader();

            // ucitavamo redove, kolonu po kolonu
            while (reader.Read())
            {
                obj = (IEntity)constructor.Invoke(null);

                foreach (string column in propertyNames)
                {
                    PropertyInfo property = obj.GetType().GetProperty(column);
                    Type interfaceType = typeof(IEntity);

                    // ako naletimo na spoljni kljuc
                    if (property.PropertyType.GetInterfaces().Contains(interfaceType))
                    {
                        ConstructorInfo innerConstructor = property.PropertyType.GetConstructor(Type.EmptyTypes);
                        object innerObj = innerConstructor.Invoke(null);
                        List<string> innerObjColumns = innerObj.GetType().GetProperties()
                            .Select(prop => prop.Name)
                            .Where(prop => prop != "TableName" && prop != "Values")
                            .ToList();

                        var innerSearchValue = new SearchValue()
                        {
                            Type = property.PropertyType.AssemblyQualifiedName,
                            Parameter = "Id",
                            Value = reader[column].ToString(),
                        };

                        // zove se preko refleksije ova metoda, rekurzivno
                        MethodInfo searchMethod = typeof(Broker).GetMethod(nameof(Search), BindingFlags.Public | BindingFlags.Instance);
                        MethodInfo genericSearchMethod = searchMethod.MakeGenericMethod(property.PropertyType);
                        var result = genericSearchMethod.Invoke(this, new object[] { innerSearchValue });

                        // samo provera da se osiguramo da se vraca neka lista ientity objekta
                        var innerList = result as IEnumerable<IEntity>; 

                        if (innerList != null && innerList.Count() == 1)
                        {
                            var firstElement = innerList.First();
                            var valueType = property.PropertyType;

                            if (valueType.IsEnum)
                                firstElement = (IEntity)Enum.Parse(valueType, firstElement.ToString());

                            property.SetValue(obj, firstElement);
                        }
                        else
                        {
                            property.SetValue(obj, null);
                        }
                    }
                    else
                    {
                        var value = reader[column];
                        var valueType = property.PropertyType;

                        if (valueType.IsEnum)
                            value = Enum.Parse(valueType, value.ToString());

                        property.SetValue(obj, value);
                    }
                }

                // dodajemo objekat u listu
                objects.Add((T)obj);
            }

            reader.Close();
            return objects;
        }
        private string BuildSearchQuery(Type type, object searchValue, bool firstTime = true, string tableAlias = "", string parentAlias = "")
        {
            string searchQuery = "";
            string alias = string.IsNullOrEmpty(tableAlias) ? type.Name : tableAlias;
            string parentJoin = string.IsNullOrEmpty(parentAlias) ? "" : $"JOIN {type.Name} {alias} ON {parentAlias}.Id = {alias}.Id";

            if (firstTime)
            {
                searchQuery = $"SELECT * FROM {type.Name} {alias} ";
                if (!string.IsNullOrEmpty(parentJoin))
                {
                    searchQuery += $"{parentJoin} ";
                }
                searchQuery += "WHERE ";
            }

            foreach (var property in type.GetProperties())
            {
                if (property.Name == "TableName" || property.Name == "Values") continue;

                var propertyValue = searchValue.ToString();
                var column = $"{alias}.{property.Name}";

                // Check if property is an IEntity type (i.e., foreign key)
                if (typeof(IEntity).IsAssignableFrom(property.PropertyType))
                {
                    // Recursive call to handle nested entities
                    string innerAlias = $"{alias}_{property.PropertyType.Name}";
                    string innerQuery = BuildSearchQuery(property.PropertyType, searchValue, false, innerAlias, alias);

                    searchQuery += $"EXISTS (SELECT 1 FROM {property.PropertyType.Name} {innerAlias} WHERE {innerAlias}.Id = {column} AND {innerQuery}) OR ";
                }
                else
                {
                    // Add condition for simple properties
                    searchQuery += $"({column} LIKE '%{propertyValue}%') OR ";
                }
            }

            // Remove the trailing " OR "
            searchQuery = searchQuery.TrimEnd(" OR ".ToCharArray());

            return searchQuery;
        }

    }
}
