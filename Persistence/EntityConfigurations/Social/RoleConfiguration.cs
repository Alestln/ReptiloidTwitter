using System.Linq.Expressions;
using System.Reflection;
using Core.Domain.Roles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Social;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        var roles = new List<Role>();

        // Используем рефлексию для вызова приватного конструктора
        var constructorInfo = typeof(Role).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            new[] { typeof(Guid), typeof(string) },
            null);

        if (constructorInfo is not null)
        {
            // Создаем экземпляр класса Role
            roles.Add((Role)constructorInfo.Invoke([Guid.Parse("9b13c3e9-a4bd-4afe-a7ae-b9c60e6265e0"), "Admin"]));
            roles.Add((Role)constructorInfo.Invoke([Guid.Parse("6db03773-9569-4db5-9b83-461d6dfcffba"), "User"]));
        }
        else
        {
            throw new InvalidOperationException("Private constructor not found.");
        }

        // Добавляем данные в контекст
        builder.HasData(roles);
    }
}