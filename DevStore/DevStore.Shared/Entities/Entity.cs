using FluentValidator;
using System;

namespace DevStore.Shared.Entities
{
    public abstract class Entity:Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id;
    }
}