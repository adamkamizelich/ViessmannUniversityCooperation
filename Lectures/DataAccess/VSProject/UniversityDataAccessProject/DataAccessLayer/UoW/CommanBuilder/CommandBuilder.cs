namespace DataAccessLayer.UoW.CommanBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using DataAccessLayer.Common.DomainModel;

    public class CommandBuilder : ICommandBuilder
    {
        public string BuildAdd<T>(T entity) where T : class, IEntity, new()
        {
            var type = typeof(T);
            string commandText = $"INSERT INTO {type.Name}(%columns%) VALUES(%values%)";

            string columnList = string.Empty;
            string valuesList = string.Empty;

            foreach (var property in type.GetProperties().Where(x => x.Name != "Id" && !x.PropertyType.IsClass))
            {
                columnList += $"{property.Name},";
                valuesList += $"{property.GetValue(entity)},";
            }

            columnList = columnList.Remove(columnList.Length - 1);
            valuesList = valuesList.Remove(columnList.Length - 1);

            commandText = commandText.Replace("%columns%", columnList).Replace("%values%", valuesList);
            return commandText;
        }

        public string BuildUpdate<T>(T entity) where T : class, IEntity, new()
        {
            var type = typeof(T);
            string commandText = $"UPDATE {type.Name} SET %assignments% WHERE Id = {entity.Id}";

            // what's the better approach?
            string assignmentList = type.GetProperties()
                .Where(x => x.Name != "Id" && !x.PropertyType.IsClass)
                .Aggregate(string.Empty, (current, property) => current + $"{property.Name} = {property.GetValue(entity)},");



            assignmentList = assignmentList.Remove(assignmentList.Length - 1);

            commandText = commandText.Replace("%assignments%", assignmentList);
            return commandText;
        }

        public string BuildDelete<T>(int? entityId) where T : class, IEntity, new()
        {
            var type = typeof(T);
            return $"DELETE FROM {type.Name} WHERE Id = {entityId.Value}";
        }

        public string BuildGetAll<T>() where T : class, IEntity, new()
        {
            var type = typeof(T);
            string commandText = $"SELECT %columns% FROM {type.Name}";

            string columnList = type.GetProperties().Where(x => !x.PropertyType.IsClass).Aggregate(string.Empty, (current, property) => current + $"{property.Name},");

            columnList = columnList.Remove(columnList.Length - 1);

            commandText = commandText.Replace("%columns%", columnList);
            return commandText;
        }

        public string BuildGetById<T>(int entityId) where T : class, IEntity, new()
        {
            var type = typeof(T);
            string commandText = $"SELECT %columns% FROM {type.Name} WHERE Id = {entityId}";

            string columnList = type.GetProperties().Where(x => !x.PropertyType.IsClass).Aggregate(string.Empty, (current, property) => current + $"{property.Name},");

            columnList = columnList.Remove(columnList.Length - 1);

            commandText = commandText.Replace("%columns%", columnList);
            return commandText;
        }

        public string BuildManyToManyConnection<T1, T2>(T1 entity1, T2 entity2) where T1 : class, IEntity, new() where T2 : class, IEntity, new()
        {
            throw new NotImplementedException();
        }
    }
}
